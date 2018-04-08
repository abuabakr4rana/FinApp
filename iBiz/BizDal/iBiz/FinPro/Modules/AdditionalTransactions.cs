using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Modules
{
	public class AdditionalTransactions
	{
		iDB.Communicate dbComm = new iDB.Communicate();

		public void Do_Transactions(int transGroupID, int additionalTransID, decimal amount, string description, decimal totalAmount, DateTime transDate, int transCreatedBy)
		{
            IDataReader idr = dbComm.SelectCMD(string.Format("select * from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=0 and additionalTransID={0} and autoTransIsPredefinedItem=0", additionalTransID));
			Transactions.Transact bTrans = new Transactions.Transact();
			Transactions.Transact.objTransaction objTrans;


			if (idr != null)
			{
				while (idr.Read())
				{
					objTrans = new Transactions.Transact.objTransaction();

					bool autoTransIsOfficial = Convert.ToBoolean(idr["autoTransIsOfficial"]);
					string transNarration = idr["autoTransNarration"].ToString();
					int accountId = Convert.ToInt32(idr["autoTransAccountId"]);
					bool doDebit = Convert.ToBoolean(idr["autoTransIsDebit"]);
					decimal transAmountMulti = Convert.ToDecimal(idr["autoTransAmountMultiplier"]);

					if (doDebit)
					{
						objTrans.transDrAccount = accountId;
					}
					else
					{
						objTrans.transCrAccount = accountId;
					}


					if (autoTransIsOfficial)
					{
						objTrans.transSystemIndex = 1;
						objTrans.transSystemRestrict = false;
					}
					else
					{
						objTrans.transSystemIndex = 0;
					}

					objTrans.transNarration = transNarration;
					objTrans.transAmount = amount * transAmountMulti;
                    objTrans.transCreatedBy = transCreatedBy;
                    objTrans.transCreatedOn = transDate;
					objTrans.transGroupID = transGroupID;
					objTrans.transInvoiceID = transGroupID;
					objTrans.transIsCompound = true;
					objTrans.transParticipantID = 1;
					objTrans.transRefID = "1";
					objTrans.transStatus = 1;
					objTrans.transType = 2;
                    objTrans.transUpdatedBy = transCreatedBy;
					objTrans.transUpdatedOn = DateTime.Now;
					bTrans.Add(objTrans);
				}
			}


            IDataReader idrGroups = dbComm.SelectCMD(string.Format("select distinct(autoTransSeparateID) from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=1 and additionalTransID={0} and autoTransIsPredefinedItem=0", additionalTransID));

			if (idrGroups != null)
			{
				while (idrGroups.Read())
				{
					int autoTransSeparateID = Convert.ToInt32(idrGroups["autoTransSeparateID"]);
					bool hasTransactions = false;
					decimal totalDrAmount = 0;
					decimal totalCrAmount = 0;
					int transCount = 0;


                    idr = dbComm.SelectCMD(string.Format("select * from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=1 and additionalTransID={0} and autoTransSeparateID={1} and autoTransIsPredefinedItem=0", additionalTransID, autoTransSeparateID));

					if (idr != null)
					{
						while (idr.Read())
						{

							objTrans = new Transactions.Transact.objTransaction();

							bool autoTransIsOfficial = Convert.ToBoolean(idr["autoTransIsOfficial"]);
							string transNarration = idr["autoTransNarration"].ToString();
							int accountId = Convert.ToInt32(idr["autoTransAccountId"]);
							bool doDebit = Convert.ToBoolean(idr["autoTransIsDebit"]);
							decimal transAmountMulti = Convert.ToDecimal(idr["autoTransAmountMultiplier"]);

							objTrans.transAmount = amount * transAmountMulti;

							if (doDebit)
							{
								objTrans.transDrAccount = accountId;
								totalDrAmount += objTrans.transAmount;
							}
							else
							{
								objTrans.transCrAccount = accountId;
								totalCrAmount += objTrans.transAmount;
							}


							if (autoTransIsOfficial)
							{
								objTrans.transSystemIndex = 2;
								objTrans.transSystemRestrict = false;
							}
							else
							{
								objTrans.transSystemIndex = 1;
							}

                            

							objTrans.transNarration = transNarration;
                            objTrans.transCreatedBy = transCreatedBy;
                            objTrans.transCreatedOn = transDate;
							objTrans.transGroupID = 0;
							objTrans.transInvoiceID = transGroupID;
							objTrans.transIsCompound = true;
							objTrans.transParticipantID = 1;
							objTrans.transRefID = transGroupID.ToString();
							objTrans.transStatus = 1;
							objTrans.transType = 3;
                            objTrans.transUpdatedBy = transCreatedBy;
							objTrans.transUpdatedOn = DateTime.Now;
							bTrans.Add(objTrans);
							hasTransactions = true;
							transCount++;

						}

						if (hasTransactions && totalCrAmount == totalDrAmount)
						{

							int groupID;
							iBiz.FinPro.Transactions.Groups.objGroup objTransGroup = new iBiz.FinPro.Transactions.Groups.objGroup();
							iBiz.FinPro.Transactions.Groups bTransGroup = new iBiz.FinPro.Transactions.Groups();

							objTransGroup.transGroupCreatedBy = transCreatedBy;
                            objTransGroup.transGroupCreatedOn = transDate;
							objTransGroup.transGroupForeNumber = transGroupID;
							objTransGroup.transGroupPrefixNo = 7;
							objTransGroup.transGroupPrefixString = "AUT";
							objTransGroup.transGroupStatus = 1;
							objTransGroup.transGroupTitle = "test";
							objTransGroup.transGroupTotalAmount = totalCrAmount;
							objTransGroup.transTransCount = transCount;
							objTransGroup.transLinkedToGroup = transGroupID;
							groupID = bTransGroup.Add(objTransGroup).Value;
                            bTrans.Update_Group(transCreatedBy, 0, groupID);

						}
					}
				}
			}
		}

        public void Do_Transactions_For_Predefined(int transGroupID, int additionalTransID, decimal amount, string description, decimal totalAmount, int moduleId, DateTime financial_Year, DateTime transCreatedOn, int transCreatedBy, int deptId)
        {
            IDataReader idr = dbComm.SelectCMD(string.Format("select * from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=0 and additionalTransID={0} and autoTransIsPredefinedItem=0", additionalTransID));
            Transactions.Transact bTrans = new Transactions.Transact();
            Transactions.Transact.objTransaction objTrans;


            if (idr != null)
            {
                while (idr.Read())
                {
                    objTrans = new Transactions.Transact.objTransaction();

                    bool autoTransIsOfficial = Convert.ToBoolean(idr["autoTransIsOfficial"]);
                    string transNarration = idr["autoTransNarration"].ToString();
                    int accountId = Convert.ToInt32(idr["autoTransAccountId"]);
                    bool doDebit = Convert.ToBoolean(idr["autoTransIsDebit"]);
                    decimal transAmountMulti = Convert.ToDecimal(idr["autoTransAmountMultiplier"]);

                    if (doDebit)
                    {
                        objTrans.transDrAccount = accountId;
                    }
                    else
                    {
                        objTrans.transCrAccount = accountId;
                    }


                    if (autoTransIsOfficial)
                    {
                        objTrans.transSystemIndex = 2;
                        objTrans.transSystemRestrict = false;
                    }
                    else
                    {
                        objTrans.transSystemIndex = 1;
                    }

                    objTrans.transNarration = transNarration;
                    objTrans.transAmount = amount * transAmountMulti;
                    objTrans.transCreatedBy = transCreatedBy;
                    objTrans.transCreatedOn = transCreatedOn;
                    objTrans.transGroupID = transGroupID;
                    objTrans.transInvoiceID = transGroupID;
                    objTrans.transIsCompound = true;
                    objTrans.transParticipantID = 1;
                    objTrans.transRefID = "1";
                    objTrans.transStatus = 1;
                    objTrans.transType = 2;
                    objTrans.transUpdatedBy = transCreatedBy;
                    objTrans.transUpdatedOn = DateTime.Now;
                    objTrans.deptId = deptId;
                    bTrans.Add(objTrans);
                }
            }


            IDataReader idrGroups = dbComm.SelectCMD(string.Format("select distinct(autoTransSeparateID) from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=1 and additionalTransID={0} and autoTransIsPredefinedItem=0", additionalTransID));

            if (idrGroups != null)
            {
                while (idrGroups.Read())
                {
                    int autoTransSeparateID = Convert.ToInt32(idrGroups["autoTransSeparateID"]);
                    bool hasTransactions = false;
                    decimal totalDrAmount = 0;
                    decimal totalCrAmount = 0;
                    int transCount = 0;


                    idr = dbComm.SelectCMD(string.Format("select * from fin_AdditionalAutoTrans where autoTransIsSeparateVouchar=1 and additionalTransID={0} and autoTransSeparateID={1} and autoTransIsPredefinedItem=0", additionalTransID, autoTransSeparateID));

                    if (idr != null)
                    {
                        while (idr.Read())
                        {

                            objTrans = new Transactions.Transact.objTransaction();

                            bool autoTransIsOfficial = Convert.ToBoolean(idr["autoTransIsOfficial"]);
                            string transNarration = idr["autoTransNarration"].ToString();
                            int accountId = Convert.ToInt32(idr["autoTransAccountId"]);
                            bool doDebit = Convert.ToBoolean(idr["autoTransIsDebit"]);
                            decimal transAmountMulti = Convert.ToDecimal(idr["autoTransAmountMultiplier"]);

                            objTrans.transAmount = amount * transAmountMulti;

                            if (doDebit)
                            {
                                objTrans.transDrAccount = accountId;
                                totalDrAmount += objTrans.transAmount;
                            }
                            else
                            {
                                objTrans.transCrAccount = accountId;
                                totalCrAmount += objTrans.transAmount;
                            }


                            if (autoTransIsOfficial)
                            {
                                objTrans.transSystemIndex = 2;
                                objTrans.transSystemRestrict = false;
                            }
                            else
                            {
                                objTrans.transSystemIndex = 1;
                            }


                            objTrans.transNarration = transNarration;
                            objTrans.transCreatedBy = transCreatedBy;
                            objTrans.transCreatedOn = transCreatedOn;
                            objTrans.transGroupID = -1;
                            objTrans.transInvoiceID = transGroupID;
                            objTrans.transIsCompound = true;
                            objTrans.transParticipantID = 1;
                            objTrans.transRefID = transGroupID.ToString();
                            objTrans.transStatus = 1;
                            objTrans.transType = 3;
                            objTrans.transUpdatedBy = transCreatedBy;
                            objTrans.transUpdatedOn = DateTime.Now;
                            objTrans.deptId = deptId;
                            bTrans.Add(objTrans);
                            hasTransactions = true;
                            transCount++;

                        }

                        if (hasTransactions && totalCrAmount == totalDrAmount)
                        {

                            int groupID;
                            string transGroupPrefixString = "AUT";
                            int transGroupPrefixNo = 7;
                            string transGroupTitle = "Auto Transaction";


                            iBiz.FinPro.Transactions.Groups.objGroup objTransGroup = new iBiz.FinPro.Transactions.Groups.objGroup();
                            iBiz.FinPro.Transactions.Groups bTransGroup = new iBiz.FinPro.Transactions.Groups();

                            idr = null;
                            idr = dbComm.SelectCMD(string.Format("select * from fin_AdditionalAutoTransGroup where atgID={0}", autoTransSeparateID));

                            while (idr.Read())
                            {
                                transGroupPrefixString = idr["transGroupPrefixString"].ToString();
                                transGroupPrefixNo = Convert.ToInt32(idr["transGroupPrefixNo"]);
                                transGroupTitle = idr["transGroupTitle"].ToString();
                            }



                            objTransGroup.transGroupCreatedBy = transCreatedBy;
                            objTransGroup.transGroupCreatedOn = transCreatedOn;
                            objTransGroup.transGroupForeNumber = bTransGroup.New_Group_Fore_Number(moduleId, transGroupPrefixString, objTransGroup.transGroupCreatedOn);
                            objTransGroup.transGroupPrefixNo = 7;
                            objTransGroup.transGroupPrefixString = transGroupPrefixString;
                            objTransGroup.transGroupStatus = 1;
                            objTransGroup.transGroupTitle = transGroupTitle;
                            objTransGroup.transGroupTotalAmount = totalCrAmount;
                            objTransGroup.transTransCount = transCount;
                            objTransGroup.transLinkedToGroup = 0;
                            groupID = bTransGroup.Add(objTransGroup).Value;
                            bTrans.Update_Group(transCreatedBy, -1, groupID);

                        }
                    }
                }
            }
        }

		public void Clear_Additional(int transGroupID)
		{
			dbComm.Execute(string.Format("Delete from fin_Transactions where (transType=2 Or transType=3) and transGroupID={0}", transGroupID));
		}

        

		public class AdditionalTransGroup
		{

		}
	}
}
