using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataLogin
    {
        Login ObjUser;

        public DataLogin()
        { }

        public DataLogin(Login BoUser)
        {
            ObjUser = BoUser;
        }

        public void Login()
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
                com.CommandText = "aoup_login_fetch";

                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjUser.UserId;

                com.Parameters.Add(new OracleParameter("in_password", OracleType.VarChar));
                com.Parameters["in_password"].Value = ObjUser.Password;

                com.Parameters.Add(new OracleParameter("Out_CompId", OracleType.Number, 50));
                com.Parameters["Out_CompId"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_UserName", OracleType.VarChar, 100));
                com.Parameters["Out_UserName"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastLogin", OracleType.DateTime, 100));
                com.Parameters["Out_LastLogin"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastLogOut", OracleType.DateTime, 100));
                com.Parameters["Out_LastLogOut"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastChangePwd", OracleType.DateTime, 100));
                com.Parameters["Out_LastChangePwd"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_IsBlock", OracleType.VarChar, 2));
                com.Parameters["Out_IsBlock"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_DesgId", OracleType.Number, 50));
                com.Parameters["Out_DesgId"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_brid", OracleType.Number, 50));
                com.Parameters["Out_brid"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_branchname", OracleType.VarChar, 100));
                com.Parameters["Out_branchname"].Direction = ParameterDirection.Output;
                
                com.Parameters.Add(new OracleParameter("Out_compname", OracleType.VarChar, 100));
                com.Parameters["Out_compname"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_desgname", OracleType.VarChar, 100));
                com.Parameters["Out_desgname"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_brcategory", OracleType.Number, 100));
                com.Parameters["Out_brcategory"].Direction = ParameterDirection.Output;
                
                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 1000));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_ErrorMsg", OracleType.VarChar, 3000));
                com.Parameters["Out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String BrId = com.Parameters["Out_brid"].Value.ToString();
                ObjUser.Brid = BrId;

                String Branchname = com.Parameters["Out_branchname"].Value.ToString();
                ObjUser.Branchname = Branchname;
                
                String CompName = com.Parameters["Out_compname"].Value.ToString();
                ObjUser.Compname = CompName;

                String Compid = com.Parameters["Out_CompId"].Value.ToString();
                ObjUser.CompId = Compid;

                String UserName = com.Parameters["Out_UserName"].Value.ToString();
                ObjUser.UserName = UserName;

                String ErrCode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjUser.ErrCode = ErrCode;

                String ErrorMsg = com.Parameters["Out_ErrorMsg"].Value.ToString();
                ObjUser.ErrMsg = ErrorMsg;

                string LastLogOut = com.Parameters["Out_LastLogOut"].Value.ToString();
                ObjUser.LastLogout = LastLogOut;

                string LastLogin = com.Parameters["Out_LastLogin"].Value.ToString();
                ObjUser.LastLogin = LastLogin;

                string LastChangePwd = com.Parameters["Out_LastChangePwd"].Value.ToString();
                ObjUser.Lastchangepwd = LastChangePwd;

                String IsBlock = com.Parameters["Out_IsBlock"].Value.ToString();
                ObjUser.Blocked = IsBlock;
                
                String DesgId = com.Parameters["Out_DesgId"].Value.ToString();
                ObjUser.Desgid = DesgId;
                
                String DesgName = com.Parameters["Out_desgname"].Value.ToString();
                ObjUser.DesgName = DesgName;

                String brcategory = com.Parameters["Out_brcategory"].Value.ToString();
                ObjUser.brcategory = brcategory;
            }
            catch (Exception ex)
            {
                ObjUser.ErrCode = "0";
                ObjUser.ErrMsg = ex.Message;
            }
            finally
            {
                conn.Close();
                com.Dispose();
                conn.Dispose();
            }
        }

        public void LoginRandomPassword()
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
                com.CommandText = "aoup_login_RandomPassfetch";

                com.Parameters.Add(new OracleParameter("in_Empcode", OracleType.VarChar));
                com.Parameters["in_Empcode"].Value = ObjUser.UserId;

                com.Parameters.Add(new OracleParameter("in_password", OracleType.VarChar));
                com.Parameters["in_password"].Value = ObjUser.Password;

                com.Parameters.Add(new OracleParameter("Out_CompId", OracleType.Number, 50));
                com.Parameters["Out_CompId"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_UserName", OracleType.VarChar, 100));
                com.Parameters["Out_UserName"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastLogin", OracleType.DateTime, 100));
                com.Parameters["Out_LastLogin"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastLogOut", OracleType.DateTime, 100));
                com.Parameters["Out_LastLogOut"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_LastChangePwd", OracleType.DateTime, 100));
                com.Parameters["Out_LastChangePwd"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_IsBlock", OracleType.VarChar, 2));
                com.Parameters["Out_IsBlock"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_Type", OracleType.Number, 50));
                com.Parameters["Out_Type"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_DesgId", OracleType.Number, 50));
                com.Parameters["Out_DesgId"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_brid", OracleType.Number, 50));
                com.Parameters["Out_brid"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_branchname", OracleType.VarChar, 100));
                com.Parameters["Out_branchname"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_brcompid", OracleType.Number, 50));
                com.Parameters["Out_brcompid"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_compname", OracleType.VarChar, 100));
                com.Parameters["Out_compname"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_typename", OracleType.VarChar, 50));
                com.Parameters["Out_typename"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_desgname", OracleType.VarChar, 100));
                com.Parameters["Out_desgname"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_brcategory", OracleType.Number, 100));
                com.Parameters["Out_brcategory"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_role", OracleType.VarChar, 100));
                com.Parameters["Out_role"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_UserId", OracleType.VarChar, 100));
                com.Parameters["Out_UserId"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 1000));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("Out_ErrorMsg", OracleType.VarChar, 3000));
                com.Parameters["Out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String BrId = com.Parameters["Out_brid"].Value.ToString();
                ObjUser.Brid = BrId;

                String Branchname = com.Parameters["Out_branchname"].Value.ToString();
                ObjUser.Branchname = Branchname;

                String BrCompId = com.Parameters["Out_brcompid"].Value.ToString();
                ObjUser.Brcompid = BrCompId;

                String CompName = com.Parameters["Out_compname"].Value.ToString();
                ObjUser.Compname = CompName;

                String Compid = com.Parameters["Out_CompId"].Value.ToString();
                ObjUser.CompId = Compid;

                String UserName = com.Parameters["Out_UserName"].Value.ToString();
                ObjUser.UserName = UserName;

                String ErrCode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjUser.ErrCode = ErrCode;

                String ErrorMsg = com.Parameters["Out_ErrorMsg"].Value.ToString();
                ObjUser.ErrMsg = ErrorMsg;

                string LastLogOut = com.Parameters["Out_LastLogOut"].Value.ToString();
                ObjUser.LastLogout = LastLogOut;

                string LastLogin = com.Parameters["Out_LastLogin"].Value.ToString();
                ObjUser.LastLogin = LastLogin;

                string LastChangePwd = com.Parameters["Out_LastChangePwd"].Value.ToString();
                ObjUser.Lastchangepwd = LastChangePwd;

                String IsBlock = com.Parameters["Out_IsBlock"].Value.ToString();
                ObjUser.Blocked = IsBlock;

                String Type = com.Parameters["Out_Type"].Value.ToString();
                ObjUser.Type = Type;

                String DesgId = com.Parameters["Out_DesgId"].Value.ToString();
                ObjUser.Desgid = DesgId;

                String TypeName = com.Parameters["Out_typename"].Value.ToString();
                ObjUser.TypeName = TypeName;


                String DesgName = com.Parameters["Out_desgname"].Value.ToString();
                ObjUser.DesgName = DesgName;

                String brcategory = com.Parameters["Out_brcategory"].Value.ToString();
                ObjUser.brcategory = brcategory;


                String Role = com.Parameters["Out_role"].Value.ToString();
                ObjUser.Role = Role;

                String UserId = com.Parameters["Out_UserId"].Value.ToString();
                ObjUser.UserId = UserId;
            }
            catch (Exception ex)
            {
                ObjUser.ErrCode = "0";
                ObjUser.ErrMsg = ex.Message;
            }
            finally
            {
                conn.Close();
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
