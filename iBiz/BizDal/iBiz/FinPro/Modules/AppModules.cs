using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iBiz.FinPro.Modules
{
    public class fin_Modules
    {
        iDB.FinPro.Modules.fin_Modules db = new iDB.FinPro.Modules.fin_Modules();
        public void Add(objfin_Modules i)
        {
            db.Add(i.moduleId, i.moduleTitle, i.moduleDescription, i.moduleIsOffial, i.CField1, i.CField2, i.CField3, i.CField4);
        }
        public void Update(objfin_Modules i)
        {
            db.Update(i.moduleId, i.moduleTitle, i.moduleDescription, i.moduleIsOffial, i.CField1, i.CField2, i.CField3, i.CField4);
        }
        public void Delete(int moduleId)
        {
            db.Delete(moduleId);
        }

        public IDataReader Select()
        {
            return db.Select();
        }
        public objfin_Modules Select(int moduleId)
        {
            IDataReader idr = db.Select(moduleId);
            return Select_Obj(idr);
        }

        public IDataReader Get_Preselected_Items(int moduleId, int moduleIParameterId, bool isOfficial)
        {
            iDB.Communicate dbComm = new iDB.Communicate();

            IDataReader idr = null;
            string query = string.Format("exec SP_fin_Preselected_Vouchar_Accounts @moduleId={0}, @moduleParameterId={1}, @moduleIsOfficial={2}", moduleId, moduleIParameterId, isOfficial);

            idr = dbComm.SelectCMD(query);

            return idr;
        }

        private objfin_Modules Select_Obj(IDataReader idr)
        {
            objfin_Modules o = new objfin_Modules();
            bool rtNull = true;
            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["moduleId"] != DBNull.Value)
                    {
                        o.moduleId = Convert.ToInt32(idr["moduleId"]);
                    }
                    if (idr["moduleTitle"] != DBNull.Value)
                    {
                        o.moduleTitle = Convert.ToString(idr["moduleTitle"]);
                    }
                    if (idr["moduleDescription"] != DBNull.Value)
                    {
                        o.moduleDescription = Convert.ToString(idr["moduleDescription"]);
                    }
                    if (idr["moduleIsOffial"] != DBNull.Value)
                    {
                        o.moduleIsOffial = Convert.ToBoolean(idr["moduleIsOffial"]);
                    }
                    if (idr["CField1"] != DBNull.Value)
                    {
                        o.CField1 = Convert.ToString(idr["CField1"]);
                    }
                    if (idr["CField2"] != DBNull.Value)
                    {
                        o.CField2 = Convert.ToString(idr["CField2"]);
                    }
                    if (idr["CField3"] != DBNull.Value)
                    {
                        o.CField3 = Convert.ToString(idr["CField3"]);
                    }
                    if (idr["CField4"] != DBNull.Value)
                    {
                        o.CField4 = Convert.ToString(idr["CField4"]);
                    }
                }
            }
            if (rtNull)
            {
                o = null;
            }
            return o;
        }


        public class objfin_Modules
        {
            public int moduleId { get; set; }
            public string moduleTitle { get; set; }
            public string moduleDescription { get; set; }
            public bool moduleIsOffial { get; set; }
            public string CField1 { get; set; }
            public string CField2 { get; set; }
            public string CField3 { get; set; }
            public string CField4 { get; set; }

        }

    }

}
