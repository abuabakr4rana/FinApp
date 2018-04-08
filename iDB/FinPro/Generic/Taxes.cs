using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.Generic
{
	public class fin_Taxes
	{
		Communicate dbComm = new Communicate();
		SortedList<string, object> srt = new SortedList<string, object>();
		public void Add(int taxId, string taxTitle, decimal taxValue, bool taxTypeIsPercent, int taxCreatedBy, DateTime taxCreatedOn, string taxCreatedIP, int taxAccountId, string taxTransNarration)
		{
			srt.Clear();
			srt.Add("taxId", taxId);
			srt.Add("taxTitle", taxTitle);
			srt.Add("taxValue", taxValue);
			srt.Add("taxTypeIsPercent", taxTypeIsPercent);
			srt.Add("taxCreatedBy", taxCreatedBy);
			srt.Add("taxCreatedOn", taxCreatedOn);
			srt.Add("taxCreatedIP", taxCreatedIP);
			srt.Add("taxAccountId", taxAccountId);
			srt.Add("taxTransNarration", taxTransNarration);
			srt.Add("Flg", 1);
			dbComm.Execute(srt, Communicate.StoredProcedures.Taxes);
		}
		public void Update(int taxId, string taxTitle, decimal taxValue, bool taxTypeIsPercent, int taxCreatedBy, DateTime taxCreatedOn, string taxCreatedIP, int taxAccountId, string taxTransNarration)
		{
			srt.Clear();
			srt.Add("taxId", taxId);
			srt.Add("taxTitle", taxTitle);
			srt.Add("taxValue", taxValue);
			srt.Add("taxTypeIsPercent", taxTypeIsPercent);
			srt.Add("taxCreatedBy", taxCreatedBy);
			srt.Add("taxCreatedOn", taxCreatedOn);
			srt.Add("taxCreatedIP", taxCreatedIP);
			srt.Add("taxAccountId", taxAccountId);
			srt.Add("taxTransNarration", taxTransNarration);
			srt.Add("Flg", 2);
			dbComm.Execute(srt, Communicate.StoredProcedures.Taxes);
		}
		public void Delete(int taxId)
		{
			srt.Clear();
			srt.Add("taxId", taxId);

			srt.Add("Flg", 3);
			dbComm.Execute(srt, Communicate.StoredProcedures.Taxes);
		}
		public IDataReader Select()
		{
			srt.Clear();
			IDataReader idr = null;
			srt.Add("Flg", 4);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Taxes, srt);
			return idr;
		}
		public IDataReader Select(int taxId)
		{
			srt.Clear();
			IDataReader idr = null;
			srt.Add("taxId", taxId);

			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.Taxes, srt);
			return idr;
		}

	}

}
