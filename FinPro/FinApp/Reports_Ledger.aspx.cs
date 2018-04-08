using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using Telerik.Web;
using Telerik.Web.UI;

namespace FinPro.FinApp
{
    public partial class Reports_Ledger : System.Web.UI.Page
    {
        int sysIndex = 0;
        //int isOfficial = 0;
        int thisUser = 1;
        int moduleId = 1;
		decimal openningBalance = 0;

        protected Reports_Ledger()
		{
            sysIndex = 0;
            string email = Membership.GetUser().Email;
            iBiz.FinPro.UserProfile bUser = new iBiz.FinPro.UserProfile();
            iBiz.FinPro.UserProfile.objUserProfile objUser = new iBiz.FinPro.UserProfile.objUserProfile();

            objUser = bUser.Select(email);

            if (objUser != null)
            {
                thisUser = objUser.userID;

                if (objUser.userIsOfficial)
                {
                    sysIndex = 1;
                }
                else
                {
                    sysIndex = 0;
                }
            }
		}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Departments();
                Preload_Accounts();
                Load_Report();
                
            }

            //rcmbAccounts.Filter = (RadComboBoxFilter)Convert.ToInt32(RadDDLFilter.SelectedValue);
        }
        protected void Preload_Accounts()
        {
            iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
            IDataReader idr = bAcc.Select();
            //ddlAccounts.DataTextField = "accountTitle";
            //ddlAccounts.DataValueField = "accountID";
            //rcmbAccounts.DataSource = idr;
            //rcmbAccounts.DataBind();
            //rcmbAccounts.SelectedIndex = 0;

            //idr = bAcc.Select();
            ddlAccounts.DataSource = idr;
            ddlAccounts.DataBind();

            ddlAccounts.SelectedIndex = 0;
        }
        protected void Load_Report()
        {
			ltrOpeningBalance.Text = "0";

            iBiz.FinPro.Transactions.Reports bReport = new iBiz.FinPro.Transactions.Reports();
            
            int accountID = Convert.ToInt32(ddlAccounts.SelectedValue);

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                accountID = Convert.ToInt32(Request.QueryString["id"]);
                ddlAccounts.SelectedValue = accountID.ToString();
            }



            int deptId = ddlDepartment.SelectedValue != null ? Convert.ToInt32(ddlDepartment.SelectedValue) : 0;
            DateTime? nullDate = null;
			//tbFromDate_CalendarExtender.SelectedDate = tbFromDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbFromDate.Text) : nullDate;
			//tbToDate_CalendarExtender.SelectedDate = tbToDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbToDate.Text) : nullDate;

			DateTime? fromDate = tbFromDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbFromDate.Text) : nullDate;
			DateTime? toDate = tbToDate.Text.Trim().Length > 0 ? Convert.ToDateTime(tbToDate.Text) : nullDate;


            //if (radFromDate.SelectedDate.HasValue)
            //{
            //    fromDate = radFromDate.SelectedDate.Value;
            //}

            //if (radToDate.SelectedDate.HasValue)
            //{
            //    toDate = radToDate.SelectedDate.Value;
            //}

            lvGrid.DataSource = bReport.Ledger(accountID, fromDate, toDate, Convert.ToBoolean(sysIndex), deptId);
            lvGrid.DataBind();

            IDataReader idr = bReport.Ledger(accountID, fromDate, toDate, Convert.ToBoolean(sysIndex), deptId);

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            if (idr != null)
            {
                while (idr.Read())
                {
                    totalCredit += Convert.ToDecimal(idr["CreditAmount"]);
                    totalDebit += Convert.ToDecimal(idr["DebitAmount"]);
                }
            }


			if (!fromDate.HasValue)
			{
				fromDate = DateTime.Now.AddYears(-2);
			}

			iBiz.FinPro.Transactions.Reports bTransReport = new iBiz.FinPro.Transactions.Reports();
			ltrOpeningBalance.Text = bTransReport.Get_Openning_Balance(accountID, fromDate.Value, deptId).ToString("0");


            ltrTotalDebit.Text = Comma_Amount(totalDebit);
            ltrTotalCredit.Text = Comma_Amount(totalCredit);
            hlPrintable.NavigateUrl = string.Format("~/FinApp/RShow_Ledger.aspx?accId={0}&from={1}&to={2}&deptId={3}", accountID, fromDate.HasValue ? fromDate.Value.ToString("MM-dd-yyyy") : "", toDate.HasValue ? toDate.Value.ToString("MM-dd-yyyy") : "", deptId.ToString());
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Load_Report();
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

        protected void Load_Departments()
        {
            IDataReader idr = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("deptId");
            dt.Columns.Add("deptCode");
            dt.Columns.Add("deptTitle");
            iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
            iBiz.FinPro.Modules.Departments bDept = new iBiz.FinPro.Modules.Departments();

            idr = bDept.Select();

            dt.Rows.Add("0", "All", "All");

            while (idr.Read())
            {
                dt.Rows.Add(idr["deptId"].ToString(), idr["deptCode"], idr["deptTitle"]);
            }

            ddlDepartment.DataSource = dt;
            ddlDepartment.DataBind();
        }

        protected string Comma_Amount(decimal amount)
        {
            //string.Format("{0:n0}", Convert.ToInt32(Eval("transGroupTotalAmount")))
            if (amount < 0)
            {
                return "(" + string.Format("{0:n0}", Convert.ToInt32(amount * -1)) + ")";
            }
            else
            {
                return string.Format("{0:n0}", Convert.ToInt32(amount));
            }
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