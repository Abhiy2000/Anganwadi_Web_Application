using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using AnganwadiLib.Business;
using System.Data;

namespace AnganwadiLib.Data
{
    public class DataBranch
    {
        BoBranch objBranch;

        public DataBranch()
        { }

        public DataBranch(BoBranch Branch)
        {
            objBranch = Branch;
        }

        public void InsertBranch(BoBranch Branch)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_bankbranch_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
           
            Cmd.Parameters.Add("in_BranchId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_BranchName", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_BankId", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_IFSCCode", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("in_Mode", OracleType.Number).Direction = ParameterDirection.Input;
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5).Direction = ParameterDirection.Output;
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 5000000).Direction = ParameterDirection.Output;

            //Cmd.Parameters["in_UserId"].Value = Branch.UserId;
            Cmd.Parameters["in_BranchId"].Value = Branch.Branchid;
            Cmd.Parameters["in_BranchName"].Value = Branch.Branchname;
            Cmd.Parameters["in_BankId"].Value = Branch.Bankid;
            Cmd.Parameters["in_IFSCCode"].Value = Branch.Ifscnumber;
            Cmd.Parameters["in_UserId"].Value = Branch.UserId;
            Cmd.Parameters["in_Mode"].Value = Branch.Mode;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();

            Branch.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);//-100
            Branch.ErrorMsg = Cmd.Parameters["out_ErrorMsg"].Value.ToString();
        }
    }
}
