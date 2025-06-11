using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class DataUserAccess
    {
        UserAccess ObjUserAccess;

        public DataUserAccess()
        {
        }

        public DataUserAccess(UserAccess BoUserAccess)
        {
            ObjUserAccess = BoUserAccess;
        }

        public void UpDate(UserAccess BoUserAccess)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();
            OracleCommand Cmd = new OracleCommand("aoup_useraccess_ins", Con.connection);

            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_BrId", OracleType.Number);
            Cmd.Parameters.Add("in_UserCode", OracleType.VarChar);
            Cmd.Parameters.Add("in_AccessString", OracleType.VarChar);
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

            Cmd.Parameters["in_BrId"].Direction = System.Data.ParameterDirection.Input;
            Cmd.Parameters["in_UserCode"].Direction = System.Data.ParameterDirection.Input;
            Cmd.Parameters["in_AccessString"].Direction = System.Data.ParameterDirection.Input;
            Cmd.Parameters["in_UserId"].Direction = System.Data.ParameterDirection.Input;

            Cmd.Parameters["out_ErrorCode"].Direction = System.Data.ParameterDirection.Output;
            Cmd.Parameters["out_ErrorMsg"].Direction = System.Data.ParameterDirection.Output;

            Cmd.Parameters["in_BrId"].Value = ObjUserAccess.BrId;
            Cmd.Parameters["in_UserCode"].Value = ObjUserAccess.UserCode;
            Cmd.Parameters["in_AccessString"].Value = ObjUserAccess.AccessString;
            Cmd.Parameters["in_UserId"].Value = ObjUserAccess.UserId;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();
            ObjUserAccess.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
            ObjUserAccess.ErrorMessage = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
