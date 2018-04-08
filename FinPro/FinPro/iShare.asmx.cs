using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FinPro
{
    /// <summary>
    /// Summary description for iShare
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class iShare : System.Web.Services.WebService
    {
        
        [WebMethod]
        public int? Create_Account(int accountType, string accountTitle, int accountDescription, bool isOfficial)
        {
            return 0;
        }

        [WebMethod]
        public int Create_TransGroup()
        { return 0; }

        [WebMethod]
        public bool Delete_TransGroup()
        {
            return true;
        }


    }
}
