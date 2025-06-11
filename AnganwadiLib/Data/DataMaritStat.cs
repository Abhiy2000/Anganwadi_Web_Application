using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataMaritStat
    {
        BoMaritStat objMaritStat;

        public DataMaritStat()
        { }

        public DataMaritStat(BoMaritStat MaritStat)
        {
            objMaritStat = MaritStat;
        }

        public void InsertMaritStat(BoMaritStat MaritStat)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_maritstat_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_MaritStatId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_MaritStatName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_MaritStatId"].Value = MaritStat.MaritStatId;
            Cmd.Parameters["in_MaritStatName"].Value = MaritStat.MaritStatName;
            Cmd.Parameters["in_UserId"].Value = MaritStat.UserId;
            Cmd.Parameters["in_Mode"].Value = MaritStat.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            MaritStat.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            MaritStat.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
