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
    public partial class Reports_Journal : System.Web.UI.Page
    {
        int isOfficial = 0;
        int thisUser = 1;
        
        protected Reports_Journal()
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
            }
		}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Report();
            }
        }

        protected void Load_Report()
        {
            iBiz.FinPro.Transactions.Reports bReport = new iBiz.FinPro.Transactions.Reports();


            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (radFromDate.SelectedDate.HasValue)
            {
                fromDate = radFromDate.SelectedDate.Value;
            }

            if (radToDate.SelectedDate.HasValue)
            {
                toDate = radToDate.SelectedDate.Value;
            }
            
            wucDataPager.maxPageShow = 100;
            wucDataPager.pageSize = 15;
            wucDataPager.showLastPages = false;
            int recordNoFrom = (wucDataPager.pageSize * wucDataPager.currentPage) - wucDataPager.pageSize;
            int recordNoTo = recordNoFrom + wucDataPager.pageSize;
            int maxRows = bReport.MaxJournalRows(fromDate, toDate, Convert.ToBoolean(isOfficial), recordNoFrom, recordNoTo);
            wucDataPager.maxRows = maxRows;

            lvGrid.DataSource = bReport.Journal_Vochars(fromDate, toDate, Convert.ToBoolean(isOfficial), recordNoFrom, recordNoTo);
            lvGrid.DataBind();



            ////// Total Rows

            //IDataReader idr = bReport.Journal_Vochars(fromDate, toDate, Convert.ToBoolean(sysIndex));

            //double totalDebit = 0;
            //double totalCredit = 0;

            //if (idr != null)
            //{
            //    while (idr.Read())
            //    {
            //        totalCredit += Convert.ToDouble(idr["credit"]);
            //        totalDebit += Convert.ToDouble(idr["debit"]);
            //    }
            //}

            //ltrTotalDebit.Text = totalDebit.ToString();
            //ltrTotalCredit.Text = totalCredit.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Load_Report();
        }

        protected IDataReader Get_Vouchar_Transactions(int voucharId)
        {
            IDataReader idr = null;
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            idr = bTrans.Select_Grp(voucharId, Convert.ToBoolean(isOfficial));
            return idr;
        }

        protected string Get_Trans_Link(int transGroupID)
        {
            string rt = string.Format("~/FinApp/Vouchar_Editor.aspx?gid={0}", transGroupID);

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

        protected void wucDataPager_PageChange(object source, EventArgs e)
        {
            RepeaterCommandEventArgs re = (RepeaterCommandEventArgs)e;
            //string aa = re.CommandArgument.ToString();
            Load_Report();
        }

        protected void wucDataPager_NextPageClicked(object source, EventArgs e)
        {
            
        }

        protected void wucDataPager_PreviousPageClicked(object source, EventArgs e)
        {
            
        }
    }
}