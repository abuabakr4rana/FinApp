using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace iBiz.FinPro
{
    public static class Statics
    {
        public static string Dashboard_LineChart_Account = ConfigurationSettings.AppSettings["DashLineAccounts"].ToString();

		public static string Get_Description_Trimmed(string input)
		{
			string rt = input;

			if (rt.Length > 50)
			{
				rt = rt.Remove(49);
			}

			return rt;
		}

	}
}
