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
	public partial class Vouchar_Editor : System.Web.UI.Page
	{
		int isOfficial = 0;
		int thisUser = 1;
		int moduleId = 1;

		string doWhat = "Create ";
		string singularTitle = "Transaction";
		string prularTitle = "Transactions";
		string short_Title = "TRA";
		protected Vouchar_Editor()
		{
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

		protected override void OnPreInit(EventArgs e)
		{
			iBiz.FinPro.Modules.Info modInfo = new iBiz.FinPro.Modules.Info();

			if (Request.QueryString["mod"] != null)
			{	
				moduleId = Convert.ToInt32(Request.QueryString["mod"]);
			}

			singularTitle = modInfo.singular_Title(moduleId);
			prularTitle = modInfo.prular_Title(moduleId);
			short_Title = modInfo.short_Title(moduleId);

			if (Request.QueryString["gid"] != null)
			{
				doWhat = "Update ";
			}

			base.OnPreInit(e);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                Load_DefaultDepartment();
                hplPrintVouchar.Visible = false;
                //tr_TotalRow.Visible = false;
				ltrTitle.Text = "New " + singularTitle;
				hplHeaderBack.Text = "Back to " + prularTitle;
				lbtnAddVouchar.Text = doWhat + singularTitle;

				if (moduleId != 1)
				{
					hplHeaderBack.NavigateUrl = "~/FinApp/Transactions.aspx?mod=" + moduleId.ToString();
				}
                

				if (Request.QueryString["gid"] != null)
				{
					pnlActions.Visible = false;
					if (Request.QueryString["update"] != null)
					{
						if (Request.QueryString["update"] == "1")
						{
							pnlActions.Visible = true;
						}
					}
				}
                else
                {
                    tr_lbtnDelete.Visible = false;
                }


                try
                {
                    tr_cfield1.Visible = false;
                    tr_cfield2.Visible = false;
                    tr_cfield3.Visible = false;
                    tr_cfield4.Visible = false;
                    tr_branchField.Visible = false;

                    iBiz.FinPro.Modules.fin_Modules bAppModule = new iBiz.FinPro.Modules.fin_Modules();
                    iBiz.FinPro.Modules.fin_Modules.objfin_Modules objModule = new iBiz.FinPro.Modules.fin_Modules.objfin_Modules();

                    objModule = bAppModule.Select(moduleId);

                    if (objModule != null)
                    {
                        if (!string.IsNullOrEmpty(objModule.CField1))
                        {
                            ltrCField1Title.Text = objModule.CField1;
                            tr_cfield1.Visible = true;
                        }

                        if (!string.IsNullOrEmpty(objModule.CField2))
                        {
                            ltrCField2Title.Text = objModule.CField2;
                            tr_cfield2.Visible = true;
                        }

                        if (!string.IsNullOrEmpty(objModule.CField3))
                        {
                            ltrCField3Title.Text = objModule.CField3;
                            tr_cfield3.Visible = true;
                        }

                        if (!string.IsNullOrEmpty(objModule.CField4))
                        {
                            ltrCField4Title.Text = objModule.CField4;
                            tr_cfield4.Visible = true;
                        }

                        if (moduleId == 4)
                        {
                            Load_Branches();
                            tr_branchField.Visible = true;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }


				Load_Items(false, false);
			}
		}

        protected void Load_DefaultDepartment()
        {
            ddlDefautlDept.DataSource = List_Departments();
            ddlDefautlDept.DataValueField = "deptId";
            ddlDefautlDept.DataTextField = "deptCode";
            ddlDefautlDept.DataBind();
        }

        protected void Load_Branches()
        {
            iBiz.FinPro.Generic.Branches bBranches = new iBiz.FinPro.Generic.Branches();
            IDataReader idr = bBranches.Select_Branches();

            ddlBranch.DataTextField = "branchTitle";
            ddlBranch.DataValueField = "branchId";
            ddlBranch.DataSource = idr;
            ddlBranch.DataBind();
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
                    //if (objTransG.transGroupIsOfficial != isOfficial)
                    //{
                    //    Response.Redirect("~/", false);
                    //}

					tbDescription.Text = objTransG.transGroupTitle;
					radVoucharDate.SelectedDate = objTransG.transGroupCreatedOn;
                    tbRefId.Text = objTransG.transGroupRefId;
                    tbCustomValue1.Text = objTransG.transCField1;
                    tbCustomValue2.Text = objTransG.transCField2;
                    tbCustomValue3.Text = objTransG.transCField3;
                    tbCustomValue4.Text = objTransG.transCField4;

					rptVoucherItems.DataSource = bTrans.Select_Grp(groupId, Convert.ToBoolean(isOfficial));
					rptVoucherItems.DataBind();

                    hplPrintVouchar.Visible = true;
                    hplPrintVouchar.NavigateUrl = hplPrintVouchar.NavigateUrl + "?id=" + objTransG.transGroupID.ToString();
                    
                    tr_lbtnUpdate.Visible = objTransG.transGroupApprovedBy.HasValue ? false : true;
                    tr_lbtnDelete.Visible = objTransG.transGroupApprovedBy.HasValue ? false : true;
                    lbtnAddRow.Visible = objTransG.transGroupApprovedBy.HasValue ? false : true;

                    tr_TotalRow.Visible = true;

                    ltrTotalCredit.Text = Comma_Amount(objTransG.Get_Total_Credit());
                    ltrTotalDebit.Text = Comma_Amount(objTransG.Get_Total_Debit());

				}

				Load_Related_Data(groupId);
                Load_Attachments(groupId);
			}


			DataTable dt = new DataTable();
            dt.Columns.Add("additionalTransId");
			dt.Columns.Add("itemNo");
            dt.Columns.Add("chkShowOff");
			dt.Columns.Add("transID");
			dt.Columns.Add("accountId");
            dt.Columns.Add("deptId");
			dt.Columns.Add("description");
			dt.Columns.Add("debitAmount");
			dt.Columns.Add("creditAmount");

			int iNo = 0;

			foreach (RepeaterItem item in rptVoucherItems.Items)
			{
				foreach (Control ctrlItem in item.Controls)
				{
					if (ctrlItem is HiddenField)
					{
						if (ctrlItem.ClientID.ToLower().Contains("hfitemno"))
						{
							iNo++;
							string itemNo, showOff, transId, accountId, deptId, description, debitAmount, creditAmount;
							HiddenField hfINo = (HiddenField)ctrlItem;
                            CheckBox chkShowOff = (CheckBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "chkShowOff"));
							//DropDownList ddlAccounts = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlAccounts"));
                            RadComboBox ddlAccounts = (RadComboBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlAccounts"));
                            DropDownList ddlDepts = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlDept"));
							TextBox tbDescription = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbDescription"));
							TextBox tbDebitAmount = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbDebitAmount"));
							TextBox tbCreditAmount = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbCreditAmount"));
							HiddenField hfTransId = (HiddenField)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "hfTransID"));

							itemNo = hfINo.Value;
                            showOff = Convert.ToInt32(chkShowOff.Checked).ToString();
							transId = hfTransId.Value;
							accountId = ddlAccounts.SelectedValue;
                            deptId = ddlDepts.SelectedValue;
							description = tbDescription.Text;
							debitAmount = tbDebitAmount.Text.Length > 0 ? tbDebitAmount.Text.Replace(",", "") : "0";
                            creditAmount = tbCreditAmount.Text.Length > 0 ? tbCreditAmount.Text.Replace(",", "") : "0";
                            dt.Rows.Add(null, itemNo, showOff, transId, accountId, deptId, description, Comma_Amount(Convert.ToDecimal(debitAmount)), Comma_Amount(Convert.ToDecimal(creditAmount)));
						}
					}
				}
			}

            //get Preset Accounts

            iBiz.FinPro.Modules.fin_Modules bModules = new iBiz.FinPro.Modules.fin_Modules();

            IDataReader idr;

            if (isOfficial == 0)
            {
                idr = bModules.Get_Preselected_Items(moduleId, moduleParameterId, false);
            }
            else
            {
                idr = bModules.Get_Preselected_Items(moduleId, moduleParameterId, true);
            }


            if (idr != null && !addMore && string.IsNullOrEmpty(Request.QueryString["gid"]))
            {
                while (idr.Read())
                {
                    int additionalTransId = Convert.ToInt32(idr["additionalTransId"]);
                    int selectedAccountId = Convert.ToInt32(idr["autoTransAccountId"]);
                    
                    string transDescription = idr["autoTransNarration"].ToString();
                    dt.Rows.Add(additionalTransId, iNo + 1, 1, 0, selectedAccountId, 0, transDescription, "", "");
                }
            }


			if (addMore || rptVoucherItems.Items.Count == 0)
			{
				dt.Rows.Add(null, iNo + 1, 1, 0, 0, 0, "", "", "");
				dt.Rows.Add(null, iNo + 2, 1, 0, 0, 0, "", "", "");

				hfTotalItems.Value = Convert.ToString(iNo + 2);
			}
			else
			{
				hfTotalItems.Value = Convert.ToString(iNo);
			}


			rptVoucherItems.DataSource = dt;
			rptVoucherItems.DataBind();
		}

		protected void lbtnAddRow_Click(object sender, EventArgs e)
		{
			Load_Items(true, false);
		}
        
		protected void rptVoucherItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem rptItem = (RepeaterItem)e.Item;

			foreach (Control item in rptItem.Controls)
			{
                if (item is RadComboBox)
                {
                    RadComboBox radDdlAccount = (RadComboBox)item;

                    if (radDdlAccount.UniqueID.ToString().ToLower().Contains("ddlaccounts"))
                    {
                        HiddenField hfSelectedAccount = (HiddenField)Form.FindControl(radDdlAccount.UniqueID.Replace("ddlAccounts", "hfSelectedAccount"));

                        if (hfSelectedAccount != null)
                        {
                            radDdlAccount.SelectedValue = hfSelectedAccount.Value;
                        }
                    }
                    else if (radDdlAccount.UniqueID.ToString().ToLower().Contains("ddldept"))
                    {
                        HiddenField hfSelectedDept = (HiddenField)Form.FindControl(radDdlAccount.UniqueID.Replace("ddlDept", "hfSelectedDept"));

                        if (hfSelectedDept != null)
                        {
                            radDdlAccount.SelectedValue = hfSelectedDept.Value;
                        }
                    }
                }

                

                if (item is DropDownList)
                {
                    DropDownList ddlAccount = (DropDownList)item;
                    if (ddlAccount.UniqueID.ToString().ToLower().Contains("ddldept"))
                    {
                        HiddenField hfSelectedDept = (HiddenField)Form.FindControl(ddlAccount.UniqueID.Replace("ddlDept", "hfSelectedDept"));

                        if (hfSelectedDept != null)
                        {
                            ddlAccount.SelectedValue = hfSelectedDept.Value;
                        }
                    }
                }

                //if (item is DropDownList)
                //{
                //    DropDownList ddlAccount = (DropDownList)item;

                //    if (ddlAccount.UniqueID.ToString().ToLower().Contains("ddlaccounts"))
                //    {
                //        HiddenField hfSelectedAccount = (HiddenField)Form.FindControl(ddlAccount.UniqueID.Replace("ddlAccounts", "hfSelectedAccount"));

                //        if (hfSelectedAccount != null)
                //        {
                //            ddlAccount.SelectedValue = hfSelectedAccount.Value;
                //        }  
                //    }
                //    else if (ddlAccount.UniqueID.ToString().ToLower().Contains("ddldept"))
                //    {
                //        HiddenField hfSelectedDept = (HiddenField)Form.FindControl(ddlAccount.UniqueID.Replace("ddlDept", "hfSelectedDept"));

                //        if (hfSelectedDept != null)
                //        {
                //            ddlAccount.SelectedValue = hfSelectedDept.Value;
                //        }  
                //    }
                //}
			}
		}

		protected void lbtnAddVouchar_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				iBiz.FinPro.Transactions.Groups bTransGroup = new iBiz.FinPro.Transactions.Groups();
				iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
				iBiz.FinPro.Transactions.Transact.objTransaction objTrans;
				iBiz.FinPro.Transactions.Groups.objGroup objTransGroup = new iBiz.FinPro.Transactions.Groups.objGroup();
                iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();

                int defaultDept = Convert.ToInt32(ddlDefautlDept.SelectedValue);
				int itemsCount = 0;
				decimal totalDebit = 0;
				decimal totalCredit = 0;
                decimal uTotalDebit = 0;
                decimal uTotalCredit = 0;
                bool hasNoDepartment = false;

                int finYear = DateTime.Now.Year;

                if (radVoucharDate.SelectedDate.Value.Month < 6)
                {
                    finYear = finYear - 1;
                }

                DateTime financialYear = Convert.ToDateTime("07/01/" + finYear.ToString());

				bTrans.Delete_Untagged(thisUser);

				if (rptVoucherItems.Items.Count > 0)
				{
					foreach (RepeaterItem item in rptVoucherItems.Items)
					{
						foreach (Control ctrlItem in item.Controls)
						{
							if (ctrlItem is HiddenField)
							{
								if (ctrlItem.ClientID.ToLower().Contains("hfitemno"))
								{
									string itemNo, transId, showOff, accountId, deptId, description, debitAmount, creditAmount, additionalTransId;
									HiddenField hfINo = (HiddenField)ctrlItem;
									//DropDownList ddlAccounts = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlAccounts"));
                                    RadComboBox ddlAccounts = (RadComboBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlAccounts"));
                                    DropDownList ddlDepts = (DropDownList)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "ddlDept"));
									TextBox tbDescription = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbDescription"));
									TextBox tbDebitAmount = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbDebitAmount"));
									TextBox tbCreditAmount = (TextBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "tbCreditAmount"));
									HiddenField hfTransId = (HiddenField)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "hfTransID"));
                                    HiddenField hfAdditionalTransId = (HiddenField)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "hfAdditionalTransId"));
                                    CheckBox chkShowOff = (CheckBox)Form.FindControl(hfINo.UniqueID.Replace("hfItemNo", "chkShowOff"));

                                    iBiz.FinPro.Accounts.objAccount objAcc = new iBiz.FinPro.Accounts.objAccount();


									itemNo = hfINo.Value;
									transId = hfTransId.Value;
									accountId = ddlAccounts.SelectedValue;
                                    deptId = ddlDepts.SelectedValue;
									description = tbDescription.Text;
									debitAmount = tbDebitAmount.Text;
									creditAmount = tbCreditAmount.Text;
                                    additionalTransId = hfAdditionalTransId.Value;
                                    showOff = Convert.ToInt32(chkShowOff.Checked).ToString();


									decimal transAmount = 0;
									bool isDebit = true;

                                    if (debitAmount.Trim().Length > 0 && debitAmount.Trim() != "0")
									{
										decimal.TryParse(debitAmount, out transAmount);
									}
									else
									{
										decimal.TryParse(creditAmount, out transAmount); 
										isDebit = false;
									}
										

									if (transAmount > 0 && transId == "0")
									{
                                        if (hasNoDepartment || (Convert.ToInt32(deptId) <= 0 && defaultDept == 0))
                                        {
                                            hasNoDepartment = true;
                                        }


                                        //Check for Additional Trans

                                        if (!string.IsNullOrEmpty(additionalTransId))
                                        {
                                            if (additionalTransId != "0")
                                            {
                                                iBiz.FinPro.Modules.AdditionalTransactions bAdditionalTrans = new iBiz.FinPro.Modules.AdditionalTransactions();
                                                bAdditionalTrans.Do_Transactions_For_Predefined(0, Convert.ToInt32(additionalTransId), transAmount, "Description", transAmount, moduleId, financialYear, radVoucharDate.SelectedDate.Value, thisUser, Convert.ToInt32(deptId));
                                            }
                                        }


										if (Convert.ToInt32(accountId) > 0)
										{
											objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();

											objTrans.transAmount = transAmount;

											if (isDebit)
											{
												objTrans.transDrAccount = Convert.ToInt32(accountId);
												totalDebit += transAmount;
											}
											else
											{
												objTrans.transCrAccount = Convert.ToInt32(accountId);
												totalCredit += transAmount;
											}

                                            objAcc = bAcc.Select(Convert.ToInt32(accountId));

                                            if (objAcc.accountSystemIndex == 2)
                                            {
                                                objTrans.transSystemRestrict = true;
                                            }
                                            else
                                            {
                                                if (objAcc.accountSystemIndex == 1 && chkShowOff.Checked == false)
                                                {
                                                    objTrans.transSystemRestrict = true;
                                                }
                                                else if (objAcc.accountSystemIndex == 1 && chkShowOff.Checked == true && isOfficial == 1)
                                                {
                                                    if (isDebit)
                                                    {
                                                        uTotalDebit += transAmount;
                                                    }
                                                    else
                                                    {
                                                        uTotalCredit += transAmount;
                                                    }
                                                }
                                                else
                                                {
                                                    objTrans.transSystemRestrict = false;
                                                }
                                            }


                                            if (isDebit)
                                            {
                                                if (objTrans.transSystemRestrict)
                                                {
                                                    uTotalDebit += transAmount;
                                                }
                                            }
                                            else
                                            {
                                                if (objTrans.transSystemRestrict)
                                                {
                                                    uTotalCredit += transAmount;
                                                }
                                            }



											objTrans.transCreatedBy = thisUser;
											objTrans.transCreatedOn = DateTime.Now;
											objTrans.transGroupID = 0;
											objTrans.transIsCompound = true;
											objTrans.transNarration = description;
											objTrans.transStatus = 1;
											objTrans.transSystemIndex = (isOfficial == 1) ? 2 : 1;
                                            objTrans.deptId = Convert.ToInt32(deptId);

                                            if (deptId == "0")
                                            {
                                                objTrans.deptId = defaultDept;
                                            }
                                            
											objTrans.transType = 1;
											objTrans.transUpdatedBy = thisUser;
											objTrans.transUpdatedOn = DateTime.Now;
                                           
											bTrans.Add(objTrans);

											itemsCount++;
										}
									}
									else if (transId != "0")
									{
                                        if (hasNoDepartment || (Convert.ToInt32(deptId) <= 0 && defaultDept == 0))
                                        {
                                            hasNoDepartment = true;
                                        }

										if (transAmount <= 0)
										{
											// Delete existing trans
											if (iBiz.FinPro.Rights.edit_vouchar)
											{
												bTrans.Delete(Convert.ToInt32(transId));
											}
										}
										else
										{
											// Update Trans
											objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
											objTrans = bTrans.Select(Convert.ToInt32(transId));

											if (objTrans != null)
											{
												objTrans.transAmount = transAmount;

												if (isDebit)
												{
													objTrans.transDrAccount = Convert.ToInt32(accountId);
													objTrans.transCrAccount = null;
													totalDebit += transAmount;
												}
												else
												{
													objTrans.transCrAccount = Convert.ToInt32(accountId);
													objTrans.transDrAccount = null;
													totalCredit += transAmount;
												}

                                                objAcc = bAcc.Select(Convert.ToInt32(accountId));

                                                if (objAcc.accountSystemIndex == 2)
                                                {
                                                    objTrans.transSystemRestrict = true;
                                                }
                                                else
                                                {
                                                    if (objAcc.accountSystemIndex == 1 && chkShowOff.Checked == false)
                                                    {
                                                        objTrans.transSystemRestrict = true;
                                                    }
                                                    else if (objAcc.accountSystemIndex == 1 && chkShowOff.Checked == true && isOfficial == 1)
                                                    {
                                                        if (isDebit)
                                                        {
                                                            uTotalDebit += transAmount;
                                                        }
                                                        else
                                                        {
                                                            uTotalCredit += transAmount;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        objTrans.transSystemRestrict = false;
                                                    }
                                                }

                                                if (isDebit)
                                                {
                                                    if (objTrans.transSystemRestrict)
                                                    {
                                                        uTotalDebit += transAmount;
                                                    }
                                                }
                                                else
                                                {
                                                    if (objTrans.transSystemRestrict)
                                                    {
                                                        uTotalCredit += transAmount;
                                                    }
                                                }

												objTrans.transNarration = description;
												objTrans.transStatus = 1;
                                                objTrans.transSystemIndex = (isOfficial == 1) ? 2 : 1;
												
												objTrans.transType = 1;
												objTrans.transUpdatedBy = thisUser;
												objTrans.transUpdatedOn = DateTime.Now;
                                                objTrans.deptId = Convert.ToInt32(deptId);
                                                if (deptId == "0")
                                                {
                                                    objTrans.deptId = defaultDept;
                                                }

												bTrans.Update(objTrans);
												itemsCount++;
											}
										}
									}
								}
							}
						}
					}

					if (itemsCount > 0 && totalDebit == totalCredit && uTotalCredit == uTotalDebit)
					{
						int groupID = 0;


						if (Request.QueryString["gid"] != null)
						{
                            if (!hasNoDepartment)
                            {
                                groupID = Convert.ToInt32(Request.QueryString["gid"]);
                                objTransGroup = bTransGroup.Select(groupID);

                                if (objTransGroup != null)
                                {
                                    objTransGroup.transGroupCreatedOn = radVoucharDate.SelectedDate.Value;
                                    objTransGroup.transGroupTitle = tbDescription.Text.Trim();
                                    objTransGroup.transGroupTotalAmount = totalCredit;
                                    objTransGroup.transTransCount = itemsCount;
                                    objTransGroup.transGroupOfficialTotalAmount = uTotalDebit;
                                    objTransGroup.transGroupRefId = tbRefId.Text;
                                    objTransGroup.transCField1 = tbCustomValue1.Text;
                                    objTransGroup.transCField2 = tbCustomValue2.Text;
                                    objTransGroup.transCField3 = tbCustomValue3.Text;
                                    objTransGroup.transCField4 = tbCustomValue4.Text;
                                    bTransGroup.Update(objTransGroup);

									iBiz.FinPro.Transactions.Attachments bTransAtt = new iBiz.FinPro.Transactions.Attachments();

									if (groupID > 0)
									{
										if (radSyncAttachments.UploadedFiles.Count > 0)
										{
											for (int i = 0; i < radSyncAttachments.UploadedFiles.Count; i++)
											{
												string guid = Guid.NewGuid().ToString();
												string fileExt = radSyncAttachments.UploadedFiles[i].GetExtension();
												radSyncAttachments.UploadedFiles[i].SaveAs(Server.MapPath("~/Attachments/") + guid + fileExt, true);

												iBiz.FinPro.Transactions.Attachments.objAttachment objTranAtt = new iBiz.FinPro.Transactions.Attachments.objAttachment();
												objTranAtt.attachmentMaskedFileName = guid + fileExt;
												objTranAtt.attachmentOriginalFileName = radSyncAttachments.UploadedFiles[i].FileName;
												objTranAtt.transGroupID = groupID;
												bTransAtt.Add(objTranAtt);
											}
										}
									}

									bTrans.Update_Group(thisUser, 0, groupID);
                                    bTrans.Update_Group(thisUser, -1, groupID);

                                    rnNotify.Show("Vouchar has been Updated.");
                                }
                            }
                            else
                            {
                                bTrans.Delete_Untagged(thisUser);
                                rnNotify.Show("You must assign department to all items.");
                            }
							
						}
						else
						{
                            if (!hasNoDepartment)
                            {
                                string fullVoucharNo = "N/A";

                                objTransGroup.transGroupCreatedBy = thisUser;
                                objTransGroup.transGroupCreatedOn = radVoucharDate.SelectedDate.Value;
                                objTransGroup.transGroupForeNumber = bTransGroup.New_Group_Fore_Number(moduleId, short_Title, objTransGroup.transGroupCreatedOn);
                                objTransGroup.transGroupPrefixNo = moduleId;
                                objTransGroup.transGroupPrefixString = short_Title;
                                objTransGroup.transGroupStatus = 1;
                                objTransGroup.transGroupTitle = tbDescription.Text.Trim();
                                objTransGroup.transGroupTotalAmount = totalCredit;
                                objTransGroup.transTransCount = itemsCount;
                                objTransGroup.transGroupIsOfficial = isOfficial;
                                objTransGroup.transGroupOfficialTotalAmount = uTotalDebit;
                                objTransGroup.transGroupRefId = tbRefId.Text;
                                objTransGroup.transCField1 = tbCustomValue1.Text;
                                objTransGroup.transCField2 = tbCustomValue2.Text;
                                objTransGroup.transCField3 = tbCustomValue3.Text;
                                objTransGroup.transCField4 = tbCustomValue4.Text;

                                fullVoucharNo = objTransGroup.transGroupPrefixNo.ToString() + short_Title + objTransGroup.transGroupForeNumber.ToString();
                                groupID = bTransGroup.Add(objTransGroup).Value;

                                // Upload Attachments
                                iBiz.FinPro.Transactions.Attachments bTransAtt = new iBiz.FinPro.Transactions.Attachments();

                                if (groupID > 0)
                                {
                                    if (radSyncAttachments.UploadedFiles.Count > 0)
                                    {
                                        for (int i = 0; i < radSyncAttachments.UploadedFiles.Count; i++)
                                        {
                                            string guid = Guid.NewGuid().ToString();
                                            string fileExt = radSyncAttachments.UploadedFiles[i].GetExtension();
                                            radSyncAttachments.UploadedFiles[i].SaveAs(Server.MapPath("~/Attachments/") + guid + fileExt, true);

                                            iBiz.FinPro.Transactions.Attachments.objAttachment objTranAtt = new iBiz.FinPro.Transactions.Attachments.objAttachment();
                                            objTranAtt.attachmentMaskedFileName = guid + fileExt;
                                            objTranAtt.attachmentOriginalFileName = radSyncAttachments.UploadedFiles[i].FileName;
                                            objTranAtt.transGroupID = groupID;
                                            bTransAtt.Add(objTranAtt);
                                        }
                                    }
                                }

                                bTrans.Update_Group(thisUser, 0, groupID);
                                bTrans.Update_Group(thisUser, -1, groupID);


                                pnlActions.Visible = false;
                                rnNotify.Show("Vouchar has been Created.<br /><br />Vouchar No. is " + fullVoucharNo + "<br /><br />");


                                // Look for Additional Items
                                iBiz.FinPro.Modules.AdditionalTransactions bAT = new iBiz.FinPro.Modules.AdditionalTransactions();
                                ControlCollection ctrlAdditionalItems = rptVoucherItems.Controls[rptVoucherItems.Controls.Count - 1].Controls;

                                foreach (Control ctrlItem in ctrlAdditionalItems)
                                {
                                    if (ctrlItem.ClientID.Contains("rptAdditionalItems"))
                                    {
                                        Repeater rptAdditionalItems = (Repeater)ctrlItem;

                                        foreach (RepeaterItem item in rptAdditionalItems.Items)
                                        {
                                            foreach (Control ctrlHFID in item.Controls)
                                            {
                                                if (ctrlHFID is HiddenField)
                                                {
                                                    if (ctrlHFID.ClientID.Contains("hfAdditionalTransId"))
                                                    {
                                                        HiddenField hfAdditionalItem = (HiddenField)ctrlHFID;
                                                        TextBox tbAdditionalDescription = (TextBox)Form.FindControl(hfAdditionalItem.UniqueID.Replace("hfAdditionalTransId", "tbAdditionalDescription"));
                                                        TextBox tbAdditionalAmount = (TextBox)Form.FindControl(hfAdditionalItem.UniqueID.Replace("hfAdditionalTransId", "tbAddiotionalAmount"));

                                                        decimal additionalAmount;

                                                        if (decimal.TryParse(tbAdditionalAmount.Text.Trim().Replace("%", ""), out additionalAmount))
                                                        {
                                                            bAT.Do_Transactions(groupID, Convert.ToInt32(hfAdditionalItem.Value), additionalAmount, tbAdditionalDescription.Text, totalDebit, radVoucharDate.SelectedDate.Value, thisUser);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bTrans.Delete_Untagged(thisUser);
                                rnNotify.Show("You must assign department to all items.");
                            }
						}
					}
					else
					{
						//imbalanced Debit and Credit
						bTrans.Delete_Untagged(thisUser);

						if (itemsCount == 0)
						{
                            bTrans.Delete_Untagged(thisUser);
							rnNotify.Show("No valid transaction found.");
						}
						else
						{
                            bTrans.Delete_Untagged(thisUser);
							rnNotify.Show("Debit and Credit sides are not equal.");
						}
					}
				}
			}
		}

		protected IDataReader Get_Additional_Items()
		{
			IDataReader idr = null;

			if (Request.QueryString["gid"] == null)
			{
				iDB.Communicate dbComm = new iDB.Communicate();

				string query = string.Format("select *, \"Amount\" = Case When addtionalTransAmountDependent = 1 Then Cast(additionalTransAmount as varchar) + '%' Else Cast(additionalTransAmount as varchar) End From fin_ModuleItems{0}", string.Format(" where moduleId={0}", moduleId));


                query += string.Format(" and addtionalTransIsOfficial={0}", isOfficial);

                query += " and (moduleIParameterId=0 or moduleIParameterId is null)";
                //if (isOfficial == 1)
                //{
                //    query += " and additionalTransIsOfficial=1";
                //}
                
				idr = dbComm.SelectCMD(query);
			}
			

			
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

		protected void Load_Related_Data(int groupID)
		{
			bool hasTrans = false;

			IDataReader idr = null;
			iDB.Communicate dbComm = new iDB.Communicate();
			string query = string.Format("select *, (userFirstName + ' ' + userLastName) as CreatedBy, (Convert(varchar, IsNull(transGroupPrefixNo, 0)) + transGroupPrefixString + Convert(varchar, IsNull(transGroupForeNumber, 0))) as voucharNo from vw_page_transactions where transLinkedToGroup={0}", groupID);
			idr = dbComm.SelectCMD(query);

			if (idr != null)
			{
				while (idr.Read())
				{
					hasTrans = true;
				}
			}

			idr = dbComm.SelectCMD(query);

			lvGridRelated.DataSource = idr;
			lvGridRelated.DataBind();

			rdPanelRelated.Visible = hasTrans;
		}

        protected void Load_Attachments(int groupID)
        {
            iBiz.FinPro.Transactions.Attachments bAttachments = new iBiz.FinPro.Transactions.Attachments();

            IDataReader idr = bAttachments.Select_For_Vouchar(groupID);

            rptUploadedFiles.DataSource = idr;
            rptUploadedFiles.DataBind();
        }

        protected bool ShowOffIsChecked(string selected)
        {
            bool rt = true;

            if (selected == "0")
            {
                rt = false;
            }

            return rt;
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Items(false, true);
        }

        protected void lbtnDeleteVouchar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int transGroupId = Convert.ToInt32(Request.QueryString["gid"]);
                iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
                bTransG.Delete(transGroupId);
                Response.Redirect("~/FinApp/Transactions.aspx", false);
            }
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
	}
}