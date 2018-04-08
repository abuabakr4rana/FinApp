using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iBiz.FinPro.Modules
{
    public class Departments
    {
        iDB.FinPro.Modules.Departments db = new iDB.FinPro.Modules.Departments();
        public void Add(objfin_Departments i)
        {
            db.Add(i.deptId, i.deptTitle, i.deptCode, i.deptDescription);
        }
        public void Update(objfin_Departments i)
        {
            db.Update(i.deptId, i.deptTitle, i.deptCode, i.deptDescription);
        }
        public void Delete(int deptId)
        {
            db.Delete(deptId);
        }

        public IDataReader Select()
        {
            return db.Select();
        }
        public objfin_Departments Select(int deptId)
        {
            IDataReader idr = db.Select(deptId);
            return Select_Obj(idr);
        }

        private objfin_Departments Select_Obj(IDataReader idr)
        {
            objfin_Departments o = new objfin_Departments();
            bool rtNull = true;
            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["deptId"] != DBNull.Value)
                    {
                        o.deptId = Convert.ToInt32(idr["deptId"]);
                    }
                    if (idr["deptTitle"] != DBNull.Value)
                    {
                        o.deptTitle = Convert.ToString(idr["deptTitle"]);
                    }
                    if (idr["deptCode"] != DBNull.Value)
                    {
                        o.deptCode = Convert.ToString(idr["deptCode"]);
                    }
                    if (idr["deptDescription"] != DBNull.Value)
                    {
                        o.deptDescription = Convert.ToString(idr["deptDescription"]);
                    }
                }
            }
            if (rtNull)
            {
                o = null;
            }
            return o;
        }


        public class objfin_Departments
        {
            public int deptId { get; set; }
            public string deptTitle { get; set; }
            public string deptCode { get; set; }
            public string deptDescription { get; set; }

        }

    }

}
