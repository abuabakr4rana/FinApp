namespace FinPro.FinApp
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rpLedger.
    /// </summary>
    public partial class rpLedger : Telerik.Reporting.Report
    {
       
        public rpLedger(string accountTitle, string periodText, int accountId, DateTime fromDate, DateTime toDate, int? deptId)
        {
             //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            paramPeriod.Value = periodText;
            paramTitle.Value = "General Ledger";
            paramAccountTitle.Value = accountTitle;
            Report.ReportParameters["accountId"].Value = accountId;
            Report.ReportParameters["fromDate"].Value = fromDate;
            Report.ReportParameters["toDate"].Value = toDate;

            if (deptId.HasValue)
            {
                if (deptId > 0)
                {
                    Report.ReportParameters["deptId"].Value = deptId; 
                }
            }

            
        }
    }
}