namespace FinPro.FinApp
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rpTransaction.
    /// </summary>
    public partial class rpTransaction : Telerik.Reporting.Report
    {
        public rpTransaction(int voucharId, string voucharCall, bool isOfficial, string voucharDate, string Description, string ReferenceId, string PreparedBy, string VerifiedBy, string ApprovedBy, string ReviewedBy, string reportTitle)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            paramVoucharId.Value = "Vouchar No. " + voucharCall.ToString();
            
            paramRefId.Value = "Reference: " + "N / A";

            if (!string.IsNullOrEmpty(ReferenceId))
            {
                paramRefId.Value = "Reference: " + ReferenceId;
            }
            
            paramDescription.Value = Description;
            paramDate.Value = voucharDate;
            paramPreparedBy.Value = PreparedBy;
            paramVerifiedBy.Value = VerifiedBy;
            paramTitle.Value = reportTitle;

            Report.ReportParameters[0].Value = voucharId;
            Report.ReportParameters[1].Value = isOfficial;
        }
    }
}