using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iBiz.FinPro.Generic
{
    public class Branches
    {
        public IDataReader Select_Branches()
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            IDataReader idr = dbComm.SelectCMD("select * from fin_Branches");
            return idr;
        }

    }
}
