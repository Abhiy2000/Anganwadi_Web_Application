using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataRetirementAge
    {
        BoRetirementAge objAge;

        public DataRetirementAge()
        { }

        public DataRetirementAge(BoRetirementAge Age)
        {
            objAge = Age;
        }

        public void InsertAge(BoRetirementAge Age)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_retirementage_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Cmd.Parameters.Add("in_CompId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AgeId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Age", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_DesgId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AffectDate", OracleType.DateTime).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            //Cmd.Parameters["in_CompId"].Value = Cast.CompId;
            Cmd.Parameters["in_AgeId"].Value = Age.AgeId;
            Cmd.Parameters["in_Age"].Value = Age.Age;
            Cmd.Parameters["in_DesgId"].Value = Age.Desg;
            Cmd.Parameters["in_AffectDate"].Value = Age.AffectDate;
            Cmd.Parameters["in_UserId"].Value = Age.UserId;
            Cmd.Parameters["in_Mode"].Value = Age.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            Age.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            Age.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
