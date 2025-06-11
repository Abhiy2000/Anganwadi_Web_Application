using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataCPSMS
    {
        BoCPSMS obcpsms;

        public DataCPSMS()
        { }

        public DataCPSMS(BoCPSMS cpsms)
        {
            obcpsms = cpsms;
        }

        public void UpdateCPSMS(BoCPSMS cpsms)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_cpsms_updt", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_FileName", OracleType.VarChar).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("in_ParamStr", OracleType.VarChar).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_UserId"].Value = cpsms.UserId;
            Cmd.Parameters["in_FileName"].Value = cpsms.FileName;

            Cmd.Parameters["in_ParamStr"].Value = cpsms.Str;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            cpsms.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            cpsms.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
