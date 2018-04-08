using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinPro
{
    public partial class Fix_AutoDeleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            iBiz.FinPro.Transactions.Transact.objTransaction objDrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            iBiz.FinPro.Transactions.Transact.objTransaction objCrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();

            iBiz.FinPro.Transactions.Groups bTGroup = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTGroup = new iBiz.FinPro.Transactions.Groups.objGroup();




            iDB.Communicate dbComm = new iDB.Communicate();
            IDataReader idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where transDrAccount=294 and transGroupId not in (select transGroupId from fin_TransGroups where transGroupPrefixString='AUT')");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);

                    if (objTrans != null)
                    {
                        int transGroupId = 0;
                        objTGroup = new iBiz.FinPro.Transactions.Groups.objGroup();
                        objTGroup.transGroupTitle = "Credit Card Department Bank UBL DHA";
                        objTGroup.transGroupCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objTGroup.transGroupCreatedBy = 1;
                        objTGroup.transGroupTotalAmount = objTrans.transAmount;
                        objTGroup.transTransCount = 2;
                        objTGroup.transGroupPrefixNo = 7;
                        objTGroup.transGroupPrefixString = "AUT";
                        objTGroup.transGroupForeNumber = objTrans.transGroupID;
                        objTGroup.transGroupStatus = 1;
                        objTGroup.transLinkedToGroup = objTrans.transGroupID;
                        objTGroup.transGroupIsOfficial = 0;
                        transGroupId = bTGroup.Add(objTGroup).Value;


                        objDrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                        objDrTrans.deptId = objTrans.deptId;
                        objDrTrans.transAmount = objTrans.transAmount;
                        objDrTrans.transAttachedFiles = "";
                        objDrTrans.transCrAccount = null;
                        objDrTrans.transCreatedBy = objTrans.transCreatedBy;
                        objDrTrans.transCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objDrTrans.transDrAccount = 301;
                        objDrTrans.transGroupID = transGroupId;
                        objDrTrans.transInvoiceID = 0;
                        objDrTrans.transIsCompound = true;
                        objDrTrans.transNarration = "Credit Card Sales UBL DHA";
                        objDrTrans.transParticipantID = 1;
                        objDrTrans.transRefID = "0";
                        objDrTrans.transStatus = 1;
                        objDrTrans.transSystemIndex = 2;
                        objDrTrans.transSystemRestrict = false;
                        objDrTrans.transType = 3;
                        objDrTrans.transUpdatedBy = 1;
                        objDrTrans.transUpdatedOn = objTrans.Get_Group().transGroupCreatedOn;

                        bTrans.Add(objDrTrans);


                        objCrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                        objCrTrans.deptId = objTrans.deptId;
                        objCrTrans.transAmount = objTrans.transAmount;
                        objCrTrans.transAttachedFiles = "";
                        objCrTrans.transCrAccount = 294;
                        objCrTrans.transCreatedBy = objTrans.transCreatedBy;
                        objCrTrans.transCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objCrTrans.transDrAccount = null;
                        objCrTrans.transGroupID = transGroupId;
                        objCrTrans.transInvoiceID = 0;
                        objCrTrans.transIsCompound = true;
                        objCrTrans.transNarration = "Credit Card Sales UBL DHA";
                        objCrTrans.transParticipantID = 1;
                        objCrTrans.transRefID = "0";
                        objCrTrans.transStatus = 1;
                        objCrTrans.transSystemIndex = 2;
                        objCrTrans.transSystemRestrict = false;
                        objCrTrans.transType = 3;
                        objCrTrans.transUpdatedBy = 1;
                        objCrTrans.transUpdatedOn = objTrans.Get_Group().transGroupCreatedOn;

                        bTrans.Add(objCrTrans);


                    }
                }
            }


            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where transDrAccount=296 and transGroupId not in (select transGroupId from fin_TransGroups where transGroupPrefixString='AUT')");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    objTrans = bTrans.Select(transId);

                    if (objTrans != null)
                    {
                        int transGroupId = 0;
                        objTGroup = new iBiz.FinPro.Transactions.Groups.objGroup();
                        objTGroup.transGroupTitle = "Credit Card Department Bank UBL Gujrat";
                        objTGroup.transGroupCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objTGroup.transGroupCreatedBy = 1;
                        objTGroup.transGroupTotalAmount = objTrans.transAmount;
                        objTGroup.transTransCount = 2;
                        objTGroup.transGroupPrefixNo = 7;
                        objTGroup.transGroupPrefixString = "AUT";
                        objTGroup.transGroupForeNumber = objTrans.transGroupID;
                        objTGroup.transGroupStatus = 1;
                        objTGroup.transLinkedToGroup = objTrans.transGroupID;
                        objTGroup.transGroupIsOfficial = 0;
                        transGroupId = bTGroup.Add(objTGroup).Value;


                        objDrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                        objDrTrans.deptId = objTrans.deptId;
                        objDrTrans.transAmount = objTrans.transAmount;
                        objDrTrans.transAttachedFiles = "";
                        objDrTrans.transCrAccount = null;
                        objDrTrans.transCreatedBy = objTrans.transCreatedBy;
                        objDrTrans.transCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objDrTrans.transDrAccount = 303;
                        objDrTrans.transGroupID = transGroupId;
                        objDrTrans.transInvoiceID = 0;
                        objDrTrans.transIsCompound = true;
                        objDrTrans.transNarration = "Credit Card Sales UBL Gujrat";
                        objDrTrans.transParticipantID = 1;
                        objDrTrans.transRefID = "0";
                        objDrTrans.transStatus = 1;
                        objDrTrans.transSystemIndex = 2;
                        objDrTrans.transSystemRestrict = false;
                        objDrTrans.transType = 3;
                        objDrTrans.transUpdatedBy = 1;
                        objDrTrans.transUpdatedOn = objTrans.Get_Group().transGroupCreatedOn;

                        bTrans.Add(objDrTrans);




                        objCrTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                        objCrTrans.deptId = objTrans.deptId;
                        objCrTrans.transAmount = objTrans.transAmount;
                        objCrTrans.transAttachedFiles = "";
                        objCrTrans.transCrAccount = 296;
                        objCrTrans.transCreatedBy = objTrans.transCreatedBy;
                        objCrTrans.transCreatedOn = objTrans.Get_Group().transGroupCreatedOn;
                        objCrTrans.transDrAccount = null;
                        objCrTrans.transGroupID = transGroupId;
                        objCrTrans.transInvoiceID = 0;
                        objCrTrans.transIsCompound = true;
                        objCrTrans.transNarration = "Credit Card Sales UBL DHA";
                        objCrTrans.transParticipantID = 1;
                        objCrTrans.transRefID = "0";
                        objCrTrans.transStatus = 1;
                        objCrTrans.transSystemIndex = 2;
                        objCrTrans.transSystemRestrict = false;
                        objCrTrans.transType = 3;
                        objCrTrans.transUpdatedBy = 1;
                        objCrTrans.transUpdatedOn = objTrans.Get_Group().transGroupCreatedOn;

                        bTrans.Add(objCrTrans);


                    }
                }
            }
        }
    }
}