using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FinPro
{
    public partial class FinanXol_Importer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Import_Sales();
            Transactions();
            Invoices();
            OfficialInvoices();
            AdvancePayments();
            Balance_Fabric_For_Sales();
            Vouchar_Verify();
        }

        protected void Transactions()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where  transType=0 group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(1, "TRA", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 1;
                    objTransG.transGroupPrefixString = "TRA";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = "Vouchar Created on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=0) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    objTrans.transType = 11;
                    objTempTrans.transDrAccount = null;
                    objTempTrans.transType = 11;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }


            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=0)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    
                    objTrans.transType = 11;
                    
                    bTrans.Update(objTrans);
                    
                }
            }
        }

        protected void Invoices()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where  transType=3 group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(2, "INV", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 2;
                    objTransG.transGroupPrefixString = "INV";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = "Invoice Created on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=3) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    objTrans.transType = 22;
                    objTempTrans.transDrAccount = null;
                    objTempTrans.transType = 22;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=3)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);

                    objTrans.transType = 22;

                    bTrans.Update(objTrans);

                }
            }
        }

        protected void OfficialInvoices()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where  transType=2 group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(2, "INV", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 2;
                    objTransG.transGroupPrefixString = "INV";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = "Invoice Created on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=2) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    objTrans.transType = 22;
                    objTempTrans.transDrAccount = null;
                    objTempTrans.transType = 22;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=2)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);

                    objTrans.transType = 22;

                    bTrans.Update(objTrans);

                }
            }
        }

        protected void Payments()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where  transType=3 group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(2, "INV", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 2;
                    objTransG.transGroupPrefixString = "INV";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = "Invoice Created on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=3) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    //objTrans.transType = 2;
                    objTempTrans.transDrAccount = null;
                    //objTempTrans.transType = 2;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }
        }

        protected void AdvancePayments()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where  transType=4 group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(3, "PAY", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 3;
                    objTransG.transGroupPrefixString = "PAY";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = "Advance Payment Made on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transType=4) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    objTrans.transType = 33;
                    objTempTrans.transDrAccount = null;
                    objTempTrans.transType = 33;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where transType=4");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);

                    objTrans.transType = 33;

                    bTrans.Update(objTrans);

                }
            }
        }

        protected void Import_Sales()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn, max(transParticipantID) as transParticipantID from fin_Transactions where (transParticipantID=8 or transParticipantID=13) group by transGroupID");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);
                    string branch = "";

                    if (idr["transParticipantID"].ToString().Trim() == "8")
                    {
                        branch = "DHA - ";
                    }
                    else
                    {
                        branch = "Gujrat - ";
                    }

                    objTransG.transGroupCreatedBy = 1;
                    objTransG.transGroupCreatedOn = Convert.ToDateTime(idr["transCreatedOn"]);
                    objTransG.transGroupForeNumber = bTransG.New_Group_Fore_Number(4, "SAL", DateTime.Now);
                    objTransG.transGroupID = transGroupId;
                    objTransG.transGroupPrefixNo = 4;
                    objTransG.transGroupPrefixString = "SAL";
                    objTransG.transGroupStatus = 1;
                    objTransG.transGroupTitle = branch + "Sales Made on " + objTransG.transGroupCreatedOn.ToString("MMM dd, yyyy");
                    objTransG.transGroupTotalAmount = Convert.ToDecimal(idr["transAmount"]);
                    objTransG.transTransCount = 0;

                    bTransG.Add(objTransG);
                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transParticipantID=8 or transParticipantID=13) and Not (transDrAccount is Null or transCrAccount is Null)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);
                    objTempTrans = bTrans.Select(transId);

                    objTrans.transCrAccount = null;
                    objTrans.transType = 44;
                    objTempTrans.transDrAccount = null;
                    objTempTrans.transType = 44;

                    bTrans.Update(objTrans);
                    bTrans.Add(objTempTrans);

                }
            }

            idr = null;
            idr = dbComm.SelectCMD("SELECT * FROM [fin_Transactions] where (transParticipantID=8 or transParticipantID=13)");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transId = Convert.ToInt32(idr["transId"]);
                    iBiz.FinPro.Transactions.Transact.objTransaction objTempTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                    objTrans = bTrans.Select(transId);

                    objTrans.transType = 44;

                    bTrans.Update(objTrans);

                }
            }
        }

        protected void Balance_Fabric_For_Sales()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID from fin_Transactions where transCrAccount=16 order by transGroupID desc");

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupId = Convert.ToInt32(idr["transGroupId"]);
                    decimal officialTotal = 0;
                    decimal unofficialTotal = 0;


                    IDataReader idrr = dbComm.SelectCMD(string.Format("select IsNull(sum(transAmount), 0) from (select distinct(transAmount) from fin_Transactions where transGroupID={0} and not transCrAccount=16 and transSystemIndex=2) as resultBox", transGroupId));

                    if (idrr != null)
                    {
                        while (idrr.Read())
                        {
                            officialTotal = Convert.ToDecimal(idrr[0]);                            
                        }
                    }



                    idrr = dbComm.SelectCMD(string.Format("select IsNull(sum(transAmount), 0) from (select distinct(transAmount) from fin_Transactions where transGroupID={0} and not transCrAccount=16 and transSystemIndex=1) as resultBox", transGroupId));


                    if (idrr != null)
                    {
                        while (idrr.Read())
                        {
                            unofficialTotal = Convert.ToDecimal(idrr[0]);
                            unofficialTotal += officialTotal;
                        }
                    }


                    idrr = dbComm.SelectCMD(string.Format("select * from fin_Transactions where transGroupID={0} and transCrAccount=16", transGroupId));


                    if (idrr != null)
                    {
                        while (idrr.Read())
                        {
                            int transID = Convert.ToInt32(idrr["transID"]);

                            objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
                            objTrans = bTrans.Select(transID);

                            if (objTrans != null)
                            {
                                objTrans.transSystemIndex = 1;
                                objTrans.transAmount = unofficialTotal;
                                bTrans.Update(objTrans);
                            }

                            objTrans = bTrans.Select(transID);
                            if (objTrans != null)
                            {
                                iBiz.FinPro.Transactions.Transact.objTransaction objTranss = new iBiz.FinPro.Transactions.Transact.objTransaction();

                                objTrans.transSystemIndex = 2;
                                objTrans.transAmount = officialTotal;
                                objTrans.transSystemRestrict = true;

                                objTranss.transParticipantID = objTrans.transParticipantID;
                                objTranss.transCreatedOn = objTrans.transCreatedOn;

                                bTrans.Add(objTrans);


                                if (objTranss.transParticipantID.Value == 8)
                                {
                                    objTranss.transDrAccount = 84;
                                }
                                else if (objTranss.transParticipantID.Value == 13)
                                {
                                    objTranss.transDrAccount = 94;
                                }
                                else
                                {
                                    objTranss.transDrAccount = null;
                                }

                               
                               objTranss.transAmount = officialTotal;
                               objTranss.transCrAccount = null;
                               objTranss.transCreatedBy = 1;
                               objTranss.transCreatedOn = DateTime.Now;
                               
                               objTranss.transGroupID = transGroupId;
                               objTranss.transNarration = "Inventory Sold";
                               objTranss.transStatus = 1;
                               objTranss.transSystemIndex = 2;
                               objTranss.transSystemRestrict = true;
                               objTranss.transType = 44;
                               objTranss.transUpdatedBy = 1;
                               objTranss.transUpdatedOn = DateTime.Now;
                                bTrans.Add(objTranss);
                            }
                        }
                    }
                    

                    objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
                    objTransG = bTransG.Select(transGroupId);

                    if (objTransG != null)
                    {
                        objTransG.transGroupTotalAmount = unofficialTotal;
                        objTransG.transGroupOfficialTotalAmount = officialTotal;
                        bTransG.Update(objTransG);
                    }
                }
            }

        }

        protected void Vouchar_Verify()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            iBiz.FinPro.Transactions.Groups bTransG = new iBiz.FinPro.Transactions.Groups();
            iBiz.FinPro.Transactions.Groups.objGroup objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
            iBiz.FinPro.Transactions.Transact bTrans = new iBiz.FinPro.Transactions.Transact();
            iBiz.FinPro.Transactions.Transact.objTransaction objTrans = new iBiz.FinPro.Transactions.Transact.objTransaction();
            IDataReader idr = dbComm.SelectCMD("Select transGroupID, Sum(transAmount) as transAmount, max(transNarration) as transNarration, max(transCreatedOn) as transCreatedOn from fin_Transactions where transGroupID in (select transGroupID from fin_TransGroups) group by transGroupID");
            string output = "<table>";

            if (idr != null)
            {
                while (idr.Read())
                {
                    int transGroupID = Convert.ToInt32(idr["transGroupID"]);
                    objTransG = new iBiz.FinPro.Transactions.Groups.objGroup();
                    objTransG = bTransG.Select(transGroupID);
                    decimal crTotal = 0, drTotal = 0, OCrTotal = 0, ODrTotal = 0;

                    output += "<tr><td>" + transGroupID.ToString() + "</td>";

                    if (objTransG != null)
                    {
                        if (objTransG.Get_Transactions(true) != null)
                        {
                            foreach (var item in objTransG.Get_Transactions(true))
                            {
                                if (item.transDrAccount == null)
                                {
                                    OCrTotal += item.transAmount;
                                }
                                else
                                {
                                    ODrTotal += item.transAmount;
                                }
                            }
                        }

                        if (ODrTotal == OCrTotal)
                        {
                            output += string.Format("<td>Balanced<td>");
                        }
                        else
                        {
                            output += string.Format("<td>Imbalanced<td>");
                        }

                        if (objTransG.Get_Transactions(false) != null)
                        {
                            foreach (var item in objTransG.Get_Transactions(false))
                            {
                                if (item.transDrAccount == null)
                                {
                                    crTotal += item.transAmount;
                                }
                                else
                                {
                                    drTotal += item.transAmount;
                                }
                            }
                        }

                        if (drTotal == crTotal)
                        {
                            output += string.Format("<td>Balanced<td>");
                        }
                        else
                        {
                            output += string.Format("<td>Imbalanced<td>");
                        }
                    }

                    output += "</tr>";
                }
            }

            output += "</table>";

            Response.Write(output);
        }

        protected IDataReader Get_Idr(string cCommand)
        {
            //Import Sales

            string cnString = "";
            DataTable dt = new DataTable();
            IDataReader idr = null;
            try
            {
                using (SqlConnection Cn = new SqlConnection(cnString))
                {
                    SqlCommand Cm = new System.Data.SqlClient.SqlCommand();
                    SqlDataAdapter Adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    Cm.Connection = Cn;
                    Cm.CommandText = cCommand;
                    
                    Cm.Connection.Open();
                    Adp.SelectCommand = Cm;
                    Adp.Fill(ds);
                    dt = ds.Tables[0];
                    idr = dt.CreateDataReader();
                }
            }
            catch (Exception ex)
            {
                //err.Log_Error(ex.Message, "Communicate - SelectValue");
            }
            return idr;
        }
    }
}