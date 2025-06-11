using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataRelation
    {
        BoRelation objrelation;

        public DataRelation()
        { }

        public DataRelation(BoRelation Relation)
        {
            objrelation = Relation;
        }

        public void Insertrelation(BoRelation Relation)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_relation_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_relationId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_relationName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_relationId"].Value = Relation.RelationId;
            Cmd.Parameters["in_relationName"].Value = Relation.RelationName;
            Cmd.Parameters["in_UserId"].Value = Relation.UserId;
            Cmd.Parameters["in_Mode"].Value = Relation.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            Relation.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            Relation.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
