using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBiz.FinPro.Modules
{
	public class Info
	{
		public string singular_Title(int moduleId)
		{
            string rt = "Transaction";

			if (moduleId == 1)
			{
				rt = "Journal Voucher";
			}
			else if (moduleId == 2)
			{
				rt = "Purchase Voucher";
			}
			else if (moduleId == 3)
			{
				rt = "Bank Payment";
			}
			else if (moduleId == 4)
			{
				rt = "Sale Voucher";
			}
            else if (moduleId == 5)
            {
                rt = "Cash Payment";
            }
            else if (moduleId == 6)
            {
                rt = "Petty Cash Voucher";
            }
            else if (moduleId == 7)
            {
                rt = "Auto Voucher";
            }
			else
			{
				rt = "Transaction";
			}

			return rt;
		}

		public string prular_Title(int moduleId)
		{
            string rt = "Transaction";

			if (moduleId == 1)
			{
                rt = "Journal Voucher";
			}
			else if (moduleId == 2)
			{
				rt = "Purchase Voucher";
			}
			else if (moduleId == 3)
			{
				rt = "Bank Payment";
			}
			else if (moduleId == 4)
			{
				rt = "Sale Voucher";
			}
            else if (moduleId == 5)
            {
                rt = "Cash Payment";
            }
            else if (moduleId == 6)
            {
                rt = "Petty Cash Voucher";
            }
            else if (moduleId == 7)
            {
                rt = "Auto Voucher";
            }
			else
			{
				rt = "Transaction";
			}

			rt += "s";

			return rt;
		}

		public string short_Title(int moduleId)
		{
			string rt = "";

			if (moduleId == 1)
			{
				rt = "JV";
			}
			else if (moduleId == 2)
			{
				rt = "PJV";
			}
			else if (moduleId == 3)
			{
				rt = "BPV";
			}
			else if (moduleId == 4)
			{
				rt = "SJV";
			}
            else if (moduleId == 5)
            {
                rt = "SPV";
            }
            else if (moduleId == 6)
            {
                rt = "PCV";
            }
            else if (moduleId == 7)
            {
                rt = "AUT";
            }
			else
			{
				rt = "TRA";
			}

			return rt;
		}
	}
}
