using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.FinPro.Modules
{
    public class EntityType
    {
        Communicate dbComm = new Communicate();
        SortedList<string, object> srt = new SortedList<string, object>();
        public void Add(int entityType, string entityTypeTitle)
        {
            srt.Clear();
            srt.Add("entityType", entityType);
            srt.Add("entityTypeTitle", entityTypeTitle);

            srt.Add("Flg", 1);
            dbComm.Execute(srt, Communicate.StoredProcedures.EntityTypes);
        }
        public void Update(int entityType, string entityTypeTitle)
        {
            srt.Clear();
            srt.Add("entityType", entityType);
            srt.Add("entityTypeTitle", entityTypeTitle);

            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.EntityTypes);
        }
        public void Delete(int entityType)
        {
            srt.Clear();
            srt.Add("entityType", entityType);

            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.EntityTypes);
        }
        public IDataReader Select()
        {
            srt.Clear();
            IDataReader idr = null;
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.EntityTypes, srt);
            return idr;
        }
        public IDataReader Select(int entityType)
        {
            srt.Clear();
            IDataReader idr = null;
            srt.Add("entityType", entityType);

            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.EntityTypes, srt);
            return idr;
        }

    }

}
