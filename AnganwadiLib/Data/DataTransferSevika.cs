using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataTransferSevika
    {
        BoTransferSevika objTrfSev;

        public DataTransferSevika()
        { }

        public DataTransferSevika(BoTransferSevika TrfSev)
        {
            objTrfSev = TrfSev;
        }

        public void Insert(BoTransferSevika TrfSev)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_transfer_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_OldBitId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_NewBitId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_OldAnganwadiId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_NewAnganwadiId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AadharNo", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_SevikaId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_OldBitId"].Value = TrfSev.OldBitId;
            Cmd.Parameters["in_NewBitId"].Value = TrfSev.NewBitId;
            Cmd.Parameters["in_OldAnganwadiId"].Value = TrfSev.OldAnganwadiId;
            Cmd.Parameters["in_NewAnganwadiId"].Value = TrfSev.NewAnganwadiId;
            Cmd.Parameters["in_AadharNo"].Value = TrfSev.AadharNo;
            Cmd.Parameters["in_SevikaId"].Value = TrfSev.SevikaId;
            Cmd.Parameters["in_UserId"].Value = TrfSev.UserId;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            TrfSev.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            TrfSev.ErrMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }

        public void Authorized(BoTransferSevika TrfSev)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_transfer_auth", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_OldBitId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_NewBitId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_OldAnganwadiId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_NewAnganwadiId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AadharNo", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_SevikaId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Status", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Remark", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_TransferDate", OracleType.DateTime).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

            Cmd.Parameters["in_OldBitId"].Value = TrfSev.OldBitId;
            Cmd.Parameters["in_NewBitId"].Value = TrfSev.NewBitId;
            Cmd.Parameters["in_OldAnganwadiId"].Value = TrfSev.OldAnganwadiId;
            Cmd.Parameters["in_NewAnganwadiId"].Value = TrfSev.NewAnganwadiId;
            Cmd.Parameters["in_AadharNo"].Value = TrfSev.AadharNo;
            Cmd.Parameters["in_SevikaId"].Value = TrfSev.SevikaId;
            Cmd.Parameters["in_Status"].Value = TrfSev.Status;
            Cmd.Parameters["in_Remark"].Value = TrfSev.Remark;
            Cmd.Parameters["in_TransferDate"].Value = TrfSev.TransferDate;
            Cmd.Parameters["in_UserId"].Value = TrfSev.UserId;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            TrfSev.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            TrfSev.ErrMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
