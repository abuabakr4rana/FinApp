using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro
{
    public class UserProfile
    {
        iDB.FinPro.UserProfile db = new iDB.FinPro.UserProfile();

        public void Add(objUserProfile i)
        {
            db.Add(
            i.userID, i.userFirstName, i.userMiddleName, i.userLastName, i.userEmail, i.userIsOfficial, i.userIsActive);
        }

        public void Update(objUserProfile i)
        {
            db.Update(
            i.userID, i.userFirstName, i.userMiddleName, i.userLastName, i.userEmail, i.userIsOfficial, i.userIsActive);
        }

        public void Delete(int i)
        {
            db.Delete(i);
        }

        public IDataReader Select()
        {
            return db.Select();
        }

        public objUserProfile Select(int userID)
        {
            objUserProfile o = new objUserProfile();
            IDataReader idr = db.Select(userID);
            o = Select_Obj(idr);
            return o;
        }

        public objUserProfile Select(string userEmail)
        {
            objUserProfile o = new objUserProfile();
            IDataReader idr = db.Select(userEmail);
            o = Select_Obj(idr);
            return o;
        }

        public objUserProfile Select_Obj(IDataReader idr)
        {
            objUserProfile o = new objUserProfile();
            bool rtNull = true;

            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;

                    if (idr["userID"] != DBNull.Value)
                    {
                        o.userID = Convert.ToInt32(idr["userID"]);
                    }
                    if (idr["userFirstName"] != DBNull.Value)
                    {
                        o.userFirstName = Convert.ToString(idr["userFirstName"]);
                    }
                    if (idr["userMiddleName"] != DBNull.Value)
                    {
                        o.userMiddleName = Convert.ToString(idr["userMiddleName"]);
                    }
                    if (idr["userLastName"] != DBNull.Value)
                    {
                        o.userLastName = Convert.ToString(idr["userLastName"]);
                    }
                    if (idr["userEmail"] != DBNull.Value)
                    {
                        o.userEmail = Convert.ToString(idr["userEmail"]);
                    }
                    if (idr["userIsOfficial"] != DBNull.Value)
                    {
                        o.userIsOfficial = Convert.ToBoolean(idr["userIsOfficial"]);
                    }
                    if (idr["userIsActive"] != DBNull.Value)
                    {
                        o.userIsActive = Convert.ToBoolean(idr["userIsActive"]);
                    }
                }
            }

            if (rtNull)
            {
                o = null;
            }

            return o;
        }

        public class objUserProfile
        {
            public int userID { get; set; }
            public string userFirstName { get; set; }
            public string userMiddleName { get; set; }
            public string userLastName { get; set; }
            public string userEmail { get; set; }
            public bool userIsOfficial { get; set; }
            public bool userIsActive { get; set; }

        }

    }
}
