using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace FinPro.FinApp
{
	public partial class Transactions : System.Web.UI.Page
	{

		int maxRows = 0;
		int isOfficial = 0;
		int thisUser = 1;
		int moduleId = 1;
		int currentPage = 1;
		int pageSize = 10;
		int maxPageShow = 10;
		bool showLastPages = true;

		string singularTitle = "Transaction";
		string prularTitle = "Transactions";
		protected Transactions()
		{
            isOfficial = 0;
            string email = Membership.GetUser().Email;
            iBiz.FinPro.UserProfile bUser = new iBiz.FinPro.UserProfile();
            iBiz.FinPro.UserProfile.objUserProfile objUser = new iBiz.FinPro.UserProfile.objUserProfile();

            objUser = bUser.Select(email);

            if (objUser != null)
            {
                thisUser = objUser.userID;

                if (objUser.userIsOfficial)
                {
                    isOfficial = 1;
                }
                else
                {
                    isOfficial = 0;
                }
            }

		}

		protected override void OnPreInit(EventArgs e)
		{
			iBiz.FinPro.Modules.Info modInfo = new iBiz.FinPro.Modules.Info();

			if (Request.QueryString["mod"] != null)
			{	
				moduleId = Convert.ToInt32(Request.QueryString["mod"]);
			}
			else
			{
				moduleId = 1;
			}

			singularTitle = modInfo.singular_Title(moduleId);
			prularTitle = modInfo.prular_Title(moduleId);

			base.OnPreInit(e);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
            //currentPage = currentPage == 0 ? 1 : currentPage;
            //pageSize = pageSize == 0 ? 1 : pageSize;

			if (!IsPostBack)
			{
				ltrTitle.Text = prularTitle;
				//hplNewVouchar.Text = "New " + singularTitle;

				if (moduleId > 0)
				{
					hplNewVouchar.NavigateUrl = "~/FinApp/Vouchar_New.aspx?mod=" + moduleId.ToString();
				}

				Load_Data();

			}

            
		}

		protected void Load_Data()
		{
			IDataReader idr = null;
			idr = Get_Grid_Data();
			lvGrid.DataSource = idr;
			lvGrid.DataBind();
			
        }

		protected IDataReader Get_Grid_Data()
		{
			
			iDB.Communicate dbComm = new iDB.Communicate();
			IDataReader idr = null;
            string query = "";

            query = string.Format("select *, (userFirstName + ' ' + userLastName) as CreatedBy, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over (Order by transGroupCreatedOn desc) as RowNo from vw_page_transactions where transGroupPrefixNo={0}", moduleId);


            if (isOfficial == 1)
            {
                query = string.Format("select *, IsNull(transGroupOfficialTotalAmount, 0) as groupTotal, (userFirstName + ' ' + userLastName) as CreatedBy, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over (Order by transGroupCreatedOn desc) as RowNo from vw_page_transactions where not transGroupStatus=3 and transGroupPrefixNo={0}", moduleId);
                //query += " and transGroupIsOfficial=1"; // Official Condition

                DateTime? nullDate = null;
                tbFromDate_CalendarExtender.SelectedDate = tbFromDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbFromDate.Text) : nullDate;
                tbToDate_CalendarExtender.SelectedDate = tbToDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbToDate.Text) : nullDate;


                query += tbFromDate_CalendarExtender.SelectedDate.HasValue && !tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and transGroupCreatedOn>='{0}'", Convert.ToDateTime(tbFromDate.Text)) : "";

                query += !tbFromDate_CalendarExtender.SelectedDate.HasValue && tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and transGroupCreatedOn<='{0}'", Convert.ToDateTime(tbToDate.Text)) : "";

                query += !tbFromDate_CalendarExtender.SelectedDate.HasValue && tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and (transGroupCreatedOn between '{0}' and '{1}')", Convert.ToDateTime(tbFromDate.Text), Convert.ToDateTime(tbToDate.Text)) : "";

                query += tbDescription.Text.Trim().Length >= 0 ? string.Format(" and transGroupTitle like '%{0}%'", tbDescription.Text.Trim()) : "";

            }
            else
            {
                query = string.Format("select *, transGroupTotalAmount as groupTotal, (userFirstName + ' ' + userLastName) as CreatedBy, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over (Order by transGroupCreatedOn desc) as RowNo from vw_page_transactions where not transGroupStatus=3 and transGroupPrefixNo={0}", moduleId);

                DateTime? nullDate = null;
                tbFromDate_CalendarExtender.SelectedDate = tbFromDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbFromDate.Text) : nullDate;
                tbToDate_CalendarExtender.SelectedDate = tbToDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbToDate.Text) : nullDate;


                query += tbFromDate_CalendarExtender.SelectedDate.HasValue && !tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and transGroupCreatedOn>='{0}'", Convert.ToDateTime(tbFromDate.Text)) : "";

                query += !tbFromDate_CalendarExtender.SelectedDate.HasValue && tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and transGroupCreatedOn<='{0}'", Convert.ToDateTime(tbToDate.Text)) : "";

                query += !tbFromDate_CalendarExtender.SelectedDate.HasValue && tbToDate_CalendarExtender.SelectedDate.HasValue ? string.Format(" and (transGroupCreatedOn between '{0}' and '{1}')", Convert.ToDateTime(tbFromDate.Text), Convert.ToDateTime(tbToDate.Text)) : "";

                query += tbDescription.Text.Trim().Length >= 0 ? string.Format(" and transGroupTitle like '%{0}%'", tbDescription.Text.Trim()) : "";
            }


            idr = dbComm.SelectCMD("select IsNull(max(RowNo), 0) as maxRows from (" + query + ") as Results");

            if (idr != null)
            {
                while (idr.Read())
                {
                    maxRows = Convert.ToInt32(idr["maxRows"]);
                }
            }
			
            int recordNoFrom = (pageSize * currentPage) - pageSize;
            int recordNoTo = recordNoFrom + pageSize;

            query = string.Format("select * from (" + query + ") as results where RowNo>={0} and RowNo<{1}", recordNoFrom, recordNoTo);

			idr = dbComm.SelectCMD(query);

			Do_Pagination(null, null);

			return idr;
		}

		protected string btn_approve_css(object i)
		{
			if (i == DBNull.Value)
			{
				return "approve_button";
			}
			else
			{
				return "approved_button";
			}
		}

		protected string get_status_css(int statusId)
		{
			string rt = "label label-sm label-info";
			if (statusId == 1)
			{
				
			}
			return rt;
		}

		protected string Get_Trans_Link(int transGroupID)
		{
			string rt = string.Format("~/FinApp/Vouchar_View.aspx?gid={0}", transGroupID);

			if (Request.QueryString["mod"] != null)
			{
				rt += string.Format("&mod={0}", Request.QueryString["mod"]);
			}

			if (iBiz.FinPro.Rights.edit_vouchar)
			{
				rt += "&update=1";
			}


			return rt;
		}
		
        protected void lvGrid_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "approve_this")
            {
                int transGId = Convert.ToInt32(e.CommandArgument);
                iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
                bTransG.MarkGroupApproved(transGId, thisUser);
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {	
            Load_Data();
        }

		protected void Do_Pagination(object source, object e)
		{
			if (source == null && e == null)
			{
				DataTable dt = new DataTable();
				DataTable dtLastPages = new DataTable();
				dt.Columns.Add("pageNo");
				dt.Columns.Add("selectedCSS");

				dtLastPages.Columns.Add("pageNo");

				int totalPageCount = maxRows / pageSize;
				double remainder = Math.IEEERemainder(maxRows, pageSize);
				double halfOfMaxPageShow = maxPageShow / 2;

				if (remainder > 0)
				{
					totalPageCount++;
				}


				int startPage = currentPage - Convert.ToInt32(halfOfMaxPageShow);
				int endPage = currentPage + Convert.ToInt32(halfOfMaxPageShow);


				for (int i = startPage; i <= endPage; i++)
				{
					if (i > 0 && i <= totalPageCount)
					{
						if (i == currentPage)
						{
							dt.Rows.Add(i.ToString(), "active");
						}
						else
						{
							dt.Rows.Add(i.ToString(), "");
						}
					}
				}

				if (currentPage == 1)
				{
					sample_2_previous.Attributes.Add("class", "paginate_button previous disabled");
                }
				else
				{
					sample_2_previous.Attributes.Add("class", "paginate_button previous");
				}


				if (currentPage == totalPageCount)
				{
					sample_2_next.Attributes.Add("class", "paginate_button next disabled");
				}
				else
				{
					sample_2_next.Attributes.Add("class", "paginate_button next");
				}

				//ltrPageSummary.Text = currentPage.ToString() + " of " + totalPageCount.ToString();


				rptStartPaging.DataSource = dt;
				rptStartPaging.DataBind();
				//lblDotted.Visible = false;

				if (showLastPages)
				{
					//lblDotted.Visible = true;
					rptLastPages.DataSource = dtLastPages;
					rptLastPages.DataBind();
				}


				if (currentPage == 1)
				{
					lbtnPrevious.Enabled = false;
				}
				else
				{
					lbtnPrevious.Enabled = true;
					lbtnNext.CommandArgument = Convert.ToString(currentPage - 1);
				}

				if (currentPage == totalPageCount)
				{
					lbtnNext.Enabled = false;
				}
				else
				{
					lbtnNext.Enabled = true;
					lbtnNext.CommandArgument = Convert.ToString(currentPage + 1);
				}


				//rptStartPaging.DataSource = dt;
				//rptStartPaging.DataBind();
			}
			else
			{
				pageSize = Convert.ToInt32(ddlPaginationRows.SelectedValue);

				if (source is Repeater)
				{
					RepeaterCommandEventArgs arg = (RepeaterCommandEventArgs)e;
					currentPage = Convert.ToInt32(arg.CommandArgument);
					hfCurrentPage.Value = currentPage.ToString();
					Load_Data();
				}
				else if (source is LinkButton)
				{
					LinkButton buttonPressed = (LinkButton)source;
					if (buttonPressed.UniqueID.ToString().Contains("lbtnNext"))
					{
						currentPage = Convert.ToInt32(hfCurrentPage.Value);
						currentPage++;
						hfCurrentPage.Value = currentPage.ToString();
						Load_Data();
					}
					else if (buttonPressed.UniqueID.ToString().Contains("lbtnPrevious"))
					{
						currentPage = Convert.ToInt32(hfCurrentPage.Value);
						currentPage--;
						hfCurrentPage.Value = currentPage.ToString();
						Load_Data();
					}
				}
				else if (source is DropDownList)
				{
					Load_Data();
				}
			}

			ddlPaginationRows.SelectedValue = pageSize.ToString();
		}

        protected string Get_Description_Trimmed(string input)
        {
            string rt = input;

            if (rt.Length > 50)
            {
                rt = rt.Remove(49);
            }

            return rt;
        }
		
	}
}