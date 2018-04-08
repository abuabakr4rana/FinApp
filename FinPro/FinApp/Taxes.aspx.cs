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
    public partial class Taxes : System.Web.UI.Page
    {
        int thisUser = 1;
        protected Taxes()
        {
            string email = Membership.GetUser().Email;
            iBiz.FinPro.UserProfile bUser = new iBiz.FinPro.UserProfile();
            iBiz.FinPro.UserProfile.objUserProfile objUser = new iBiz.FinPro.UserProfile.objUserProfile();

            objUser = bUser.Select(email);

            if (objUser != null)
            {
                thisUser = objUser.userID;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Data();
            }
        }

        private void Load_Data()
        {
            IDataReader idr = new iDB.Communicate().SelectCMD("select * from fin_Taxes");
            lvGrid.DataSource = idr;
            lvGrid.DataBind();
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                iBiz.FinPro.Generic.Taxes bTax = new iBiz.FinPro.Generic.Taxes();
                iBiz.FinPro.Generic.Taxes.objfin_Taxes objTax = new iBiz.FinPro.Generic.Taxes.objfin_Taxes();

                bool isPercent = true;

                if (ddlTaxType.SelectedIndex == 0)
                {
                    isPercent = false;
                }

                if (string.IsNullOrEmpty(hfTaxId.Value))
                {
                    objTax.taxCreatedBy = thisUser;
                    objTax.taxCreatedIP = Request.UserHostAddress;
                    objTax.taxCreatedOn = DateTime.Now;
                    objTax.taxTitle = tbTaxTitle.Text;
                    objTax.taxTransNarration = tbTaxDescription.Text;
                    objTax.taxTypeIsPercent = isPercent;
                    objTax.taxValue = Convert.ToDecimal(tbTaxValue.Text);
                    objTax.taxAccountId = 0;
                    bTax.Add(objTax);

                    rnNotify.Show("Tax has been created.");
                }
                else
                {
                    objTax = bTax.Select(Convert.ToInt32(hfTaxId.Value));
                    objTax.taxTitle = tbTaxTitle.Text;
                    objTax.taxTransNarration = tbTaxDescription.Text;
                    objTax.taxTypeIsPercent = isPercent;
                    objTax.taxValue = Convert.ToDecimal(tbTaxValue.Text);
                    bTax.Update(objTax);
                    rnNotify.Show("Tax has been updated.");
                }

                hfTaxId.Value = "";
                mpeNewAccount.Hide();
                Load_Data();
            }
        }

        protected String TaxUnit(bool taxType)
        {
            if (taxType)
            {
                return "%";
            }
            else
            {
                return iBiz.Settings.GetCurrencyCode;
            }
        }

        protected void lvGrid_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                if (e.CommandName == "change")
                {
                    int taxId = Convert.ToInt32(e.CommandArgument);
                    iBiz.FinPro.Generic.Taxes bTax = new iBiz.FinPro.Generic.Taxes();
                    iBiz.FinPro.Generic.Taxes.objfin_Taxes objTax = new iBiz.FinPro.Generic.Taxes.objfin_Taxes();

                    objTax = bTax.Select(taxId);

                    if (objTax != null)
                    {
                        hfTaxId.Value = objTax.taxId.ToString();
                        tbTaxDescription.Text = objTax.taxTransNarration;
                        tbTaxTitle.Text = objTax.taxTitle;
                        tbTaxValue.Text = objTax.taxValue.ToString("0.00");
                        ddlTaxType.SelectedIndex = 1;
                        if (!objTax.taxTypeIsPercent)
                        {
                            ddlTaxType.SelectedIndex = 0;
                        }

                        mpeNewAccount.Show();
                    }
                }
            }
        }
    }
}