using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.FinPro
{
    public class ChequePrinting
    {
        Communicate dbComm = new Communicate();
        SortedList<string, object> srt = new SortedList<string, object>();
        public int Add(int chequeId, int bankId, string chequeTitle, string chequeAmount, decimal chequeAmountFig, DateTime? chequeDate, string chequeNo, string chequeReceivedBy, string chequeReceiverPhone, string chequeReceiverIDCard, int? chequeCreatedBy, DateTime? chequeCreatedOn, int? chequeStatus)
        {
            int rt = 0;

            srt.Clear();
            srt.Add("chequeId", chequeId);
            srt.Add("bankId", bankId);
            srt.Add("chequeTitle", chequeTitle);
            srt.Add("chequeAmount", chequeAmount);
            srt.Add("chequeAmountFig", chequeAmountFig);
            srt.Add("chequeDate", chequeDate);
            srt.Add("chequeNo", chequeNo);
            srt.Add("chequeReceivedBy", chequeReceivedBy);
            srt.Add("chequeReceiverPhone", chequeReceiverPhone);
            srt.Add("chequeReceiverIDCard", chequeReceiverIDCard);
            srt.Add("chequeCreatedBy", chequeCreatedBy);
            srt.Add("chequeCreatedOn", chequeCreatedOn);
            srt.Add("chequeStatus", chequeStatus);

            srt.Add("Flg", 1);
            IDataReader idr = dbComm.SelectIDR(Communicate.StoredProcedures.ChequePrinting, srt);

            if (idr != null)
            {
                while (idr.Read())
                {
                    rt = Convert.ToInt32(idr[0]);
                }
            }

            return rt;
        }
        public void Update(int chequeId, int bankId, string chequeTitle, string chequeAmount, decimal chequeAmountFig, DateTime? chequeDate, string chequeNo, string chequeReceivedBy, string chequeReceiverPhone, string chequeReceiverIDCard, int? chequeCreatedBy, DateTime? chequeCreatedOn, int? chequeStatus)
        {
            srt.Clear();
            srt.Add("chequeId", chequeId);
            srt.Add("bankId", bankId);
            srt.Add("chequeTitle", chequeTitle);
            srt.Add("chequeAmount", chequeAmount);
            srt.Add("chequeAmountFig", chequeAmountFig);
            srt.Add("chequeDate", chequeDate);
            srt.Add("chequeNo", chequeNo);
            srt.Add("chequeReceivedBy", chequeReceivedBy);
            srt.Add("chequeReceiverPhone", chequeReceiverPhone);
            srt.Add("chequeReceiverIDCard", chequeReceiverIDCard);
            srt.Add("chequeCreatedBy", chequeCreatedBy);
            srt.Add("chequeCreatedOn", chequeCreatedOn);
            srt.Add("chequeStatus", chequeStatus);

            srt.Add("Flg", 2);
            dbComm.Execute(srt, Communicate.StoredProcedures.ChequePrinting);
        }
        public void Delete(int chequeId)
        {
            srt.Clear();
            srt.Add("chequeId", chequeId);

            srt.Add("Flg", 3);
            dbComm.Execute(srt, Communicate.StoredProcedures.ChequePrinting);
        }
        public IDataReader Select()
{
srt.Clear();
IDataReader idr = null;
srt.Add("Flg", 4);
idr = dbComm.SelectIDR(Communicate.StoredProcedures.ChequePrinting, srt);
return idr;
}
        public IDataReader Select(int chequeId)
        {
            srt.Clear();
            IDataReader idr = null;
            srt.Add("chequeId", chequeId);

            srt.Add("Flg", 5);
            idr = dbComm.SelectIDR(Communicate.StoredProcedures.ChequePrinting, srt);
            return idr;
        }

    }

}
