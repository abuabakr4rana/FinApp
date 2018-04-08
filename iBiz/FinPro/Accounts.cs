using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro
{
	public class Accounts
	{
		iDB.FinPro.Accounts db = new iDB.FinPro.Accounts();
		
		public int Add(objAccount i)
		{
            return db.Add(i.accountPrefix, i.accountNo, i.accountLevel, i.accountParent, i.accountType, i.associateID, i.accountTitle, i.accountDescription, i.accountCreatedOn, i.accountCreatedBy, i.accountLastUpdated, i.accountLastUpdatedBy, i.accountLedger, i.accountActual, i.accountDefaultVersaAccount, i.accountIsBudgetDependent, i.accountIsActive, i.accountIsVisible, i.accountIsTransactable, i.accountSystemIndex);
		}
		public void Update(objAccount i)
		{
			db.Update(
            i.accountID, i.accountPrefix, i.accountNo, i.accountLevel, i.accountParent, i.accountType, i.associateID, i.accountTitle, i.accountDescription, i.accountCreatedOn, i.accountCreatedBy, i.accountLastUpdated, i.accountLastUpdatedBy, i.accountLedger, i.accountActual, i.accountDefaultVersaAccount, i.accountIsBudgetDependent, i.accountIsActive, i.accountIsVisible, i.accountIsTransactable, i.accountSystemIndex);
		}
		public void Delete(int i)
		{
			db.Delete(i);
		}
		public IDataReader Select()
		{
			return db.Select();
		}

        public List<objAccount> SelectAllAccounts()
        {
            IDataReader idr = db.Select();
            List<objAccount> rt = Select_liObj(idr);
            return rt;
        }

        public IDataReader Select(bool isOfficial)
        {
            IDataReader idr = null;
            iDB.Communicate dbComm = new iDB.Communicate();
            string query = "select * from fin_Accounts where  accountSystemIndex in (0, 1) order by accountTitle asc";

            if (isOfficial)
            {
                query = "select * from fin_Accounts where accountSystemIndex in (1, 2) order by accountTitle asc";
            }

            idr = dbComm.SelectCMD(query);

            return idr;
        }

		public objAccount Select(int accountID)
		{
			IDataReader idr = null;
			objAccount o = new objAccount();

			try
			{
				idr = db.Select(accountID);
				o = Select_Obj(idr);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (idr != null)
				{
					idr.Dispose();
				}
			}

			return o;
		}	

		public IDataReader Select_By_Type(int AccountCategoryID)
		{
			return db.Select_For_AccountType(AccountCategoryID);
		}

        public IDataReader Select_By_Type(int AccountCategoryID, bool isOfficial)
        {
           
            IDataReader idr = null;
            iDB.Communicate dbComm = new iDB.Communicate();
            string query = "select * from fin_Accounts where  accountSystemIndex in (0, 1)";

            if (isOfficial)
            {
                query = "select * from fin_Accounts where accountSystemIndex in (1, 2)";
            }

            query += " and accountType=" + AccountCategoryID.ToString();

            idr = dbComm.SelectCMD(query);

            return idr;
        }

		public IDataReader Select_By_Type(int AccountCategoryID, int accountParent)
		{

			IDataReader idr = null;
			iDB.Communicate dbComm = new iDB.Communicate();
			string query = "select * from fin_Accounts where  accountParent=" + accountParent;
			
			query += " and accountType=" + AccountCategoryID.ToString();

			idr = dbComm.SelectCMD(query);

			return idr;
		}

		public List<objAccount> liSelect_By_Type(int AccountCategoryID)
        {
            List<objAccount> rt = new List<objAccount>();
            rt = Select_liObj(Select_By_Type(AccountCategoryID));
            return rt;
        }

		public List<objAccount> Select_Top_Parents()
		{
			List<objAccount> rt = new List<objAccount>();

			IDataReader idr = db.Select_Account_By_Parent(0);

			rt = Select_liObj(idr);

			return rt;
		}

		public List<objAccount> Select_Child_Accounts(int parentAccount)
		{
			List<objAccount> rt = new List<objAccount>();
			IDataReader idr = db.Select_Account_By_Parent(parentAccount);

			rt = Select_liObj(idr);
			return rt;
		}

        public objAccount Get_Latest_Account_By_Prefix(string accountPrefix)
        {
            objAccount rt = new objAccount();

            IDataReader idr = db.Select_Max_Account_By_Prefix(accountPrefix);

            rt = Select_Obj(idr);
            

            return rt;
        }

        public string Generate_Account_Number(string accountPrefix)
        {
            string rt = "01";

            objAccount objAcc = Get_Latest_Account_By_Prefix(accountPrefix);

            if (objAcc != null)
            {
                bool found = false;
                int accountId;
                found = int.TryParse(objAcc.accountNo.Replace("-", ""), out accountId);

                if (found)
                {
                    rt = Convert.ToInt32(accountId + 1).ToString("00");
                }
            }
            else
            {
                
            }

            return rt;
        }

		/// <summary>
        /// Return Account Number
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string Update_Account_Number(int accountId)
        {
            string rt = "";
            objAccount objAcc = new objAccount();
            objAcc = Select(accountId);

            if (objAcc != null)
            {
                string accountPrefix = "";

                if (!string.IsNullOrEmpty(objAcc.accountPrefix))
                {
                    accountPrefix = objAcc.accountPrefix;
                    rt = Generate_Account_Number(objAcc.accountPrefix);
                }
                else
                {
                    accountPrefix = Get_Prefix_For_Account(accountId);
                    rt = Generate_Account_Number(accountPrefix);
                }

                objAcc.accountPrefix = accountPrefix;

                objAcc.accountNo = rt;

                Update(objAcc);
            }

            return rt;
        }

        public string Get_Prefix_For_Account(int accountId)
        {
            string rt = "";

            objAccount objAcc = new objAccount();
            objAcc = Select(accountId);

            if (objAcc != null)
            {
                if (!string.IsNullOrEmpty(objAcc.accountPrefix))
                {
                    rt = objAcc.accountPrefix;
                }
                else
                {
                    if (objAcc.accountParent.HasValue)
                    {
                        if (objAcc.accountParent == 0)
                        {
                            if (string.IsNullOrEmpty(objAcc.accountNo))
                            {
                                if (objAcc.accountType.HasValue)
                                {
                                    iBiz.FinPro.Accounts.Categories bCat = new Categories();
                                    Accounts.Categories.objCategory objCat = new Categories.objCategory();

                                    objCat = bCat.Select(objAcc.accountType.Value);

                                    if (objCat != null)
                                    {
                                        rt = Convert.ToInt32(objCat.accCatID + 10).ToString("00");
                                    }
                                }
                            }
                            else
                            {
                                rt = objAcc.accountPrefix + objAcc.accountNo;
                            }
                        }
                        else
                        {
                            int parentId = objAcc.accountParent.Value;
                            objAcc = new objAccount();
                            objAcc = Select(parentId);

                            if (objAcc != null)
                            {
                                if (!string.IsNullOrEmpty(objAcc.accountNo))
                                {
									rt = objAcc.accountPrefix + objAcc.accountNo;
                                }
                                else
                                {
                                    Update_Account_Number(objAcc.accountID);
                                }
                            }
                        }
                    }
                }
            }


            return rt;
        }

		public void Make_Account_Transactable(int accountId, bool isTransactable)
		{
			objAccount acc = new objAccount();

			acc = Select(accountId);

			if (acc != null)
			{
				if (isTransactable == true)
				{
					acc.accountIsTransactable = 1;
				}
				else
				{
					acc.accountIsTransactable = 2;
				}

				Update(acc);
			}
		}

		public IDataReader SelectTransactable(bool isOfficial)
		{
			IDataReader idr = null;
			iDB.Communicate dbComm = new iDB.Communicate();
			string query = "select * from fin_Accounts where accountIsTransactable in (0, 1) and accountSystemIndex in (0, 1) order by accountTitle asc";

			if (isOfficial)
			{
				query = "select * from fin_Accounts where accountIsTransactable in (0, 1) and accountSystemIndex in (1, 2) order by accountTitle asc";
			}

			idr = dbComm.SelectCMD(query);

			return idr;
		}
		public int GetAccountId(string accountTitle)
		{
			int accountId = 0;

			IDataReader idr = null;
			iDB.Communicate dbComm = new iDB.Communicate();
			string query = "select * from fin_Accounts where accountTitle='" + accountTitle.Trim() + "'";
			idr = dbComm.SelectCMD(query);

			if (idr != null)
			{
				while (idr.Read())
				{
					accountId = Convert.ToInt32(idr["accountId"]);
				}
			}

			return accountId;
		}

		public bool IsTransactable(int accountId)
		{
			objAccount objAcc = new objAccount();
			objAcc = Select(accountId);

			bool rt = false;

			if (objAcc.accountIsTransactable == 1)
			{
				rt = true;
			}

			return rt;
		}

		private List<objAccount> Select_liObj(IDataReader idr)
		{
			List<objAccount> rt = new List<objAccount>();

			if (idr != null)
			{
				while (idr.Read())
				{
					objAccount o = new objAccount();

					if (idr["accountID"] != DBNull.Value)
					{
						o.accountID = Convert.ToInt32(idr["accountID"]);
					}
					if (idr["accountPrefix"] != DBNull.Value)
					{
						o.accountPrefix = idr["accountPrefix"].ToString();
					}
					if (idr["accountNo"] != DBNull.Value)
					{
						o.accountNo = idr["accountNo"].ToString();
					}
					if (idr["accountLevel"] != DBNull.Value)
					{
						o.accountLevel = Convert.ToInt32(idr["accountLevel"]);
					}
					if (idr["accountParent"] != DBNull.Value)
					{
						o.accountParent = Convert.ToInt32(idr["accountParent"]);
					}
					if (idr["accountType"] != DBNull.Value)
					{
						o.accountType = Convert.ToInt32(idr["accountType"]);
					}
					if (idr["associateID"] != DBNull.Value)
					{
						o.associateID = Convert.ToInt32(idr["associateID"]);
					}
					if (idr["accountTitle"] != DBNull.Value)
					{
						o.accountTitle = Convert.ToString(idr["accountTitle"]);
					}
					if (idr["accountDescription"] != DBNull.Value)
					{
						o.accountDescription = Convert.ToString(idr["accountDescription"]);
					}
					if (idr["accountCreatedOn"] != DBNull.Value)
					{
						o.accountCreatedOn = Convert.ToDateTime(idr["accountCreatedOn"]);
					}
					if (idr["accountCreatedBy"] != DBNull.Value)
					{
						o.accountCreatedBy = Convert.ToInt32(idr["accountCreatedBy"]);
					}
					if (idr["accountLastUpdated"] != DBNull.Value)
					{
						o.accountLastUpdated = Convert.ToDateTime(idr["accountLastUpdated"]);
					}
					if (idr["accountLastUpdatedBy"] != DBNull.Value)
					{
						o.accountLastUpdatedBy = Convert.ToInt32(idr["accountLastUpdatedBy"]);
					}
					if (idr["accountLedger"] != DBNull.Value)
					{
						o.accountLedger = Convert.ToDecimal(idr["accountLedger"]);
					}
					if (idr["accountActual"] != DBNull.Value)
					{
						o.accountActual = Convert.ToDecimal(idr["accountActual"]);
					}
					if (idr["accountDefaultVersaAccount"] != DBNull.Value)
					{
						o.accountDefaultVersaAccount = Convert.ToInt32(idr["accountDefaultVersaAccount"]);
					}
					if (idr["accountIsBudgetDependent"] != DBNull.Value)
					{
						o.accountIsBudgetDependent = Convert.ToBoolean(idr["accountIsBudgetDependent"]);
					}
					if (idr["accountIsActive"] != DBNull.Value)
					{
						o.accountIsActive = Convert.ToBoolean(idr["accountIsActive"]);
					}
					if (idr["accountIsVisible"] != DBNull.Value)
					{
						o.accountIsVisible = Convert.ToBoolean(idr["accountIsVisible"]);
					}
					if (idr["accountIsTransactable"] != DBNull.Value)
					{
						o.accountIsTransactable = Convert.ToInt32(idr["accountIsTransactable"]);
					}
					if (idr["accountSystemIndex"] != DBNull.Value)
					{
						o.accountSystemIndex = Convert.ToInt32(idr["accountSystemIndex"]);
					}

					rt.Add(o);
				}
			}

			return rt;
		}
		private objAccount Select_Obj(IDataReader idr)
		{
			objAccount o = new objAccount();
			bool rtNull = true;


			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["accountID"] != DBNull.Value)
					{
						o.accountID = Convert.ToInt32(idr["accountID"]);
					}
					if (idr["accountPrefix"] != DBNull.Value)
					{
						o.accountPrefix = idr["accountPrefix"].ToString();
					}
					if (idr["accountNo"] != DBNull.Value)
					{
						o.accountNo = idr["accountNo"].ToString();
					}
					if (idr["accountLevel"] != DBNull.Value)
					{
						o.accountLevel = Convert.ToInt32(idr["accountLevel"]);
					}
					if (idr["accountParent"] != DBNull.Value)
					{
						o.accountParent = Convert.ToInt32(idr["accountParent"]);
					}
					if (idr["accountType"] != DBNull.Value)
					{
						o.accountType = Convert.ToInt32(idr["accountType"]);
					}
					if (idr["associateID"] != DBNull.Value)
					{
						o.associateID = Convert.ToInt32(idr["associateID"]);
					}
					if (idr["accountTitle"] != DBNull.Value)
					{
						o.accountTitle = Convert.ToString(idr["accountTitle"]);
					}
					if (idr["accountDescription"] != DBNull.Value)
					{
						o.accountDescription = Convert.ToString(idr["accountDescription"]);
					}
					if (idr["accountCreatedOn"] != DBNull.Value)
					{
						o.accountCreatedOn = Convert.ToDateTime(idr["accountCreatedOn"]);
					}
					if (idr["accountCreatedBy"] != DBNull.Value)
					{
						o.accountCreatedBy = Convert.ToInt32(idr["accountCreatedBy"]);
					}
					if (idr["accountLastUpdated"] != DBNull.Value)
					{
						o.accountLastUpdated = Convert.ToDateTime(idr["accountLastUpdated"]);
					}
					if (idr["accountLastUpdatedBy"] != DBNull.Value)
					{
						o.accountLastUpdatedBy = Convert.ToInt32(idr["accountLastUpdatedBy"]);
					}
					if (idr["accountLedger"] != DBNull.Value)
					{
						o.accountLedger = Convert.ToDecimal(idr["accountLedger"]);
					}
					if (idr["accountActual"] != DBNull.Value)
					{
						o.accountActual = Convert.ToDecimal(idr["accountActual"]);
					}
					if (idr["accountDefaultVersaAccount"] != DBNull.Value)
					{
						o.accountDefaultVersaAccount = Convert.ToInt32(idr["accountDefaultVersaAccount"]);
					}
					if (idr["accountIsBudgetDependent"] != DBNull.Value)
					{
						o.accountIsBudgetDependent = Convert.ToBoolean(idr["accountIsBudgetDependent"]);
					}
					if (idr["accountIsActive"] != DBNull.Value)
					{
						o.accountIsActive = Convert.ToBoolean(idr["accountIsActive"]);
					}
					if (idr["accountIsVisible"] != DBNull.Value)
					{
						o.accountIsVisible = Convert.ToBoolean(idr["accountIsVisible"]);
					}
                    if (idr["accountIsTransactable"] != DBNull.Value)
					{
                        o.accountIsTransactable = Convert.ToInt32(idr["accountIsTransactable"]);
					}
                    if (idr["accountSystemIndex"] != DBNull.Value)
                    {
                        o.accountSystemIndex = Convert.ToInt32(idr["accountSystemIndex"]);
                    }
				}
			}

			if (rtNull == true)
			{
				o = null;
			}

			return o;
		}

		public class objAccount
		{
			public int accountID { get; set; }
			public string accountPrefix { get; set; }
			public string accountNo { get; set; }
			public int? accountLevel { get; set; }
			public int? accountParent { get; set; }
			public int? accountType { get; set; }
			public int? associateID { get; set; }
			public string accountTitle { get; set; }
			public string accountDescription { get; set; }
			public DateTime accountCreatedOn { get; set; }
			public int? accountCreatedBy { get; set; }
			public DateTime? accountLastUpdated { get; set; }
			public int? accountLastUpdatedBy { get; set; }
			public decimal accountLedger { get; set; }
			public decimal accountActual { get; set; }
			public int? accountDefaultVersaAccount { get; set; }
			public bool accountIsBudgetDependent { get; set; }
			public bool accountIsActive { get; set; }
			public bool accountIsVisible { get; set; }
			public int accountIsTransactable { get; set; }
            public int accountSystemIndex { get; set; }
		}
		public class Categories
		{
			iDB.FinPro.Accounts.Categories db = new iDB.FinPro.Accounts.Categories();

			public void Add(objCategory i)
			{
				db.Add(
				i.accCatID, i.accCatTitle, i.accCatDescription);
			}

			public void Update(objCategory i)
			{
				db.Update(
				i.accCatID, i.accCatTitle, i.accCatDescription);
			}

			public void Delete(int i)
			{
				db.Delete(i);
			}

			public IDataReader Select()
			{
				return db.Select();
			}

            public List<objCategory> SelectAllCategories()
			{
                IDataReader idr = db.Select();
                List<objCategory> rt = Select_liObj(idr);
				return rt;
			}

			private objCategory Select_Obj(IDataReader idr)
			{
				objCategory o = new objCategory();
				bool rtNull = true;

				if (idr != null)
				{
					while (idr.Read())
					{
						if (idr["accCatID"] != DBNull.Value)
						{
							o.accCatID = Convert.ToInt32(idr["accCatID"]);
						}
						if (idr["accCatTitle"] != DBNull.Value)
						{
							o.accCatTitle = Convert.ToString(idr["accCatTitle"]);
						}
						if (idr["accCatDescription"] != DBNull.Value)
						{
							o.accCatDescription = Convert.ToString(idr["accCatDescription"]);
						}
						rtNull = false;
					}
				}

				if (rtNull)
				{
					o = null;
				}

				return o;
			}

            private List<objCategory> Select_liObj(IDataReader idr)
            {
                List<objCategory> rt = new List<objCategory>();
                bool rtNull = true;

                if (idr != null)
                {
                    while (idr.Read())
                    {
                        objCategory o = new objCategory();
                        if (idr["accCatID"] != DBNull.Value)
                        {
                            o.accCatID = Convert.ToInt32(idr["accCatID"]);
                        }
                        if (idr["accCatTitle"] != DBNull.Value)
                        {
                            o.accCatTitle = Convert.ToString(idr["accCatTitle"]);
                        }
                        if (idr["accCatDescription"] != DBNull.Value)
                        {
                            o.accCatDescription = Convert.ToString(idr["accCatDescription"]);
                        }
                        rtNull = false;
                        rt.Add(o);
                    }
                }

                if (rtNull)
                {
                    rt = null;
                }

                return rt;
            }

            public objCategory Select(int catId)
            {
                IDataReader idr = db.Select(catId);
                objCategory objCat = new objCategory();
                objCat = Select_Obj(idr);

                return objCat;
            }
            

            public class objCategory
			{
				public int accCatID { get; set; }
				public string accCatTitle { get; set; }
				public string accCatDescription { get; set; }
			}

		}
		public enum Types
		{
			Asset=1,
			Fixed_Assets=2
		}
		public TransItems Transacts(int accountId)
		{
			TransItems i = new TransItems(accountId, 0);

			return i;
		}
		public class TransItems : Transactions.Transact
		{
			private int forAccount { get; set; }
			private int sysIndex { get; set; }

			public TransItems(int accountId, int systemIndex)
			{
				forAccount = accountId;
				sysIndex = systemIndex;
			}

			public IDataReader GetItems()
			{
				IDataReader idr = null;

				return idr;
			}

			public IDataReader GetItems(DateTime? from, DateTime? to)
			{
				IDataReader idr = null;

				return idr;
			}

			public IDataReader Openning_Balance(DateTime onDate)
			{
				IDataReader idr = null;

				return idr;
			}

			public IDataReader Closing_Balanace(DateTime onDate)
			{
				IDataReader idr = null;

				return idr;
			}
		}


		
	}
}
