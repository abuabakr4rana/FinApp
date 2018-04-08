using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace FinPro
{
	public partial class Quick_Coder : System.Web.UI.Page
	{
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            iDB.Communicate dbComm = new iDB.Communicate();
            DataTable dt = new DataTable();
            IDataReader idr = null;
            SortedList<string, object> srt = new SortedList<string, object>();
            string moduleName = ".FinPro";
            string bizModuleName = ".FinPro";
            string bizPath = @"D:\Projects\FinPro\FinPro\iBiz\FinPro\Modules\" + tbClassFileName.Text + ".cs";
            string idbPath = @"D:\Projects\FinPro\FinPro\iDB\FinPro\Modules\" + tbClassFileName.Text + ".cs";


            //dt = dbComm.SelectExecute(iDB.Payroll.Communicate.StoredProcedures.coder, srt);
            //idr = dbComm.SelectCMD("sp_");



            using (SqlConnection Cn = new SqlConnection("Data Source=localhost;Initial Catalog=FinApp; User Id=sa; Password=Aa1Bb2!@"))
            {
                SqlCommand Cm = new System.Data.SqlClient.SqlCommand();
                SqlDataAdapter Adp = new SqlDataAdapter();
                DataSet ds = new DataSet();

                Cm.Connection = Cn;
                Cm.CommandText = string.Format("sp_help '{0}'", tbname.Text);
                Cm.Connection.Open();
                //Adp.FillSchema(ds, SchemaType.Source);
                //Cm.ExecuteNonQuery();
                //idr = Cm.ExecuteReader();
                Adp.SelectCommand = Cm;
                Adp.Fill(ds);
                dt = ds.Tables[1];

                //return idr;
            }

            if (dt != null)
            {

                // Create Procedure
                string proc = "Create Procedure SP_" + tbprocname.Text + "(<br />";
                string structProc = string.Empty;
                string insertVar = string.Empty;
                string updateVar = string.Empty;
                string primaryCol = string.Empty;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string colName = dt.Rows[i]["Column_name"].ToString();
                    string colType = dt.Rows[i]["Type"].ToString();
                    string colLength = dt.Rows[i]["Length"].ToString();
                    string colNullable = dt.Rows[i]["Nullable"].ToString();
                    string colPrec = dt.Rows[i]["Prec"].ToString();
                    string colScale = dt.Rows[i]["Scale"].ToString();
                    string colLengthAdd = "";

                    if (colType.ToLower() == "decimal")
                    {
                        colLengthAdd = "(" + colPrec + ", " + colScale + ")";
                    }
                    else if (colType.ToLower() == "varchar" || colType.ToLower() == "nvarchar")
                    {
                        colLengthAdd = "(" + colLength + ")";
                    }

                    colType += " " + colLengthAdd;

                    colName = "@" + colName;
                    if (i != 0)
                    {
                        if (i != dt.Rows.Count - 1)
                        {
                            insertVar += colName + ",";
                            updateVar += colName.Replace("@", "") + "=" + colName + ",";
                        }
                        else
                        {
                            insertVar += colName;
                            updateVar += colName.Replace("@", "") + "=" + colName;
                        }
                    }
                    else
                    {
                        primaryCol = colName;
                    }
                    structProc += colName + " " + colType + "=null,<br />";
                }

                structProc += "@Flg int";

                string Creater = "Create Procedure " + tbprocname.Text + "(<br />";
                string closeCreater = ") as Begin <br />";
                dt.TableName = tbname.Text;


                string insertedID = String.Format("Declare @lastID int<br />Set @lastID=IsNull((select max({0}) from {1}), 0)<br />Set {2}=@lastID+1<br />", primaryCol.Replace("@", ""), dt.TableName, primaryCol);
                string flg1 = String.Format("if @Flg=1<br />Begin<br />{1}<br />insert into " + dt.TableName + " output inserted.{0} values(" + insertVar + ") <br />End<br />", primaryCol.Replace("@", ""), insertedID);


                string flg2 = "if @Flg=2<br />Begin<br />update " + dt.TableName + " set " + updateVar + " where " + primaryCol.Replace("@", "") + "=" + primaryCol + " <br />End<br />";
                string flg3 = "if @Flg=3<br />Begin<br />delete from " + dt.TableName + " where " + primaryCol.Replace("@", "") + "=" + primaryCol + " <br />End<br />";
                string flg4 = "if @Flg=4<br />Begin<br /> select * from " + dt.TableName + " <br />End<br />";
                string flg5 = "if @Flg=5<br />Begin<br /> select * from " + dt.TableName + " where " + primaryCol.Replace("@", "") + "=" + primaryCol + "<br />End<br />";

                string hugeSeprator = "<br /><br />";
                string dbCreater = Creater + structProc + closeCreater + flg1 + flg2 + flg3 + flg4 + flg5 + "<br /> End" + hugeSeprator;

                //dbComm.Execute(dbCreater.Replace("<br />", " "));

                //Create DB Class
                string dbCommClass = "public class " + tbname.Text + "<br />{<br />Communicate dbComm = new Communicate();<br />SortedList" + Server.HtmlEncode("<string, object>") + " srt = new " + Server.HtmlEncode("SortedList<string, object>()") + ";<br />";
                string dbAdd = "public void Add(";
                string dbUpdate = "public void Update(";
                string dbDelete = "public void Delete(";
                string dbSelect = "public IDataReader Select()<br />";
                string dbSelectThis = "public IDataReader Select(";
                string dbAllAttribs = "";
                string firstAttrib = "";


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string colName = dt.Rows[i]["Column_name"].ToString();
                    string colType = dt.Rows[i]["Type"].ToString();
                    string colLength = dt.Rows[i]["Length"].ToString();
                    string colNullable = dt.Rows[i]["Nullable"].ToString();
                    string colPrec = dt.Rows[i]["Prec"].ToString();
                    string colScale = dt.Rows[i]["Scale"].ToString();

                    string colTypeCSharpe = "";


                    if (colType.ToLower().Contains("varchar"))
                    {
                        colTypeCSharpe = "string";
                    }
                    else if (colType.ToLower() == "int" || colType.ToLower() == "tinyint")
                    {
                        colTypeCSharpe = "int";
                    }
                    else if (colType.ToLower() == "decimal" || colType.ToLower() == "money")
                    {
                        colTypeCSharpe = "decimal";
                    }
                    else if (colType.ToLower() == "datetime")
                    {
                        colTypeCSharpe = "DateTime";
                    }
                    else if (colType.ToLower() == "bit")
                    {
                        colTypeCSharpe = "bool";
                    }


                    if (colNullable.ToLower() == "yes" && colTypeCSharpe != "string")
                    {
                        colTypeCSharpe += "? ";
                    }
                    else
                    {
                        colTypeCSharpe += " ";
                    }

                    dbAllAttribs += "srt.Add(\"" + colName + "\", " + colName + ");<br />";

                    if (i == 0)
                    {
                        dbAdd += colTypeCSharpe + colName;
                        dbUpdate += colTypeCSharpe + colName;
                        dbDelete += colTypeCSharpe + colName;
                        dbSelectThis += colTypeCSharpe + colName;

                        firstAttrib += "srt.Add(\"" + colName + "\", " + colName + ");<br />";
                    }
                    else
                    {
                        dbAdd += ", " + colTypeCSharpe + colName;
                        dbUpdate += ", " + colTypeCSharpe + colName;
                    }

                }

                dbAdd += "){<br />srt.Clear();<br />" + dbAllAttribs + "<br />srt.Add(\"Flg\", 1);<br />dbComm.Execute(srt, Communicate.StoredProcedures." + tbproc.Text + ");<br />}<br />";
                dbUpdate += "){<br />srt.Clear();<br />" + dbAllAttribs + "<br />srt.Add(\"Flg\", 2);<br />dbComm.Execute(srt, Communicate.StoredProcedures." + tbproc.Text + ");<br />}<br />";
                dbDelete += "){<br />srt.Clear();<br />" + firstAttrib + "<br />srt.Add(\"Flg\", 3);<br />dbComm.Execute(srt, Communicate.StoredProcedures." + tbproc.Text + ");<br />}<br />";
                dbSelect += "{<br />srt.Clear();<br />IDataReader idr = null;<br />" + "srt.Add(\"Flg\", 4);<br />idr = dbComm.SelectIDR(Communicate.StoredProcedures." + tbproc.Text + ", srt);<br />return idr;<br />}<br />";
                dbSelectThis += "){<br />srt.Clear();<br />IDataReader idr = null;<br />" + firstAttrib + "<br />srt.Add(\"Flg\", 5);<br />idr = dbComm.SelectIDR(Communicate.StoredProcedures." + tbproc.Text + ", srt);<br />return idr;<br />}<br />";


                dbCommClass += dbAdd + dbUpdate + dbDelete + dbSelect + dbSelectThis;
                dbCommClass += "<br />}<br />";


                // Create Business Object
                string bizObject = "public class obj" + tbname.Text + "<br />{<br />";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string colName = dt.Rows[i]["Column_name"].ToString();
                    string colType = dt.Rows[i]["Type"].ToString();
                    string colLength = dt.Rows[i]["Length"].ToString();
                    string colNullable = dt.Rows[i]["Nullable"].ToString();
                    string colPrec = dt.Rows[i]["Prec"].ToString();
                    string colScale = dt.Rows[i]["Scale"].ToString();

                    string colTypeCSharpe = "";


                    if (colType.ToLower().Contains("varchar"))
                    {
                        colTypeCSharpe = "string";
                    }
                    else if (colType.ToLower() == "int" || colType.ToLower() == "tinyint")
                    {
                        colTypeCSharpe = "int";
                    }
                    else if (colType.ToLower() == "decimal" || colType.ToLower() == "money")
                    {
                        colTypeCSharpe = "decimal";
                    }
                    else if (colType.ToLower() == "datetime")
                    {
                        colTypeCSharpe = "DateTime";
                    }
                    else if (colType.ToLower() == "bit")
                    {
                        colTypeCSharpe = "bool";
                    }


                    if (colNullable.ToLower() == "yes" && colTypeCSharpe != "string")
                    {
                        colTypeCSharpe += "? ";
                    }
                    else
                    {
                        colTypeCSharpe += " ";
                    }

                    bizObject += "public " + colTypeCSharpe + colName + " { get; set; }<br />";

                }

                bizObject += "<br />}<br />";



                //Create Business Class
                string bizClass = "public class " + tbname.Text + "<br />{<br />iDB" + moduleName + "." + tbname.Text + " db = new iDB" + moduleName + "." + tbname.Text + "();<br />";
                string addRoutine = "public void Add(obj" + tbname.Text + " i)<br />{<br />db.Add(";
                string updateRoutine = "public void Update(obj" + tbname.Text + " i)<br />{<br />db.Update(";
                string deleteRoutine = "public void Delete(int **0**)<br />{<br />db.Delete(**0**);<br />}<br />";
                string selectRoutine = "public IDataReader Select()<br />{<br />return db.Select();<br />}<br />";
                string selectThisRoutine = "public obj" + tbname.Text + " Select(int **0**)<br />{<br />IDataReader idr = db.Select(**0**);<br />return Select_Obj(idr);<br />}<br />";
                string selectObjPrivate = "private obj" + tbname.Text + " Select_Obj(IDataReader idr)<br />{<br />obj" + tbname.Text + " o = new obj" + tbname.Text + "();<br />bool rtNull = true;<br />if (idr != null){<br />while (idr.Read())<br />{<br />rtNull = false;<br />";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string colName = dt.Rows[i]["Column_name"].ToString();
                    string colType = dt.Rows[i]["Type"].ToString();
                    string colLength = dt.Rows[i]["Length"].ToString();
                    string colNullable = dt.Rows[i]["Nullable"].ToString();
                    string colPrec = dt.Rows[i]["Prec"].ToString();
                    string colScale = dt.Rows[i]["Scale"].ToString();

                    string colTypeCSharpe = "";


                    if (colType.ToLower().Contains("varchar"))
                    {
                        colTypeCSharpe = "string";
                    }
                    else if (colType.ToLower() == "int" || colType.ToLower() == "tinyint")
                    {
                        colTypeCSharpe = "int32";
                    }
                    else if (colType.ToLower() == "decimal" || colType.ToLower() == "money")
                    {
                        colTypeCSharpe = "decimal";
                    }
                    else if (colType.ToLower() == "datetime")
                    {
                        colTypeCSharpe = "DateTime";
                    }
                    else if (colType.ToLower() == "bit")
                    {
                        colTypeCSharpe = "bool";
                    }

                    TextInfo tInfo = new CultureInfo("en-US", false).TextInfo;
                    selectObjPrivate += "if (idr[\"" + colName + "\"] != DBNull.Value){<br />o." + colName + " = Convert.To" + tInfo.ToTitleCase(colTypeCSharpe).Replace("Bool", "Boolean").Replace("Datetime", "DateTime") + "(idr[\"" + colName + "\"]);<br />}<br />";

                    if (colNullable.ToLower() == "yes" && colTypeCSharpe != "string")
                    {
                        colTypeCSharpe += "? ";
                    }
                    else
                    {
                        colTypeCSharpe += " ";
                    }


                    if (i == 0)
                    {
                        addRoutine += "i." + colName;
                        updateRoutine += "i." + colName;
                        deleteRoutine = deleteRoutine.Replace("**0**", colName);
                        selectThisRoutine = selectThisRoutine.Replace("**0**", colName);
                    }
                    else
                    {
                        addRoutine += ", i." + colName;
                        updateRoutine += ", i." + colName;
                    }
                }


                addRoutine += ");<br />}<br />";
                updateRoutine += ");<br />}<br />";
                deleteRoutine += "<br />";
                selectThisRoutine += "<br />";
                selectObjPrivate += "}<br />}<br /> if (rtNull){<br />o = null;<br />}<br />return o; <br />}<br />";


                bizClass += addRoutine + updateRoutine + deleteRoutine + selectRoutine + selectThisRoutine + selectObjPrivate;
                bizClass += "<br /><br />" + bizObject + "<br />}<br />";

                string importChunks = "using System;<br />using System.Collections.Generic;<br />using System.Linq;<br />using System.Web;<br />using System.Data;<br />";
                bizClass = importChunks + "<br />namespace iBiz" + bizModuleName + "{<br />" + bizClass + "<br />}";

                dbCommClass = importChunks + "<br />namespace iDB" + moduleName + "{<br />" + dbCommClass + "<br />}";


                Edit_Communicate(tbproc.Text, tbprocname.Text);

                string[] bizFile = { Server.HtmlDecode(bizClass).Replace("<br />", "\r\n") };
                System.IO.File.WriteAllLines(bizPath, bizFile);

                string[] dbFile = { Server.HtmlDecode(dbCommClass).Replace("<br />", "\r\n") };
                System.IO.File.WriteAllLines(idbPath, dbFile);


                Response.Write(dbCreater + bizClass + dbCommClass);


                //Response.Write(dbCreater + dbAdd + hugeSeprator + dbUpdate + hugeSeprator + dbDelete + hugeSeprator + dbSelect + hugeSeprator + dbSelectThis + hugeSeprator + allObj + hugeSeprator + objDBBind + hugeSeprator + bizAdd + hugeSeprator + bizUpdate + hugeSeprator + bizDelete + hugeSeprator + bizSelectObj + hugeSeprator + allControls);

            }
        }

		private string Create_Object()
		{
			string rt = string.Empty;

			return rt;
		}

		private void Edit_Communicate(string procedure, string storedprocedure)
		{

			string filePath = @"D:\Projects\Hammond\HammondNewSite\HammondNew\iDB\Communicate.cs";



			string file = File.ReadAllText(filePath);

			file = file.Replace("//ProcedureGoesHere", "," + Environment.NewLine + procedure + "//ProcedureGoesHere");

			file = file.Replace("//ExecuteNow", "case StoredProcedures." + procedure + ":" + Environment.NewLine + "SaveUpdateDelete(srt, \"" + storedprocedure + "\");" + Environment.NewLine + "break;" + Environment.NewLine + "//ExecuteNow");

			file = file.Replace("//SelectDataTable", "case StoredProcedures." + procedure + ":" + Environment.NewLine + "dt = SelectValue(\"" + storedprocedure + "\", srt);" + Environment.NewLine + "break;" + Environment.NewLine + "//SelectDataTable");

			file = file.Replace("//SelectIDR", "case StoredProcedures." + procedure + ":" + Environment.NewLine + "idr = SelectReader(\"" + storedprocedure + "\", srt);" + Environment.NewLine + "break;" + Environment.NewLine + "//SelectIDR");


			File.WriteAllText(filePath, file);
		}
	}
}