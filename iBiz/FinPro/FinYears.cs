using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iBiz.FinPro
{
    public class FinYears
    {
        iDB.FinPro.FinYears db = new iDB.FinPro.FinYears();

        public void AddFinYear(objFinYears i) {

            db.Add(i.FinYrId, i.StartDate, i.EndDate, i.Status);

        }

        public void UpdateFinYear(objFinYears i)
        {

            db.Update(i.FinYrId, i.StartDate, i.EndDate, i.Status);

        }

        public void DeleteFinYear(int i)
        {

            db.Delete(i);

        }

        public IDataReader Select()
        {
            return db.Select();
        }

        public bool isLock(DateTime inputDate)
        {
            objFinYears o = new objFinYears();
            IDataReader idr = db.SelectForStatus(inputDate, true);
            o = Select_Obj(idr);

			if (o != null)
			{
				return o.Status;
			}
			else
			{
				return false;
			}
        }

        public objFinYears Select_Obj(IDataReader idr)
        {
            objFinYears o = new objFinYears();
            bool rtNull = true;

            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;

                    if (idr["status"] != DBNull.Value)
                    {
						o.FinYrId = Convert.ToInt32(idr["finyrId"]);
						o.StartDate = Convert.ToDateTime(idr["startDate"]);
						o.EndDate = Convert.ToDateTime(idr["endDate"]);
						o.Status = Convert.ToBoolean(idr["status"]);
                    }
                }
            }

            if (rtNull)
            {
                o = null;
            }

            return o;
        }


        public class objFinYears
        {
            public int FinYrId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool Status { get; set; }

        }


    }
}
