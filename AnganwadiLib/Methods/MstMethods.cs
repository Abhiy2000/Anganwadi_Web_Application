using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using AnganwadiLib.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace AnganwadiLib.Methods
{
    public class MstMethods
    {
        public class Query2DataTable
        {
            public static object GetResult(String Query)
            {
                DataTable MstTbl = new DataTable();

                Data.GetCon Con = new Data.GetCon();
                Con.OpenConn();

                OracleCommand Cmd = new OracleCommand(Query, Con.connection);
                OracleDataAdapter AdpData = new OracleDataAdapter();
                AdpData.SelectCommand = Cmd;
                AdpData.Fill(MstTbl);

                Con.CloseConn();

                return MstTbl;
            }
        }

        public class Dropdown
        {
            public static object Fill(System.Web.UI.WebControls.DropDownList Dropdown, String TableName, String DisplayField, String ValueField, String Condition, String SqlQuery)
            {
                String query;
                String DISTINCT = "";

                if (ValueField != null && ValueField.ToUpper().Contains("DISTINCT"))
                {
                    DISTINCT = "Y";
                }

                if (SqlQuery == "")
                {
                    if (Condition == "" || Condition == null)
                    {
                        query = "select " + DisplayField + ", " + ValueField + " from " + TableName;
                    }
                    else
                    {
                        query = "select " + DisplayField + ", " + ValueField + " from " + TableName + " where " + Condition;
                    }
                }
                else
                {
                    query = SqlQuery;
                }

                Data.GetCon con = new Data.GetCon();
                con.OpenConn();

                OracleCommand cmd = new OracleCommand(query, con.connection);
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("DisplayField", typeof(String));
                dt.Columns.Add("ValueField", typeof(String));
                dt.Rows.Add("-- Select Option --", null);
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }

                Dropdown.DataSource = dt;
                Dropdown.DataTextField = dt.Columns[0].ToString();
                Dropdown.DataValueField = dt.Columns[1].ToString();
                Dropdown.DataBind();
                con.CloseConn();
                return Dropdown;
            }
        }

        public class LastLogOut
        {
            public static object LastLogout(String UserId)
            {
                OracleConnection conn = Cls_Dbconnection.dbconn();
                OracleCommand com = new OracleCommand();

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                    }
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = conn;
                    com.CommandText = "aoup_logout_upd";
                    com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                    com.Parameters["in_UserId"].Value = UserId;
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    com.Dispose();
                    conn.Dispose();
                }
                return UserId;
            }
        }

        public class UploadImage
        {
            public static void UploadBlobImg(string UserId, byte[] mydataLogo, string imagetype)
            {
                Data.GetCon con = new Data.GetCon();

                String Query = "update aoup_usermst_def set var_usermst_imagetype='" + imagetype + "' , blob_usermst_proofimage = :BLOBLogo where var_usermst_userid = '" + UserId + "'";
                OracleParameter BLOBLogo = new OracleParameter();
                BLOBLogo.OracleType = OracleType.Blob;
                BLOBLogo.ParameterName = "BLOBLogo";
                BLOBLogo.Value = mydataLogo;
                OracleCommand Cmd = new OracleCommand(Query, con.connection);
                Cmd.Parameters.Add(BLOBLogo);
                con.OpenConn();
                int a = Cmd.ExecuteNonQuery();
                con.CloseConn();
            }

            public static void UploadBlobImg2(string UserId, byte[] mydataLogo, string imagetype)
            {
                Data.GetCon con = new Data.GetCon();

                String Query = "update aoup_usermst_def set var_usermst_imagetype2='" + imagetype + "' , blob_usermst_proofimage2 = :BLOBLogo where var_usermst_userid = '" + UserId + "'";
                OracleParameter BLOBLogo = new OracleParameter();
                BLOBLogo.OracleType = OracleType.Blob;
                BLOBLogo.ParameterName = "BLOBLogo";
                BLOBLogo.Value = mydataLogo;
                OracleCommand Cmd = new OracleCommand(Query, con.connection);
                Cmd.Parameters.Add(BLOBLogo);
                con.OpenConn();
                int a = Cmd.ExecuteNonQuery();
                con.CloseConn();
            }

            public static void UploadBranchBlobImg(string BrId, byte[] mydataLogo)
            {
                Data.GetCon con = new Data.GetCon();

                String Query = "update aoup_companymst_def set blob_companymst_logo = :BLOBLogo where num_companymst_compid = '" + BrId + "'";
                OracleParameter BLOBLogo = new OracleParameter();
                BLOBLogo.OracleType = OracleType.Blob;
                BLOBLogo.ParameterName = "BLOBLogo";
                BLOBLogo.Value = mydataLogo;
                OracleCommand Cmd = new OracleCommand(Query, con.connection);
                Cmd.Parameters.Add(BLOBLogo);
                con.OpenConn();
                int a = Cmd.ExecuteNonQuery();
                con.CloseConn();
            }
        }

        public class DataSource
        {
            public static object GetDateSource()
            {
                AnganwadiLib.Data.GetCon con = new GetCon();
                String a = con.connection.ConnectionString;
                String b = con.connection.DataSource;
                return b;
            }
        }

        public class GetSelectedRow
        {
            public static void GetRow(DataTable TblList, String ColumName, String TblName, String Conditions)
            {
                Data.GetCon Con = new GetCon();
                Con.OpenConn();
                String query = "select " + ColumName + " from " + TblName + " where " + Conditions + " ";
                OracleCommand Cmd = new OracleCommand(query, Con.connection);
                OracleDataAdapter AdpData = new OracleDataAdapter();
                AdpData.SelectCommand = Cmd;
                AdpData.Fill(TblList);
                Con.CloseConn();
            }
        }

        public class DataUpload
        {
            public static Object Upload(string filepath, string ctlfilenamepath, string logfilepath, string tablecol, string dbsid, string dbuser, string dbpwd, string tablename)
            {
                string tablecolumn = "";
                String returnval = "";
                Data.GetCon con = new GetCon();
                con.OpenConn();
                if (tablecol == "")
                {
                    if (tablename == "")
                    {
                        return returnval = "";
                    }
                    else
                    {
                        string str = "select column_name abc from user_tab_columns  where upper(table_name)=upper('" + tablename + "') order by column_id ";

                        OracleCommand cmd = new OracleCommand(str, con.connection);
                        OracleDataReader droper = cmd.ExecuteReader();

                        bool a = droper.HasRows;

                        while (droper.Read())
                        {
                            tablecolumn += droper["abc"].ToString() + ",";
                        }

                        droper.Close();
                        tablecolumn = "(" + tablecolumn.ToString().TrimEnd(',') + ")";
                    }
                }
                con.connection.Close();

                try
                {
                    string file = "";
                    string a = "LOAD DATA";
                    string b = "INFILE '" + filepath + "'";
                    string c = "INSERT INTO  TABLE " + tablename + " ";
                    string d = "APPEND";
                    string g = "FIELDS TERMINATED BY ";
                    string h = "" + "\"" + "	" + "\"";
                    string e = "TRAILING NULLCOLS";
                    if (tablecol == "")
                    {
                        file = a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d + Environment.NewLine + g + h + Environment.NewLine + e + Environment.NewLine + tablecolumn;
                    }
                    else
                    {
                        file = a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d + Environment.NewLine + g + h + Environment.NewLine + e + Environment.NewLine + tablecol;
                    }

                    StreamWriter sw = new StreamWriter(ctlfilenamepath);
                    sw.WriteLine(file);

                    sw.Flush();
                    sw.Close();

                    string ctlfilename = ctlfilenamepath.Substring(ctlfilenamepath.LastIndexOf('\\') + 1);
                    string dir = ctlfilenamepath.Substring(0, ctlfilenamepath.LastIndexOf('\\'));
                    string logfilename = logfilepath.Substring(logfilepath.LastIndexOf('\\') + 1);

                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");

                    psi.Arguments = @"/c sqlldr " + dbuser + "/" + dbpwd + "@" + dbsid + " control=" + ctlfilename + " log=" + logfilename + " ";

                    psi.UseShellExecute = false;
                    psi.RedirectStandardOutput = true;
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardError = true;
                    psi.WorkingDirectory = dir;

                    System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
                    System.IO.StreamReader sOut = proc.StandardOutput;
                    System.IO.StreamWriter sIn = proc.StandardInput;

                    string results = sOut.ReadToEnd().Trim();

                    proc.WaitForExit();

                    if (proc.ExitCode == 0)
                    {
                        returnval = "0";
                    }
                    else
                    {
                        System.IO.StreamReader sError = proc.StandardError;
                        returnval = sError.ReadToEnd().Trim();
                    }
                }

                catch (Exception e)
                {
                    returnval = e.Message.ToString();
                }

                return returnval;
            }

            public static void DeleteBeforeUpload(Int32 BrId, String TblName, String ClmName)
            {
                Data.GetCon con = new GetCon();
                con.OpenConn();
                string str = "delete " + TblName + " where " + ClmName + " = '" + BrId + "'";

                OracleCommand cmd = new OracleCommand(str, con.connection);
                int a = cmd.ExecuteNonQuery();

                con.CloseConn();
            }

            public static void TempDataUploadLogIns(Int32 BrId, String DBTable, String Status, String UserName)
            {
                Data.GetCon Con = new GetCon();
                Con.OpenConn();
                OracleCommand Cmd = new OracleCommand("aoup_datauploadtemplog_ins", Con.connection);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.Parameters.Add("in_Brid", OracleType.Number);
                Cmd.Parameters.Add("in_table", OracleType.VarChar);
                Cmd.Parameters.Add("in_Status", OracleType.VarChar);
                Cmd.Parameters.Add("in_UserId", OracleType.VarChar);

                Cmd.Parameters["in_Brid"].Direction = ParameterDirection.Input;
                Cmd.Parameters["in_table"].Direction = ParameterDirection.Input;
                Cmd.Parameters["in_Status"].Direction = ParameterDirection.Input;
                Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;

                Cmd.Parameters["in_Brid"].Value = BrId;
                Cmd.Parameters["in_table"].Value = DBTable;
                Cmd.Parameters["in_Status"].Value = Status;
                Cmd.Parameters["in_UserId"].Value = UserName;

                Cmd.ExecuteNonQuery();
                Con.CloseConn();
            }

            public static void GetMackerRights(DataTable Tbl, String BrId)
            {
                Data.GetCon Con = new GetCon();
                Con.OpenConn();

                String query = "select num_templog_brid, var_templog_table, var_templog_status, var_tepmlog_finalestatus from aoup_temp_log where num_templog_brid = " + BrId;

                OracleCommand Cmd = new OracleCommand(query, Con.connection);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = Cmd;

                da.Fill(Tbl);
                Con.CloseConn();
            }

            public static Object TempToFinaleErrorLog(Int32 BrId, String TableName)
            {
                String ErrorMessage = "";
                DataTable Tbl = new DataTable();
                Data.GetCon Con = new GetCon();
                Con.OpenConn();

                String query = "select num_errorlog_description from aoup_errorlog_cust where num_errorlog_brid = " + BrId + " and num_errorlog_tablename = '" + TableName + "'";

                OracleCommand Cmd = new OracleCommand(query, Con.connection);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = Cmd;
                da.Fill(Tbl);
                Con.CloseConn();

                for (int i = 0; i < Tbl.Rows.Count; i++)
                {
                    ErrorMessage += i + 1 + ") " + Tbl.Rows[i][0].ToString() + Environment.NewLine;
                }
                return ErrorMessage;
            }

            public static void TempToFinale(String ProcdName, Int32 BrId, String UserName, out Int32 ErrorCode, out String ErrorMessage)
            {
                Data.GetCon Con = new GetCon();
                Con.OpenConn();
                OracleCommand Cmd = new OracleCommand(ProcdName, Con.connection);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.Parameters.Add("in_Brid", OracleType.Number);
                Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
                Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
                Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

                Cmd.Parameters["in_Brid"].Direction = ParameterDirection.Input;
                Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;
                Cmd.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;
                Cmd.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                Cmd.Parameters["in_Brid"].Value = BrId;
                Cmd.Parameters["in_UserId"].Value = UserName;

                Cmd.ExecuteNonQuery();
                Con.CloseConn();

                ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
                ErrorMessage = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
            }
        }

        public class aadharcard
        {
            static int[,] d = new int[,]    
            { 
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 
            {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
            {2, 3, 4, 0, 1, 7, 8, 9, 5, 6}, 
            {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
            {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
            {5, 9, 8, 7, 6, 0, 4, 3, 2, 1}, 
            {6, 5, 9, 8, 7, 1, 0, 4, 3, 2}, 
            {7, 6, 5, 9, 8, 2, 1, 0, 4, 3}, 
            {8, 7, 6, 5, 9, 3, 2, 1, 0, 4}, 
            {9, 8, 7, 6, 5, 4, 3, 2, 1, 0} 
            };

            static int[,] p = new int[,] 
             {
             {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
             {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
             {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
             {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
             {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
             {4, 2, 8, 6, 5, 7, 3, 9, 0, 1}, 
             {2, 7, 9, 3, 8, 0, 6, 4, 1, 5}, 
             {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
             };

            static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

            public static bool validateVerhoeff(string num)
            {
                int c = 0; int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[(i % 8), myArray[i]]];
                }
                return c == 0;
            }

            public static bool validateAadharNumber(String aadharNumber)
            {
                //Pattern aadharPattern = Pattern.compile("\\d{12}");

                //bool isValidAadhar = aadharPattern.matcher(aadharNumber).matches();

                //if (isValidAadhar)
                //{

                //    isValidAadhar = aadharcard.validateVerhoeff(aadharNumber);

                //}

                //return isValidAadhar;
                return true;
            }

            public static string generateVerhoeff(string num)
            {
                int c = 0;
                int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[((i + 1) % 8), myArray[i]]];
                }
                return inv[c].ToString();
            }

            private static int[] StringToReversedIntArray(string num)
            {
                int[] myArray = new int[num.Length];
                for (int i = 0; i < num.Length; i++)
                {
                    myArray[i] = int.Parse(num.Substring(i, 1));
                }
                Array.Reverse(myArray); return myArray;
            }
        }

        public class Report
        {
            public static Byte[] ViewReport(String BrId, DataTable DTbl, String RptPath, String ExportPath, String[] Parameter, String[] ParameterValue, String ReportType,
                 String CorporationNameE, String CorporationNameM, String BrNameMar, String BrNameEng, String BrAddMar, String BrAddEng)
            {
                if (ReportType == "pdf")
                {
                    ShowReport(BrId, DTbl, RptPath, ExportPath, Parameter, ParameterValue, CorporationNameE, CorporationNameM, BrNameMar, BrNameEng, BrAddMar,
                       BrAddEng);
                }
                else if (ReportType == "xls")
                {
                    ShowReportExcel(BrId, DTbl, RptPath, ExportPath, Parameter, ParameterValue, CorporationNameE, CorporationNameM, BrNameMar, BrNameEng, BrAddMar,
                       BrAddEng);
                }
                else if (ReportType == "xlsRec")
                {
                    ShowReportExcelRecord(BrId.ToString(), DTbl, RptPath, ExportPath, Parameter, ParameterValue, CorporationNameE, CorporationNameM, BrNameMar, BrNameEng, BrAddMar,
                       BrAddEng);
                }

                FileStream fs = null;
                fs = File.Open(ExportPath, FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                return btFile;
            }


            public static void ShowReport(String BrId, DataTable DTbl, String RptPath, String ExportPath, String[] Parameter, String[] ParameterValue,
                String CorporationNameE, String CorporationNameM, String BrNameMar, String BrNameEng, String BrAddMar, String BrAddEng)
            {
                ReportDocument rpt = new ReportDocument();
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTbl);

                rpt.Load(RptPath);
                rpt.SetDataSource(DSet.Tables[0]);

                //rpt.SetParameterValue("CorporationNameE", CorporationNameE);
                //rpt.SetParameterValue("CorporationNameM", CorporationNameM);
                //rpt.SetParameterValue("BrNameMar", BrNameMar);
                //rpt.SetParameterValue("BrNameEng", BrNameEng);
                //rpt.SetParameterValue("BrAddMar", BrAddMar);
                //rpt.SetParameterValue("BrAddEng", BrAddEng);

                for (int i = 0; i < Parameter.Length; i++)
                {
                    String ArrParameter = Parameter[i];
                    String ArrParameterValue = ParameterValue[i];

                    //String ArrParameterValue = ParameterValue[i];
                    rpt.SetParameterValue(ArrParameter, ArrParameterValue);
                }


                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ExportPath);
                rpt.Close();
                rpt.Dispose();
            }

            public static void ShowReportExcel(String BrId, DataTable DTbl, String RptPath, String ExportPath, String[] Parameter, String[] ParameterValue,
                String CorporationNameE, String CorporationNameM, String BrNameMar, String BrNameEng, String BrAddMar, String BrAddEng)
            {
                ReportDocument rpt = new ReportDocument();
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTbl);

                rpt.Load(RptPath);
                rpt.SetDataSource(DSet.Tables[0]);

                rpt.SetParameterValue("CorporationNameE", CorporationNameE);
                rpt.SetParameterValue("CorporationNameM", CorporationNameM);
                rpt.SetParameterValue("BrNameMar", BrNameMar);
                rpt.SetParameterValue("BrNameEng", BrNameEng);
                rpt.SetParameterValue("BrAddMar", BrAddMar);
                rpt.SetParameterValue("BrAddEng", BrAddEng);

                for (int i = 0; i < Parameter.Length; i++)
                {
                    String ArrParameter = Parameter[i];
                    String ArrParameterValue = ParameterValue[i];
                    rpt.SetParameterValue(ArrParameter, ArrParameterValue);
                }

                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, ExportPath);
                rpt.Close();
                rpt.Dispose();
            }

            public static void ShowReportExcelRecord(String BrId, DataTable DTbl, String RptPath, String ExportPath, String[] Parameter, String[] ParameterValue,
                String CorporationNameE, String CorporationNameM, String BrNameMar, String BrNameEng, String BrAddMar, String BrAddEng)
            {
                ReportDocument rpt = new ReportDocument();
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTbl);

                rpt.Load(RptPath);
                rpt.SetDataSource(DSet.Tables[0]);

                rpt.SetParameterValue("CorporationNameE", CorporationNameE);
                rpt.SetParameterValue("CorporationNameM", CorporationNameM);
                rpt.SetParameterValue("BrNameMar", BrNameMar);
                rpt.SetParameterValue("BrNameEng", BrNameEng);
                rpt.SetParameterValue("BrAddMar", BrAddMar);
                rpt.SetParameterValue("BrAddEng", BrAddEng);

                for (int i = 0; i < Parameter.Length; i++)
                {
                    String ArrParameter = Parameter[i];
                    String ArrParameterValue = ParameterValue[i];
                    rpt.SetParameterValue(ArrParameter, ArrParameterValue);
                }

                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, ExportPath);
                rpt.Close();
                rpt.Dispose();
            }

            public static void ShowReportCr(String BrId, DataTable DTbl, String RptPath, String ExportPath, String[] Parameter, String[] ParameterValue, out ReportDocument rpt,
                 String CorporationNameE, String CorporationNameM, String BrNameMar, String BrNameEng, String BrAddMar, String BrAddEng, String UserId, String Header)
            {
                rpt = new ReportDocument();

                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTbl);

                rpt.Load(RptPath);
                rpt.SetDataSource(DSet.Tables[0]);

                rpt.SetParameterValue("CorporationNameE", CorporationNameE);
                rpt.SetParameterValue("CorporationNameM", CorporationNameM);
                rpt.SetParameterValue("BrNameMar", BrNameMar);
                rpt.SetParameterValue("BrNameEng", BrNameEng);
                rpt.SetParameterValue("BrAddMar", BrAddMar);
                rpt.SetParameterValue("BrAddEng", BrAddEng);
                rpt.SetParameterValue("UserId", UserId);
                rpt.SetParameterValue("Header", Header);

                for (int i = 0; i < Parameter.Length; i++)
                {
                    String ArrParameter = Parameter[i];
                    String ArrParameterValue = ParameterValue[i];
                    rpt.SetParameterValue(ArrParameter, ArrParameterValue);
                }
            }
        }

        public static void write_log(string Source, string Description)
        {
            StreamWriter sw = null;

            try
            {
                string DATA_LOG = "C:\\Anganwadi_Log\\";

                DirectoryInfo dir = new DirectoryInfo(DATA_LOG);

                if (dir.Exists)
                {
                    string filePath = DATA_LOG + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_Log.log";

                    sw = new StreamWriter(filePath, true);
                    DateTime dtNow = DateTime.Now;
                    sw.WriteLine("----------------------------------------------------------");
                    sw.WriteLine(dtNow.ToString("dd-MM-yyyy HH:mm:ss") + " | " + Source + " | " + Description);
                    sw.Flush();
                    sw.Dispose();
                }
            }

            catch
            {
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }

        public static void PasswordStrength(String password, out Boolean Flag, out string Msg)
        {
            Flag = false;
            Msg = "";

            Boolean numflag = false, alphflag = false;

            if (password.Length > 7)
            {
                foreach (char pchar in password)
                {
                    string input = "0123456789";
                    string input2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                    foreach (char inum in input)
                    {
                        if (inum == pchar)
                        {
                            numflag = true;
                        }
                    }
                    foreach (char ichar in input2)
                    {
                        if (ichar == pchar)
                        {
                            alphflag = true;
                        }
                    }
                    if (numflag == true && alphflag == true)
                    {
                        Flag = true;
                    }
                    else
                    {
                        Flag = false;
                        Msg = "Password need to contain both alphabates and numbers";
                    }
                }
            }
            else
            {
                Flag = false;
                Msg = "Password length should be minimum 8 character";
            }
        }

        public static string ChkRights(string UserId, string PagePath)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();
            DataTable Tbl = new DataTable();
            string MenuRights = "";

            try
            {
                String str = " select * from aoup_menumst_def inner join aoup_menuusersmst_def on num_menumst_menuid=num_menuusersmst_menuid ";
                str += " where var_menuusersmst_userid='" + UserId + "' and var_menumst_pagepath='" + PagePath + "' ";

                OracleCommand Cmd = new OracleCommand(str, Con.connection);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = Cmd;

                da.Fill(Tbl);
                Con.CloseConn();

                if (Tbl.Rows.Count > 0)
                {
                    MenuRights = "Y";
                }
                else
                {
                    MenuRights = "N";
                }
            }
            catch (Exception ex)
            {
                //MenuRights = ex.Message.ToString();
            }
            return MenuRights;
        }
    }
}
