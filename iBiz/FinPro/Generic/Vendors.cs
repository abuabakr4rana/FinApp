using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace iBiz.FinPro.Generic
{
	public class Vendors
	{
		iDB.FinPro.Generic.Vendors db = new iDB.FinPro.Generic.Vendors();

		public void Add(objVendor i)
		{
			int vendorId = db.Add(
i.vendorId, i.vendorCode, i.vendorURL, i.vendorTitle, i.vendorDescription, i.vendorProductType, i.vendorAddressLine1, i.vendorAddressLine2, i.vendorCity, i.vendorZip, i.vendorState, i.vendorStateShortcode, i.vendorCountry, i.vendorCountryShortcode, i.vendorIsActive, i.vendorEmail, i.vendorEmailAlt, i.vendorPhone, i.vendorPhoneAlt, i.vendorMinQty, i.vendorMaxQty, i.vendorOrderIntimationEmal, i.vendorSampleIntimationEmail, i.vendorFTP, i.vendorFtpUsername, i.vendorFtpPassword, i.vendorSendOnFtp, i.vendorFirstName, i.vendorLastName, i.vendorAccountId, i.vendorCreatedOn, i.vendorCreatedBy, i.vendorCreatedIP);

			//iBiz.Integration.FinWithErp.Vendors bIVendors = new Integration.FinWithErp.Vendors();
			//bIVendors.Create_Account(vendorId);

		}

		public void Update(objVendor i)
		{
			db.Update(
i.vendorId, i.vendorCode, i.vendorURL, i.vendorTitle, i.vendorDescription, i.vendorProductType, i.vendorAddressLine1, i.vendorAddressLine2, i.vendorCity, i.vendorZip, i.vendorState, i.vendorStateShortcode, i.vendorCountry, i.vendorCountryShortcode, i.vendorIsActive, i.vendorEmail, i.vendorEmailAlt, i.vendorPhone, i.vendorPhoneAlt, i.vendorMinQty, i.vendorMaxQty, i.vendorOrderIntimationEmal, i.vendorSampleIntimationEmail, i.vendorFTP, i.vendorFtpUsername, i.vendorFtpPassword, i.vendorSendOnFtp, i.vendorFirstName, i.vendorLastName, i.vendorAccountId, i.vendorCreatedOn, i.vendorCreatedBy, i.vendorCreatedIP);
		}

		public void Delete(int i)
		{
			db.Delete(i);
		}

		public IDataReader Select()
		{
			return db.Select();
		}

		public List<objVendor> liSelect()
		{
			List<objVendor> rt = new List<objVendor>();
			IDataReader idr = Select();
			rt = Select_liObj(idr);
			return rt;
		}

		public objVendor Select(int vendorId)
		{
			objVendor o = new objVendor();
			IDataReader idr = db.Select(vendorId);
			o = Select_Obj(idr);
			return o;
		}

        public objVendor SelectByVendorAccountId(int vendorAccountId)
        {
            objVendor o = new objVendor();
            IDataReader idr = db.SelectByVendorAccountId(vendorAccountId);
            o = Select_Obj(idr);
            return o;
        }

        public objVendor Select(string vendorURL)
        {
            objVendor o = new objVendor();
            IDataReader idr = db.Select(vendorURL);
            o = Select_Obj(idr);
            return o;
        }

        public void syncVendors(List<objVendor> liVendors)
        {
            foreach (var item in liVendors)
            {
                Add(item);
            }
        }

        private objVendor Select_Obj(IDataReader idr)
		{
			objVendor o = new objVendor();
			bool rtNull = true;

			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["vendorId"] != DBNull.Value)
					{
						o.vendorId = Convert.ToInt32(idr["vendorId"]);
					}
					if (idr["vendorCode"] != DBNull.Value)
					{
						o.vendorCode = Convert.ToString(idr["vendorCode"]);
					}
                    if (idr["vendorURL"] != DBNull.Value)
                    {
                        o.vendorURL = Convert.ToString(idr["vendorURL"]);
                    }
                    if (idr["vendorTitle"] != DBNull.Value)
					{
						o.vendorTitle = Convert.ToString(idr["vendorTitle"]);
					}
					if (idr["vendorDescription"] != DBNull.Value)
					{
						o.vendorDescription = Convert.ToString(idr["vendorDescription"]);
					}
					if (idr["vendorProductType"] != DBNull.Value)
					{
						o.vendorProductType = Convert.ToInt32(idr["vendorProductType"]);
					}
					if (idr["vendorAddressLine1"] != DBNull.Value)
					{
						o.vendorAddressLine1 = Convert.ToString(idr["vendorAddressLine1"]);
					}
					if (idr["vendorAddressLine2"] != DBNull.Value)
					{
						o.vendorAddressLine2 = Convert.ToString(idr["vendorAddressLine2"]);
					}
					if (idr["vendorCity"] != DBNull.Value)
					{
						o.vendorCity = Convert.ToString(idr["vendorCity"]);
					}
					if (idr["vendorZip"] != DBNull.Value)
					{
						o.vendorZip = Convert.ToString(idr["vendorZip"]);
					}
					if (idr["vendorState"] != DBNull.Value)
					{
						o.vendorState = Convert.ToString(idr["vendorState"]);
					}
					if (idr["vendorStateShortcode"] != DBNull.Value)
					{
						o.vendorStateShortcode = Convert.ToString(idr["vendorStateShortcode"]);
					}
					if (idr["vendorCountry"] != DBNull.Value)
					{
						o.vendorCountry = Convert.ToString(idr["vendorCountry"]);
					}
					if (idr["vendorCountryShortcode"] != DBNull.Value)
					{
						o.vendorCountryShortcode = Convert.ToString(idr["vendorCountryShortcode"]);
					}
					if (idr["vendorIsActive"] != DBNull.Value)
					{
						o.vendorIsActive = Convert.ToBoolean(idr["vendorIsActive"]);
					}
					if (idr["vendorEmail"] != DBNull.Value)
					{
						o.vendorEmail = Convert.ToString(idr["vendorEmail"]);
					}
					if (idr["vendorEmailAlt"] != DBNull.Value)
					{
						o.vendorEmailAlt = Convert.ToString(idr["vendorEmailAlt"]);
					}
					if (idr["vendorPhone"] != DBNull.Value)
					{
						o.vendorPhone = Convert.ToString(idr["vendorPhone"]);
					}
					if (idr["vendorPhoneAlt"] != DBNull.Value)
					{
						o.vendorPhoneAlt = Convert.ToString(idr["vendorPhoneAlt"]);
					}
					if (idr["vendorMinQty"] != DBNull.Value)
					{
						o.vendorMinQty = Convert.ToInt32(idr["vendorMinQty"]);
					}
					if (idr["vendorMaxQty"] != DBNull.Value)
					{
						o.vendorMaxQty = Convert.ToInt32(idr["vendorMaxQty"]);
					}
					if (idr["vendorOrderIntimationEmal"] != DBNull.Value)
					{
						o.vendorOrderIntimationEmal = Convert.ToString(idr["vendorOrderIntimationEmal"]);
					}
					if (idr["vendorSampleIntimationEmail"] != DBNull.Value)
					{
						o.vendorSampleIntimationEmail = Convert.ToString(idr["vendorSampleIntimationEmail"]);
					}
					if (idr["vendorFTP"] != DBNull.Value)
					{
						o.vendorFTP = Convert.ToString(idr["vendorFTP"]);
					}
					if (idr["vendorFtpUsername"] != DBNull.Value)
					{
						o.vendorFtpUsername = Convert.ToString(idr["vendorFtpUsername"]);
					}
					if (idr["vendorFtpPassword"] != DBNull.Value)
					{
						o.vendorFtpPassword = Convert.ToString(idr["vendorFtpPassword"]);
					}
					if (idr["vendorSendOnFtp"] != DBNull.Value)
					{
						o.vendorSendOnFtp = Convert.ToBoolean(idr["vendorSendOnFtp"]);
					}
					if (idr["vendorFirstName"] != DBNull.Value)
					{
						o.vendorFirstName = idr["vendorFirstName"].ToString();
					}
					if (idr["vendorLastName"] != DBNull.Value)
					{
						o.vendorLastName = idr["vendorLastName"].ToString();
					}
					if (idr["vendorAccountId"] != DBNull.Value)
					{
						o.vendorAccountId = Convert.ToInt32(idr["vendorAccountId"]);
					}
					if (idr["vendorCreatedOn"] != DBNull.Value)
					{
						o.vendorCreatedOn = Convert.ToDateTime(idr["vendorCreatedOn"]);
					}
					if (idr["vendorCreatedBy"] != DBNull.Value)
					{
						o.vendorCreatedBy = Convert.ToInt32(idr["vendorCreatedBy"]);
					}
					if (idr["vendorCreatedIP"] != DBNull.Value)
					{
						o.vendorCreatedIP = Convert.ToString(idr["vendorCreatedIP"]);
					}

				}
			}

			if (rtNull)
			{
				o = null;
			}

			return o;
		}

		private List<objVendor> Select_liObj(IDataReader idr)
		{
			List<objVendor> rt = new List<objVendor>();

			if (idr != null)
			{
				while (idr.Read())
				{
					objVendor o = new objVendor();

					if (idr["vendorId"] != DBNull.Value)
					{
						o.vendorId = Convert.ToInt32(idr["vendorId"]);
					}
					if (idr["vendorCode"] != DBNull.Value)
					{
						o.vendorCode = Convert.ToString(idr["vendorCode"]);
					}
					if (idr["vendorURL"] != DBNull.Value)
					{
						o.vendorURL = Convert.ToString(idr["vendorURL"]);
					}
					if (idr["vendorTitle"] != DBNull.Value)
					{
						o.vendorTitle = Convert.ToString(idr["vendorTitle"]);
					}
					if (idr["vendorDescription"] != DBNull.Value)
					{
						o.vendorDescription = Convert.ToString(idr["vendorDescription"]);
					}
					if (idr["vendorProductType"] != DBNull.Value)
					{
						o.vendorProductType = Convert.ToInt32(idr["vendorProductType"]);
					}
					if (idr["vendorAddressLine1"] != DBNull.Value)
					{
						o.vendorAddressLine1 = Convert.ToString(idr["vendorAddressLine1"]);
					}
					if (idr["vendorAddressLine2"] != DBNull.Value)
					{
						o.vendorAddressLine2 = Convert.ToString(idr["vendorAddressLine2"]);
					}
					if (idr["vendorCity"] != DBNull.Value)
					{
						o.vendorCity = Convert.ToString(idr["vendorCity"]);
					}
					if (idr["vendorZip"] != DBNull.Value)
					{
						o.vendorZip = Convert.ToString(idr["vendorZip"]);
					}
					if (idr["vendorState"] != DBNull.Value)
					{
						o.vendorState = Convert.ToString(idr["vendorState"]);
					}
					if (idr["vendorStateShortcode"] != DBNull.Value)
					{
						o.vendorStateShortcode = Convert.ToString(idr["vendorStateShortcode"]);
					}
					if (idr["vendorCountry"] != DBNull.Value)
					{
						o.vendorCountry = Convert.ToString(idr["vendorCountry"]);
					}
					if (idr["vendorCountryShortcode"] != DBNull.Value)
					{
						o.vendorCountryShortcode = Convert.ToString(idr["vendorCountryShortcode"]);
					}
					if (idr["vendorIsActive"] != DBNull.Value)
					{
						o.vendorIsActive = Convert.ToBoolean(idr["vendorIsActive"]);
					}
					if (idr["vendorEmail"] != DBNull.Value)
					{
						o.vendorEmail = Convert.ToString(idr["vendorEmail"]);
					}
					if (idr["vendorEmailAlt"] != DBNull.Value)
					{
						o.vendorEmailAlt = Convert.ToString(idr["vendorEmailAlt"]);
					}
					if (idr["vendorPhone"] != DBNull.Value)
					{
						o.vendorPhone = Convert.ToString(idr["vendorPhone"]);
					}
					if (idr["vendorPhoneAlt"] != DBNull.Value)
					{
						o.vendorPhoneAlt = Convert.ToString(idr["vendorPhoneAlt"]);
					}
					if (idr["vendorMinQty"] != DBNull.Value)
					{
						o.vendorMinQty = Convert.ToInt32(idr["vendorMinQty"]);
					}
					if (idr["vendorMaxQty"] != DBNull.Value)
					{
						o.vendorMaxQty = Convert.ToInt32(idr["vendorMaxQty"]);
					}
					if (idr["vendorOrderIntimationEmal"] != DBNull.Value)
					{
						o.vendorOrderIntimationEmal = Convert.ToString(idr["vendorOrderIntimationEmal"]);
					}
					if (idr["vendorSampleIntimationEmail"] != DBNull.Value)
					{
						o.vendorSampleIntimationEmail = Convert.ToString(idr["vendorSampleIntimationEmail"]);
					}
					if (idr["vendorFTP"] != DBNull.Value)
					{
						o.vendorFTP = Convert.ToString(idr["vendorFTP"]);
					}
					if (idr["vendorFtpUsername"] != DBNull.Value)
					{
						o.vendorFtpUsername = Convert.ToString(idr["vendorFtpUsername"]);
					}
					if (idr["vendorFtpPassword"] != DBNull.Value)
					{
						o.vendorFtpPassword = Convert.ToString(idr["vendorFtpPassword"]);
					}
					if (idr["vendorSendOnFtp"] != DBNull.Value)
					{
						o.vendorSendOnFtp = Convert.ToBoolean(idr["vendorSendOnFtp"]);
					}
					if (idr["vendorFirstName"] != DBNull.Value)
					{
						o.vendorFirstName = idr["vendorFirstName"].ToString();
					}
					if (idr["vendorLastName"] != DBNull.Value)
					{
						o.vendorLastName = idr["vendorLastName"].ToString();
					}
					if (idr["vendorAccountId"] != DBNull.Value)
					{
						o.vendorAccountId = Convert.ToInt32(idr["vendorAccountId"]);
					}
					if (idr["vendorCreatedOn"] != DBNull.Value)
					{
						o.vendorCreatedOn = Convert.ToDateTime(idr["vendorCreatedOn"]);
					}
					if (idr["vendorCreatedBy"] != DBNull.Value)
					{
						o.vendorCreatedBy = Convert.ToInt32(idr["vendorCreatedBy"]);
					}
					if (idr["vendorCreatedIP"] != DBNull.Value)
					{
						o.vendorCreatedIP = Convert.ToString(idr["vendorCreatedIP"]);
					}



					rt.Add(o);
				}
			}
			
			return rt;
		}

		public class objVendor
		{
			public int vendorId { get; set; }
			public string vendorCode { get; set; }
            public string vendorURL { get; set; }
            public string vendorTitle { get; set; }
			public string vendorDescription { get; set; }
			public int vendorProductType { get; set; }
			public string vendorAddressLine1 { get; set; }
			public string vendorAddressLine2 { get; set; }
			public string vendorCity { get; set; }
			public string vendorZip { get; set; }
			public string vendorState { get; set; }
			public string vendorStateShortcode { get; set; }
			public string vendorCountry { get; set; }
			public string vendorCountryShortcode { get; set; }
			public bool vendorIsActive { get; set; }
			public string vendorEmail { get; set; }
			public string vendorEmailAlt { get; set; }
			public string vendorPhone { get; set; }
			public string vendorPhoneAlt { get; set; }
			public int vendorMinQty { get; set; }
			public int vendorMaxQty { get; set; }
			public string vendorOrderIntimationEmal { get; set; }
			public string vendorSampleIntimationEmail { get; set; }
			public string vendorFTP { get; set; }
			public string vendorFtpUsername { get; set; }
			public string vendorFtpPassword { get; set; }
			public bool vendorSendOnFtp { get; set; }
			public string vendorFirstName { get; set; }
			public string vendorLastName { get; set; }
			public int? vendorAccountId { get; set; }
			public DateTime vendorCreatedOn { get; set; }
			public int vendorCreatedBy { get; set; }
			public string vendorCreatedIP { get; set; }

		}

        
    }
}
