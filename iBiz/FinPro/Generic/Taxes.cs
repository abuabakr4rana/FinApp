using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iBiz.FinPro.Generic
{
	public class Taxes
	{
		iDB.Generic.fin_Taxes db = new iDB.Generic.fin_Taxes();
		public void Add(objfin_Taxes i)
		{
			int accountId = 0;
			FinPro.Accounts bAcc = new Accounts();
			FinPro.Accounts.objAccount objAcc = new Accounts.objAccount();

			objAcc.accountActual = 0;
			objAcc.accountCreatedBy = i.taxCreatedBy;
			objAcc.accountCreatedOn = i.taxCreatedOn;
			objAcc.accountDefaultVersaAccount = 0;
			objAcc.accountDescription = i.taxTransNarration;
			objAcc.accountIsActive = true;
			objAcc.accountIsBudgetDependent = false;
			objAcc.accountIsTransactable = 1;
			objAcc.accountIsVisible = true;
			objAcc.accountLastUpdated = DateTime.Now;
			objAcc.accountLastUpdatedBy = i.taxCreatedBy;
			objAcc.accountLedger = 0;
			objAcc.accountLevel = 2;
			objAcc.accountNo = bAcc.Generate_Account_Number("TX");
			objAcc.accountParent = iBiz.Settings.TaxParentAccountId;
			objAcc.accountPrefix = "TX";
			objAcc.accountSystemIndex = 1;
			objAcc.accountTitle = i.taxTitle;
			objAcc.accountType = 15;
			objAcc.associateID = null;


			accountId = bAcc.Add(objAcc);

			i.taxAccountId = accountId;
			db.Add(i.taxId, i.taxTitle, i.taxValue, i.taxTypeIsPercent, i.taxCreatedBy, i.taxCreatedOn, i.taxCreatedIP, i.taxAccountId, i.taxTransNarration);
		}
		public void Update(objfin_Taxes i)
		{
			db.Update(i.taxId, i.taxTitle, i.taxValue, i.taxTypeIsPercent, i.taxCreatedBy, i.taxCreatedOn, i.taxCreatedIP, i.taxAccountId, i.taxTransNarration);
		}
		public void Delete(int taxId)
		{
			db.Delete(taxId);
		}

		public IDataReader Select()
		{
			return db.Select();
		}
		public objfin_Taxes Select(int taxId)
		{
			IDataReader idr = db.Select(taxId);
			return Select_Obj(idr);
		}

		private objfin_Taxes Select_Obj(IDataReader idr)
		{
			objfin_Taxes o = new objfin_Taxes();
			bool rtNull = true;
			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["taxId"] != DBNull.Value)
					{
						o.taxId = Convert.ToInt32(idr["taxId"]);
					}
					if (idr["taxTitle"] != DBNull.Value)
					{
						o.taxTitle = Convert.ToString(idr["taxTitle"]);
					}
					if (idr["taxValue"] != DBNull.Value)
					{
						o.taxValue = Convert.ToDecimal(idr["taxValue"]);
					}
					if (idr["taxTypeIsPercent"] != DBNull.Value)
					{
						o.taxTypeIsPercent = Convert.ToBoolean(idr["taxTypeIsPercent"]);
					}
					if (idr["taxCreatedBy"] != DBNull.Value)
					{
						o.taxCreatedBy = Convert.ToInt32(idr["taxCreatedBy"]);
					}
					if (idr["taxCreatedOn"] != DBNull.Value)
					{
						o.taxCreatedOn = Convert.ToDateTime(idr["taxCreatedOn"]);
					}
					if (idr["taxCreatedIP"] != DBNull.Value)
					{
						o.taxCreatedIP = Convert.ToString(idr["taxCreatedIP"]);
					}
					if (idr["taxAccountId"] != DBNull.Value)
					{
						o.taxAccountId = Convert.ToInt32(idr["taxAccountId"]);
					}
					if (idr["taxTransNarration"] != DBNull.Value)
					{
						o.taxTransNarration = Convert.ToString(idr["taxTransNarration"]);
					}
				}
			}
			if (rtNull)
			{
				o = null;
			}
			return o;
		}

		private List<objfin_Taxes> Select_liObj(IDataReader idr)
		{
			List<objfin_Taxes> rt = new List<objfin_Taxes>();

			if (idr != null)
			{
				while (idr.Read())
				{
					objfin_Taxes o = new objfin_Taxes();
					if (idr["taxId"] != DBNull.Value)
					{
						o.taxId = Convert.ToInt32(idr["taxId"]);
					}
					if (idr["taxTitle"] != DBNull.Value)
					{
						o.taxTitle = Convert.ToString(idr["taxTitle"]);
					}
					if (idr["taxValue"] != DBNull.Value)
					{
						o.taxValue = Convert.ToDecimal(idr["taxValue"]);
					}
					if (idr["taxTypeIsPercent"] != DBNull.Value)
					{
						o.taxTypeIsPercent = Convert.ToBoolean(idr["taxTypeIsPercent"]);
					}
					if (idr["taxCreatedBy"] != DBNull.Value)
					{
						o.taxCreatedBy = Convert.ToInt32(idr["taxCreatedBy"]);
					}
					if (idr["taxCreatedOn"] != DBNull.Value)
					{
						o.taxCreatedOn = Convert.ToDateTime(idr["taxCreatedOn"]);
					}
					if (idr["taxCreatedIP"] != DBNull.Value)
					{
						o.taxCreatedIP = Convert.ToString(idr["taxCreatedIP"]);
					}
					if (idr["taxAccountId"] != DBNull.Value)
					{
						o.taxAccountId = Convert.ToInt32(idr["taxAccountId"]);
					}
					if (idr["taxTransNarration"] != DBNull.Value)
					{
						o.taxTransNarration = Convert.ToString(idr["taxTransNarration"]);
					}
					rt.Add(o);
				}
			}

			return rt;
		}


		public class objfin_Taxes
		{
			public int taxId { get; set; }
			public string taxTitle { get; set; }
			public decimal taxValue { get; set; }
			public bool taxTypeIsPercent { get; set; }
			public int taxCreatedBy { get; set; }
			public DateTime taxCreatedOn { get; set; }
			public string taxCreatedIP { get; set; }
			public int taxAccountId { get; set; }
			public string taxTransNarration { get; set; }

		}

	}

}
