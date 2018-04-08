using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro.FinApp
{
    public partial class Cheque_Printing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateCheque_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                iBiz.FinPro.ChequePrinting bChqPrinting = new iBiz.FinPro.ChequePrinting();
                iBiz.FinPro.ChequePrinting.objChequePrinting objChqPrinting = new iBiz.FinPro.ChequePrinting.objChequePrinting();


                objChqPrinting.bankId = Convert.ToInt32(ddlBankAccount.SelectedValue);
                objChqPrinting.chequeAmountFig = Convert.ToDecimal(tbChequeAmount.Text);

                if (tbChequeAmountInWords.Text.Trim().Length == 0)
                {
                    objChqPrinting.chequeAmount = NumberToWords(Convert.ToInt32(objChqPrinting.chequeAmountFig));
                }
                else
                {
                    objChqPrinting.chequeAmount = tbChequeAmountInWords.Text;
                }
                
                objChqPrinting.chequeCreatedBy = 1;
                objChqPrinting.chequeCreatedOn = DateTime.Now;
                // chequeDate.Text = 12/02/2015
                objChqPrinting.chequeDate = Convert.ToDateTime(chequeDate.Text);
                objChqPrinting.chequeNo = tbChequeNo.Text;
                objChqPrinting.chequeReceivedBy = tbChequeReceiverName.Text;
                objChqPrinting.chequeReceiverIDCard = tbChequeReceiverCNIC.Text;
                objChqPrinting.chequeReceiverPhone = tbChequeReceiverPhone.Text;
                objChqPrinting.chequeStatus = 1;
                objChqPrinting.chequeTitle = tbChequeTitle.Text;

                int chequeId = 0;
                chequeId = bChqPrinting.Add(objChqPrinting);

                if (chequeId == 0)
                {
                    rnNotify.Show("Unable to Create Cheque.");
                }
                else
                {
                    Response.Redirect("~/FinApp/Printable_Cheque.aspx?id=" + chequeId.ToString());
                }
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}