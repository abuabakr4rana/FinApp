using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;
using Telerik;
using Telerik.ReportViewer;

namespace FinPro.FinApp
{
    public partial class RShow_Ledger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Load_Report();
            
        }

        protected void Load_Report()
        {
            int accId = Convert.ToInt32(Request.QueryString["accId"]);
            DateTime fromDate = string.IsNullOrEmpty(Request.QueryString["from"]) == false ? Convert.ToDateTime(Request.QueryString["from"]) : Convert.ToDateTime("01/01/2001");

            DateTime toDate = string.IsNullOrEmpty(Request.QueryString["to"]) == false ? Convert.ToDateTime(Request.QueryString["to"]) : DateTime.Now;

            int deptId = string.IsNullOrEmpty(Request.QueryString["deptId"]) == false ? Convert.ToInt32(Request.QueryString["deptId"]) : 0;

            iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
            iBiz.FinPro.Accounts.objAccount objAcc = new iBiz.FinPro.Accounts.objAccount();
            objAcc = bAcc.Select(accId);

            if (objAcc != null)
            {
                Report raReport = new rpLedger(objAcc.accountTitle, string.Format("{0} till {1}", fromDate.ToString("MMM dd, yyyy"), toDate.ToString("MMM dd, yyyy")), accId, fromDate, toDate, deptId);
                rvReport.Report = raReport;
                
            }
        }
    }
}