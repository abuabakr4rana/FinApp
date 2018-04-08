using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace iBiz.FinPro.Generic
{
	public class Customers
	{
		iDB.FinPro.Generic.Customers db = new iDB.FinPro.Generic.Customers();

		public void Add(objCustomer i)
		{
			int customerId = db.Add(
i.customerId, i.customerCode, i.customerURL, i.customerTitle, i.customerDescription, i.customerProductType, i.customerAddressLine1, i.customerAddressLine2, i.customerCity, i.customerZip, i.customerState, i.customerStateShortcode, i.customerCountry, i.customerCountryShortcode, i.customerIsActive, i.customerEmail, i.customerEmailAlt, i.customerPhone, i.customerPhoneAlt, i.customerMinQty, i.customerMaxQty, i.customerOrderIntimationEmal, i.customerSampleIntimationEmail, i.customerFTP, i.customerFtpUsername, i.customerFtpPassword, i.customerSendOnFtp, i.customerFirstName, i.customerLastName, i.customerAccountId, i.customerCreatedOn, i.customerCreatedBy, i.customerCreatedIP);

			//Integration.FinWithErp.Customers bICustomer = new Integration.FinWithErp.Customers();
			//bICustomer.Create_Account(customerId);



		}

		public void Update(objCustomer i)
		{
			db.Update(
i.customerId, i.customerCode, i.customerURL, i.customerTitle, i.customerDescription, i.customerProductType, i.customerAddressLine1, i.customerAddressLine2, i.customerCity, i.customerZip, i.customerState, i.customerStateShortcode, i.customerCountry, i.customerCountryShortcode, i.customerIsActive, i.customerEmail, i.customerEmailAlt, i.customerPhone, i.customerPhoneAlt, i.customerMinQty, i.customerMaxQty, i.customerOrderIntimationEmal, i.customerSampleIntimationEmail, i.customerFTP, i.customerFtpUsername, i.customerFtpPassword, i.customerSendOnFtp, i.customerFirstName, i.customerLastName, i.customerAccountId, i.customerCreatedOn, i.customerCreatedBy, i.customerCreatedIP);
		}

		public void Delete(int i)
		{
			db.Delete(i);
		}

		public IDataReader Select()
		{
			return db.Select();
		}

		public List<objCustomer> liSelect()
		{
			List<objCustomer> rt = new List<objCustomer>();
			IDataReader idr = Select();
			rt = Select_liObj(idr);
			return rt;
		}

		public objCustomer Select(int customerId)
		{
			objCustomer o = new objCustomer();
			IDataReader idr = db.Select(customerId);
			o = Select_Obj(idr);
			return o;
		}

		public objCustomer Select(string customerURL)
		{
			objCustomer o = new objCustomer();
			IDataReader idr = db.Select(customerURL);
			o = Select_Obj(idr);
			return o;
		}

		public void synccustomers(List<objCustomer> licustomers)
		{
			foreach (var item in licustomers)
			{
				Add(item);
			}
		}

		public objCustomer SelectByCustomerAccountId(int customerAccountId)
		{
			IDataReader idr = db.SelectByCustomerAccountId(customerAccountId);
			objCustomer rt = new objCustomer();
			rt = Select_Obj(idr);
			return rt;
		}

		private objCustomer Select_Obj(IDataReader idr)
		{
			objCustomer o = new objCustomer();
			bool rtNull = true;

			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["customerId"] != DBNull.Value)
					{
						o.customerId = Convert.ToInt32(idr["customerId"]);
					}
					if (idr["customerCode"] != DBNull.Value)
					{
						o.customerCode = Convert.ToString(idr["customerCode"]);
					}
					if (idr["customerURL"] != DBNull.Value)
					{
						o.customerURL = Convert.ToString(idr["customerURL"]);
					}
					if (idr["customerTitle"] != DBNull.Value)
					{
						o.customerTitle = Convert.ToString(idr["customerTitle"]);
					}
					if (idr["customerDescription"] != DBNull.Value)
					{
						o.customerDescription = Convert.ToString(idr["customerDescription"]);
					}
					if (idr["customerProductType"] != DBNull.Value)
					{
						o.customerProductType = Convert.ToInt32(idr["customerProductType"]);
					}
					if (idr["customerAddressLine1"] != DBNull.Value)
					{
						o.customerAddressLine1 = Convert.ToString(idr["customerAddressLine1"]);
					}
					if (idr["customerAddressLine2"] != DBNull.Value)
					{
						o.customerAddressLine2 = Convert.ToString(idr["customerAddressLine2"]);
					}
					if (idr["customerCity"] != DBNull.Value)
					{
						o.customerCity = Convert.ToString(idr["customerCity"]);
					}
					if (idr["customerZip"] != DBNull.Value)
					{
						o.customerZip = Convert.ToString(idr["customerZip"]);
					}
					if (idr["customerState"] != DBNull.Value)
					{
						o.customerState = Convert.ToString(idr["customerState"]);
					}
					if (idr["customerStateShortcode"] != DBNull.Value)
					{
						o.customerStateShortcode = Convert.ToString(idr["customerStateShortcode"]);
					}
					if (idr["customerCountry"] != DBNull.Value)
					{
						o.customerCountry = Convert.ToString(idr["customerCountry"]);
					}
					if (idr["customerCountryShortcode"] != DBNull.Value)
					{
						o.customerCountryShortcode = Convert.ToString(idr["customerCountryShortcode"]);
					}
					if (idr["customerIsActive"] != DBNull.Value)
					{
						o.customerIsActive = Convert.ToBoolean(idr["customerIsActive"]);
					}
					if (idr["customerEmail"] != DBNull.Value)
					{
						o.customerEmail = Convert.ToString(idr["customerEmail"]);
					}
					if (idr["customerEmailAlt"] != DBNull.Value)
					{
						o.customerEmailAlt = Convert.ToString(idr["customerEmailAlt"]);
					}
					if (idr["customerPhone"] != DBNull.Value)
					{
						o.customerPhone = Convert.ToString(idr["customerPhone"]);
					}
					if (idr["customerPhoneAlt"] != DBNull.Value)
					{
						o.customerPhoneAlt = Convert.ToString(idr["customerPhoneAlt"]);
					}
					if (idr["customerMinQty"] != DBNull.Value)
					{
						o.customerMinQty = Convert.ToInt32(idr["customerMinQty"]);
					}
					if (idr["customerMaxQty"] != DBNull.Value)
					{
						o.customerMaxQty = Convert.ToInt32(idr["customerMaxQty"]);
					}
					if (idr["customerOrderIntimationEmal"] != DBNull.Value)
					{
						o.customerOrderIntimationEmal = Convert.ToString(idr["customerOrderIntimationEmal"]);
					}
					if (idr["customerSampleIntimationEmail"] != DBNull.Value)
					{
						o.customerSampleIntimationEmail = Convert.ToString(idr["customerSampleIntimationEmail"]);
					}
					if (idr["customerFTP"] != DBNull.Value)
					{
						o.customerFTP = Convert.ToString(idr["customerFTP"]);
					}
					if (idr["customerFtpUsername"] != DBNull.Value)
					{
						o.customerFtpUsername = Convert.ToString(idr["customerFtpUsername"]);
					}
					if (idr["customerFtpPassword"] != DBNull.Value)
					{
						o.customerFtpPassword = Convert.ToString(idr["customerFtpPassword"]);
					}
					if (idr["customerSendOnFtp"] != DBNull.Value)
					{
						o.customerSendOnFtp = Convert.ToBoolean(idr["customerSendOnFtp"]);
					}
					if (idr["customerFirstName"] != DBNull.Value)
					{
						o.customerFirstName = idr["customerFirstName"].ToString();
					}
					if (idr["customerLastName"] != DBNull.Value)
					{
						o.customerLastName = idr["customerLastName"].ToString();
					}
					if (idr["customerAccountId"] != DBNull.Value)
					{
						o.customerAccountId = Convert.ToInt32(idr["customerAccountId"]);
					}
					if (idr["customerCreatedOn"] != DBNull.Value)
					{
						o.customerCreatedOn = Convert.ToDateTime(idr["customerCreatedOn"]);
					}
					if (idr["customerCreatedBy"] != DBNull.Value)
					{
						o.customerCreatedBy = Convert.ToInt32(idr["customerCreatedBy"]);
					}
					if (idr["customerCreatedIP"] != DBNull.Value)
					{
						o.customerCreatedIP = Convert.ToString(idr["customerCreatedIP"]);
					}
				}
			}

			if (rtNull)
			{
				o = null;
			}

			return o;
		}
		

		private List<objCustomer> Select_liObj(IDataReader idr)
		{
			List<objCustomer> rt = new List<objCustomer>();

			if (idr != null)
			{
				while (idr.Read())
				{
					objCustomer o = new objCustomer();

					if (idr["customerId"] != DBNull.Value)
					{
						o.customerId = Convert.ToInt32(idr["customerId"]);
					}
					if (idr["customerCode"] != DBNull.Value)
					{
						o.customerCode = Convert.ToString(idr["customerCode"]);
					}
					if (idr["customerURL"] != DBNull.Value)
					{
						o.customerURL = Convert.ToString(idr["customerURL"]);
					}
					if (idr["customerTitle"] != DBNull.Value)
					{
						o.customerTitle = Convert.ToString(idr["customerTitle"]);
					}
					if (idr["customerDescription"] != DBNull.Value)
					{
						o.customerDescription = Convert.ToString(idr["customerDescription"]);
					}
					if (idr["customerProductType"] != DBNull.Value)
					{
						o.customerProductType = Convert.ToInt32(idr["customerProductType"]);
					}
					if (idr["customerAddressLine1"] != DBNull.Value)
					{
						o.customerAddressLine1 = Convert.ToString(idr["customerAddressLine1"]);
					}
					if (idr["customerAddressLine2"] != DBNull.Value)
					{
						o.customerAddressLine2 = Convert.ToString(idr["customerAddressLine2"]);
					}
					if (idr["customerCity"] != DBNull.Value)
					{
						o.customerCity = Convert.ToString(idr["customerCity"]);
					}
					if (idr["customerZip"] != DBNull.Value)
					{
						o.customerZip = Convert.ToString(idr["customerZip"]);
					}
					if (idr["customerState"] != DBNull.Value)
					{
						o.customerState = Convert.ToString(idr["customerState"]);
					}
					if (idr["customerStateShortcode"] != DBNull.Value)
					{
						o.customerStateShortcode = Convert.ToString(idr["customerStateShortcode"]);
					}
					if (idr["customerCountry"] != DBNull.Value)
					{
						o.customerCountry = Convert.ToString(idr["customerCountry"]);
					}
					if (idr["customerCountryShortcode"] != DBNull.Value)
					{
						o.customerCountryShortcode = Convert.ToString(idr["customerCountryShortcode"]);
					}
					if (idr["customerIsActive"] != DBNull.Value)
					{
						o.customerIsActive = Convert.ToBoolean(idr["customerIsActive"]);
					}
					if (idr["customerEmail"] != DBNull.Value)
					{
						o.customerEmail = Convert.ToString(idr["customerEmail"]);
					}
					if (idr["customerEmailAlt"] != DBNull.Value)
					{
						o.customerEmailAlt = Convert.ToString(idr["customerEmailAlt"]);
					}
					if (idr["customerPhone"] != DBNull.Value)
					{
						o.customerPhone = Convert.ToString(idr["customerPhone"]);
					}
					if (idr["customerPhoneAlt"] != DBNull.Value)
					{
						o.customerPhoneAlt = Convert.ToString(idr["customerPhoneAlt"]);
					}
					if (idr["customerMinQty"] != DBNull.Value)
					{
						o.customerMinQty = Convert.ToInt32(idr["customerMinQty"]);
					}
					if (idr["customerMaxQty"] != DBNull.Value)
					{
						o.customerMaxQty = Convert.ToInt32(idr["customerMaxQty"]);
					}
					if (idr["customerOrderIntimationEmal"] != DBNull.Value)
					{
						o.customerOrderIntimationEmal = Convert.ToString(idr["customerOrderIntimationEmal"]);
					}
					if (idr["customerSampleIntimationEmail"] != DBNull.Value)
					{
						o.customerSampleIntimationEmail = Convert.ToString(idr["customerSampleIntimationEmail"]);
					}
					if (idr["customerFTP"] != DBNull.Value)
					{
						o.customerFTP = Convert.ToString(idr["customerFTP"]);
					}
					if (idr["customerFtpUsername"] != DBNull.Value)
					{
						o.customerFtpUsername = Convert.ToString(idr["customerFtpUsername"]);
					}
					if (idr["customerFtpPassword"] != DBNull.Value)
					{
						o.customerFtpPassword = Convert.ToString(idr["customerFtpPassword"]);
					}
					if (idr["customerSendOnFtp"] != DBNull.Value)
					{
						o.customerSendOnFtp = Convert.ToBoolean(idr["customerSendOnFtp"]);
					}
					if (idr["customerFirstName"] != DBNull.Value)
					{
						o.customerFirstName = idr["customerFirstName"].ToString();
					}
					if (idr["customerLastName"] != DBNull.Value)
					{
						o.customerLastName = idr["customerLastName"].ToString();
					}
					if (idr["customerAccountId"] != DBNull.Value)
					{
						o.customerAccountId = Convert.ToInt32(idr["customerAccountId"]);
					}
					if (idr["customerCreatedOn"] != DBNull.Value)
					{
						o.customerCreatedOn = Convert.ToDateTime(idr["customerCreatedOn"]);
					}
					if (idr["customerCreatedBy"] != DBNull.Value)
					{
						o.customerCreatedBy = Convert.ToInt32(idr["customerCreatedBy"]);
					}
					if (idr["customerCreatedIP"] != DBNull.Value)
					{
						o.customerCreatedIP = Convert.ToString(idr["customerCreatedIP"]);
					}
					rt.Add(o);
				}
			}

			return rt;
		}

		public class objCustomer
		{
			public int customerId { get; set; }
			public string customerCode { get; set; }
			public string customerURL { get; set; }
			public string customerTitle { get; set; }
			public string customerDescription { get; set; }
			public int customerProductType { get; set; }
			public string customerAddressLine1 { get; set; }
			public string customerAddressLine2 { get; set; }
			public string customerCity { get; set; }
			public string customerZip { get; set; }
			public string customerState { get; set; }
			public string customerStateShortcode { get; set; }
			public string customerCountry { get; set; }
			public string customerCountryShortcode { get; set; }
			public bool customerIsActive { get; set; }
			public string customerEmail { get; set; }
			public string customerEmailAlt { get; set; }
			public string customerPhone { get; set; }
			public string customerPhoneAlt { get; set; }
			public int customerMinQty { get; set; }
			public int customerMaxQty { get; set; }
			public string customerOrderIntimationEmal { get; set; }
			public string customerSampleIntimationEmail { get; set; }
			public string customerFTP { get; set; }
			public string customerFtpUsername { get; set; }
			public string customerFtpPassword { get; set; }
			public bool customerSendOnFtp { get; set; }
			public string customerFirstName { get; set; }
			public string customerLastName { get; set; }
			public int? customerAccountId { get; set; }
			public DateTime customerCreatedOn { get; set; }
			public int customerCreatedBy { get; set; }
			public string customerCreatedIP { get; set; }


		}


	}
}
