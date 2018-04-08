using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iDB.FinPro
{
	public class FinYears
	{
        SortedList<string, object> srt = new SortedList<string, object>();
        Communicate dbComm = new Communicate();

        public void Add(int finyrID, DateTime startDate, DateTime endDate, bool status)
        {
            srt.Clear();
            srt.Add("finyrID", finyrID);
            srt.Add("startDate", startDate);
            srt.Add("endDate", endDate);
            srt.Add("status", status);
            srt.Add("Flg", 1);

            dbComm.Execute(srt, Communicate.StoredProcedures.FinYear);
        }

        public void Update(int finyrID, DateTime startDate, DateTime endDate, bool status)
        {
            srt.Clear();
            srt.Add("finyrID", finyrID);
            srt.Add("startDate", startDate);
            srt.Add("endDate", endDate);
            srt.Add("status", status);
            srt.Add("Flg", 2);

            dbComm.Execute(srt, Communicate.StoredProcedures.FinYear);
        }

        public void Delete(int userID)
        {
            srt.Clear();
            srt.Add("finyrID", userID);
            srt.Add("Flg", 3);

            dbComm.Execute(srt, Communicate.StoredProcedures.FinYear);
        }

        public IDataReader Select()
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.FinYear , srt);
            return idr;
        }

		public IDataReader Select(int finyrId)
		{
			IDataReader idr = null;
			srt.Clear();
			srt.Add("finyrID", finyrId);
			srt.Add("Flg", 5);
			idr = dbComm.SelectIDR(Communicate.StoredProcedures.FinYear, srt);
			return idr;
		}


        public IDataReader SelectForStatus(DateTime d, bool status)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("inputDate", d);
			srt.Add("status", status);
			srt.Add("Flg", 6);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.FinYear, srt);
            return idr;
        }

	}
}
