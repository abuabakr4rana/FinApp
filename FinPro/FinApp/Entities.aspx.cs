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
    public partial class Entities : System.Web.UI.Page
    {

        int isOfficial = 0;
        int thisUser = 1;
        iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();

        protected Entities()
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
                
                ltrModalTitle.Text = "Account Editor";
                if (isOfficial == 1)
                {
                    rblUsability.SelectedIndex = 1;
                    tr_usability.Visible = false;
                }

            }

        }


        protected void Load_Entities()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            IDataReader idr = dbComm.SelectCMD("select * from vw_Entities");
            lvGrid.DataSource = idr;
            lvGrid.DataBind();
            
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

        protected IDataReader Get_Accounts(int categoryID)
        {
            IDataReader idr = null;
            iBiz.FinPro.Accounts bAcc = new iBiz.FinPro.Accounts();
            idr = bAcc.Select_By_Type(categoryID, Convert.ToBoolean(isOfficial));
            return idr;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
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
            
        }
    }
}