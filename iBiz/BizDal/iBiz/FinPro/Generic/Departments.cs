using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Generic
{
    public class Departments
    {
        iDB.Communicate dbComm = new iDB.Communicate();

        public IDataReader Select()
        {
            IDataReader idr = dbComm.SelectCMD("select * from fin_Departments");

            return idr;
        }
    }
}
