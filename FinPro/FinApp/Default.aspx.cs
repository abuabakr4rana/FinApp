using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FinPro.FinApp
{
	public partial class Default : System.Web.UI.Page
	{
        int sysIndex = 0;
        //int isOfficial = 0;
        int thisUser = 1;
        int moduleId = 1;

        protected Default()
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
                
            }
		}

        protected string Get_LineChart_XAxisTitles()
        {
            DateTime currentDate = DateTime.Now;

            string rt = "";

            for (int i = 11; i >= 0; i--)
            {
                rt += "'" + currentDate.AddMonths(i * -1).ToString("MMM, yyyy") + "' ,";
            }

            if (rt[rt.Length - 1].ToString() == ",")
            {
                rt = rt.Remove(rt.Length - 1, 1);
            }

            //return "2002,2003,2004,2005,2006,2007,2008,2009,2010,2011";
            return rt;
        }

        protected string Get_LineChart_Data()
        {
            iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
            iBiz.FinPro.Accounts.objAccount objAccount;
            iBiz.FinPro.Transactions.Reports bReports = new iBiz.FinPro.Transactions.Reports();


            string accountIDs = iBiz.FinPro.Statics.Dashboard_LineChart_Account;
            string[] accountIdArr = accountIDs.Split(',');


            string rt = ""; // "{ name: \"Pakistan\", data: [3.907, 7.943, 7.848, 9.284, 9.263, 9.801, 3.890, 8.238, 9.552, 6.855,] }, ";
            for (int i = 0; i < accountIdArr.Length; i++)
            {
                int accountId = Convert.ToInt32(accountIdArr[i]);
                objAccount = new iBiz.FinPro.Accounts.objAccount();
                objAccount = bAcc.Select(accountId);

                if (objAccount != null)
                {
                    string dataString = "";


                    DateTime currentDate = DateTime.Now;

                    
                    for (int j = 11; j >= 0; j--)
                    {
                        DateTime tempDate = currentDate.AddMonths(j * -1);
                        DateTime startDate = Convert.ToDateTime(tempDate.Month.ToString() + "/1/" + tempDate.Year.ToString());
                        DateTime endDate = Convert.ToDateTime(tempDate.Month.ToString() + "/" + DateTime.DaysInMonth(tempDate.Year, tempDate.Month).ToString() + "/" + tempDate.Year.ToString());
                        string str = currentDate.AddMonths(i * -1).ToString("MMM, yyyy");
                        string data = bReports.Account_Period_Sum(objAccount.accountID, startDate, endDate, Convert.ToBoolean(sysIndex)).ToString();
                        dataString += "[" + data + ", '" + str + "']" + ",";  
                    }

                    rt += "{ name: \"" + objAccount.accountTitle + "\", data: [ " + dataString + " ] }, ";
                }
            }

            return rt;
        }
	}
}