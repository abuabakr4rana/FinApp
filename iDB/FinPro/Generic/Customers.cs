using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace iDB.FinPro.Generic
{
	public class Customers
	{
		Communicate dbComm = new Communicate();
		SortedList<string, object> srt = new SortedList<string, object>();
		public int Add(int customerId, string customerCode, string customerURL, string customerTitle, string customerDescription, int customerProductType, string customerAddressLine1, string customerAddressLine2, string customerCity, string customerZip, string customerState, string customerStateShortcode, string customerCountry, string customerCountryShortcode, bool customerIsActive, string customerEmail, string customerEmailAlt, string customerPhone, string customerPhoneAlt, int customerMinQty, int customerMaxQty, string customerOrderIntimationEmal, string customerSampleIntimationEmail, string customerFTP, string customerFtpUsername, string customerFtpPassword, bool customerSendOnFtp, string customerFirstName, string customerLastName, int? customerAccountId, DateTime customerCreatedOn, int customerCreatedBy, string customerCreatedIP)
		{
			int rt = 0;

			srt.Clear();
			srt.Add("customerId", customerId);
			srt.Add("customerCode", customerCode);
			srt.Add("customerURL", customerURL);
			srt.Add("customerTitle", customerTitle);
			srt.Add("customerDescription", customerDescription);
			srt.Add("customerProductType", customerProductType);
			srt.Add("customerAddressLine1", customerAddressLine1);
			srt.Add("customerAddressLine2", customerAddressLine2);
			srt.Add("customerCity", customerCity);
			srt.Add("customerZip", customerZip);
			srt.Add("customerState", customerState);
			srt.Add("customerStateShortcode", customerStateShortcode);
			srt.Add("customerCountry", customerCountry);
			srt.Add("customerCountryShortcode", customerCountryShortcode);
			srt.Add("customerIsActive", customerIsActive);
			srt.Add("customerEmail", customerEmail);
			srt.Add("customerEmailAlt", customerEmailAlt);
			srt.Add("customerPhone", customerPhone);
			srt.Add("customerPhoneAlt", customerPhoneAlt);
			srt.Add("customerMinQty", customerMinQty);
			srt.Add("customerMaxQty", customerMaxQty);
			srt.Add("customerOrderIntimationEmal", customerOrderIntimationEmal);
			srt.Add("customerSampleIntimationEmail", customerSampleIntimationEmail);
			srt.Add("customerFTP", customerFTP);
			srt.Add("customerFtpUsername", customerFtpUsername);
			srt.Add("customerFtpPassword", customerFtpPassword);
			srt.Add("customerSendOnFtp", customerSendOnFtp);
			srt.Add("customerFirstName", customerFirstName);
			srt.Add("customerLastName", customerLastName);
			srt.Add("customerAccountId", customerAccountId);

			srt.Add("customerCreatedOn", customerCreatedOn);
			srt.Add("customerCreatedBy", customerCreatedBy);
			srt.Add("customerCreatedIP", customerCreatedIP);

			srt.Add("Flg", 1);
			IDataReader idr = dbComm.SelectIDR(Communicate.StoredProcedures.Customers, srt);

			if (idr != null)
			{
				while (idr.Read())
				{
					rt = Convert.ToInt32(idr[0]);
				}
			}

			return rt;
		}
		

		public void Update(int customerId, string customerCode, string customerURL, string customerTitle, string customerDescription, int customerProductType, string customerAddressLine1, string customerAddressLine2, string customerCity, string customerZip, string customerState, string customerStateShortcode, string customerCountry, string customerCountryShortcode, bool customerIsActive, string customerEmail, string customerEmailAlt, string customerPhone, string customerPhoneAlt, int customerMinQty, int customerMaxQty, string customerOrderIntimationEmal, string customerSampleIntimationEmail, string customerFTP, string customerFtpUsername, string customerFtpPassword, bool customerSendOnFtp, string customerFirstName, string customerLastName, int? customerAccountId, DateTime customerCreatedOn, int customerCreatedBy, string customerCreatedIP)
		{
			srt.Clear();
			srt.Add("customerId", customerId);
			srt.Add("customerURL", customerURL);
			srt.Add("customerCode", customerCode);
			srt.Add("customerTitle", customerTitle);
			srt.Add("customerDescription", customerDescription);
			srt.Add("customerProductType", customerProductType);
			srt.Add("customerAddressLine1", customerAddressLine1);
			srt.Add("customerAddressLine2", customerAddressLine2);
			srt.Add("customerCity", customerCity);
			srt.Add("customerZip", customerZip);
			srt.Add("customerState", customerState);
			srt.Add("customerStateShortcode", customerStateShortcode);
			srt.Add("customerCountry", customerCountry);
			srt.Add("customerCountryShortcode", customerCountryShortcode);
			srt.Add("customerIsActive", customerIsActive);
			srt.Add("customerEmail", customerEmail);
			srt.Add("customerEmailAlt", customerEmailAlt);
			srt.Add("customerPhone", customerPhone);
			srt.Add("customerPhoneAlt", customerPhoneAlt);
			srt.Add("customerMinQty", customerMinQty);
			srt.Add("customerMaxQty", customerMaxQty);
			srt.Add("customerOrderIntimationEmal", customerOrderIntimationEmal);
			srt.Add("customerSampleIntimationEmail", customerSampleIntimationEmail);
			srt.Add("customerFTP", customerFTP);
			srt.Add("customerFtpUsername", customerFtpUsername);
			srt.Add("customerFtpPassword", customerFtpPassword);
			srt.Add("customerSendOnFtp", customerSendOnFtp);
			srt.Add("customerFirstName", customerFirstName);
			srt.Add("customerLastName", customerLastName);
			srt.Add("customerAccountId", customerAccountId);
			srt.Add("customerCreatedOn", customerCreatedOn);
			srt.Add("customerCreatedBy", customerCreatedBy);
			srt.Add("customerCreatedIP", customerCreatedIP);
			srt.Add("Flg", 2);
			dbComm.Execute(srt, Communicate.StoredProcedures.Customers);

		}

		public void Delete(int customerId)
		{
			srt.Clear();
			srt.Add("customerId", customerId);
			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.Customers);

		}

		public IDataReader Select()
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Customers, srt);
			return idr;
		}

		public IDataReader Select(int customerId)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("customerId", customerId);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Customers, srt);
			return idr;
		}

		public IDataReader Select(string customerURL)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("customerURL", customerURL);
			srt.Add("Flg", 6);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Customers, srt);
			return idr;
		}

		public IDataReader SelectByCustomerAccountId(int customerAccountId)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("customerAccountId", customerAccountId);
			srt.Add("Flg", 7);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Customers, srt);
			return idr;
		}

	}
}

