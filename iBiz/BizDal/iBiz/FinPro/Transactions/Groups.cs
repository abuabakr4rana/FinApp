using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Transactions
{
	public class Groups
	{
		iDB.FinPro.Transactions.Groups db = new iDB.FinPro.Transactions.Groups();

		public int? Add(objGroup i)
		{
			return db.Add(
            i.transGroupID, i.transGroupTitle, i.transGroupCreatedOn, i.transGroupCreatedBy, i.transGroupTotalAmount, i.transGroupOfficialTotalAmount, i.transTransCount, i.transGroupPrefixNo, i.transGroupPrefixString, i.transGroupForeNumber, i.transGroupStatus, i.transGroupApprovedBy, i.transGroupApprovedOn, i.transGroupReviewedBy, i.transGroupReviewedOn, i.transLinkedToGroup, i.transGroupIsOfficial, i.transGroupRefId, i.transCField1, i.transCField2, i.transCField3, i.transCField4);
		}

		public void Update(objGroup i)
		{
			db.Update(
            i.transGroupID, i.transGroupTitle, i.transGroupCreatedOn, i.transGroupCreatedBy, i.transGroupTotalAmount, i.transGroupOfficialTotalAmount, i.transTransCount, i.transGroupPrefixNo, i.transGroupPrefixString, i.transGroupForeNumber, i.transGroupStatus, i.transGroupApprovedBy, i.transGroupApprovedOn, i.transGroupReviewedBy, i.transGroupReviewedOn, i.transLinkedToGroup, i.transGroupIsOfficial, i.transGroupRefId, i.transCField1, i.transCField2, i.transCField3, i.transCField4);
		}

		public void Delete(int i)
		{
			db.Delete(i);
		}

		public IDataReader Select()
		{
			return db.Select();
		}
        public List<objGroup> SelectAllGroups()
        {
            IDataReader idr = db.Select();
            List<objGroup> rt = Select_liObj(idr);
            return rt;
        }

        public objGroup Select(int transGroupID)
		{
			IDataReader idr = null;
			objGroup o = new objGroup();

			try
			{
				idr = db.Select(transGroupID);
				o = Select_Obj(idr);	
			}
			catch (Exception)
			{	
				throw;
			}
			finally
			{
				if (!idr.Equals(null))
				{
					idr.Dispose();
				}
			}

			return o;
		}

        public int New_Group_Fore_Number(int PrefixNo, string PrefixString, DateTime voucharDate)
        {
            int rt = 1 + db.Get_Last_Fore_Number(PrefixNo, PrefixString, voucharDate);
            return rt;
        }

        public decimal Get_Total_Debit(int transGroupId)
        {
            decimal rt = 0;
            
            return rt;
        }

        public void MarkGroupApproved(int groupId, int approvedBy)
        {
            Transact bTrans = new Transact();

            objGroup o = new objGroup();
            o = Select(groupId);

            if (o != null)
            {
                o.transGroupApprovedBy = approvedBy;
                o.transGroupApprovedOn = DateTime.Now;
                o.transGroupStatus = 2;
                Update(o);

                bTrans.MarkGroupItemsApproved(groupId);
            }
        }

		private objGroup Select_Obj(IDataReader idr)
		{
			objGroup o = new objGroup();
			bool rtNull = true;

			if (idr != null)
			{
				while (idr.Read())
				{
					rtNull = false;

					if (idr["transGroupID"] != DBNull.Value)
					{
						o.transGroupID = Convert.ToInt32(idr["transGroupID"]);
					}
					if (idr["transGroupTitle"] != DBNull.Value)
					{
						o.transGroupTitle = Convert.ToString(idr["transGroupTitle"]);
					}
					if (idr["transGroupCreatedOn"] != DBNull.Value)
					{
						o.transGroupCreatedOn = Convert.ToDateTime(idr["transGroupCreatedOn"]);
					}
					if (idr["transGroupCreatedBy"] != DBNull.Value)
					{
						o.transGroupCreatedBy = Convert.ToInt32(idr["transGroupCreatedBy"]);
					}
					if (idr["transGroupTotalAmount"] != DBNull.Value)
					{
						o.transGroupTotalAmount = Convert.ToDecimal(idr["transGroupTotalAmount"]);
					}
                    if (idr["transGroupOfficialTotalAmount"] != DBNull.Value)
                    {
                        o.transGroupOfficialTotalAmount = Convert.ToDecimal(idr["transGroupOfficialTotalAmount"]);
                    }
					if (idr["transTransCount"] != DBNull.Value)
					{
						o.transTransCount = Convert.ToInt32(idr["transTransCount"]);
					}
					if (idr["transGroupPrefixNo"] != DBNull.Value)
					{
						o.transGroupPrefixNo = Convert.ToInt32(idr["transGroupPrefixNo"]);
					}
					if (idr["transGroupPrefixString"] != DBNull.Value)
					{
						o.transGroupPrefixString = Convert.ToString(idr["transGroupPrefixString"]);
					}
					if (idr["transGroupForeNumber"] != DBNull.Value)
					{
						o.transGroupForeNumber = Convert.ToInt32(idr["transGroupForeNumber"]);
					}
					if (idr["transGroupStatus"] != DBNull.Value)
					{
						o.transGroupStatus = Convert.ToInt32(idr["transGroupStatus"]);
					}
					if (idr["transGroupApprovedBy"] != DBNull.Value)
					{
						o.transGroupApprovedBy = Convert.ToInt32(idr["transGroupApprovedBy"]);
					}
					if (idr["transGroupApprovedOn"] != DBNull.Value)
					{
						o.transGroupApprovedOn = Convert.ToDateTime(idr["transGroupApprovedOn"]);
					}
					if (idr["transGroupReviewedBy"] != DBNull.Value)
					{
						o.transGroupReviewedBy = Convert.ToInt32(idr["transGroupReviewedBy"]);
					}
					if (idr["transGroupReviewedOn"] != DBNull.Value)
					{
						o.transGroupReviewedOn = Convert.ToDateTime(idr["transGroupReviewedOn"]);
					}
					if (idr["transLinkedToGroup"] != DBNull.Value)
					{
						o.transLinkedToGroup = Convert.ToInt32(idr["transLinkedToGroup"]);
					}
                    if (idr["transGroupIsOfficial"] != DBNull.Value)
                    {
                        o.transGroupIsOfficial = Convert.ToInt32(idr["transGroupIsOfficial"]);
                    }
                    if (idr["transGroupRefId"] != DBNull.Value)
                    {
                        o.transGroupRefId = idr["transGroupRefId"].ToString();
                    }
                    if (idr["transCField1"] != DBNull.Value)
                    {
                        o.transCField1 = idr["transCField1"].ToString();
                    }
                    if (idr["transCField2"] != DBNull.Value)
                    {
                        o.transCField2 = idr["transCField2"].ToString();
                    }
                    if (idr["transCField3"] != DBNull.Value)
                    {
                        o.transCField3 = idr["transCField3"].ToString();
                    }
                    if (idr["transCField4"] != DBNull.Value)
                    {
                        o.transCField4 = idr["transCField4"].ToString();
                    }
				}
			}

			if (rtNull)
			{
				o = null;
			}

			return o;
		}

        private List<objGroup> Select_liObj(IDataReader idr)
        {
            List<objGroup> rt = new List<objGroup>();
            bool rtNull = true;

            if (idr != null)
            {
                while (idr.Read())
                {
                    objGroup o = new objGroup();
                    rtNull = false;

                    if (idr["transGroupID"] != DBNull.Value)
                    {
                        o.transGroupID = Convert.ToInt32(idr["transGroupID"]);
                    }
                    if (idr["transGroupTitle"] != DBNull.Value)
                    {
                        o.transGroupTitle = Convert.ToString(idr["transGroupTitle"]);
                    }
                    if (idr["transGroupCreatedOn"] != DBNull.Value)
                    {
                        o.transGroupCreatedOn = Convert.ToDateTime(idr["transGroupCreatedOn"]);
                    }
                    if (idr["transGroupCreatedBy"] != DBNull.Value)
                    {
                        o.transGroupCreatedBy = Convert.ToInt32(idr["transGroupCreatedBy"]);
                    }
                    if (idr["transGroupTotalAmount"] != DBNull.Value)
                    {
                        o.transGroupTotalAmount = Convert.ToDecimal(idr["transGroupTotalAmount"]);
                    }
                    if (idr["transGroupOfficialTotalAmount"] != DBNull.Value)
                    {
                        o.transGroupOfficialTotalAmount = Convert.ToDecimal(idr["transGroupOfficialTotalAmount"]);
                    }
                    if (idr["transTransCount"] != DBNull.Value)
                    {
                        o.transTransCount = Convert.ToInt32(idr["transTransCount"]);
                    }
                    if (idr["transGroupPrefixNo"] != DBNull.Value)
                    {
                        o.transGroupPrefixNo = Convert.ToInt32(idr["transGroupPrefixNo"]);
                    }
                    if (idr["transGroupPrefixString"] != DBNull.Value)
                    {
                        o.transGroupPrefixString = Convert.ToString(idr["transGroupPrefixString"]);
                    }
                    if (idr["transGroupForeNumber"] != DBNull.Value)
                    {
                        o.transGroupForeNumber = Convert.ToInt32(idr["transGroupForeNumber"]);
                    }
                    if (idr["transGroupStatus"] != DBNull.Value)
                    {
                        o.transGroupStatus = Convert.ToInt32(idr["transGroupStatus"]);
                    }
                    if (idr["transGroupApprovedBy"] != DBNull.Value)
                    {
                        o.transGroupApprovedBy = Convert.ToInt32(idr["transGroupApprovedBy"]);
                    }
                    if (idr["transGroupApprovedOn"] != DBNull.Value)
                    {
                        o.transGroupApprovedOn = Convert.ToDateTime(idr["transGroupApprovedOn"]);
                    }
                    if (idr["transGroupReviewedBy"] != DBNull.Value)
                    {
                        o.transGroupReviewedBy = Convert.ToInt32(idr["transGroupReviewedBy"]);
                    }
                    if (idr["transGroupReviewedOn"] != DBNull.Value)
                    {
                        o.transGroupReviewedOn = Convert.ToDateTime(idr["transGroupReviewedOn"]);
                    }
                    if (idr["transLinkedToGroup"] != DBNull.Value)
                    {
                        o.transLinkedToGroup = Convert.ToInt32(idr["transLinkedToGroup"]);
                    }
                    if (idr["transGroupIsOfficial"] != DBNull.Value)
                    {
                        o.transGroupIsOfficial = Convert.ToInt32(idr["transGroupIsOfficial"]);
                    }
                    if (idr["transGroupRefId"] != DBNull.Value)
                    {
                        o.transGroupRefId = idr["transGroupRefId"].ToString();
                    }
                    if (idr["transCField1"] != DBNull.Value)
                    {
                        o.transCField1 = idr["transCField1"].ToString();
                    }
                    if (idr["transCField2"] != DBNull.Value)
                    {
                        o.transCField2 = idr["transCField2"].ToString();
                    }
                    if (idr["transCField3"] != DBNull.Value)
                    {
                        o.transCField3 = idr["transCField3"].ToString();
                    }
                    if (idr["transCField4"] != DBNull.Value)
                    {
                        o.transCField4 = idr["transCField4"].ToString();
                    }
                    rt.Add(o);
                }
            }

            if (rtNull)
            {
                rt = null;
            }

            return rt;
        }

        public class objGroup
		{
			public int transGroupID { get; set; }
			public string transGroupTitle { get; set; }
			public DateTime transGroupCreatedOn { get; set; }
			public int transGroupCreatedBy { get; set; }
			public decimal transGroupTotalAmount { get; set; }
            public decimal? transGroupOfficialTotalAmount { get; set; }
			public int transTransCount { get; set; }
			public int? transGroupPrefixNo { get; set; }
			public string transGroupPrefixString { get; set; }
			public int? transGroupForeNumber { get; set; }
			public int transGroupStatus { get; set; }
			public int? transGroupApprovedBy { get; set; }
			public DateTime? transGroupApprovedOn { get; set; }
			public int? transGroupReviewedBy { get; set; }
			public DateTime? transGroupReviewedOn { get; set; }
			public int? transLinkedToGroup { get; set; }
            public int transGroupIsOfficial { get; set; }
            public string transGroupRefId { get; set; }
            public string transCField1 { get; set; }
            public string transCField2 { get; set; }
            public string transCField3 { get; set; }
            public string transCField4 { get; set; }
			public List<Transact.objTransaction> Get_Transactions(bool isOffical)
			{
				List<Transact.objTransaction> o = new List<Transact.objTransaction>();
				Transact tDB = new Transact();
				o = tDB.Select_GrpLi(transGroupID, isOffical);
				return o;
			}

            public List<Transact.objTransaction> Get_Transactions()
            {
                List<Transact.objTransaction> o = new List<Transact.objTransaction>();
                Transact tDB = new Transact();
                o = tDB.Select_GrpLi(transGroupID);
                return o;
            }

            public decimal Get_Total_Debit()
            {
                iBiz.FinPro.Transactions.Transact bTrans = new Transact();
                return bTrans.Get_Total_Debit_For_Group(transGroupID);
            }

            public decimal Get_Total_Credit()
            {
                iBiz.FinPro.Transactions.Transact bTrans = new Transact();
                return bTrans.Get_Total_Credit_For_Group(transGroupID);
            }
		}
	}
}
