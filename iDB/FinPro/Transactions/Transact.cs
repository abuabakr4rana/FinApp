using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iDB.FinPro.Transactions
{
	public class Transact
	{
		Communicate dbComm = new Communicate();
		SortedList<string, object> srt = new SortedList<string, object>();

        public int Add(int? transSystemIndex, int? transParticipantID, string transRefID, string transAttachedFiles, int? transInvoiceID, int? transDrAccount, int? transCrAccount, string transNarration, decimal transAmount, DateTime transCreatedOn, int transCreatedBy, DateTime transUpdatedOn, int transUpdatedBy, int transStatus, bool transSystemRestrict, int? transGroupID, bool transIsCompound, int? transType, int? deptId)
		{
			IDataReader idr = null;
			srt.Clear();
			//srt.Add("transSystemIndex", transSystemIndex);
            srt.Add("transSystemIndex", 2);
			srt.Add("transParticipantID", transParticipantID);
			srt.Add("transRefID", transRefID);
			srt.Add("transAttachedFiles", transAttachedFiles);
			srt.Add("transInvoiceID", transInvoiceID);
			srt.Add("transDrAccount", transDrAccount);
			srt.Add("transCrAccount", transCrAccount);
            srt.Add("deptId", deptId);
			srt.Add("transNarration", transNarration);
			srt.Add("transAmount", transAmount);
			srt.Add("transCreatedOn", transCreatedOn);
			srt.Add("transCreatedBy", transCreatedBy);
			srt.Add("transUpdatedOn", transUpdatedOn);
			srt.Add("transUpdatedBy", transUpdatedBy);
			srt.Add("transStatus", transStatus);
			//srt.Add("transSystemRestrict", transSystemRestrict);
            srt.Add("transSystemRestrict", 0);
			srt.Add("transGroupID", transGroupID);
			srt.Add("transIsCompound", transIsCompound);
			srt.Add("transType", transType);
			srt.Add("Flg", 1);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Transactions, srt);

			int rt = 0;

			if (idr != null)
			{
				while (idr.Read())
				{
					rt = Convert.ToInt32(idr[0]);
				}
			}

			return rt;
		}

        public void Update(int transID, int? transSystemIndex, int? transParticipantID, string transRefID, string transAttachedFiles, int? transInvoiceID, int? transDrAccount, int? transCrAccount, string transNarration, decimal transAmount, DateTime transCreatedOn, int transCreatedBy, DateTime transUpdatedOn, int transUpdatedBy, int transStatus, bool transSystemRestrict, int? transGroupID, bool transIsCompound, int? transType, int? deptId)
		{
			srt.Clear();
			srt.Add("transID", transID);
			srt.Add("transSystemIndex", transSystemIndex);
			srt.Add("transParticipantID", transParticipantID);
			srt.Add("transRefID", transRefID);
			srt.Add("transAttachedFiles", transAttachedFiles);
			srt.Add("transInvoiceID", transInvoiceID);
			srt.Add("transDrAccount", transDrAccount);
			srt.Add("transCrAccount", transCrAccount);
            srt.Add("deptId", deptId);
			srt.Add("transNarration", transNarration);
			srt.Add("transAmount", transAmount);
			srt.Add("transCreatedOn", transCreatedOn);
			srt.Add("transCreatedBy", transCreatedBy);
			srt.Add("transUpdatedOn", transUpdatedOn);
			srt.Add("transUpdatedBy", transUpdatedBy);
			srt.Add("transStatus", transStatus);
			srt.Add("transSystemRestrict", transSystemRestrict);
			srt.Add("transGroupID", transGroupID);
			srt.Add("transIsCompound", transIsCompound);
			srt.Add("transType", transType);
			srt.Add("Flg", 2);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

		public void Delete(int transID)
		{
			srt.Clear();
			srt.Add("transID", transID);
			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

		public IDataReader Select()
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Transactions, srt);
			return idr;
		}

		public IDataReader Select(int transID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("transID", transID);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Transactions, srt);
			return idr;
		}

		public void Delete_Sales_Transactions(int branchID, int saleID)
		{
			srt.Clear();
			srt.Add("transParticipantID", branchID);
			srt.Add("transRefID", saleID);
			srt.Add("Flg", 7);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

		public void Delete_By_GroupID(int transGroupID)
		{
			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("Flg", 8);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

		public IDataReader Get_Dr_Total_forGroup(int transGroupID)
		{
			IDataReader idr = null;

			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("Flg", 9);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Transactions, srt);

			return idr;
		}

		public IDataReader Get_Cr_Total_forGroup(int transGroupID)
		{
			IDataReader idr = null;

			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("Flg", 10);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Transactions, srt);

			return idr;
		}

		public void Delete_Untagged(int createdBy)
		{
			srt.Clear();
			srt.Add("@transCreatedBy", createdBy);
			srt.Add("Flg", 11);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

		public void Update_Group(int createdBy, int oldGroup, int newGroup)
		{
			srt.Clear();
			srt.Add("@transCreatedBy", createdBy);
			srt.Add("@transGroupIDOld", oldGroup);
			srt.Add("@transGroupID", newGroup);
			srt.Add("Flg", 12);
			dbComm.Execute(srt, Communicate.StoredProcedures.Transactions);
		}

        public IDataReader Select_Group(int transGroupID, bool isOfficial)
        {
            dbComm = new Communicate();
            IDataReader idr = dbComm.SelectCMD(string.Format("exec SP_fin_SelectVouchar @transGroupId={0}, @isOfficial={1}", transGroupID, Convert.ToInt32(isOfficial)));
            return idr;
        }

        public IDataReader Select_Group(int transGroupID)
        {
            dbComm = new Communicate();
            IDataReader idr = dbComm.SelectCMD(string.Format("exec SP_fin_SelectVouchar @transGroupId={0}", transGroupID));
            return idr;
        }

	}
}

