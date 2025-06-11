using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataReligion
    {
        BoReligion objreligion;

        public DataReligion()
        { }

        public DataReligion(BoReligion Religion)
        {
            objreligion = Religion;
        }

        public void Insertreligion(BoReligion Religion)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_religion_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Cmd.Parameters.Add("in_CompId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_ReligionId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_ReligionName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            //Cmd.Parameters["in_CompId"].Value = Religion.CompId;
            Cmd.Parameters["in_ReligionId"].Value = Religion.ReligionId;
            Cmd.Parameters["in_ReligionName"].Value = Religion.ReligionName;
            Cmd.Parameters["in_UserId"].Value = Religion.UserId;
            Cmd.Parameters["in_Mode"].Value = Religion.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            Religion.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            Religion.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
