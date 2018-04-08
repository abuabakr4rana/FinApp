using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iBiz.FinPro.Modules
{
    public class EntiityType
    {
        iDB.FinPro.Modules.EntityType db = new iDB.FinPro.Modules.EntityType();
        public void Add(objEntityType i)
        {
            db.Add(i.entityType, i.entityTypeTitle);
        }
        public void Update(objEntityType i)
        {
            db.Update(i.entityType, i.entityTypeTitle);
        }
        public void Delete(int entityType)
        {
            db.Delete(entityType);
        }

        public IDataReader Select()
        {
            return db.Select();
        }
        public objEntityType Select(int entityType)
        {
            IDataReader idr = db.Select(entityType);
            return Select_Obj(idr);
        }

        private objEntityType Select_Obj(IDataReader idr)
        {
            objEntityType o = new objEntityType();
            bool rtNull = true;
            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["entityType"] != DBNull.Value)
                    {
                        o.entityType = Convert.ToInt32(idr["entityType"]);
                    }
                    if (idr["entityTypeTitle"] != DBNull.Value)
                    {
                        o.entityTypeTitle = Convert.ToString(idr["entityTypeTitle"]);
                    }
                }
            }
            if (rtNull)
            {
                o = null;
            }
            return o;
        }


        public class objEntityType
        {
            public int entityType { get; set; }
            public string entityTypeTitle { get; set; }

        }

    }

}
