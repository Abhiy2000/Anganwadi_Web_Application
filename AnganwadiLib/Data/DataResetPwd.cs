using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataResetPwd
    {
        BoResetPwd ObjResetPwd;

        public DataResetPwd()
        { }

        public DataResetPwd(BoResetPwd BoResetPwd)
        {
            ObjResetPwd = BoResetPwd;
        }

        public void Update(BoResetPwd BoResetPwd)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_resetpassword_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
            Cmd.Parameters.Add("in_NewPassword", OracleType.VarChar);
            Cmd.Parameters.Add("in_insby", OracleType.VarChar);
            Cmd.Parameters.Add("in_remark", OracleType.VarChar);
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

            Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_NewPassword"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_insby"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_remark"].Direction = ParameterDirection.Input;
            Cmd.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;
            Cmd.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

            Cmd.Parameters["in_UserId"].Value = BoResetPwd.UserId;
            Cmd.Parameters["in_NewPassword"].Value = BoResetPwd.NewPassword;
            Cmd.Parameters["in_insby"].Value = BoResetPwd.Insby;
            Cmd.Parameters["in_remark"].Value = BoResetPwd.Remark;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();
            BoResetPwd.ErrCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
            BoResetPwd.ErrMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
