using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace iBiz
{
    public static class Settings
    {
   
        public static int TaxParentAccountId = Convert.ToInt32(ConfigurationSettings.AppSettings["TaxParentAccountId"]);
        public static string GetCurrencyCode = ConfigurationSettings.AppSettings["CurrencyCode"];
	}
}
