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
    public partial class Problems : System.Web.UI.Page
    {
        int isOfficial = 0;
		int thisUser = 1;
		//int moduleId = 1;

        //string singularTitle = "Transaction";
        //string prularTitle = "Transactions";
        protected Problems()
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


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ltrTitle.Text = "Problematic Transactions";
			}
            Load_Data();
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

            int maxRows = 0;

			iDB.Communicate dbComm = new iDB.Communicate();
			IDataReader idr = null;
            string query = "";

            query = string.Format("select *, (userFirstName + ' ' + userLastName) as CreatedBy, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo, ROW_NUMBER() Over (Order by transGroupCreatedOn desc) as RowNo from vw_page_transactions where transGroupId in ({0})", Imbalanced_Vouchars());


			idr = dbComm.SelectCMD(query);
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

        protected void lvGrid_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_this")
            {
                int transGId = Convert.ToInt32(e.CommandArgument);
                iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
                //bTransG.MarkGroupApproved(transGId, thisUser);
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        protected string Imbalanced_Vouchars()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where transGroupID in (select transGroupID from fin_TransGroups) group by transGroupID");
            string output = "";

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupID = Convert.ToInt32(idr["transGroupID"]);
                    objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
                    objTransG = bTransG.Select(transGroupID);
                    decimal crTotal = 0, drTotal = 0, OCrTotal = 0, ODrTotal = 0;



                    if (objTransG != null)
                    {
                        if (objTransG.Get_Transactions() != null)
                        {
                            foreach (var item in objTransG.Get_Transactions())
                            {
                                if (item.transDrAccount == null)
                                {
                                    OCrTotal += item.transAmount;
                                }
                                else
                                {
                                    ODrTotal += item.transAmount;
                                }
                            }
                        }

                        if (ODrTotal == OCrTotal)
                        {
                            //output += string.Format("<td>Balanced<td>");
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(output))
                            {
                                output += ",";
                            }

                            output += transGroupID.ToString();
                        }

                    }
                }
            }


            return output;
        }
    }
}