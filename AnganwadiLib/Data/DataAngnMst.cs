using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnganwadiLib.Business;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataAngnMst
    {
        BoAnganMst objangn;

        public DataAngnMst()
        { }

        public DataAngnMst(BoAnganMst angn)
        {
            objangn = angn;
        }

        public void InsertAngn(BoAnganMst angn)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_angnwadimst_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_BrId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AngnID", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_PrjTypeId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AngnName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_AngnCode", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Address", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Email", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_MobileNo", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_PhoneNo", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Active", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_PinCode", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar,500).Direction = ParameterDirection.Output;
            
            Cmd.Parameters["in_BrId"].Value=objangn.BrId;
            Cmd.Parameters["in_AngnID"].Value = objangn.AngnID;
            if (objangn.PrjTypeId == 0 || objangn.PrjTypeId == null)
            {
                Cmd.Parameters["in_PrjTypeId"].Value = DBNull.Value;
            }
            else
            {
                Cmd.Parameters["in_PrjTypeId"].Value = objangn.PrjTypeId;
            }

            Cmd.Parameters["in_AngnName"].Value = objangn.AngnName;
            Cmd.Parameters["in_AngnCode"].Value = objangn.AngnCode;
            Cmd.Parameters["in_Address"].Value = objangn.Address;
            Cmd.Parameters["in_Email"].Value = objangn.Email;

            if (objangn.MobileNo != 0 && objangn.MobileNo != null)
            {
                Cmd.Parameters["in_MobileNo"].Value = objangn.MobileNo;
            }
            else
            {
                Cmd.Parameters["in_MobileNo"].Value = DBNull.Value;
            }

            if (objangn.PhoneNo != "" && objangn.PhoneNo != null)
            {
                Cmd.Parameters["in_PhoneNo"].Value = objangn.PhoneNo;
            }
            else
            {
                Cmd.Parameters["in_PhoneNo"].Value = DBNull.Value;
            }
            Cmd.Parameters["in_Active"].Value = objangn.Active;

            if (objangn.PinCode != 0 && objangn.PinCode !=null)
            {
                Cmd.Parameters["in_PinCode"].Value = objangn.PinCode;
            }
            else
            {
                Cmd.Parameters["in_PinCode"].Value = DBNull.Value;
            }
            Cmd.Parameters["in_UserId"].Value = objangn.UserId;
            Cmd.Parameters["in_Mode"].Value = objangn.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            angn.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            angn.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
