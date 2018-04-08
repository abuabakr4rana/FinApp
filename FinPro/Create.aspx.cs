using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FinPro
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            //    Membership.CreateUser("admin", "humabilal786", "me@bilalmuhammad.com");
            //    iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
            //    iBiz.FinPro.UserProfile.objUserProfile oProfile = new iBiz.FinPro.UserProfile.objUserProfile();

            //    oProfile.userEmail = "me@bilalmuhammad.com";
            //    oProfile.userFirstName = "Bilal";
            //    oProfile.userIsActive = true;
            //    oProfile.userIsOfficial = false;
            //    oProfile.userLastName = "Muhammad";

            //    bProfile.Add(oProfile);

                
                Membership.CreateUser("admin", "admin123", "jamshed@bilalmuhammad.com");
                iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
                iBiz.FinPro.UserProfile.objUserProfile oProfile = new iBiz.FinPro.UserProfile.objUserProfile();

                oProfile.userEmail = "jamshed@bilalmuhammad.com";
                oProfile.userFirstName = "Bilal";
                oProfile.userIsActive = true;
                oProfile.userIsOfficial = true;
                oProfile.userLastName = "Muhammad";

                bProfile.Add(oProfile);


                //Membership.CreateUser("naeem", "naeem786", "naeemakhtar@traditions.pk");
                ////iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
                //oProfile = new iBiz.FinPro.UserProfile.objUserProfile();
                //oProfile.userEmail = "naeemakhtar@traditions.pk";
                //oProfile.userFirstName = "Naeem";
                //oProfile.userIsActive = true;
                //oProfile.userIsOfficial = false;
                //oProfile.userLastName = "Akhtar";
                //bProfile.Add(oProfile);


                ////Rafphi Qadeer

                //Membership.CreateUser("rafphi", "qadeer786", "rafphiqadeer@traditions.pk");
                
                //oProfile = new iBiz.FinPro.UserProfile.objUserProfile();
                //oProfile.userEmail = "rafphiqadeer@traditions.pk";
                //oProfile.userFirstName = "Rafphi";
                //oProfile.userIsActive = true;
                //oProfile.userIsOfficial = false;
                //oProfile.userLastName = "Qadeer";
                //bProfile.Add(oProfile);


                //Membership.CreateUser("zeeshan", "zeeshantrd786", "zeeshan@traditions.pk");

                //oProfile = new iBiz.FinPro.UserProfile.objUserProfile();
                //oProfile.userEmail = "zeeshan@traditions.pk";
                //oProfile.userFirstName = "Zeeshan";
                //oProfile.userIsActive = true;
                //oProfile.userIsOfficial = false;
                //oProfile.userLastName = "Aftab";
                //bProfile.Add(oProfile);


                //Membership.CreateUser("admin", "humabilal786", "me@bilalmuhammad.com");
                //iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
                //iBiz.FinPro.UserProfile.objUserProfile oProfile = new iBiz.FinPro.UserProfile.objUserProfile();

                //oProfile.userEmail = "me@bilalmuhammad.com";
                //oProfile.userFirstName = "Bilal";
                //oProfile.userIsActive = true;
                //oProfile.userIsOfficial = false;
                //oProfile.userLastName = "Muhammad";

                //bProfile.Add(oProfile);


                //Membership.CreateUser("admin", "humabilal786", "me@bilalmuhammad.com");
                //iBiz.FinPro.UserProfile bProfile = new iBiz.FinPro.UserProfile();
                //iBiz.FinPro.UserProfile.objUserProfile oProfile = new iBiz.FinPro.UserProfile.objUserProfile();

                //oProfile.userEmail = "me@bilalmuhammad.com";
                //oProfile.userFirstName = "Bilal";
                //oProfile.userIsActive = true;
                //oProfile.userIsOfficial = false;
                //oProfile.userLastName = "Muhammad";

                //bProfile.Add(oProfile);




            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}