using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Transactions
{
	public class Transact
	{
		iDB.FinPro.Transactions.Transact db = new iDB.FinPro.Transactions.Transact();
		iDB.Communicate dbComm = new iDB.Communicate();

		public int Add(objTransaction i)
		{
			return db.Add(i.transSystemIndex, i.transParticipantID, i.transRefID, i.transAttachedFiles, i.transInvoiceID, i.transDrAccount, i.transCrAccount, i.transNarration, i.transAmount, i.transCreatedOn, i.transCreatedBy, i.transUpdatedOn, i.transUpdatedBy, i.transStatus, i.transSystemRestrict, i.transGroupID, i.transIsCompound, i.transType, i.deptId);
		}

		public void Update(objTransaction i)
		{
			db.Update(
			i.transID, i.transSystemIndex, i.transParticipantID, i.transRefID, i.transAttachedFiles, i.transInvoiceID, i.transDrAccount, i.transCrAccount, i.transNarration, i.transAmount, i.transCreatedOn, i.transCreatedBy, i.transUpdatedOn, i.transUpdatedBy, i.transStatus, i.transSystemRestrict, i.transGroupID, i.transIsCompound, i.transType, i.deptId);
		}

		public void Delete(int i)
		{
			db.Delete(i);
		}

		public IDataReader Select()
		{
			return db.Select();
		}

        public List<objTransaction> SelectAllTransactions()
        {
            IDataReader idr = db.Select();
            List<objTransaction> rt = Select_ObjLi(idr);
            return rt;
        }

        public objTransaction Select(int transID)
		{
			IDataReader idr = null;
			objTransaction o = new objTransaction();

			try
			{
				idr = db.Select(transID);
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

        public IDataReader Select_Grp(int transGroupId, bool isOfficial)
        {
            IDataReader idr = null;
            idr = db.Select_Group(transGroupId, isOfficial);
            return idr;
        }

        public IDataReader Select_Grp(int transGroupId)
        {
            IDataReader idr = null;
            idr = db.Select_Group(transGroupId);
            return idr;
        }

		public void Delete_Untagged(int createdBy)
		{
			db.Delete_Untagged(createdBy);
		}

		public void Update_Group(int createdBy, int oldGroup, int newGroup)
		{
			db.Update_Group(createdBy, oldGroup, newGroup);
		}

        public decimal Get_Total_Credit_For_Group(int transGroupId)
        {
            decimal rt = 0;

            IDataReader idr = null;
            idr = db.Get_Cr_Total_forGroup(transGroupId);

            if (idr != null)
            {
                while (idr.Read())
                {
                    if (idr[0] != DBNull.Value)
                    {
                        rt = Convert.ToDecimal(idr[0]);    
                    }
                }
            }

            return rt;
        }

        public decimal Get_Total_Debit_For_Group(int transGroupId)
        {
            decimal rt = 0;

            IDataReader idr = null;
            idr = db.Get_Dr_Total_forGroup(transGroupId);

            if (idr != null)
            {
                while (idr.Read())
                {
                    if (idr[0] != DBNull.Value)
                    {
                        rt = Convert.ToDecimal(idr[0]);
                    }
                }
            }

            return rt;
        }

        public void MarkGroupItemsApproved(int transGroupId)
        {

            List<objTransaction> oLi = new List<objTransaction>();

            oLi = Select_GrpLi(transGroupId, true);

            foreach (objTransaction o in oLi)
            {
                o.transStatus = 1;
                Update(o);
            }

            oLi = new List<objTransaction>();
            oLi = Select_GrpLi(transGroupId, false);

            foreach (objTransaction o in oLi)
            {
                o.transStatus = 1;
                Update(o);
            }

        }

		public List<objTransaction> Select_GrpLi(int transGroupId, bool isOfficial)
		{
			IDataReader idr = null;
			List<objTransaction> o = new List<objTransaction>();

			try
			{
				idr = Select_Grp(transGroupId, isOfficial);
				o = Select_ObjLi(idr);
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

        public List<objTransaction> Select_GrpLi(int transGroupId)
        {
            IDataReader idr = null;
            List<objTransaction> o = new List<objTransaction>();

            try
            {
                idr = Select_Grp(transGroupId);
                o = Select_ObjLi(idr);
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

		private objTransaction Select_Obj(IDataReader idr)
		{
			objTransaction o = new objTransaction();
			bool rtNull = true;

			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["transID"] != DBNull.Value)
					{
						o.transID = Convert.ToInt32(idr["transID"]);
					}
					if (idr["transSystemIndex"] != DBNull.Value)
					{
						o.transSystemIndex = Convert.ToInt32(idr["transSystemIndex"]);
					}
					if (idr["transParticipantID"] != DBNull.Value)
					{
						o.transParticipantID = Convert.ToInt32(idr["transParticipantID"]);
					}
					if (idr["transRefID"] != DBNull.Value)
					{
						o.transRefID = Convert.ToString(idr["transRefID"]);
					}
					if (idr["transAttachedFiles"] != DBNull.Value)
					{
						o.transAttachedFiles = Convert.ToString(idr["transAttachedFiles"]);
					}
					if (idr["transInvoiceID"] != DBNull.Value)
					{
						o.transInvoiceID = Convert.ToInt32(idr["transInvoiceID"]);
					}
					if (idr["transDrAccount"] != DBNull.Value)
					{
						o.transDrAccount = Convert.ToInt32(idr["transDrAccount"]);
					}
					if (idr["transCrAccount"] != DBNull.Value)
					{
						o.transCrAccount = Convert.ToInt32(idr["transCrAccount"]);
					}
                    
					if (idr["transNarration"] != DBNull.Value)
					{
						o.transNarration = Convert.ToString(idr["transNarration"]);
					}
					if (idr["transAmount"] != DBNull.Value)
					{
						o.transAmount = Convert.ToDecimal(idr["transAmount"]);
					}
					if (idr["transCreatedOn"] != DBNull.Value)
					{
						o.transCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
					}
					if (idr["transCreatedBy"] != DBNull.Value)
					{
						o.transCreatedBy = Convert.ToInt32(idr["transCreatedBy"]);
					}
					if (idr["transUpdatedOn"] != DBNull.Value)
					{
						o.transUpdatedOn = Convert.ToDateTime(idr["transUpdatedOn"]);
					}
					if (idr["transUpdatedBy"] != DBNull.Value)
					{
						o.transUpdatedBy = Convert.ToInt32(idr["transUpdatedBy"]);
					}
					if (idr["transStatus"] != DBNull.Value)
					{
						o.transStatus = Convert.ToInt32(idr["transStatus"]);
					}
					if (idr["transSystemRestrict"] != DBNull.Value)
					{
						o.transSystemRestrict = Convert.ToBoolean(idr["transSystemRestrict"]);
					}
					if (idr["transGroupID"] != DBNull.Value)
					{
						o.transGroupID = Convert.ToInt32(idr["transGroupID"]);
					}
					if (idr["transIsCompound"] != DBNull.Value)
					{
						o.transIsCompound = Convert.ToBoolean(idr["transIsCompound"]);
					}
					if (idr["transType"] != DBNull.Value)
					{
						o.transType = Convert.ToInt32(idr["transType"]);
					}
                    if (idr["deptId"] != DBNull.Value)
                    {
                        o.deptId = Convert.ToInt32(idr["deptId"]);
                    }
				}
			}

			if (rtNull == true)
			{
				o = null;
			}

			return o;
		}

		private List<objTransaction> Select_ObjLi(IDataReader idr)
		{
			
			List<objTransaction> liO = new List<objTransaction>();

			bool rtNull = true;

			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;
                    objTransaction o = new objTransaction();

					if (idr["transID"] != DBNull.Value)
					{
						o.transID = Convert.ToInt32(idr["transID"]);
					}
					if (idr["transSystemIndex"] != DBNull.Value)
					{
						o.transSystemIndex = Convert.ToInt32(idr["transSystemIndex"]);
					}
					if (idr["transParticipantID"] != DBNull.Value)
					{
						o.transParticipantID = Convert.ToInt32(idr["transParticipantID"]);
					}
					if (idr["transRefID"] != DBNull.Value)
					{
						o.transRefID = Convert.ToString(idr["transRefID"]);
					}
					if (idr["transAttachedFiles"] != DBNull.Value)
					{
						o.transAttachedFiles = Convert.ToString(idr["transAttachedFiles"]);
					}
					if (idr["transInvoiceID"] != DBNull.Value)
					{
						o.transInvoiceID = Convert.ToInt32(idr["transInvoiceID"]);
					}
					if (idr["transDrAccount"] != DBNull.Value)
					{
						o.transDrAccount = Convert.ToInt32(idr["transDrAccount"]);
					}
					if (idr["transCrAccount"] != DBNull.Value)
					{
						o.transCrAccount = Convert.ToInt32(idr["transCrAccount"]);
					}
					if (idr["transNarration"] != DBNull.Value)
					{
						o.transNarration = Convert.ToString(idr["transNarration"]);
					}
					if (idr["transAmount"] != DBNull.Value)
					{
						o.transAmount = Convert.ToDecimal(idr["transAmount"]);
					}
					if (idr["transCreatedOn"] != DBNull.Value)
					{
						o.transCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
					}
					if (idr["transCreatedBy"] != DBNull.Value)
					{
						o.transCreatedBy = Convert.ToInt32(idr["transCreatedBy"]);
					}
					if (idr["transUpdatedOn"] != DBNull.Value)
					{
						o.transUpdatedOn = Convert.ToDateTime(idr["transUpdatedOn"]);
					}
					if (idr["transUpdatedBy"] != DBNull.Value)
					{
						o.transUpdatedBy = Convert.ToInt32(idr["transUpdatedBy"]);
					}
					if (idr["transStatus"] != DBNull.Value)
					{
						o.transStatus = Convert.ToInt32(idr["transStatus"]);
					}
					if (idr["transSystemRestrict"] != DBNull.Value)
					{
						o.transSystemRestrict = Convert.ToBoolean(idr["transSystemRestrict"]);
					}
					if (idr["transGroupID"] != DBNull.Value)
					{
						o.transGroupID = Convert.ToInt32(idr["transGroupID"]);
					}
					if (idr["transIsCompound"] != DBNull.Value)
					{
						o.transIsCompound = Convert.ToBoolean(idr["transIsCompound"]);
					}
					if (idr["transType"] != DBNull.Value)
					{
						o.transType = Convert.ToInt32(idr["transType"]);
					}
                    if (idr["deptId"] != DBNull.Value)
                    {
                        o.deptId = Convert.ToInt32(idr["deptId"]);
                    }
					liO.Add(o);
				}
			}

			if (rtNull == true)
			{
				liO = null;
			}

			return liO;
		}

		public class objTransaction
		{
			public int transID { get; set; }
			public int? transSystemIndex { get; set; }
			public int? transParticipantID { get; set; }
			public string transRefID { get; set; }
			public string transAttachedFiles { get; set; }
			public int? transInvoiceID { get; set; }
			public int? transDrAccount { get; set; }
			public int? transCrAccount { get; set; }
            public int? deptId { get; set; }
			public string transNarration { get; set; }
			public decimal transAmount { get; set; }
			public DateTime transCreatedOn { get; set; }
			public int transCreatedBy { get; set; }
			public DateTime transUpdatedOn { get; set; }
			public int transUpdatedBy { get; set; }
			public int transStatus { get; set; }
			public bool transSystemRestrict { get; set; }
			public int? transGroupID { get; set; }
			public bool transIsCompound { get; set; }
			public int? transType { get; set; }

			public Groups.objGroup Get_Group()
			{
				Groups.objGroup o = new Groups.objGroup();
				Groups gDB = new Groups();
				o = gDB.Select(transGroupID.Value);
				return o;
			}
		}
	}
}
