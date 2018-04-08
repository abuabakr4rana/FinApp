using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDB
{
	public class Errors
	{
		public void Log_Error(string ErrMsg, string ErrPath)
		{
			Communicate dbComm = new Communicate();
			SortedList<string, object> srt = new SortedList<string, object>();
			srt.Add("@ErrMsg", ErrMsg);
			srt.Add("@ErrPath", ErrPath);
			dbComm.Execute(srt, Communicate.StoredProcedures.CatchErrors);
		}
	}
}
