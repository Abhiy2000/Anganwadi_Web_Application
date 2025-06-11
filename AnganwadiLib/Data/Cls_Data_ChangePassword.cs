using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;


namespace AnganwadiLib.Data
{
    public class Cls_Data_ChangePassword
    {
        AnganwadiLib.Business.Cls_Business_ChangePassword ObjChangePass;

        public Cls_Data_ChangePassword()
        { }

        public Cls_Data_ChangePassword(AnganwadiLib.Business.Cls_Business_ChangePassword BoChangePass)
        {
            ObjChangePass = BoChangePass;
        }

        public void Update(AnganwadiLib.Business.Cls_Business_ChangePassword BoChangePass)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_changepassword_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
            Cmd.Parameters.Add("in_OldPassword", OracleType.VarChar);
            Cmd.Parameters.Add("in_NewPassword", OracleType.VarChar);
            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

            Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_OldPassword"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_NewPassword"].Direction = ParameterDirection.Input;
            Cmd.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;
            Cmd.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

            Cmd.Parameters["in_UserId"].Value = BoChangePass.UserId;
            Cmd.Parameters["in_OldPassword"].Value = BoChangePass.OldPassword;
            Cmd.Parameters["in_NewPassword"].Value = BoChangePass.NewPassword;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();
            BoChangePass.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
            BoChangePass.ErrorMessage = Cmd.Parameters["out_ErrorMsg"].Value.ToString();

        }
    }
}
