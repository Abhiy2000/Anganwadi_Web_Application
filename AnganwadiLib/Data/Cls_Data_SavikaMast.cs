using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class Cls_Data_SavikaMast
    {
        Cls_Business_SavikaMast ObjSavikaMast;

        public Cls_Data_SavikaMast()
        { }

        public Cls_Data_SavikaMast(Cls_Business_SavikaMast BoSavikaMast)
        {
            ObjSavikaMast = BoSavikaMast;
        }

        public void Update(Cls_Business_SavikaMast BoSavikaMast)
        {
            Data.GetCon Con = new GetCon();
            Con.OpenConn();

            OracleCommand Cmd = new OracleCommand("aoup_sevika_ins", Con.connection);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            Cmd.Parameters.Add("in_CompID", OracleType.Number);
            Cmd.Parameters.Add("in_SevikaID", OracleType.Number);
            Cmd.Parameters.Add("in_UserId", OracleType.VarChar);
            Cmd.Parameters.Add("in_AnganId", OracleType.Number);
            Cmd.Parameters.Add("in_Name", OracleType.VarChar);
            Cmd.Parameters.Add("in_SevikaCode", OracleType.VarChar);
            Cmd.Parameters.Add("in_EducId", OracleType.Number);
            Cmd.Parameters.Add("in_BirthDate", OracleType.DateTime);
            Cmd.Parameters.Add("in_RetireDate", OracleType.DateTime);
            Cmd.Parameters.Add("in_Address", OracleType.VarChar);
            Cmd.Parameters.Add("in_MobileNo", OracleType.NVarChar);
            Cmd.Parameters.Add("in_PhoneNo", OracleType.NVarChar);
            Cmd.Parameters.Add("in_PanNo", OracleType.NVarChar);
            Cmd.Parameters.Add("in_AadharNo", OracleType.VarChar);
            Cmd.Parameters.Add("in_JoinDate", OracleType.DateTime);
            Cmd.Parameters.Add("in_OrderNo", OracleType.VarChar);
            Cmd.Parameters.Add("in_Orderdate", OracleType.DateTime);
            Cmd.Parameters.Add("in_DesigID", OracleType.Number);
            Cmd.Parameters.Add("in_PayScalID", OracleType.Number);
            Cmd.Parameters.Add("in_BranchId", OracleType.Number);
            Cmd.Parameters.Add("in_AccNo", OracleType.NVarChar);
            Cmd.Parameters.Add("in_Remark", OracleType.VarChar);
            Cmd.Parameters.Add("in_Active", OracleType.VarChar);
            Cmd.Parameters.Add("in_Mode", OracleType.Number);
            Cmd.Parameters.Add("in_CPSMSCode", OracleType.VarChar);
            Cmd.Parameters.Add("in_ReligID", OracleType.Number);
            Cmd.Parameters.Add("in_CastID", OracleType.Number);
            Cmd.Parameters.Add("in_MiddleName", OracleType.VarChar);
            Cmd.Parameters.Add("in_Village", OracleType.VarChar);
            Cmd.Parameters.Add("in_PinCode", OracleType.VarChar);
            Cmd.Parameters.Add("in_maritstatid", OracleType.Number);
            Cmd.Parameters.Add("in_Reason", OracleType.VarChar);
            Cmd.Parameters.Add("in_Experience", OracleType.Number);//----added on 24-03-18

            Cmd.Parameters.Add("in_Nom1Name", OracleType.VarChar);
            Cmd.Parameters.Add("in_Nom1RelatnId", OracleType.Number);
            Cmd.Parameters.Add("in_Nom1Age", OracleType.Number);
            Cmd.Parameters.Add("in_Nom1Address", OracleType.VarChar);
            Cmd.Parameters.Add("in_Nom2Name", OracleType.VarChar);
            Cmd.Parameters.Add("in_Nom2RelationId", OracleType.Number);
            Cmd.Parameters.Add("in_Nom2Age", OracleType.Number);
            Cmd.Parameters.Add("in_Nom2Address", OracleType.VarChar);

            Cmd.Parameters.Add("out_ErrorCode", OracleType.Number, 5);
            Cmd.Parameters.Add("out_ErrorMsg", OracleType.VarChar, 300);

            Cmd.Parameters["in_CompID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_SevikaID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_UserId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_AnganId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Name"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_SevikaCode"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_EducId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_BirthDate"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_RetireDate"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Address"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_MobileNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_PhoneNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_PanNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_AadharNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_JoinDate"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_OrderNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Orderdate"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_DesigID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_PayScalID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_BranchId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_AccNo"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Remark"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Active"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Mode"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_CPSMSCode"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_ReligID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_CastID"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_MiddleName"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Village"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_PinCode"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_maritstatid"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Reason"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Experience"].Direction = ParameterDirection.Input; //----added on 24-03-18

            Cmd.Parameters["in_Nom1Name"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom1RelatnId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom1Age"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom1Address"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom2Name"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom2RelationId"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom2Age"].Direction = ParameterDirection.Input;
            Cmd.Parameters["in_Nom2Address"].Direction = ParameterDirection.Input;

            Cmd.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;
            Cmd.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

            Cmd.Parameters["in_CompID"].Value = BoSavikaMast.CompID;
            Cmd.Parameters["in_SevikaID"].Value = BoSavikaMast.SevikaID;
            Cmd.Parameters["in_UserId"].Value = BoSavikaMast.UserID;
            Cmd.Parameters["in_AnganId"].Value = BoSavikaMast.AnganId;
            Cmd.Parameters["in_Name"].Value = BoSavikaMast.Name;
            Cmd.Parameters["in_SevikaCode"].Value = BoSavikaMast.SevikaCode;

            if (BoSavikaMast.EducId != 0)
            {
                Cmd.Parameters["in_EducId"].Value = BoSavikaMast.EducId;
            }
            else
            {
                Cmd.Parameters["in_EducId"].Value = DBNull.Value;
            }
            if (BoSavikaMast.BirthDate != DateTime.MinValue)
            {
                Cmd.Parameters["in_BirthDate"].Value = BoSavikaMast.BirthDate;
            }
            else
            {
                Cmd.Parameters["in_BirthDate"].Value = DBNull.Value;
            }
            if (BoSavikaMast.RetireDate != DateTime.MinValue)
            {
                Cmd.Parameters["in_RetireDate"].Value = BoSavikaMast.RetireDate;
            }
            else
            {
                Cmd.Parameters["in_RetireDate"].Value = DBNull.Value;
            }
            Cmd.Parameters["in_Address"].Value = BoSavikaMast.Address;
            Cmd.Parameters["in_MobileNo"].Value = BoSavikaMast.MobileNo;
            Cmd.Parameters["in_PhoneNo"].Value = BoSavikaMast.PhoneNo;
            Cmd.Parameters["in_PanNo"].Value = BoSavikaMast.PanNo;
            Cmd.Parameters["in_AadharNo"].Value = BoSavikaMast.AadharNo;
            if (BoSavikaMast.JoinDate != DateTime.MinValue)
            {
                Cmd.Parameters["in_JoinDate"].Value = BoSavikaMast.JoinDate;
            }
            else
            {
                Cmd.Parameters["in_JoinDate"].Value = DBNull.Value;
            }

            Cmd.Parameters["in_OrderNo"].Value = BoSavikaMast.OrderNo;
            if (BoSavikaMast.Orderdate != DateTime.MinValue)
            {
                Cmd.Parameters["in_Orderdate"].Value = BoSavikaMast.Orderdate;
            }
            else
            {
                Cmd.Parameters["in_Orderdate"].Value = DBNull.Value;
            }

            if (BoSavikaMast.DesigID != 0)
            {
                Cmd.Parameters["in_DesigID"].Value = BoSavikaMast.DesigID;
            }
            else
            {
                Cmd.Parameters["in_DesigID"].Value = DBNull.Value;
            }

            if (BoSavikaMast.PayScalID != 0)
            {
                Cmd.Parameters["in_PayScalID"].Value = BoSavikaMast.PayScalID;
            }
            else
            {
                Cmd.Parameters["in_PayScalID"].Value = DBNull.Value;
            }

            if (BoSavikaMast.BranchId != 0)
            {
                Cmd.Parameters["in_BranchId"].Value = BoSavikaMast.BranchId;
            }
            else
            {
                Cmd.Parameters["in_BranchId"].Value = DBNull.Value;
            }
            Cmd.Parameters["in_AccNo"].Value = BoSavikaMast.AccNo;
            Cmd.Parameters["in_Remark"].Value = BoSavikaMast.Remark;
            Cmd.Parameters["in_Active"].Value = BoSavikaMast.Active;
            Cmd.Parameters["in_Mode"].Value = BoSavikaMast.Mode;
            Cmd.Parameters["in_CPSMSCode"].Value = BoSavikaMast.CPSMSCode;

            if (BoSavikaMast.ReligID != 0)
            {
                Cmd.Parameters["in_ReligID"].Value = BoSavikaMast.ReligID;
            }
            else
            {
                Cmd.Parameters["in_ReligID"].Value = DBNull.Value;
            }

            if (BoSavikaMast.CastID != 0)
            {
                Cmd.Parameters["in_CastID"].Value = BoSavikaMast.CastID;
            }
            else
            {
                Cmd.Parameters["in_CastID"].Value = DBNull.Value;
            }

            if (BoSavikaMast.Maritstatid != 0)
            {
                Cmd.Parameters["in_maritstatid"].Value = BoSavikaMast.Maritstatid;
            }
            else
            {
                Cmd.Parameters["in_maritstatid"].Value = DBNull.Value;
            }

            if (BoSavikaMast.Reason != "")
            {
                Cmd.Parameters["in_Reason"].Value = BoSavikaMast.Reason;
            }
            else
            {
                Cmd.Parameters["in_Reason"].Value = DBNull.Value;
            }

            //-------------added on 24-03-18 -----------
            if (BoSavikaMast.Experience != 0)
            {
                Cmd.Parameters["in_Experience"].Value = BoSavikaMast.Experience;
            }
            else
            {
                Cmd.Parameters["in_Experience"].Value = DBNull.Value;
            }
            //-------------------------------------

            Cmd.Parameters["in_MiddleName"].Value = BoSavikaMast.MiddleName;
            Cmd.Parameters["in_Village"].Value = BoSavikaMast.Village;
            Cmd.Parameters["in_PinCode"].Value = BoSavikaMast.PinCode;

            if (BoSavikaMast.Nom1Name != "")
            {
                Cmd.Parameters["in_Nom1Name"].Value = BoSavikaMast.Nom1Name;
            }
            else
            {
                Cmd.Parameters["in_Nom1Name"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom1RelatnId != 0)
            {
                Cmd.Parameters["in_Nom1RelatnId"].Value = BoSavikaMast.Nom1RelatnId;
            }
            else
            {
                Cmd.Parameters["in_Nom1RelatnId"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom1Age != 0)
            {
                Cmd.Parameters["in_Nom1Age"].Value = BoSavikaMast.Nom1Age;
            }
            else
            {
                Cmd.Parameters["in_Nom1Age"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom1Address != "")
            {
                Cmd.Parameters["in_Nom1Address"].Value = BoSavikaMast.Nom1Address;
            }
            else
            {
                Cmd.Parameters["in_Nom1Address"].Value = DBNull.Value;
            }

            if (BoSavikaMast.Nom2Name != "")
            {
                Cmd.Parameters["in_Nom2Name"].Value = BoSavikaMast.Nom2Name;
            }
            else
            {
                Cmd.Parameters["in_Nom2Name"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom2RelationId != 0)
            {
                Cmd.Parameters["in_Nom2RelationId"].Value = BoSavikaMast.Nom2RelationId;
            }
            else
            {
                Cmd.Parameters["in_Nom2RelationId"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom2Age != 0)
            {
                Cmd.Parameters["in_Nom2Age"].Value = BoSavikaMast.Nom2Age;
            }
            else
            {
                Cmd.Parameters["in_Nom2Age"].Value = DBNull.Value;
            }
            if (BoSavikaMast.Nom2Address != "")
            {
                Cmd.Parameters["in_Nom2Address"].Value = BoSavikaMast.Nom2Address;
            }
            else
            {
                Cmd.Parameters["in_Nom2Address"].Value = DBNull.Value;
            }

            Cmd.Parameters["out_ErrorCode"].Value = BoSavikaMast.ErrorCode;
            Cmd.Parameters["out_ErrorMsg"].Value = BoSavikaMast.ErrorMessage;

            Cmd.ExecuteNonQuery();
            Con.CloseConn();
            BoSavikaMast.ErrorCode = Convert.ToInt32(Cmd.Parameters["out_ErrorCode"].Value);
            BoSavikaMast.ErrorMessage = Cmd.Parameters["out_ErrorMsg"].Value.ToString();

        }
    }
}
