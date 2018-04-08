using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro.FinApp
{
    public partial class Vendor_Edit : System.Web.UI.Page
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
            int vendorId = Convert.ToInt32(Request.QueryString["id"]);
            iBiz.FinPro.Generic.Vendors bVendors = new iBiz.FinPro.Generic.Vendors();
            iBiz.FinPro.Generic.Vendors.objVendor objVendor = new iBiz.FinPro.Generic.Vendors.objVendor();

            objVendor = bVendors.Select(vendorId);

            if (objVendor != null)
            {
                tbVendorTitle.Text = objVendor.vendorTitle;
                tbVendorURL.Text = objVendor.vendorURL;
                tbVendorCode.Text = objVendor.vendorCode;
                tbVendorDescription.Text = objVendor.vendorDescription;
                tbVendorFirstName.Text = objVendor.vendorFirstName;
                tbVendorLastName.Text = objVendor.vendorLastName;
                tbVendorAddressLine1.Text = objVendor.vendorAddressLine1;
                tbVendorAddressLine2.Text = objVendor.vendorAddressLine2;
                tbVendorState.Text = objVendor.vendorState;
                tbVendorZip.Text = objVendor.vendorZip;
                tbVendorCountry.Text = objVendor.vendorCountry;
                tbVendorEmail.Text = objVendor.vendorEmail;
                tbVendorAltEmail.Text = objVendor.vendorEmailAlt;
                tbVendorPhone.Text = objVendor.vendorPhone;
                tbVendorAltPhone.Text = objVendor.vendorPhoneAlt;
                tbVendorMinQty.Text = objVendor.vendorMinQty.ToString();
                tbVendorMaxQty.Text = objVendor.vendorMaxQty.ToString();
                rblStatus.SelectedIndex = 0;
                if (objVendor.vendorIsActive)
                {
                    rblStatus.SelectedIndex = 1;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                iBiz.FinPro.Generic.Vendors bVendors = new iBiz.FinPro.Generic.Vendors();
                iBiz.FinPro.Generic.Vendors.objVendor objVendor = new iBiz.FinPro.Generic.Vendors.objVendor();
                
                objVendor = bVendors.Select(Convert.ToInt32(Request.QueryString["id"]));
                if (objVendor != null)
                {
                    objVendor.vendorTitle = tbVendorTitle.Text.Trim();
                    objVendor.vendorURL = tbVendorURL.Text.Trim();
                    objVendor.vendorCode = tbVendorCode.Text.Trim();
                    objVendor.vendorDescription = tbVendorDescription.Text.Trim();
                    objVendor.vendorFirstName = tbVendorFirstName.Text.Trim();
                    objVendor.vendorLastName = tbVendorLastName.Text.Trim();
                    objVendor.vendorAddressLine1 = tbVendorAddressLine1.Text.Trim();
                    objVendor.vendorAddressLine2 = tbVendorAddressLine2.Text.Trim();
                    objVendor.vendorState = tbVendorState.Text.Trim();
                    objVendor.vendorZip = tbVendorZip.Text.Trim();
                    objVendor.vendorCountry = tbVendorCountry.Text.Trim();
                    objVendor.vendorEmail = tbVendorEmail.Text.Trim();
                    objVendor.vendorEmailAlt = tbVendorAltEmail.Text.Trim();
                    objVendor.vendorPhone = tbVendorPhone.Text.Trim();
                    objVendor.vendorPhoneAlt = tbVendorAltPhone.Text.Trim();

                    objVendor.vendorMinQty = 0;
                    if (tbVendorMinQty.Text.Trim().Length > 0)
                    {
                        objVendor.vendorMinQty = Convert.ToInt32(tbVendorMinQty.Text.Trim());
                    }

                    objVendor.vendorMaxQty = 0;
                    if (tbVendorMaxQty.Text.Trim().Length > 0)
                    {
                        objVendor.vendorMaxQty = Convert.ToInt32(tbVendorMaxQty.Text.Trim());
                    }

                    objVendor.vendorIsActive = true;

                    if (rblStatus.SelectedIndex == 0)
                    {
                        objVendor.vendorIsActive = false;
                    }


                    bVendors.Update(objVendor);
                    rnNotify.Show("Vendor has been updated.");
                }
                else
                {
                    objVendor = new iBiz.FinPro.Generic.Vendors.objVendor();
                    objVendor.vendorTitle = tbVendorTitle.Text.Trim();
                    objVendor.vendorURL = tbVendorURL.Text.Trim();
                    objVendor.vendorCode = tbVendorCode.Text.Trim();
                    objVendor.vendorDescription = tbVendorDescription.Text.Trim();
                    objVendor.vendorFirstName = tbVendorFirstName.Text.Trim();
                    objVendor.vendorLastName = tbVendorLastName.Text.Trim();
                    objVendor.vendorAddressLine1 = tbVendorAddressLine1.Text.Trim();
                    objVendor.vendorAddressLine2 = tbVendorAddressLine2.Text.Trim();
                    objVendor.vendorState = tbVendorState.Text.Trim();
                    objVendor.vendorZip = tbVendorZip.Text.Trim();
                    objVendor.vendorCountry = tbVendorCountry.Text.Trim();
                    objVendor.vendorEmail = tbVendorEmail.Text.Trim();
                    objVendor.vendorEmailAlt = tbVendorAltEmail.Text.Trim();
                    objVendor.vendorPhone = tbVendorPhone.Text.Trim();
                    objVendor.vendorPhoneAlt = tbVendorAltPhone.Text.Trim();

                    objVendor.vendorMinQty = 0;
                    if (tbVendorMinQty.Text.Trim().Length > 0)
                    {
                        objVendor.vendorMinQty = Convert.ToInt32(tbVendorMinQty.Text.Trim());
                    }

                    objVendor.vendorMaxQty = 0;
                    if (tbVendorMaxQty.Text.Trim().Length > 0)
                    {
                        objVendor.vendorMaxQty = Convert.ToInt32(tbVendorMaxQty.Text.Trim());
                    }

                    objVendor.vendorIsActive = true;

                    if (rblStatus.SelectedIndex == 0)
                    {
                        objVendor.vendorIsActive = false;
                    }

                    objVendor.vendorCreatedBy = 1;
                    objVendor.vendorCreatedIP = Request.UserHostAddress;
                    objVendor.vendorCreatedOn = DateTime.Now;

                    bVendors.Add(objVendor);
                    rnNotify.Show("Vendor has been added.");

                }
            }
        }
    }
}