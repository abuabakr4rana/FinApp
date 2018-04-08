using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FinPro.FinApp
{
    public partial class Settings_User_Editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_User()
        {

            try
            {
                Membership.CreateUser(tbUsername.Text, tbPassword.Text, tbEmail.Text);
                iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
                iBiz.FinPro.UserProfile.objUserProfile oProfile = new iBiz.FinPro.UserProfile.objUserProfile();

                oProfile.userEmail = tbEmail.Text;
                oProfile.userFirstName = tbFirstName.Text;
                oProfile.userIsActive = true;
                oProfile.userIsOfficial = false;
                oProfile.userLastName = tbLastName.Text;

                bProfile.Add(oProfile);

                Response.Write("User has been Created.");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            


        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Create_User();
        }
    }
}