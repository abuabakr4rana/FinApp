using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iDB.FinPro.Transactions
{
    public class Attachments
    {
        Communicate dbComm = new Communicate();
        SortedList<string, object> srt = new SortedList<string, object>();

        public void Add(int attachmentId, string attachmentOriginalFileName, string attachmentMaskedFileName, int transGroupID)
        {
            srt.Clear();
            srt.Add("attachmentId", attachmentId);
            srt.Add("attachmentOriginalFileName", attachmentOriginalFileName);
            srt.Add("attachmentMaskedFileName", attachmentMaskedFileName);
            srt.Add("transGroupID", transGroupID);
            srt.Add("Flg", 1);
            dbComm.Execute(srt, Communicate.StoredProcedures.Attachments);
        }

        public void Update(int attachmentId, string attachmentOriginalFileName, string attachmentMaskedFileName, int transGroupID)
        {
            srt.Clear();
            srt.Add("attachmentId", attachmentId);
            srt.Add("attachmentOriginalFileName", attachmentOriginalFileName);
            srt.Add("attachmentMaskedFileName", attachmentMaskedFileName);
            srt.Add("transGroupID", transGroupID);
            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.Attachments);
        }

        public void Delete(int attachmentId)
        {
            srt.Clear();
            srt.Add("attachmentId", attachmentId);
            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.Attachments);
        }

        public IDataReader Select()
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("Flg", 4);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Attachments, srt);
            return idr;
        }

        public IDataReader Select(int attachmentId)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("attachmentId", attachmentId);
            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Attachments, srt);
            return idr;
        }

        public IDataReader Select_For_Vouchar(int transGroupID)
        {
            IDataReader idr = null;
            srt.Clear();
            srt.Add("transGroupID", transGroupID);
            srt.Add("Flg", 6);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.Attachments, srt);
            return idr;
        }
    }
}
