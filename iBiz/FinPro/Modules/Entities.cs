using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iBiz.FinPro.Modules
{
    public class Entities
    {
        iDB.FinPro.Modules.Entities db = new iDB.FinPro.Modules.Entities();
        public void Add(objEntity i)
        {
            db.Add(i.entityId, i.entityType, i.entityTitle, i.entityDescription, i.entityFirstName, i.entityLastName, i.entityEmail, i.entityAltEmail, i.entityAddress, i.entityCity, i.entityZip, i.entityCountry, i.entityState, i.entityPhone, i.entityAltPhone, i.entityMobile, i.entityAltMobile, i.entityFax, i.entityAltFax, i.entityStatus, i.entityAccountId, i.entityAccountTitle, i.entityCreatedOn, i.entityCreatedBy, i.entityLastUpdatedBy, i.entityLastUpdateOn);
        }
        public void Update(objEntity i)
        {
            db.Update(i.entityId, i.entityType, i.entityTitle, i.entityDescription, i.entityFirstName, i.entityLastName, i.entityEmail, i.entityAltEmail, i.entityAddress, i.entityCity, i.entityZip, i.entityCountry, i.entityState, i.entityPhone, i.entityAltPhone, i.entityMobile, i.entityAltMobile, i.entityFax, i.entityAltFax, i.entityStatus, i.entityAccountId, i.entityAccountTitle, i.entityCreatedOn, i.entityCreatedBy, i.entityLastUpdatedBy, i.entityLastUpdateOn);
        }
        public void Delete(int entityId)
        {
            db.Delete(entityId);
        }

        public IDataReader Select()
        {
            return db.Select();
        }
        public objEntity Select(int entityId)
        {
            IDataReader idr = db.Select(entityId);
            return Select_Obj(idr);
        }

        private objEntity Select_Obj(IDataReader idr)
        {
            objEntity o = new objEntity();
            bool rtNull = true;
            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["entityId"] != DBNull.Value)
                    {
                        o.entityId = Convert.ToInt32(idr["entityId"]);
                    }
                    if (idr["entityType"] != DBNull.Value)
                    {
                        o.entityType = Convert.ToInt32(idr["entityType"]);
                    }
                    if (idr["entityTitle"] != DBNull.Value)
                    {
                        o.entityTitle = Convert.ToString(idr["entityTitle"]);
                    }
                    if (idr["entityDescription"] != DBNull.Value)
                    {
                        o.entityDescription = Convert.ToString(idr["entityDescription"]);
                    }
                    if (idr["entityFirstName"] != DBNull.Value)
                    {
                        o.entityFirstName = Convert.ToString(idr["entityFirstName"]);
                    }
                    if (idr["entityLastName"] != DBNull.Value)
                    {
                        o.entityLastName = Convert.ToString(idr["entityLastName"]);
                    }
                    if (idr["entityEmail"] != DBNull.Value)
                    {
                        o.entityEmail = Convert.ToString(idr["entityEmail"]);
                    }
                    if (idr["entityAltEmail"] != DBNull.Value)
                    {
                        o.entityAltEmail = Convert.ToString(idr["entityAltEmail"]);
                    }
                    if (idr["entityAddress"] != DBNull.Value)
                    {
                        o.entityAddress = Convert.ToString(idr["entityAddress"]);
                    }
                    if (idr["entityCity"] != DBNull.Value)
                    {
                        o.entityCity = Convert.ToString(idr["entityCity"]);
                    }
                    if (idr["entityZip"] != DBNull.Value)
                    {
                        o.entityZip = Convert.ToString(idr["entityZip"]);
                    }
                    if (idr["entityCountry"] != DBNull.Value)
                    {
                        o.entityCountry = Convert.ToInt32(idr["entityCountry"]);
                    }
                    if (idr["entityState"] != DBNull.Value)
                    {
                        o.entityState = Convert.ToString(idr["entityState"]);
                    }
                    if (idr["entityPhone"] != DBNull.Value)
                    {
                        o.entityPhone = Convert.ToString(idr["entityPhone"]);
                    }
                    if (idr["entityAltPhone"] != DBNull.Value)
                    {
                        o.entityAltPhone = Convert.ToString(idr["entityAltPhone"]);
                    }
                    if (idr["entityMobile"] != DBNull.Value)
                    {
                        o.entityMobile = Convert.ToString(idr["entityMobile"]);
                    }
                    if (idr["entityAltMobile"] != DBNull.Value)
                    {
                        o.entityAltMobile = Convert.ToString(idr["entityAltMobile"]);
                    }
                    if (idr["entityFax"] != DBNull.Value)
                    {
                        o.entityFax = Convert.ToString(idr["entityFax"]);
                    }
                    if (idr["entityAltFax"] != DBNull.Value)
                    {
                        o.entityAltFax = Convert.ToString(idr["entityAltFax"]);
                    }
                    if (idr["entityStatus"] != DBNull.Value)
                    {
                        o.entityStatus = Convert.ToInt32(idr["entityStatus"]);
                    }
                    if (idr["entityAccountId"] != DBNull.Value)
                    {
                        o.entityAccountId = Convert.ToInt32(idr["entityAccountId"]);
                    }
                    if (idr["entityAccountTitle"] != DBNull.Value)
                    {
                        o.entityAccountTitle = Convert.ToString(idr["entityAccountTitle"]);
                    }
                    if (idr["entityCreatedOn"] != DBNull.Value)
                    {
                        o.entityCreatedOn = Convert.ToDateTime(idr["entityCreatedOn"]);
                    }
                    if (idr["entityCreatedBy"] != DBNull.Value)
                    {
                        o.entityCreatedBy = Convert.ToInt32(idr["entityCreatedBy"]);
                    }
                    if (idr["entityLastUpdatedBy"] != DBNull.Value)
                    {
                        o.entityLastUpdatedBy = Convert.ToInt32(idr["entityLastUpdatedBy"]);
                    }
                    if (idr["entityLastUpdateOn"] != DBNull.Value)
                    {
                        o.entityLastUpdateOn = Convert.ToDateTime(idr["entityLastUpdateOn"]);
                    }
                }
            }
            if (rtNull)
            {
                o = null;
            }
            return o;
        }


        public class objEntity
        {
            public int entityId { get; set; }
            public int entityType { get; set; }
            public string entityTitle { get; set; }
            public string entityDescription { get; set; }
            public string entityFirstName { get; set; }
            public string entityLastName { get; set; }
            public string entityEmail { get; set; }
            public string entityAltEmail { get; set; }
            public string entityAddress { get; set; }
            public string entityCity { get; set; }
            public string entityZip { get; set; }
            public int? entityCountry { get; set; }
            public string entityState { get; set; }
            public string entityPhone { get; set; }
            public string entityAltPhone { get; set; }
            public string entityMobile { get; set; }
            public string entityAltMobile { get; set; }
            public string entityFax { get; set; }
            public string entityAltFax { get; set; }
            public int entityStatus { get; set; }
            public int entityAccountId { get; set; }
            public string entityAccountTitle { get; set; }
            public DateTime entityCreatedOn { get; set; }
            public int entityCreatedBy { get; set; }
            public int entityLastUpdatedBy { get; set; }
            public DateTime entityLastUpdateOn { get; set; }
            public virtual EntityType.objEntityType objEntityType()
            {
                EntityType bEntity = new EntityType();
                EntityType.objEntityType rt = new EntityType.objEntityType();
                rt = bEntity.Select(entityType);
                return rt;
            }
        }

        public class EntityType
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

    
}
