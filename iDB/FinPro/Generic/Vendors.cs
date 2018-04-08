using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace iDB.FinPro.Generic
{
	public class Vendors
	{
		Communicate dbComm = new Communicate();
		SortedList<string, object> srt = new SortedList<string, object>();
		public int Add(int vendorId, string vendorCode, string vendorURL, string vendorTitle, string vendorDescription, int vendorProductType, string vendorAddressLine1, string vendorAddressLine2, string vendorCity, string vendorZip, string vendorState, string vendorStateShortcode, string vendorCountry, string vendorCountryShortcode, bool vendorIsActive, string vendorEmail, string vendorEmailAlt, string vendorPhone, string vendorPhoneAlt, int vendorMinQty, int vendorMaxQty, string vendorOrderIntimationEmal, string vendorSampleIntimationEmail, string vendorFTP, string vendorFtpUsername, string vendorFtpPassword, bool vendorSendOnFtp, string vendorFirstName, string vendorLastName, int? vendorAccountId, DateTime vendorCreatedOn, int vendorCreatedBy, string vendorCreatedIP)
		{
			int rt = 0;


			srt.Clear();
			srt.Add("vendorId", vendorId);
			srt.Add("vendorCode", vendorCode);
            srt.Add("vendorURL", vendorURL);
            srt.Add("vendorTitle", vendorTitle);
			srt.Add("vendorDescription", vendorDescription);
			srt.Add("vendorProductType", vendorProductType);
			srt.Add("vendorAddressLine1", vendorAddressLine1);
			srt.Add("vendorAddressLine2", vendorAddressLine2);
			srt.Add("vendorCity", vendorCity);
			srt.Add("vendorZip", vendorZip);
			srt.Add("vendorState", vendorState);
			srt.Add("vendorStateShortcode", vendorStateShortcode);
			srt.Add("vendorCountry", vendorCountry);
			srt.Add("vendorCountryShortcode", vendorCountryShortcode);
			srt.Add("vendorIsActive", vendorIsActive);
			srt.Add("vendorEmail", vendorEmail);
			srt.Add("vendorEmailAlt", vendorEmailAlt);
			srt.Add("vendorPhone", vendorPhone);
			srt.Add("vendorPhoneAlt", vendorPhoneAlt);
			srt.Add("vendorMinQty", vendorMinQty);
			srt.Add("vendorMaxQty", vendorMaxQty);
			srt.Add("vendorOrderIntimationEmal", vendorOrderIntimationEmal);
			srt.Add("vendorSampleIntimationEmail", vendorSampleIntimationEmail);
			srt.Add("vendorFTP", vendorFTP);
			srt.Add("vendorFtpUsername", vendorFtpUsername);
			srt.Add("vendorFtpPassword", vendorFtpPassword);
			srt.Add("vendorSendOnFtp", vendorSendOnFtp);
			srt.Add("vendorFirstName", vendorFirstName);
			srt.Add("vendorLastName", vendorLastName);
			srt.Add("vendorAccountId", vendorAccountId);

			srt.Add("vendorCreatedOn", vendorCreatedOn);
			srt.Add("vendorCreatedBy", vendorCreatedBy);
			srt.Add("vendorCreatedIP", vendorCreatedIP);

			srt.Add("Flg", 1);
			IDataReader idr = dbComm.SelectIDR(Communicate.StoredProcedures.Product_Vendors, srt);

			if (idr != null)
			{
				while (idr.Read())
				{
					rt = Convert.ToInt32(idr[0]);
				}
			}

			return rt;
		}

       
        public void Update(int vendorId, string vendorCode, string vendorURL, string vendorTitle, string vendorDescription, int vendorProductType, string vendorAddressLine1, string vendorAddressLine2, string vendorCity, string vendorZip, string vendorState, string vendorStateShortcode, string vendorCountry, string vendorCountryShortcode, bool vendorIsActive, string vendorEmail, string vendorEmailAlt, string vendorPhone, string vendorPhoneAlt, int vendorMinQty, int vendorMaxQty, string vendorOrderIntimationEmal, string vendorSampleIntimationEmail, string vendorFTP, string vendorFtpUsername, string vendorFtpPassword, bool vendorSendOnFtp, string vendorFirstName, string vendorLastName, int? vendorAccountId, DateTime vendorCreatedOn, int vendorCreatedBy, string vendorCreatedIP)
		{
			srt.Clear();
			srt.Add("vendorId", vendorId);
			srt.Add("vendorURL", vendorURL);
            srt.Add("vendorCode", vendorCode);
            srt.Add("vendorTitle", vendorTitle);
			srt.Add("vendorDescription", vendorDescription);
			srt.Add("vendorProductType", vendorProductType);
			srt.Add("vendorAddressLine1", vendorAddressLine1);
			srt.Add("vendorAddressLine2", vendorAddressLine2);
			srt.Add("vendorCity", vendorCity);
			srt.Add("vendorZip", vendorZip);
			srt.Add("vendorState", vendorState);
			srt.Add("vendorStateShortcode", vendorStateShortcode);
			srt.Add("vendorCountry", vendorCountry);
			srt.Add("vendorCountryShortcode", vendorCountryShortcode);
			srt.Add("vendorIsActive", vendorIsActive);
			srt.Add("vendorEmail", vendorEmail);
			srt.Add("vendorEmailAlt", vendorEmailAlt);
			srt.Add("vendorPhone", vendorPhone);
			srt.Add("vendorPhoneAlt", vendorPhoneAlt);
			srt.Add("vendorMinQty", vendorMinQty);
			srt.Add("vendorMaxQty", vendorMaxQty);
			srt.Add("vendorOrderIntimationEmal", vendorOrderIntimationEmal);
			srt.Add("vendorSampleIntimationEmail", vendorSampleIntimationEmail);
			srt.Add("vendorFTP", vendorFTP);
			srt.Add("vendorFtpUsername", vendorFtpUsername);
			srt.Add("vendorFtpPassword", vendorFtpPassword);
			srt.Add("vendorSendOnFtp", vendorSendOnFtp);
			srt.Add("vendorFirstName", vendorFirstName);
			srt.Add("vendorLastName", vendorLastName);
			srt.Add("vendorAccountId", vendorAccountId);
			srt.Add("vendorCreatedOn", vendorCreatedOn);
			srt.Add("vendorCreatedBy", vendorCreatedBy);
			srt.Add("vendorCreatedIP", vendorCreatedIP);
			srt.Add("Flg", 2);
			dbComm.Execute(srt, Communicate.StoredProcedures.Product_Vendors);

		}

		public void Delete(int vendorId)
		{
			srt.Clear();
			srt.Add("vendorId", vendorId);
			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.Product_Vendors);

		}

		public IDataReader Select()
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Product_Vendors, srt);
			return idr;
		}

		public IDataReader Select(int vendorId)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("vendorId", vendorId);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Product_Vendors, srt);
			return idr;
		}

        public IDataReader Select(string vendorURL)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("vendorURL", vendorURL);
            srt.Add("Flg", 6);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Product_Vendors, srt);
            return idr;
        }

        public IDataReader SelectByVendorAccountId(int vendorAccountId)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("vendorAccountId", vendorAccountId);
            srt.Add("Flg", 7);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Product_Vendors, srt);
            return idr;
        }

    }
}
