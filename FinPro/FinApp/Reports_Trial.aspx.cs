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
    public partial class Reports_Trial : System.Web.UI.Page
    {
        int isOfficial = 0;
        //int isOfficial = 0;
        int thisUser = 1;
        int moduleId = 1;

        protected Reports_Trial()
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
                Load_Report();   
            }
        }

        protected void Load_Report()
        {
            iBiz.FinPro.Transactions.Reports bReport = new iBiz.FinPro.Transactions.Reports();

            
            DateTime? fromDate = null;
            DateTime? toDate = null;

			if (tbFromDate.Text.Trim().Length == 0)
			{
				
			}
			else
			{
				fromDate = Convert.ToDateTime(tbFromDate.Text.Trim());
			}

			if (tbToDate.Text.Trim().Length == 0)
			{
				
			}
			else
			{
				toDate = Convert.ToDateTime(tbToDate.Text.Trim());
			}

            lvGrid.DataSource = bReport.Trial_Balance(fromDate, toDate, Convert.ToBoolean(isOfficial));
            lvGrid.DataBind();

            IDataReader idr = bReport.Trial_Balance(fromDate, toDate, Convert.ToBoolean(isOfficial));

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            if (idr != null)
            {
                while (idr.Read())
                {
                    totalCredit += Convert.ToDecimal(idr["credit"]);
                    totalDebit += Convert.ToDecimal(idr["debit"]);
                }
            }

            ltrTotalDebit.Text = Difference_Amount(totalDebit);
            ltrTotalCredit.Text = Difference_Amount(totalCredit);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Load_Report();
        }

        protected string Difference_Amount(decimal amount)
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
    }
}