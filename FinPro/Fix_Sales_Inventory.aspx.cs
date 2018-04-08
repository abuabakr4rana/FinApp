using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinPro
{
    public partial class Fix_Sales_Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fix_Inv();
        }

        protected void Fix_Inv()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            IDataReader idr = dbComm.SelectCMD("select transGroupID, sum(transAmount) as transAmount, max(transCreatedOn) as transCreatedOn from fin_transactions where (transDrAccount=84 or transCRAccount=84) and transAmount>0 and transSystemIndex=2 and Not transGroupID in (select transGroupID from fin_transactions where transDrAccount=84 and transType=44) group by transGroupID");
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupID = Convert.ToInt32(idr["transGroupID"]);
                    decimal transTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    DateTime transCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);

                    iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();

                    objTrans.transSystemIndex = 2;
                    objTrans.transParticipantID = 8;
                    objTrans.transDrAccount = 84;
                    objTrans.transNarration = "Inventory Sold from DHA Shop";
                    objTrans.transAmount = transTotalAmount;
                    objTrans.transCreatedBy = 1;
                    objTrans.transCreatedOn = transCreatedOn;
                    objTrans.transUpdatedBy = 1;
                    objTrans.transUpdatedOn = DateTime.Now;
                    objTrans.transStatus = 1;
                    objTrans.transSystemRestrict = false;
                    objTrans.transGroupID = transGroupID;
                    objTrans.transIsCompound = true;
                    objTrans.transType = 44;
                    bTrans.Add(objTrans);

                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans.transSystemIndex = 2;
                    objTrans.transParticipantID = 8;
                    objTrans.transCrAccount = 16;
                    objTrans.transNarration = "Inventory Sold from DHA Shop";
                    objTrans.transAmount = transTotalAmount;
                    objTrans.transCreatedBy = 1;
                    objTrans.transCreatedOn = transCreatedOn;
                    objTrans.transUpdatedBy = 1;
                    objTrans.transUpdatedOn = DateTime.Now;
                    objTrans.transStatus = 1;
                    objTrans.transSystemRestrict = false;
                    objTrans.transGroupID = transGroupID;
                    objTrans.transIsCompound = true;
                    objTrans.transType = 44;
                    bTrans.Add(objTrans);
                }
            }
        }
    }
}