using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iDB.FinPro.Modules{
public class fin_Modules
{
Communicate dbComm = new Communicate();
SortedList<string, object> srt = new SortedList<string, object>();
public void Add(int moduleId, string moduleTitle, string moduleDescription, bool moduleIsOffial, string CField1, string CField2, string CField3, string CField4){
srt.Add("moduleId", moduleId);
srt.Add("moduleTitle", moduleTitle);
srt.Add("moduleDescription", moduleDescription);
srt.Add("moduleIsOffial", moduleIsOffial);
srt.Add("CField1", CField1);
srt.Add("CField2", CField2);
srt.Add("CField3", CField3);
srt.Add("CField4", CField4);

srt.Add("Flg", 1);
dbComm.Execute(srt, iDB.Communicate.StoredProcedures.AppModules);
}
public void Update(int moduleId, string moduleTitle, string moduleDescription, bool moduleIsOffial, string CField1, string CField2, string CField3, string CField4){
srt.Add("moduleId", moduleId);
srt.Add("moduleTitle", moduleTitle);
srt.Add("moduleDescription", moduleDescription);
srt.Add("moduleIsOffial", moduleIsOffial);
srt.Add("CField1", CField1);
srt.Add("CField2", CField2);
srt.Add("CField3", CField3);
srt.Add("CField4", CField4);

srt.Add("Flg", 2);
dbComm.Execute(srt, iDB.Communicate.StoredProcedures.AppModules);
}
public void Delete(int moduleId){
srt.Add("moduleId", moduleId);

srt.Add("Flg", 3);
dbComm.Execute(srt, iDB.Communicate.StoredProcedures.AppModules);
}
public IDataReader Select()
{
IDataReader idr = null;
srt.Add("Flg", 4);
idr = dbComm.SelectIDR(iDB.Communicate.StoredProcedures.AppModules, srt);
return idr;
}
public IDataReader Select(int moduleId){
IDataReader idr = null;
srt.Add("moduleId", moduleId);

srt.Add("Flg", 5);
idr = dbComm.SelectIDR(iDB.Communicate.StoredProcedures.AppModules, srt);
return idr;
}

}

}
