using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace FinPro.FinApp
{
    public partial class Printable_Cheque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Load_Cheque(Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                Response.Redirect("~/", false);
            }
        }

        protected void Load_Cheque(int chequeId)
        {
            iBiz.FinPro.ChequePrinting bChqPrinting = new iBiz.FinPro.ChequePrinting();
            iBiz.FinPro.ChequePrinting.objChequePrinting objChqPrinting = new iBiz.FinPro.ChequePrinting.objChequePrinting();

            objChqPrinting = bChqPrinting.Select(chequeId);

            if (objChqPrinting != null)
            {
                string templateContent = "";

                using (StreamReader sr = new StreamReader(Server.MapPath(string.Format("~/ResourceBox/Cheques/{0}.txt", Template_Name(objChqPrinting.bankId)))))
                {
                    templateContent = sr.ReadToEnd();
                }
                templateContent = templateContent.Replace("[date]", objChqPrinting.chequeDate.Value.ToString("ddMMyyyy"));
                templateContent = templateContent.Replace("[title]", objChqPrinting.chequeTitle);
                templateContent = templateContent.Replace("[amount]", Comma_Amount(Convert.ToDecimal(objChqPrinting.chequeAmountFig.ToString("0"))));
				templateContent = templateContent.Replace("[amount_words]", objChqPrinting.chequeAmount);

                Response.Write(templateContent);
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

        protected string Template_Name(int bankId)
        {
            string rt = "";

            if (bankId == 1)
            {
                rt = "BankAlfalah";
            }
            else if (bankId == 2)
            {
                rt = "UnitedBank";
            }

            return rt;
        }
    }
}