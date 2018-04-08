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
	public partial class Accounts : System.Web.UI.Page
	{
        int isOfficial = 0;
        int thisUser = 1;
		iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
		public string rand { get; set; }
		public string rand1 { get; set; }
		public string rand2 { get; set; }
		public string rand3 { get; set; }
		public string rand4 { get; set; }

		protected Accounts()
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
			rand = Guid.NewGuid().ToString();
			if (!IsPostBack)
			{
				
				Load_Categories();
                Load_ParentAccounts();
                ltrModalTitle.Text = "Account Editor";
			}

		}


		protected void Load_ParentAccounts()
		{
			iBiz.FinPro.Accounts bAccounts = new iBiz.FinPro.Accounts();
			List<iBiz.FinPro.Accounts.objAccount> liAcc = new List<iBiz.FinPro.Accounts.objAccount>();
			liAcc = bAccounts.liSelect_By_Type(Convert.ToInt32(ddlEditCategory.SelectedValue));

			ddlParentAccount.Items.Clear();
			ddlParentAccount.Items.Add(new ListItem("--- None ---", "0"));

			foreach (var item in liAcc)
			{
				if (item.accountIsTransactable == 0 || item.accountIsTransactable == 2)
				{
					ddlParentAccount.Items.Add(new ListItem(item.accountTitle, item.accountID.ToString()));
					List<iBiz.FinPro.Accounts.objAccount> liSAcc = new List<iBiz.FinPro.Accounts.objAccount>();
					liSAcc = bAcc.Select_Child_Accounts(item.accountID);


					foreach (var sItem in liSAcc)
					{
						if (sItem.accountIsTransactable == 0 || sItem.accountIsTransactable == 2)
						{
							ddlParentAccount.Items.Add(new ListItem(sItem.accountTitle, sItem.accountID.ToString()));
							List<iBiz.FinPro.Accounts.objAccount> liSSAcc = new List<iBiz.FinPro.Accounts.objAccount>();
							liSSAcc = bAcc.Select_Child_Accounts(sItem.accountID);

							foreach (var ssItem in liSSAcc)
							{
								if (ssItem.accountIsTransactable == 0 || ssItem.accountIsTransactable == 2)
								{
									ddlParentAccount.Items.Add(new ListItem(ssItem.accountTitle, ssItem.accountID.ToString()));
									List<iBiz.FinPro.Accounts.objAccount> liSSSAcc = new List<iBiz.FinPro.Accounts.objAccount>();
									liSSSAcc = bAcc.Select_Child_Accounts(ssItem.accountID);

									foreach (var sssItem in liSSSAcc)
									{
										if (sssItem.accountIsTransactable == 0 || sssItem.accountIsTransactable == 2)
										{
											ddlParentAccount.Items.Add(new ListItem(sssItem.accountTitle, sssItem.accountID.ToString()));
										}
									}

								}
							}

						}
					}
				}

			}
		}

		protected List<TreeNode> Get_AccountsNodes(int parentAccountId)
		{
			List<TreeNode> rt = new List<TreeNode>();
			List<iBiz.FinPro.Accounts.objAccount> liAcc = new List<iBiz.FinPro.Accounts.objAccount>();

			liAcc = bAcc.Select_Child_Accounts(parentAccountId);


			foreach (var item in liAcc)
			{
				TreeNode o = new TreeNode();
				o.Text = item.accountTitle;
				o.Value = item.accountID.ToString();
				o.Collapse();
				List<TreeNode> subAccounts = new List<TreeNode>();
				subAccounts = Get_AccountsNodes(item.accountID);

				foreach (var subItem in subAccounts)
				{
					o.ChildNodes.Add(subItem);
				}
				rt.Add(o);
			}

			return rt;
		}

		protected void Load_Categories()
		{
			iBiz.FinPro.Accounts.Categories bCat = new iBiz.FinPro.Accounts.Categories();
			IDataReader idr = bCat.Select();
			rptAccountCategories.DataSource = idr;
			rptAccountCategories.DataBind();

			idr = bCat.Select();
			ddlEditCategory.DataSource = idr;
			ddlEditCategory.DataBind();
		}

		protected IDataReader Get_Accounts(int categoryID)
		{
			IDataReader idr = null;
			iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
			idr = bAcc.Select_By_Type(categoryID, Convert.ToBoolean(isOfficial));
			idr = bAcc.Select_By_Type(categoryID, 0);
			return idr;
		}

		protected List<iBiz.FinPro.Accounts.objAccount> Get_Child_Accounts(int parentAccountId)
		{
			List<iBiz.FinPro.Accounts.objAccount> liAccounts = new List<iBiz.FinPro.Accounts.objAccount>();
			iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
			liAccounts = bAcc.Select_Child_Accounts(parentAccountId);
			return liAccounts;

		}

		protected void lbtnSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
                iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
                iBiz.FinPro.Accounts.objAccount objAcc = new iBiz.FinPro.Accounts.objAccount();

                if (iBiz.FinPro.Rights.create_account && string.IsNullOrEmpty(hfAccountId.Value))
				{
					objAcc.accountActual = 0;
					objAcc.accountCreatedBy = thisUser;
					objAcc.accountCreatedOn = DateTime.Now;
					objAcc.accountDefaultVersaAccount = 0;
					objAcc.accountDescription = tbEditDescription.Text;
					objAcc.accountIsActive = true;
					objAcc.accountIsBudgetDependent = false;
					objAcc.accountIsTransactable = 0;
					objAcc.accountIsVisible = true;
					objAcc.accountLedger = 0;
					objAcc.accountLevel = 1;
					objAcc.accountTitle = tbEditTitle.Text;
					objAcc.accountType = Convert.ToInt32(ddlEditCategory.SelectedValue);
					objAcc.accountParent = Convert.ToInt32(ddlParentAccount.SelectedValue);
					objAcc.associateID = null;
                    objAcc.accountSystemIndex = 1;
					bAcc.Add(objAcc);


					//Mark Parent Account as Control / Non-Transactable

					if (Convert.ToInt32(ddlParentAccount.SelectedValue) != 0)
					{
						bAcc.Make_Account_Transactable(Convert.ToInt32(ddlParentAccount.SelectedValue), false);
					}


					rnNotify.Show("Account has been created.");
					Load_Categories();
				}
                else if (iBiz.FinPro.Rights.edit_account && !string.IsNullOrEmpty(hfAccountId.Value))
                {
                    objAcc = bAcc.Select(Convert.ToInt32(hfAccountId.Value)); 
                    objAcc.accountActual = 0;
                    objAcc.accountCreatedBy = thisUser;
                    objAcc.accountCreatedOn = DateTime.Now;
                    objAcc.accountDefaultVersaAccount = 0;
					objAcc.accountDescription = tbEditDescription.Text;
                    objAcc.accountIsActive = true;
                    objAcc.accountIsVisible = true;
                    objAcc.accountLedger = 0;
                    objAcc.accountLevel = 1;
                    objAcc.accountTitle = tbEditTitle.Text;
					objAcc.accountSystemIndex = 1;
                    bAcc.Update(objAcc);
                    rnNotify.Show("Account has been created.");
                    Load_Categories();
                }
                else
                {
                    rnNotify.Show("You are not allowed to perform this action.");
                }
			}
		}

		protected void rptAccountCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "edit_item")
			{
				if (iBiz.FinPro.Rights.edit_account)
				{
                    int accountId = Convert.ToInt32(e.CommandArgument);
                    iBiz.FinPro.Accounts.objAccount objAcc = new iBiz.FinPro.Accounts.objAccount();
                    iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();


                    objAcc = bAcc.Select(accountId);

                    if (objAcc != null)
                    {
                        if (objAcc.accountType.HasValue)
                        {
                            hfAccountId.Value = objAcc.accountID.ToString();
                            ddlEditCategory.SelectedValue = objAcc.accountType.Value.ToString();
                            tbEditTitle.Text = objAcc.accountTitle;
                            tbEditDescription.Text = objAcc.accountDescription;
                            mpeNewAccount.Show();
                        }
                    }
                    else
                    {
                        hfAccountId.Value = "";
                        rnNotify.Show("Account doesn't exist.");
                    }
				}
				else
				{
					rnNotify.Show("You are not allowed to Edit an Account.");
				}
			}
			else if (e.CommandName == "addchildaccount")
			{
				int accountId = Convert.ToInt32(e.CommandArgument);
				iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
				iBiz.FinPro.Accounts.objAccount objAcc = new iBiz.FinPro.Accounts.objAccount();

				objAcc = bAcc.Select(accountId);

				if (objAcc != null)
				{
					if (objAcc.accountIsTransactable != 1)
					{	
						ddlEditCategory.SelectedValue = objAcc.accountType.Value.ToString();
						Load_ParentAccounts();
						ddlParentAccount.SelectedValue = accountId.ToString();
						mpeNewAccount.Show();
					}
					else
					{
						rnNotify.Show("Child account can't be added under transactable account.");
					}
				}
			}
            else
            {
                rnNotify.Show("You don't have Rights to edit this page.");
            }
		}

        protected string account_sticker(string accountSystemIndex)
        {
            string rt = "";

            if (accountSystemIndex == "0")
            {
                rt = "sticker_uo";
            }
            else if (accountSystemIndex == "1")
            {
                rt = "sticker_both";
            }
            else if (accountSystemIndex == "2")
            {
                rt = "sticker_o";
            }

            return rt;
        }

        protected string get_account_no(int accountId, string accountPrefix, string accountNo)
        {
            string rt = "N/A";

            if (string.IsNullOrEmpty(accountNo))
            {
                iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
                rt = bAcc.Update_Account_Number(accountId);
            }
            else
            {
                rt = accountPrefix + accountNo;
            }
            
            return rt;
        }

		protected void ddlEditCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			Load_ParentAccounts();
		}

		protected void rptAccountCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			rand = Guid.NewGuid().ToString();
			rand1 = Guid.NewGuid().ToString();
			rand2 = Guid.NewGuid().ToString();
			rand3 = Guid.NewGuid().ToString();
			rand4 = Guid.NewGuid().ToString();
		}

		protected bool CanHaveChild(int accountId)
		{
			iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
			bool rt = bAcc.IsTransactable(accountId);

			if (rt)
			{
				rt = false;
			}
			else
			{
				rt = true;

			}

			return rt;
		}
	}
}