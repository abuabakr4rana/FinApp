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
	public partial class Invoice_New : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Load_Items(true, true);
			}
		}

		protected DataTable List_Departments()
		{
			IDataReader idr = null;
			DataTable dt = new DataTable();
			dt.Columns.Add("deptId");
			dt.Columns.Add("deptCode");

			iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
			iBiz.FinPro.Modules.Departments bDept = new iBiz.FinPro.Modules.Departments();

			idr = bDept.Select();

			dt.Rows.Add("0", "None");

			while (idr.Read())
			{
				dt.Rows.Add(idr["deptId"].ToString(), idr["deptCode"]);
			}


			return dt;
		}

		protected DataTable List_Accounts()
		{
			IDataReader idr = null;
			DataTable dt = new DataTable();
			dt.Columns.Add("accountID");
			dt.Columns.Add("accountTitle");

			iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
			idr = bAcc.SelectTransactable(true);

			dt.Rows.Add("0", "");

			while (idr.Read())
			{
				dt.Rows.Add(idr["accountID"].ToString(), idr["accountTitle"]);
			}


			return dt;
		}

		protected void rptVoucherItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem rptItem = (RepeaterItem)e.Item;

			foreach (Control item in rptItem.Controls)
			{
				if (item is DropDownList)
				{
					DropDownList ddlCtrl = (DropDownList)item;

					if (item.UniqueID.ToString().ToLower().Contains("ddldept"))
					{
						HiddenField hfSelectedDept = (HiddenField)Form.FindControl(item.UniqueID.Replace("ddlDept", "hfSelectedDept"));
						if (hfSelectedDept != null)
						{
							ddlCtrl.SelectedValue = hfSelectedDept.Value;
						}
					}
					else if (item.UniqueID.ToString().ToLower().Contains("ddltax1"))
					{
						HiddenField hfSelectedTax = (HiddenField)Form.FindControl(item.UniqueID.Replace("ddlTax1", "hfTax1"));
						if (hfSelectedTax != null)
						{
							ddlCtrl.SelectedValue = hfSelectedTax.Value;
						}
					}
					else if (item.UniqueID.ToString().ToLower().Contains("ddltax2"))
					{
						HiddenField hfSelectedTax = (HiddenField)Form.FindControl(item.UniqueID.Replace("ddlTax2", "hfTax2"));
						if (hfSelectedTax != null)
						{
							ddlCtrl.SelectedValue = hfSelectedTax.Value;
						}
					}
				}
				else if (item is RadComboBox)
				{
					RadComboBox ctrl = (RadComboBox)item;
					HiddenField hfSelectedItem = (HiddenField)Form.FindControl(item.UniqueID.Replace("ddlCreditAccount", "hfCrSelectedAccount"));

					if (hfSelectedItem != null)
					{
						ctrl.SelectedValue = hfSelectedItem.Value;
					}
				}
			}
		}

		protected void btnAddRows_Click(object sender, EventArgs e)
		{
			Load_Items(true, false);
		}

		protected void btnSubmitForm_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{

			}
		}

		protected void Load_Items(bool addMore, bool doReset)
		{
			int moduleParameterId = 0;

			if (!string.IsNullOrEmpty(ddlBranch.SelectedValue))
			{
				moduleParameterId = Convert.ToInt32(ddlBranch.SelectedValue);
			}

			if (doReset)
			{
				rptVoucherItems.DataSourceID = null;
				rptVoucherItems.DataBind();
			}



			if (Request.QueryString["gid"] != null && addMore == false)
			{
				int groupId = Convert.ToInt32(Request.QueryString["gid"]);
				iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
				iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
				iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
				objTransG = bTransG.Select(groupId);

				if (objTransG != null)
				{
					rptVoucherItems.DataSource = bTrans.Select_Grp(groupId, true);
					rptVoucherItems.DataBind();
				}

			}


			DataTable dt = new DataTable();
			dt.Columns.Add("itemCount");
			dt.Columns.Add("invItemId");
			dt.Columns.Add("invItemAccId");
			dt.Columns.Add("invItemDescription");
			dt.Columns.Add("invItemCost");
			dt.Columns.Add("invItemQty");
			dt.Columns.Add("invItemTax1Id");
			dt.Columns.Add("invItemTax2Id");
			dt.Columns.Add("deptId");

			int iNo = 0;

			foreach (RepeaterItem item in rptVoucherItems.Items)
			{
				foreach (Control ctrlItem in item.Controls)
				{
					if (ctrlItem is HiddenField)
					{
						if (ctrlItem.ClientID.ToLower().Contains("hfitemcount"))
						{
							HiddenField hfINo = (HiddenField)ctrlItem;
							RadComboBox ddlCreditAccounts = (RadComboBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "ddlCreditAccount"));
							TextBox tbDescription = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "tbDescription"));
							TextBox tbUnitCost = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "tbUnitCost"));
							TextBox tbQuantity = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "tbQty"));
							DropDownList ddlTax1 = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "ddlTax1"));
							DropDownList ddlTax2 = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "ddlTax2"));
							DropDownList ddlDept = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemCount", "ddlDept"));


							dt.Rows.Add(iNo + 1, "", ddlCreditAccounts.SelectedValue.ToString(), tbDescription.Text, tbUnitCost.Text, tbQuantity.Text, ddlTax1.SelectedValue, ddlTax2.SelectedValue, ddlDept.SelectedValue);

							//dt.Rows.Add(null, itemNo, showOff, transId, drAccountId, crAccountId, deptId, description, Comma_Amount(""));
						}
					}
				}
			}

			
			if (addMore || rptVoucherItems.Items.Count == 0)
			{
				dt.Rows.Add(iNo + 1, "", "", "", "", "", "", "");
				dt.Rows.Add(iNo + 1, "", "", "", "", "", "", "");

				hfTotalItems.Value = Convert.ToString(iNo + 2);
			}
			else
			{
				hfTotalItems.Value = Convert.ToString(iNo);
			}


			rptVoucherItems.DataSource = dt;
			rptVoucherItems.DataBind();
		}

	}
}