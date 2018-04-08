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
	public partial class Vouchar_View : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack && !string.IsNullOrEmpty(Request.QueryString["gid"]))
			{
				int voucharId = Convert.ToInt32(Request.QueryString["gid"]);
				iBiz.FinPro.Transactions.Groups bTransGroup = new iBiz.FinPro.Transactions.Groups();
				iBiz.FinPro.Transactions.Groups.objGroup objTransGroup = new iBiz.FinPro.Transactions.Groups.objGroup();

				objTransGroup = bTransGroup.Select(voucharId);

				if (objTransGroup != null)
				{
					iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
					iBiz.FinPro.UserProfile.objUserProfile objProfile = new iBiz.FinPro.UserProfile.objUserProfile();
					objProfile = bProfile.Select(objTransGroup.transGroupCreatedBy);

					string CreatedBy = "Unknown";

					if (objProfile != null)
					{
						CreatedBy = objProfile.userFirstName + " " + objProfile.userLastName;
					}



					string VerfiedBy = "Unverified";
					if (objTransGroup.transGroupApprovedBy != null)
					{
						objProfile = new iBiz.FinPro.UserProfile.objUserProfile();
						objProfile = bProfile.Select(objTransGroup.transGroupApprovedBy.Value);

						if (objProfile != null)
						{
							VerfiedBy = objProfile.userFirstName + " " + objProfile.userLastName;
						}
					}


					iBiz.FinPro.Modules.Info bModuleInfo = new iBiz.FinPro.Modules.Info();
					string reportTitle = "Vouchar";
					if (objTransGroup.transGroupPrefixNo.HasValue)
					{
						reportTitle = bModuleInfo.singular_Title(objTransGroup.transGroupPrefixNo.Value);
					}


					Report raReport = new rpTransaction(voucharId, objTransGroup.transGroupPrefixString + objTransGroup.transGroupForeNumber.ToString(), true, objTransGroup.transGroupCreatedOn.ToString("MMM dd, yyyy"), objTransGroup.transGroupTitle, objTransGroup.transGroupRefId, CreatedBy, VerfiedBy, "Apprv By", "Rev by", reportTitle);


					rvReport.Report = raReport;
				}
			}
		}
	}
}