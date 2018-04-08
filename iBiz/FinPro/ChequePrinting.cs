using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace iBiz.FinPro
{
    public class ChequePrinting
    {
        iDB.FinPro.ChequePrinting db = new iDB.FinPro.ChequePrinting();
        public int Add(objChequePrinting i)
        {
            return db.Add(i.chequeId, i.bankId, i.chequeTitle, i.chequeAmount, i.chequeAmountFig, i.chequeDate, i.chequeNo, i.chequeReceivedBy, i.chequeReceiverPhone, i.chequeReceiverIDCard, i.chequeCreatedBy, i.chequeCreatedOn, i.chequeStatus);
        }
        public void Update(objChequePrinting i)
        {
            db.Update(i.chequeId, i.bankId, i.chequeTitle, i.chequeAmount, i.chequeAmountFig, i.chequeDate, i.chequeNo, i.chequeReceivedBy, i.chequeReceiverPhone, i.chequeReceiverIDCard, i.chequeCreatedBy, i.chequeCreatedOn, i.chequeStatus);
        }
        public void Delete(int chequeId)
        {
            db.Delete(chequeId);
        }

        public IDataReader Select()
        {
            return db.Select();
        }
        public objChequePrinting Select(int chequeId)
        {
            IDataReader idr = db.Select(chequeId);
            return Select_Obj(idr);
        }

		public static string NumberToCurrencyText(decimal number, MidpointRounding midpointRounding)
		{
			// Round the value just in case the decimal value is longer than two digits
			number = decimal.Round(number, 2, midpointRounding);

			string wordNumber = string.Empty;

			// Divide the number into the whole and fractional part strings
			string[] arrNumber = number.ToString().Split('.');

			// Get the whole number text
			long wholePart = long.Parse(arrNumber[0]);
			string strWholePart = NumberToText(wholePart);

			// For amounts of zero dollars show 'No Dollars...' instead of 'Zero Dollars...'
			wordNumber = (wholePart == 0 ? "No" : strWholePart) + (wholePart == 1 ? " Rupee and " : " Rupees and ");

			// If the array has more than one element then there is a fractional part otherwise there isn't
			// just add 'No Cents' to the end
			if (arrNumber.Length > 1)
			{
				// If the length of the fractional element is only 1, add a 0 so that the text returned isn't,
				// 'One', 'Two', etc but 'Ten', 'Twenty', etc.
				long fractionPart = long.Parse((arrNumber[1].Length == 1 ? arrNumber[1] + "0" : arrNumber[1]));
				string strFarctionPart = NumberToText(fractionPart);

				wordNumber += (fractionPart == 0 ? " No" : strFarctionPart) + (fractionPart == 1 ? " Cent" : " Cents");
			}
			else
				wordNumber += "No Cents";

			return wordNumber;
		}


		public static string NumberToText(long number)
		{
			StringBuilder wordNumber = new StringBuilder();

			string[] powers = new string[] { "Thousand ", "Million ", "Billion " };
			string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
			string[] ones = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
                                       "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

			if (number == 0) { return "Zero"; }
			if (number < 0)
			{
				wordNumber.Append("Negative ");
				number = -number;
			}

			long[] groupedNumber = new long[] { 0, 0, 0, 0 };
			int groupIndex = 0;

			while (number > 0)
			{
				groupedNumber[groupIndex++] = number % 1000;
				number /= 1000;
			}

			for (int i = 3; i >= 0; i--)
			{
				long group = groupedNumber[i];

				if (group >= 100)
				{
					wordNumber.Append(ones[group / 100 - 1] + " Hundred ");
					group %= 100;

					if (group == 0 && i > 0)
						wordNumber.Append(powers[i - 1]);
				}

				if (group >= 20)
				{
					if ((group % 10) != 0)
						wordNumber.Append(tens[group / 10 - 2] + " " + ones[group % 10 - 1] + " ");
					else
						wordNumber.Append(tens[group / 10 - 2] + " ");
				}
				else if (group > 0)
					wordNumber.Append(ones[group - 1] + " ");

				if (group != 0 && i > 0)
					wordNumber.Append(powers[i - 1]);
			}

			return wordNumber.ToString().Trim();
		}

        private objChequePrinting Select_Obj(IDataReader idr)
        {
            objChequePrinting o = new objChequePrinting();
            bool rtNull = true;
            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["chequeId"] != DBNull.Value)
                    {
                        o.chequeId = Convert.ToInt32(idr["chequeId"]);
                    }
                    if (idr["bankId"] != DBNull.Value)
                    {
                        o.bankId = Convert.ToInt32(idr["bankId"]);
                    }
                    if (idr["chequeTitle"] != DBNull.Value)
                    {
                        o.chequeTitle = Convert.ToString(idr["chequeTitle"]);
                    }
                    if (idr["chequeAmount"] != DBNull.Value)
                    {
                        o.chequeAmount = Convert.ToString(idr["chequeAmount"]);
                    }
                    if (idr["chequeAmountFig"] != DBNull.Value)
                    {
                        o.chequeAmountFig = Convert.ToDecimal(idr["chequeAmountFig"]);
                    }
                    if (idr["chequeDate"] != DBNull.Value)
                    {
                        o.chequeDate = Convert.ToDateTime(idr["chequeDate"]);
                    }
                    if (idr["chequeNo"] != DBNull.Value)
                    {
                        o.chequeNo = Convert.ToString(idr["chequeNo"]);
                    }
                    if (idr["chequeReceivedBy"] != DBNull.Value)
                    {
                        o.chequeReceivedBy = Convert.ToString(idr["chequeReceivedBy"]);
                    }
                    if (idr["chequeReceiverPhone"] != DBNull.Value)
                    {
                        o.chequeReceiverPhone = Convert.ToString(idr["chequeReceiverPhone"]);
                    }
                    if (idr["chequeReceiverIDCard"] != DBNull.Value)
                    {
                        o.chequeReceiverIDCard = Convert.ToString(idr["chequeReceiverIDCard"]);
                    }
                    if (idr["chequeCreatedBy"] != DBNull.Value)
                    {
                        o.chequeCreatedBy = Convert.ToInt32(idr["chequeCreatedBy"]);
                    }
                    if (idr["chequeCreatedOn"] != DBNull.Value)
                    {
                        o.chequeCreatedOn = Convert.ToDateTime(idr["chequeCreatedOn"]);
                    }
                    if (idr["chequeStatus"] != DBNull.Value)
                    {
                        o.chequeStatus = Convert.ToInt32(idr["chequeStatus"]);
                    }
                }
            }
            if (rtNull)
            {
                o = null;
            }
            return o;
        }

        public class objChequePrinting
        {
            public int chequeId { get; set; }
            public int bankId { get; set; }
            public string chequeTitle { get; set; }
            public string chequeAmount { get; set; }
            public decimal chequeAmountFig { get; set; }
            public DateTime? chequeDate { get; set; }
            public string chequeNo { get; set; }
            public string chequeReceivedBy { get; set; }
            public string chequeReceiverPhone { get; set; }
            public string chequeReceiverIDCard { get; set; }
            public int? chequeCreatedBy { get; set; }
            public DateTime? chequeCreatedOn { get; set; }
            public int? chequeStatus { get; set; }

        }

    }

}
