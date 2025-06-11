using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataAttendenceAccess
    {
        BoAttendenceAccess objAttend;

        public DataAttendenceAccess()
        { }

        public DataAttendenceAccess(BoAttendenceAccess AttendAccess)
        {
            objAttend = AttendAccess;
        }

        public void Insert(BoAttendenceAccess AttendAccess)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_attendencemenu_access", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
            Cmd.Parameters.Add("in_StateId", OracleType.Number);
            Cmd.Parameters.Add("in_Str", OracleType.VarChar);
            Cmd.Parameters.Add("in_Str1", OracleType.VarChar);
            Cmd.Parameters.Add("in_Str2", OracleType.VarChar);

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

            Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_StateId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Str"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Str1"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Str2"].Direction = ParameterDirection.Input;

            Cmd.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;
            Cmd.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

            Cmd.Parameters["in_UserId"].Value = AttendAccess.UserId;
            Cmd.Parameters["in_StateId"].Value = AttendAccess.StateId;            
            Cmd.Parameters["in_Str"].Value = AttendAccess.Str;
            Cmd.Parameters["in_Str1"].Value = AttendAccess.Str1;
            Cmd.Parameters["in_Str2"].Value = AttendAccess.Str2;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            AttendAccess.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
            AttendAccess.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
