using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Configuration;

namespace iDB
{
	public class Communicate
	{
		Errors err = new Errors();
		string cnString = ConfigurationSettings.AppSettings["FinPro"].ToString();
		//string cnString = "Data Source=192.168.2.103;Initial Catalog=Auth; User Id=sa; Password:Aa1Bb2!@";
		protected void SaveUpdateDelete(SortedList<string, object> srtval, string proname)
		{
			try
			{
				using (SqlConnection Cn = new SqlConnection(cnString))
				{
					SqlCommand Cm = new SqlCommand();
					Cm.Connection = Cn;
					Cm.CommandType = CommandType.StoredProcedure;
					Cm.CommandText = proname;
					SortedList<string, object> srt = srtval;
					for (int i = 0; i <= srt.Count - 1; i++)
					{
						if (srt.Values[i] != null)
						{

							if (srt.Values[i].ToString().Trim().Length > 0)
							{
								if (srt.Keys[i].ToString().Trim().Contains("@"))
								{
									Cm.Parameters.Add(new SqlParameter(srt.Keys[i], srt.Values[i]));
								}
								else
								{
									Cm.Parameters.Add(new SqlParameter("@" + srt.Keys[i].ToString(), srt.Values[i]));
								}
							}
						}
					}
					Cm.Connection.Open();
					Cm.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SaveUpdateDelete");
			}

		}

		public enum StoredProcedures
		{
			CatchErrors,
			coder,
			TransGroups,
			Transactions,
			Accounts,
			AccountCategories,
			Attachments,
			UserProfile,
			Categories,
			AppModules,
			Departments,
			ChequePrinting,
            FinYear,
Entities,
EntityTypes//ProcedureGoesHere
		}

		public void Execute(SortedList<string, object> srt, StoredProcedures spname)
		{
			switch (spname)
			{

				case StoredProcedures.CatchErrors:
					SaveUpdateDelete(srt, "SP_CatchErrors");
					break;
				case StoredProcedures.coder:
					SaveUpdateDelete(srt, "SP_coder");
					break;
				case StoredProcedures.TransGroups:
					SaveUpdateDelete(srt, "SP_fin_TransGroups");
					break;
				case StoredProcedures.Transactions:
					SaveUpdateDelete(srt, "SP_fin_Transactions");
					break;
				case StoredProcedures.Accounts:
					SaveUpdateDelete(srt, "SP_fin_Accounts");
					break;
				case StoredProcedures.AccountCategories:
					SaveUpdateDelete(srt, "SP_fin_AccountCategories");
					break;
				case StoredProcedures.Attachments:
					SaveUpdateDelete(srt, "SP_fin_Attachments");
					break;
				case StoredProcedures.UserProfile:
					SaveUpdateDelete(srt, "SP_userProfile");
					break;
				case StoredProcedures.Categories:
					SaveUpdateDelete(srt, "SP_Categories");
					break;
				case StoredProcedures.AppModules:
					SaveUpdateDelete(srt, "SP_fin_Modules");
					break;
				case StoredProcedures.Departments:
					SaveUpdateDelete(srt, "SP_fin_Departments");
					break;
				case StoredProcedures.ChequePrinting:
					SaveUpdateDelete(srt, "SP_fin_ChequePrinting");
					break;
				case StoredProcedures.Entities:
SaveUpdateDelete(srt, "SP_Entities");
break;
case StoredProcedures.EntityTypes:
SaveUpdateDelete(srt, "SP_EntityTypes");
break;

case StoredProcedures.FinYear:
SaveUpdateDelete(srt, "SP_FinYear");
break;
//ExecuteNow
			}
		}

		public DataTable SelectExecute(StoredProcedures e, SortedList<string, object> srt)
		{
			DataTable dt = new DataTable();
			switch (e)
			{
				case StoredProcedures.CatchErrors:
					dt = SelectValue("SP_BooksGoogle", srt);
					break;
				case StoredProcedures.coder:
					dt = SelectValue("SP_Coder", srt);
					break;
				case StoredProcedures.TransGroups:
					dt = SelectValue("SP_fin_TransGroups", srt);
					break;
				case StoredProcedures.Transactions:
					dt = SelectValue("SP_fin_Transactions", srt);
					break;
				case StoredProcedures.Accounts:
					dt = SelectValue("SP_fin_Accounts", srt);
					break;
				case StoredProcedures.AccountCategories:
					dt = SelectValue("SP_fin_AccountCategories", srt);
					break;
				case StoredProcedures.Attachments:
					dt = SelectValue("SP_fin_Attachments", srt);
					break;
				case StoredProcedures.UserProfile:
					dt = SelectValue("SP_userProfile", srt);
					break;
				case StoredProcedures.Categories:
					dt = SelectValue("SP_Categories", srt);
					break;
				case StoredProcedures.AppModules:
					dt = SelectValue("SP_fin_Modules", srt);
					break;
				case StoredProcedures.Departments:
					dt = SelectValue("SP_fin_Departments", srt);
					break;
				case StoredProcedures.ChequePrinting:
					dt = SelectValue("SP_fin_ChequePrinting", srt);
					break;
				case StoredProcedures.Entities:
dt = SelectValue("SP_Entities", srt);
break;
case StoredProcedures.EntityTypes:
dt = SelectValue("SP_EntityTypes", srt);
break;
//SelectDataTable
			}
			return dt;
		}

		public IDataReader SelectIDR(StoredProcedures e, SortedList<string, object> srt)
		{
			IDataReader idr = null;
			switch (e)
			{
				case StoredProcedures.CatchErrors:
					idr = SelectReader("SP_BooksGoogle", srt);
					break;
				case StoredProcedures.coder:
					idr = SelectReader("SP_Coder", srt);
					break;
				case StoredProcedures.TransGroups:
					idr = SelectReader("SP_fin_TransGroups", srt);
					break;
				case StoredProcedures.Transactions:
					idr = SelectReader("SP_fin_Transactions", srt);
					break;
				case StoredProcedures.Accounts:
					idr = SelectReader("SP_fin_Accounts", srt);
					break;
				case StoredProcedures.AccountCategories:
					idr = SelectReader("SP_fin_AccountCategories", srt);
					break;
				case StoredProcedures.Attachments:
					idr = SelectReader("SP_fin_Attachments", srt);
					break;
				case StoredProcedures.UserProfile:
					idr = SelectReader("SP_userProfile", srt);
					break;
				case StoredProcedures.Categories:
					idr = SelectReader("SP_Categories", srt);
					break;
				case StoredProcedures.AppModules:
					idr = SelectReader("SP_fin_Modules", srt);
					break;
				case StoredProcedures.Departments:
					idr = SelectReader("SP_fin_Departments", srt);
					break;
				case StoredProcedures.ChequePrinting:
					idr = SelectReader("SP_fin_ChequePrinting", srt);
					break;
				case StoredProcedures.Entities:
idr = SelectReader("SP_Entities", srt);
break;
case StoredProcedures.EntityTypes:
idr = SelectReader("SP_EntityTypes", srt);
break;
case StoredProcedures.FinYear:
idr = SelectReader("SP_FinYear", srt);
break;
//SelectIDR
			}
			return idr;
		}

		public IDataReader SelectCMD(string Command)
		{
			DataTable dt = new DataTable();

			try
			{
				using (SqlConnection Cn = new SqlConnection(cnString))
				{
					SqlCommand Cm = new System.Data.SqlClient.SqlCommand();
					SqlDataAdapter Adp = new SqlDataAdapter();
					DataSet ds = new DataSet();

					Cm.Connection = Cn;
					Cm.CommandText = Command;
					Cm.Connection.Open();
					//Cm.ExecuteNonQuery();
					//idr = Cm.ExecuteReader();
					Adp.SelectCommand = Cm;
					Adp.Fill(ds);
					dt = ds.Tables[0];

					//return idr;
				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SelectValue");
			}
			return dt.CreateDataReader();
		}

		public DataTable SelectCmdAsTable(string Command)
		{
			DataTable dt = new DataTable();

			try
			{
				using (SqlConnection Cn = new SqlConnection(cnString))
				{
					SqlCommand Cm = new System.Data.SqlClient.SqlCommand();
					SqlDataAdapter Adp = new SqlDataAdapter();
					DataSet ds = new DataSet();

					Cm.Connection = Cn;
					Cm.CommandText = Command;
					Cm.Connection.Open();
					//Cm.ExecuteNonQuery();
					//idr = Cm.ExecuteReader();
					Adp.SelectCommand = Cm;
					Adp.Fill(ds);
					dt = ds.Tables[0];

					//return idr;
				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SelectValue");
			}
			return dt;
		}

		public void Execute(string Command)
		{

			try
			{
				using (SqlConnection Cn = new SqlConnection(cnString))
				{
					SqlCommand Cm = new System.Data.SqlClient.SqlCommand();

					Cm.Connection = Cn;
					Cm.CommandText = Command;
					Cm.Connection.Open();
					Cm.ExecuteNonQuery();

				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SelectValue");
			}

		}

		protected IDataReader SelectReader(string proname, SortedList<string, object> srt)
		{
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
					Cm.CommandText = proname;
					Cm.CommandType = CommandType.StoredProcedure;
					for (int i = 0; i <= srt.Count - 1; i++)
					{
						if (srt.Values[i] != null)
						{
							if (srt.Values[i].ToString().Trim().Length > 0)
							{
								if (srt.Keys[i].ToString().Trim().Contains("@"))
								{
									Cm.Parameters.Add(new SqlParameter(srt.Keys[i], srt.Values[i]));
								}
								else
								{
									Cm.Parameters.Add(new SqlParameter("@" + srt.Keys[i].ToString(), srt.Values[i]));
								}
							}
						}
					}
					Cm.Connection.Open();
					Adp.SelectCommand = Cm;
					Adp.Fill(ds);
					dt = ds.Tables[0];
					return dt.CreateDataReader();
				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SelectValue");
			}
			return idr;
		}
		protected DataTable SelectValue(string proname, SortedList<string, object> srt)
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection Cn = new SqlConnection(cnString))
				{
					SqlCommand Cm = new System.Data.SqlClient.SqlCommand();
					SqlDataAdapter Adp = new SqlDataAdapter();
					DataSet ds = new DataSet();

					Cm.Connection = Cn;
					Cm.CommandText = proname;
					Cm.CommandType = CommandType.StoredProcedure;
					for (int i = 0; i <= srt.Count - 1; i++)
					{
						if (srt.Values[i] != null)
						{
							if (srt.Values[i].ToString().Trim().Length > 0)
							{
								if (srt.Keys[i].ToString().Trim().Contains("@"))
								{
									Cm.Parameters.Add(new SqlParameter(srt.Keys[i], srt.Values[i]));
								}
								else
								{
									Cm.Parameters.Add(new SqlParameter("@" + srt.Keys[i].ToString(), srt.Values[i]));
								}
							}
						}
					}
					Cm.Connection.Open();
					Cm.ExecuteNonQuery();
					Adp.SelectCommand = Cm;
					Adp.Fill(ds);
					dt = ds.Tables[0];
				}
			}
			catch (Exception ex)
			{
				err.Log_Error(ex.Message, "Communicate - SelectValue");
			}
			return dt;
		}
	}
}
