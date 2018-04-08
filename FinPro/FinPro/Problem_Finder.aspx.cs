using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinPro
{
    public partial class Problem_Finder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Vouchar_Verify();
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

                    

                    if (objTransG != null)
                    {
                        if (objTransG.Get_Transactions() != null)
                        {
                            foreach (var item in objTransG.Get_Transactions())
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
                            //output += string.Format("<td>Balanced<td>");
                        }
                        else
                        {
                            output += "<tr><td>" + transGroupID.ToString() + "</td>";
                            output += string.Format("<td>Imbalanced<td>");
                            output += "</tr>";
                        }

                        //if (objTransG.Get_Transactions(false) != null)
                        //{
                        //    foreach (var item in objTransG.Get_Transactions(false))
                        //    {
                        //        if (item.transDrAccount == null)
                        //        {
                        //            crTotal += item.transAmount;
                        //        }
                        //        else
                        //        {
                        //            drTotal += item.transAmount;
                        //        }
                        //    }
                        //}

                        //if (drTotal == crTotal)
                        //{
                        //    output += string.Format("<td>Balanced<td>");
                        //}
                        //else
                        //{
                        //    output += string.Format("<td>Imbalanced<td>");
                        //}
                    }

                    
                }
            }

            output += "</table>";

            Response.Write(output);
        }

    }
}