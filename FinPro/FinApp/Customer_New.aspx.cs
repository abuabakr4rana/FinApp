using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro.FinApp
{
    public partial class Customer_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Populate_Form();
            }
        }

        protected void Populate_Form()
        {
            int CustomerId = Convert.ToInt32(Request.QueryString["id"]);

            iBiz.FinPro.Generic.Customers bCustomers = new iBiz.FinPro.Generic.Customers();
            iBiz.FinPro.Generic.Customers.objCustomer objCustomer = new iBiz.FinPro.Generic.Customers.objCustomer();


            objCustomer = bCustomers.Select(CustomerId);

            if (objCustomer != null)
            {
                tbCustomerTitle.Text = objCustomer.customerTitle;
                tbCustomerURL.Text = objCustomer.customerURL;
                tbCustomerCode.Text = objCustomer.customerCode;
                tbCustomerDescription.Text = objCustomer.customerDescription;
                tbCustomerFirstName.Text = objCustomer.customerFirstName;
                tbCustomerLastName.Text = objCustomer.customerLastName;
                tbCustomerAddressLine1.Text = objCustomer.customerAddressLine1;
                tbCustomerAddressLine2.Text = objCustomer.customerAddressLine2;
                tbCustomerState.Text = objCustomer.customerState;
                tbCustomerZip.Text = objCustomer.customerZip;
                tbCustomerCountry.Text = objCustomer.customerCountry;
                tbCustomerEmail.Text = objCustomer.customerEmail;
                tbCustomerAltEmail.Text = objCustomer.customerEmailAlt;
                tbCustomerPhone.Text = objCustomer.customerPhone;
                tbCustomerAltPhone.Text = objCustomer.customerPhoneAlt;
                tbCustomerMinQty.Text = objCustomer.customerMinQty.ToString();
                tbCustomerMaxQty.Text = objCustomer.customerMaxQty.ToString();
                rblStatus.SelectedIndex = 0;
                if (objCustomer.customerIsActive)
                {
                    rblStatus.SelectedIndex = 1;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                iBiz.FinPro.Generic.Customers bCustomers = new iBiz.FinPro.Generic.Customers();
                iBiz.FinPro.Generic.Customers.objCustomer objCustomer = new iBiz.FinPro.Generic.Customers.objCustomer();

                objCustomer = bCustomers.Select(Convert.ToInt32(Request.QueryString["id"]));
                if (objCustomer != null)
                {
                    objCustomer.customerTitle = tbCustomerTitle.Text.Trim();
                    objCustomer.customerURL = tbCustomerURL.Text.Trim();
                    objCustomer.customerCode = tbCustomerCode.Text.Trim();
                    objCustomer.customerDescription = tbCustomerDescription.Text.Trim();
                    objCustomer.customerFirstName = tbCustomerFirstName.Text.Trim();
                    objCustomer.customerLastName = tbCustomerLastName.Text.Trim();
                    objCustomer.customerAddressLine1 = tbCustomerAddressLine1.Text.Trim();
                    objCustomer.customerAddressLine2 = tbCustomerAddressLine2.Text.Trim();
                    objCustomer.customerState = tbCustomerState.Text.Trim();
                    objCustomer.customerZip = tbCustomerZip.Text.Trim();
                    objCustomer.customerCountry = tbCustomerCountry.Text.Trim();
                    objCustomer.customerEmail = tbCustomerEmail.Text.Trim();
                    objCustomer.customerEmailAlt = tbCustomerAltEmail.Text.Trim();
                    objCustomer.customerPhone = tbCustomerPhone.Text.Trim();
                    objCustomer.customerPhoneAlt = tbCustomerAltPhone.Text.Trim();

                    objCustomer.customerMinQty = 0;
                    if (tbCustomerMinQty.Text.Trim().Length > 0)
                    {
                        objCustomer.customerMinQty = Convert.ToInt32(tbCustomerMinQty.Text.Trim());
                    }

                    objCustomer.customerMaxQty = 0;
                    if (tbCustomerMaxQty.Text.Trim().Length > 0)
                    {
                        objCustomer.customerMaxQty = Convert.ToInt32(tbCustomerMaxQty.Text.Trim());
                    }

                    objCustomer.customerIsActive = true;

                    if (rblStatus.SelectedIndex == 0)
                    {
                        objCustomer.customerIsActive = false;
                    }


                    bCustomers.Update(objCustomer);
                    rnNotify.Show("Customer has been updated.");
                }
                else
                {
                    objCustomer = new iBiz.FinPro.Generic.Customers.objCustomer();
                    objCustomer.customerTitle = tbCustomerTitle.Text.Trim();
                    objCustomer.customerURL = tbCustomerURL.Text.Trim();
                    objCustomer.customerCode = tbCustomerCode.Text.Trim();
                    objCustomer.customerDescription = tbCustomerDescription.Text.Trim();
                    objCustomer.customerFirstName = tbCustomerFirstName.Text.Trim();
                    objCustomer.customerLastName = tbCustomerLastName.Text.Trim();
                    objCustomer.customerAddressLine1 = tbCustomerAddressLine1.Text.Trim();
                    objCustomer.customerAddressLine2 = tbCustomerAddressLine2.Text.Trim();
                    objCustomer.customerState = tbCustomerState.Text.Trim();
                    objCustomer.customerZip = tbCustomerZip.Text.Trim();
                    objCustomer.customerCountry = tbCustomerCountry.Text.Trim();
                    objCustomer.customerEmail = tbCustomerEmail.Text.Trim();
                    objCustomer.customerEmailAlt = tbCustomerAltEmail.Text.Trim();
                    objCustomer.customerPhone = tbCustomerPhone.Text.Trim();
                    objCustomer.customerPhoneAlt = tbCustomerAltPhone.Text.Trim();

                    objCustomer.customerMinQty = 0;
                    if (tbCustomerMinQty.Text.Trim().Length > 0)
                    {
                        objCustomer.customerMinQty = Convert.ToInt32(tbCustomerMinQty.Text.Trim());
                    }

                    objCustomer.customerMaxQty = 0;
                    if (tbCustomerMaxQty.Text.Trim().Length > 0)
                    {
                        objCustomer.customerMaxQty = Convert.ToInt32(tbCustomerMaxQty.Text.Trim());
                    }

                    objCustomer.customerIsActive = true;

                    if (rblStatus.SelectedIndex == 0)
                    {
                        objCustomer.customerIsActive = false;
                    }

                    objCustomer.customerCreatedBy = 1;
                    objCustomer.customerCreatedIP = Request.UserHostAddress;
                    objCustomer.customerCreatedOn = DateTime.Now;

                    bCustomers.Add(objCustomer);
                    rnNotify.Show("Customer has been added.");

                }
            }
        }
    }
}