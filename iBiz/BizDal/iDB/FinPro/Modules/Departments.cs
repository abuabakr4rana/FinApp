using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.FinPro.Modules
{
    public class Departments
    {
        Communicate dbComm = new Communicate();
        SortedList<string, object> srt = new SortedList<string, object>();
        public void Add(int deptId, string deptTitle, string deptCode, string deptDescription)
        {
            srt.Add("deptId", deptId);
            srt.Add("deptTitle", deptTitle);
            srt.Add("deptCode", deptCode);
            srt.Add("deptDescription", deptDescription);

            srt.Add("Flg", 1);
            dbComm.Execute(srt, Communicate.StoredProcedures.Departments);
        }
        public void Update(int deptId, string deptTitle, string deptCode, string deptDescription)
        {
            srt.Add("deptId", deptId);
            srt.Add("deptTitle", deptTitle);
            srt.Add("deptCode", deptCode);
            srt.Add("deptDescription", deptDescription);

            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.Departments);
        }
        public void Delete(int deptId)
        {
            srt.Add("deptId", deptId);

            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.Departments);
        }
        public IDataReader Select()
        {
            IDataReader idr = null;
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Departments, srt);
            return idr;
        }
        public IDataReader Select(int deptId)
        {
            IDataReader idr = null;
            srt.Add("deptId", deptId);

            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Departments, srt);
            return idr;
        }

    }

}
