using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace FinPro.FinApp
{
    public partial class Departments : System.Web.UI.Page
    {

        int isOfficial = 0;
        int thisUser = 1;

        protected Departments()
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
                Load_Departments();
                ltrModalTitle.Text = "Department Editor";
                

            }
        }


        protected void Load_Departments()
        {
            iBiz.FinPro.Modules.Departments bDept = new iBiz.FinPro.Modules.Departments();

            rptDepatments.DataSource = bDept.Select();
            rptDepatments.DataBind();

        }


        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                iBiz.FinPro.Modules.Departments bDept = new iBiz.FinPro.Modules.Departments();
                iBiz.FinPro.Modules.Departments.objfin_Departments objDept = new iBiz.FinPro.Modules.Departments.objfin_Departments();

                objDept.deptCode = tbDeptCode.Text;
                objDept.deptDescription = tbDeptDescription.Text;
                objDept.deptTitle = tbDeptTitle.Text;
                
                if (!string.IsNullOrEmpty(hfDeptId.Value))
                {
                    objDept.deptId = Convert.ToInt32(hfDeptId.Value);
                    bDept.Update(objDept);
                    rnNotify.Show("Department has been updated.");
                }
                else
                {
                    bDept.Add(objDept);
                    rnNotify.Show("Department has been created.");
                }

                hfDeptId.Value = null;
                tbDeptTitle.Text = "";
                tbDeptDescription.Text = "";
                tbDeptCode.Text = "";

                Load_Departments();
                
            }
        }

        protected void rptDepatments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit_item")
            {
                if (iBiz.FinPro.Rights.edit_department)
                {
                    int deptId = Convert.ToInt32(e.CommandArgument);
                    iBiz.FinPro.Modules.Departments bDept = new iBiz.FinPro.Modules.Departments();
                    iBiz.FinPro.Modules.Departments.objfin_Departments objDept = new iBiz.FinPro.Modules.Departments.objfin_Departments();

                    objDept = bDept.Select(deptId);

                    if (objDept != null)
                    {
                        hfDeptId.Value = objDept.deptId.ToString();
                        tbDeptCode.Text = objDept.deptCode;
                        tbDeptDescription.Text = objDept.deptDescription;
                        tbDeptTitle.Text = objDept.deptTitle;
                        mpeNewAccount.Show();
                    }
                    else
                    {
                        rnNotify.Show("Department doesn't exist.");
                    }
                }
            }
        }
    }
}