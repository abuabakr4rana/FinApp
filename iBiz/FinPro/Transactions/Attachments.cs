using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Transactions
{
    public class Attachments
    {
        iDB.FinPro.Transactions.Attachments db = new iDB.FinPro.Transactions.Attachments();

        public void Add(objAttachment i)
        {
            db.Add(
            i.attachmentId, i.attachmentOriginalFileName, i.attachmentMaskedFileName, i.transGroupID);
        }

        public void Update(objAttachment i)
        {
            db.Update(
            i.attachmentId, i.attachmentOriginalFileName, i.attachmentMaskedFileName, i.transGroupID);
        }

        public void Delete(int i)
        {
            db.Delete(i);
        }

        public IDataReader Select_For_Vouchar(int transGroupID)
        {
            return db.Select_For_Vouchar(transGroupID);
        }

        public objAttachment Select_Obj(IDataReader idr)
        {
            objAttachment o = new objAttachment();
            bool rtNull = true;

            if (idr != null)
            {
                while (idr.Read())
                {
                    rtNull = false;
                    if (idr["attachmentId"] != DBNull.Value)
                    {
                        o.attachmentId = Convert.ToInt32(idr["attachmentId"]);
                    }
                    if (idr["attachmentOriginalFileName"] != DBNull.Value)
                    {
                        o.attachmentOriginalFileName = Convert.ToString(idr["attachmentOriginalFileName"]);
                    }
                    if (idr["attachmentMaskedFileName"] != DBNull.Value)
                    {
                        o.attachmentMaskedFileName = Convert.ToString(idr["attachmentMaskedFileName"]);
                    }
                    if (idr["transGroupID"] != DBNull.Value)
                    {
                        o.transGroupID = Convert.ToInt32(idr["transGroupID"]);
                    }
                }
            }

            if (rtNull)
            {
                o = null;
            }

            return o;
        }

        public class objAttachment
        {
            public int attachmentId { get; set; }
            public string attachmentOriginalFileName { get; set; }
            public string attachmentMaskedFileName { get; set; }
            public int transGroupID { get; set; }

        }
    }
}
