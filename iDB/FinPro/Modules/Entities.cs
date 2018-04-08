using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.FinPro.Modules
{
    public class Entities
    {
        Communicate dbComm = new Communicate();
        SortedList<string, object> srt = new SortedList<string, object>();
        public void Add(int entityId, int entityType, string entityTitle, string entityDescription, string entityFirstName, string entityLastName, string entityEmail, string entityAltEmail, string entityAddress, string entityCity, string entityZip, int? entityCountry, string entityState, string entityPhone, string entityAltPhone, string entityMobile, string entityAltMobile, string entityFax, string entityAltFax, int entityStatus, int entityAccountId, string entityAccountTitle, DateTime entityCreatedOn, int entityCreatedBy, int entityLastUpdatedBy, DateTime entityLastUpdateOn)
        {
            srt.Clear();
            srt.Add("entityId", entityId);
            srt.Add("entityType", entityType);
            srt.Add("entityTitle", entityTitle);
            srt.Add("entityDescription", entityDescription);
            srt.Add("entityFirstName", entityFirstName);
            srt.Add("entityLastName", entityLastName);
            srt.Add("entityEmail", entityEmail);
            srt.Add("entityAltEmail", entityAltEmail);
            srt.Add("entityAddress", entityAddress);
            srt.Add("entityCity", entityCity);
            srt.Add("entityZip", entityZip);
            srt.Add("entityCountry", entityCountry);
            srt.Add("entityState", entityState);
            srt.Add("entityPhone", entityPhone);
            srt.Add("entityAltPhone", entityAltPhone);
            srt.Add("entityMobile", entityMobile);
            srt.Add("entityAltMobile", entityAltMobile);
            srt.Add("entityFax", entityFax);
            srt.Add("entityAltFax", entityAltFax);
            srt.Add("entityStatus", entityStatus);
            srt.Add("entityAccountId", entityAccountId);
            srt.Add("entityAccountTitle", entityAccountTitle);
            srt.Add("entityCreatedOn", entityCreatedOn);
            srt.Add("entityCreatedBy", entityCreatedBy);
            srt.Add("entityLastUpdatedBy", entityLastUpdatedBy);
            srt.Add("entityLastUpdateOn", entityLastUpdateOn);

            srt.Add("Flg", 1);
            dbComm.Execute(srt, Communicate.StoredProcedures.Entities);
        }
        public void Update(int entityId, int entityType, string entityTitle, string entityDescription, string entityFirstName, string entityLastName, string entityEmail, string entityAltEmail, string entityAddress, string entityCity, string entityZip, int? entityCountry, string entityState, string entityPhone, string entityAltPhone, string entityMobile, string entityAltMobile, string entityFax, string entityAltFax, int entityStatus, int entityAccountId, string entityAccountTitle, DateTime entityCreatedOn, int entityCreatedBy, int entityLastUpdatedBy, DateTime entityLastUpdateOn)
        {
            srt.Clear();
            srt.Add("entityId", entityId);
            srt.Add("entityType", entityType);
            srt.Add("entityTitle", entityTitle);
            srt.Add("entityDescription", entityDescription);
            srt.Add("entityFirstName", entityFirstName);
            srt.Add("entityLastName", entityLastName);
            srt.Add("entityEmail", entityEmail);
            srt.Add("entityAltEmail", entityAltEmail);
            srt.Add("entityAddress", entityAddress);
            srt.Add("entityCity", entityCity);
            srt.Add("entityZip", entityZip);
            srt.Add("entityCountry", entityCountry);
            srt.Add("entityState", entityState);
            srt.Add("entityPhone", entityPhone);
            srt.Add("entityAltPhone", entityAltPhone);
            srt.Add("entityMobile", entityMobile);
            srt.Add("entityAltMobile", entityAltMobile);
            srt.Add("entityFax", entityFax);
            srt.Add("entityAltFax", entityAltFax);
            srt.Add("entityStatus", entityStatus);
            srt.Add("entityAccountId", entityAccountId);
            srt.Add("entityAccountTitle", entityAccountTitle);
            srt.Add("entityCreatedOn", entityCreatedOn);
            srt.Add("entityCreatedBy", entityCreatedBy);
            srt.Add("entityLastUpdatedBy", entityLastUpdatedBy);
            srt.Add("entityLastUpdateOn", entityLastUpdateOn);

            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.Entities);
        }
        public void Delete(int entityId)
        {
            srt.Clear();
            srt.Add("entityId", entityId);

            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.Entities);
        }
        public IDataReader Select()
        {
            srt.Clear();
            IDataReader idr = null;
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Entities, srt);
            return idr;
        }
        public IDataReader Select(int entityId)
        {
            srt.Clear();
            IDataReader idr = null;
            srt.Add("entityId", entityId);

            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Entities, srt);
            return idr;
        }

    }

}
