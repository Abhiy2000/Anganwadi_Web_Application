using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataAllowence
    {
        BoAllowence objallow;

        public DataAllowence()
        { }

        public DataAllowence(BoAllowence allow)
        {
            objallow = allow;
        }

        public void InsertAllow(BoAllowence allow)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_allowence_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_CompID", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_DesgId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_PrjTypeId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_EduId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AllowName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AllowAmt", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar,500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_UserId"].Value = allow.UserId;
            Cmd.Parameters["in_CompID"].Value = allow.CompId;
            Cmd.Parameters["in_DesgId"].Value = allow.DesgId;
            Cmd.Parameters["in_PrjTypeId"].Value = allow.PrjId;
            Cmd.Parameters["in_EduId"].Value = allow.EduId;
            Cmd.Parameters["in_AllowName"].Value = allow.AllowName;
            Cmd.Parameters["in_AllowAmt"].Value = allow.Amt;
            Cmd.Parameters["in_Mode"].Value = allow.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            allow.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            allow.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
