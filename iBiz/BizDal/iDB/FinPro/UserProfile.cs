using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iDB.FinPro
{
    public class UserProfile
    {
        SortedList<string, object> srt = new SortedList<string, object>();
        Communicate dbComm = new Communicate();
        public void Add(int userID, string userFirstName, string userMiddleName, string userLastName, string userEmail, bool userIsOfficial, bool userIsActive)
        {
            srt.Clear();
            srt.Add("userID", userID);
            srt.Add("userFirstName", userFirstName);
            srt.Add("userMiddleName", userMiddleName);
            srt.Add("userLastName", userLastName);
            srt.Add("userEmail", userEmail);
            srt.Add("userIsOfficial", userIsOfficial);
            srt.Add("userIsActive", userIsActive);
            srt.Add("Flg", 1);
            dbComm.Execute(srt, Communicate.StoredProcedures.UserProfile);
        }

        public void Update(int userID, string userFirstName, string userMiddleName, string userLastName, string userEmail, bool userIsOfficial, bool userIsActive)
        {
            srt.Clear();
            srt.Add("userID", userID);
            srt.Add("userFirstName", userFirstName);
            srt.Add("userMiddleName", userMiddleName);
            srt.Add("userLastName", userLastName);
            srt.Add("userEmail", userEmail);
            srt.Add("userIsOfficial", userIsOfficial);
            srt.Add("userIsActive", userIsActive);
            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.UserProfile);
        }

        public void Delete(int userID)
        {
            srt.Clear();
            srt.Add("userID", userID);
            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.UserProfile);
        }

        public IDataReader Select()
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.UserProfile, srt);
            return idr;
        }

        public IDataReader Select(int userID)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("userID", userID);
            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.UserProfile, srt);
            return idr;
        }

        public IDataReader Select(string userEmail)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("userEmail", userEmail);
            srt.Add("Flg", 6);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.UserProfile, srt);
            return idr;
        }
    }
}
