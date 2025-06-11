using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataSevikaAuth
    {
        BoSevikaAuth objSevAuth;

        public DataSevikaAuth()
        { }

        public DataSevikaAuth(BoSevikaAuth SevAuth)
        {
            objSevAuth = SevAuth;
        }

        public void AuthSevika(BoSevikaAuth SevAuth)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_sevika_auth", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_CompId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_SevikaCode", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_CompId"].Value = SevAuth.CompId;
            Cmd.Parameters["in_SevikaCode"].Value = SevAuth.SevikaCode;
            Cmd.Parameters["in_UserId"].Value = SevAuth.UserId;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            SevAuth.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            SevAuth.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
