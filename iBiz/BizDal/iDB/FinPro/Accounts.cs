using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iDB.FinPro
{
	public class Accounts
	{
		Communicate dbComm = new Communicate();
		SortedList<string, object> srt = new SortedList<string, object>();

        public int Add(string accountPrefix, string accountNo, int? accountLevel, int? accountParent, int? accountType, int? associateID, string accountTitle, string accountDescription, DateTime accountCreatedOn, int? accountCreatedBy, DateTime? accountLastUpdated, int? accountLastUpdatedBy, decimal accountLedger, decimal accountActual, int? accountDefaultVersaAccount, bool accountIsBudgetDependent, bool accountIsActive, bool accountIsVisible, int accountIsTransactable, int accountSystemIndex)
		{
			IDataReader idr = null;
			int rt = 0;

			srt.Clear();
			srt.Add("accountPrefix", accountPrefix);
			srt.Add("accountNo", accountNo);
			srt.Add("accountLevel", accountLevel);
			srt.Add("accountParent", accountParent);
			srt.Add("accountType", accountType);
			srt.Add("associateID", associateID);
			srt.Add("accountTitle", accountTitle);
			srt.Add("accountDescription", accountDescription);
			srt.Add("accountCreatedOn", accountCreatedOn);
			srt.Add("accountCreatedBy", accountCreatedBy);
			srt.Add("accountLastUpdated", accountLastUpdated);
			srt.Add("accountLastUpdatedBy", accountLastUpdatedBy);
			srt.Add("accountLedger", accountLedger);
			srt.Add("accountActual", accountActual);
			srt.Add("accountDefaultVersaAccount", accountDefaultVersaAccount);
			srt.Add("accountIsBudgetDependent", accountIsBudgetDependent);
			srt.Add("accountIsActive", accountIsActive);
			srt.Add("accountIsVisible", accountIsVisible);
			srt.Add("accountIsTransactable", accountIsTransactable);
            //srt.Add("accountSystemIndex", accountSystemIndex);
            srt.Add("accountSystemIndex", 1);
			srt.Add("Flg", 1);
			//dbComm.Execute(srt, Communicate.StoredProcedures.Accounts);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);

			if (idr != null)
			{
				while (idr.Read())
				{
					if (idr[0] != DBNull.Value)
					{
						rt = Convert.ToInt32(idr[0]);
					}
				}
			}

			return rt;
		}

        public void Update(int accountID, string accountPrefix, string accountNo, int? accountLevel, int? accountParent, int? accountType, int? associateID, string accountTitle, string accountDescription, DateTime accountCreatedOn, int? accountCreatedBy, DateTime? accountLastUpdated, int? accountLastUpdatedBy, decimal accountLedger, decimal accountActual, int? accountDefaultVersaAccount, bool accountIsBudgetDependent, bool accountIsActive, bool accountIsVisible, int accountIsTransactable, int accountSystemIndex)
		{
			srt.Clear();
			srt.Add("accountID", accountID);
			srt.Add("accountPrefix", accountPrefix);
			srt.Add("accountNo", accountNo);
			srt.Add("accountLevel", accountLevel);
			srt.Add("accountParent", accountParent);
			srt.Add("accountType", accountType);
			srt.Add("associateID", associateID);
			srt.Add("accountTitle", accountTitle);
			srt.Add("accountDescription", accountDescription);
			srt.Add("accountCreatedOn", accountCreatedOn);
			srt.Add("accountCreatedBy", accountCreatedBy);
			srt.Add("accountLastUpdated", accountLastUpdated);
			srt.Add("accountLastUpdatedBy", accountLastUpdatedBy);
			srt.Add("accountLedger", accountLedger);
			srt.Add("accountActual", accountActual);
			srt.Add("accountDefaultVersaAccount", accountDefaultVersaAccount);
			srt.Add("accountIsBudgetDependent", accountIsBudgetDependent);
			srt.Add("accountIsActive", accountIsActive);
			srt.Add("accountIsVisible", accountIsVisible);
			srt.Add("accountIsTransactable", accountIsTransactable);
            //srt.Add("accountSystemIndex", accountSystemIndex);
            srt.Add("accountSystemIndex", 1);
			srt.Add("Flg", 2);
			dbComm.Execute(srt, Communicate.StoredProcedures.Accounts);

		}

        

        public void Delete(int accountID)
		{
			srt.Clear();
			srt.Add("accountID", accountID);
			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.Accounts);

		}

		public IDataReader Select()
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

		public IDataReader Select(int accountID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("accountID", accountID);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

		public IDataReader Select_For_Associate(int associateID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("associateID", associateID);
			srt.Add("Flg", 6);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

		public IDataReader Select_For_Add_Account(int? accountID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("accountID", accountID);
			srt.Add("Flg", 7);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

		public IDataReader Select_For_AccountType(int? AccountTypeID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("accountType", AccountTypeID);
			srt.Add("Flg", 8);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

		/// <summary>
		/// account Parent = 0 for Top level accounts
		/// </summary>
		/// <param name="accountParent"></param>
		/// <returns></returns>
		public IDataReader Select_Account_By_Parent(int accountParent)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("accountParent", accountParent);
			srt.Add("Flg", 9);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
			return idr;
		}

        public IDataReader Select_Max_Account_By_Prefix(string accountPrefix)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("accountPrefix", accountPrefix);
            srt.Add("Flg", 10);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Accounts, srt);
            return idr;
        }

        public class Categories
		{
			SortedList<string, object> srt = new SortedList<string, object>();
			Communicate dbComm = new Communicate();

			public void Add(int accCatID, string accCatTitle, string accCatDescription)
			{
				srt.Clear();
				srt.Add("accCatID", accCatID);
				srt.Add("accCatTitle", accCatTitle);
				srt.Add("accCatDescription", accCatDescription);
				srt.Add("Flg", 1);
				dbComm.Execute(srt, Communicate.StoredProcedures.AccountCategories);
			}

			public void Update(int accCatID, string accCatTitle, string accCatDescription)
			{
				srt.Clear();
				srt.Add("accCatID", accCatID);
				srt.Add("accCatTitle", accCatTitle);
				srt.Add("accCatDescription", accCatDescription);
				srt.Add("Flg", 2);
				dbComm.Execute(srt, Communicate.StoredProcedures.AccountCategories);
			}

			public void Delete(int accCatID)
			{
				srt.Clear();
				srt.Add("accCatID", accCatID);
				srt.Add("Flg", 3);
				dbComm.Execute(srt, Communicate.StoredProcedures.AccountCategories);
			}

			public IDataReader Select()
			{
				IDataReader idr = null;
				srt.Clear();
				srt.Add("Flg", 4);
				idr = dbComm.SelectIDR(Communicate.StoredProcedures.AccountCategories, srt);
				return idr;
			}

			public IDataReader Select(int accCatID)
			{
				IDataReader idr = null;
				srt.Clear();
				srt.Add("accCatID", accCatID);
				srt.Add("Flg", 5);
				idr = dbComm.SelectIDR(Communicate.StoredProcedures.AccountCategories, srt);
				return idr;
			}
            
        }
	}
}
