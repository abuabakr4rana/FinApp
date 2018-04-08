using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //iBiz.FinPro.Accounts db = new iBiz.FinPro.Accounts();
            //db.Transacts(1).GetItems();

            Response.Redirect("~/Login.aspx", false);
		}
	}
}