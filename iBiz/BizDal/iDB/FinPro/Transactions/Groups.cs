using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iDB.FinPro.Transactions
{
	public class Groups
	{
		SortedList<string, object> srt = new SortedList<string, object>();
		Communicate dbComm = new Communicate();

        public int? Add(int transGroupID, string transGroupTitle, DateTime transGroupCreatedOn, int transGroupCreatedBy, decimal transGroupTotalAmount, decimal? transGroupOfficialTotalAmount, int transTransCount, int? transGroupPrefixNo, string transGroupPrefixString, int? transGroupForeNumber, int transGroupStatus, int? transGroupApprovedBy, DateTime? transGroupApprovedOn, int? transGroupReviewedBy, DateTime? transGroupReviewedOn, int? transLinkedToGroup, int transGroupIsOfficial, string transGroupRefId, string transCField1, string transCField2, string transCField3, string transCField4)
		{
			int? rt = null;
			IDataReader idr = null;

			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("transGroupTitle", transGroupTitle);
			srt.Add("transGroupCreatedOn", transGroupCreatedOn);
			srt.Add("transGroupCreatedBy", transGroupCreatedBy);
			srt.Add("transGroupTotalAmount", transGroupTotalAmount);
            srt.Add("transGroupOfficialTotalAmount", transGroupOfficialTotalAmount);
			srt.Add("transTransCount", transTransCount);
			srt.Add("transGroupPrefixNo", transGroupPrefixNo);
			srt.Add("transGroupPrefixString", transGroupPrefixString);
			srt.Add("transGroupForeNumber", transGroupForeNumber);
			srt.Add("transGroupStatus", transGroupStatus);
			srt.Add("transGroupApprovedBy", transGroupApprovedBy);
			srt.Add("transGroupApprovedOn", transGroupApprovedOn);
			srt.Add("transGroupReviewedBy", transGroupReviewedBy);
			srt.Add("transGroupReviewedOn", transGroupReviewedOn);
			srt.Add("transLinkedToGroup", transLinkedToGroup);
            srt.Add("transGroupIsOfficial", transGroupIsOfficial);
            srt.Add("transGroupRefId", transGroupRefId);
            srt.Add("transCField1", transCField1);
            srt.Add("transCField2", transCField2);
            srt.Add("transCField3", transCField3);
            srt.Add("transCField4", transCField4);
			srt.Add("Flg", 1);

			idr = dbComm.SelectIDR(Communicate.StoredProcedures.TransGroups, srt);

			if (idr != null)
			{
				while (idr.Read())
				{
					rt = Convert.ToInt32(idr[0]);
				}
			}

			return rt;
		}

        public void Update(int transGroupID, string transGroupTitle, DateTime transGroupCreatedOn, int transGroupCreatedBy, decimal transGroupTotalAmount, decimal? transGroupOfficialTotalAmount, int transTransCount, int? transGroupPrefixNo, string transGroupPrefixString, int? transGroupForeNumber, int transGroupStatus, int? transGroupApprovedBy, DateTime? transGroupApprovedOn, int? transGroupReviewedBy, DateTime? transGroupReviewedOn, int? transLinkedToGroup, int transGroupIsOfficial, string transGroupRefId, string transCField1, string transCField2, string transCField3, string transCField4)
		{
			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("transGroupTitle", transGroupTitle);
			srt.Add("transGroupCreatedOn", transGroupCreatedOn);
			srt.Add("transGroupCreatedBy", transGroupCreatedBy);
			srt.Add("transGroupTotalAmount", transGroupTotalAmount);
            srt.Add("transGroupOfficialTotalAmount", transGroupOfficialTotalAmount);
			srt.Add("transTransCount", transTransCount);
			srt.Add("transGroupPrefixNo", transGroupPrefixNo);
			srt.Add("transGroupPrefixString", transGroupPrefixString);
			srt.Add("transGroupForeNumber", transGroupForeNumber);
			srt.Add("transGroupStatus", transGroupStatus);
			srt.Add("transGroupApprovedBy", transGroupApprovedBy);
			srt.Add("transGroupApprovedOn", transGroupApprovedOn);
			srt.Add("transGroupReviewedBy", transGroupReviewedBy);
			srt.Add("transGroupReviewedOn", transGroupReviewedOn);
			srt.Add("transLinkedToGroup", transLinkedToGroup);
			srt.Add("Flg", 2);
            srt.Add("transGroupIsOfficial", transGroupIsOfficial);
            srt.Add("transGroupRefId", transGroupRefId);
            srt.Add("transCField1", transCField1);
            srt.Add("transCField2", transCField2);
            srt.Add("transCField3", transCField3);
            srt.Add("transCField4", transCField4);
			dbComm.Execute(srt, Communicate.StoredProcedures.TransGroups);
		}

		public void Delete(int transGroupID)
		{
			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.TransGroups);
		}

		public IDataReader Select()
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.TransGroups, srt);
			return idr;
		}

		public IDataReader Select(int transGroupID)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("transGroupID", transGroupID);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.TransGroups, srt);
			return idr;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrefixNo"></param>
        /// <param name="PrefixString"></param>
        /// <param name="transGroupCreatedOn">Refreshes Every month</param>
        /// <returns></returns>
        public int Get_Last_Fore_Number(int PrefixNo, string PrefixString, DateTime voucharDate)
        {
            int rt = 1;

            IDataReader idr = null;
            srt.Clear();
            srt.Add("transGroupPrefixNo", PrefixNo);
            srt.Add("transGroupPrefixString", PrefixString);
            srt.Add("transGroupCreatedOn", voucharDate);
            srt.Add("Flg", 6);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.TransGroups, srt);

            if (idr != null)
            {
                while (idr.Read())
                {
                    rt = Convert.ToInt32(idr["maxForeNo"]);
                }
            }

            return rt;
        }
	}
}
