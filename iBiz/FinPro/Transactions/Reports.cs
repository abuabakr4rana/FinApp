using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Transactions
{
	public class Reports
	{
        iDB.Communicate dbComm = new iDB.Communicate();

        public DataTable Vouchar(int voucharId, bool isOfficial)
        {
            DataTable dt = new DataTable();
            dt = dbComm.SelectCmdAsTable(string.Format("select * from fin_Transactions where transGroupId={0}", voucharId));
            return dt;

        }

        public IDataReader Journal_Vochars(DateTime? fromDate, DateTime? toDate, bool isOfficial, int recordNoFrom, int recordNoTo)
        {
            IDataReader idr = null;

            string cmd = "";

            if (isOfficial)
            {
                cmd = "exec SP_fin_ReportJournalOfficial";
            }
            else
            {
                cmd = "exec SP_fin_ReportJournalUnofficial";
            }

            string condition = " ";
            bool hasCondition = true;


            //condition += string.Format(" @accountID={0}", accountID);

            if (fromDate != null)
            {
                condition += string.Format("@fromDate='{0}'", fromDate.Value.ToString());
            }
            else
            {
                condition += string.Format("@fromDate='{0}'", "01/01/1987");
            }

            if (toDate != null)
            {
                condition += string.Format(", @toDate='{0}'", toDate.Value.ToString());
            }
            else
            {
                condition += string.Format(", @toDate='{0}'", string.Format("01/01/{0}", DateTime.Now.Date.AddYears(2).Year));
            }


            condition += string.Format(", @recordNoFrom={0}", recordNoFrom);
            condition += string.Format(", @recordNoTo={0}", recordNoTo);

            if (hasCondition == true)
            {
                cmd += condition;
            }

            idr = dbComm.SelectCMD(cmd);

            return idr;
        }

        public int MaxJournalRows(DateTime? fromDate, DateTime? toDate, bool isOfficial, int recordNoFrom, int recordNoTo)
        {
            int rt = 0;

            IDataReader idr = Journal_Vochars(fromDate, toDate, isOfficial, recordNoFrom, recordNoTo);

            if (idr != null)
            {
                while (idr.Read())
                {
                    rt = Convert.ToInt32(idr["MaxRows"]);
                }
            }

            return rt;
        }

        public IDataReader Ledger(int accountID, DateTime? fromDate, DateTime? toDate, bool isOfficial, int departmentId)
        {
            IDataReader idr = null;

            string cmd = "";

            if (isOfficial)
            {
                cmd = "exec SP_OfficialLedgerReport";
            }
            else
            {
                cmd = "exec SP_LedgerReport";
            }

            string condition = " ";
            bool hasCondition = true;


            condition += string.Format(" @accountID={0}", accountID);

            if (fromDate != null)
            {
                condition += string.Format(", @fromDate='{0}'", fromDate.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                condition += string.Format(", @fromDate='{0}'", "01/01/1987");
            }

            if (toDate != null)
            {
                condition += string.Format(", @toDate='{0}'", toDate.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                condition += string.Format(", @toDate='{0}'", string.Format("01/01/{0}", DateTime.Now.Date.AddYears(2).Year));
            }

            if (departmentId != 0)
            {
                condition += string.Format(", @deptId='{0}'", departmentId);
            }
            //else
            //{
            //    condition += string.Format(", @deptId='{0}'", null);
            //}


            if (hasCondition == true)
            {
                cmd += condition;
            }

            idr = dbComm.SelectCMD(cmd);

            return idr;
        }

        public IDataReader Trial_Balance(DateTime? from, DateTime? to, bool isOfficial)
        {

            IDataReader idr = null;


            string cmd = "exec SP_fin_TrialBalance";
            string condition = " ";
            bool hasCondition = false;

            if (!isOfficial)
            {
                condition += " @systemIndex=1";
                hasCondition = true;
            }
            else
            {
                condition += " @systemIndex=2";
                hasCondition = true;
            }

            if (from != null)
            {
                if (hasCondition == true)
                {
                    condition += ", ";
                }
                hasCondition = true;
                condition += string.Format(" @fromDate='{0}'", from.Value.Date.ToString("yyyy-MM-dd"));
            }

            if (to != null)
            {
                if (hasCondition == true)
                {
                    condition += ", ";
                }
                hasCondition = true;
                condition += string.Format(" @toDate='{0}'", to.Value.Date.ToString("yyyy-MM-dd"));
            }


            if (hasCondition == true)
            {
                cmd += condition;
            }

            idr = dbComm.SelectCMD(cmd);

            return idr;
        }

		public decimal Get_Openning_Balance(int accountId, DateTime tillDate, int? deptId)
		{
			decimal rt = 0;

			//IDataReader idr = dbComm.SelectCMD($"declare @openningBalance money; exec @openningBalance = SP_OpenningBalance @accountId={accountId}, @fromDate='{tillDate}', @deptId={deptId}; select @openningBalance");
            IDataReader idr = dbComm.SelectCMD(string.Format("declare @openningBalance money; exec @openningBalance = SP_OpenningBalance @accountId={0}, @fromDate='{1}', @deptId={2}; select @openningBalance", accountId, tillDate, deptId));



			if (idr != null)
			{
				while (idr.Read())
				{
					rt = Convert.ToDecimal(idr[0]);
					break;
				}
			}

			return rt;
		}

        public double Account_Period_Sum(int accountId, DateTime startDate, DateTime endDate, bool isOfficial)
        {
            IDataReader idr = null;
            double rt = 0;


            string cmd = "exec SP_fin_AccountTotalInPeriod";
            string condition = " ";
            bool hasCondition = false;

            if (!isOfficial)
            {
                condition += " @systemIndex=1";
                hasCondition = true;
            }
            else
            {
                condition += " @systemIndex=2";
                hasCondition = true;
            }

            if (accountId != null)
            {
                if (hasCondition == true)
                {
                    condition += ", ";
                }
                hasCondition = true;
                condition += string.Format(" @accountId={0}", accountId);
            }

            if (startDate != null)
            {
                if (hasCondition == true)
                {
                    condition += ", ";
                }
                hasCondition = true;
                condition += string.Format(" @fromDate='{0}'", startDate.Date.ToString("yyyy-MM-dd"));
            }

            if (endDate != null)
            {
                if (hasCondition == true)
                {
                    condition += ", ";
                }
                hasCondition = true;
                condition += string.Format(" @toDate='{0}'", endDate.Date.ToString("yyyy-MM-dd"));
            }


            if (hasCondition == true)
            {
                cmd += condition;
            }

            idr = dbComm.SelectCMD(cmd);

            if (idr != null)
            {
                while (idr.Read())
                {
                    rt = Convert.ToDouble(idr[0]);
                }
            }

            return rt;
        }
		
	}
}
