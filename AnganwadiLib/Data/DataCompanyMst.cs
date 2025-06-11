using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace AnganwadiLib.Data
{
    class DataCompanyMst
    {
        AnganwadiLib.Business.CompanyMst ObjCompanyMst;

        public DataCompanyMst()
        { }

        public DataCompanyMst(AnganwadiLib.Business.CompanyMst BoCompanyMst)
        {
            ObjCompanyMst = BoCompanyMst;
        }

        public void Insert(AnganwadiLib.Business.CompanyMst BoCompanyMst)
        {
            OracleConnection conn = Cls_Dbconnection.dbconn();
            OracleCommand com = new OracleCommand();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                }

                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = "aoup_company_ins";

                com.Parameters.Add(new OracleParameter("in_Category", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_Parent", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_CorpId", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_CompanyName", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_BranchName", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_CompCode", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_Address", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_PhoneNumber", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_EmailAddress", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_BankBranchId", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_BankAccNo", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_ProjectTypeId", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_OfficerNM", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_PinCode", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_PrjCode", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_DistCode", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.Number)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar)).Direction = ParameterDirection.Input;
                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100)).Direction = ParameterDirection.Output;
                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 200)).Direction = ParameterDirection.Output;

                if (ObjCompanyMst.Category == null)
                {
                    com.Parameters["in_Category"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_Category"].Value = ObjCompanyMst.Category;
                }
                if (ObjCompanyMst.Parent == null)
                {

                    com.Parameters["in_Parent"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_Parent"].Value = ObjCompanyMst.Parent;
                }

                if (ObjCompanyMst.CorpId == null)
                {
                    com.Parameters["in_CorpId"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_CorpId"].Value = ObjCompanyMst.CorpId;
                }

                if (ObjCompanyMst.CompanyName == null || ObjCompanyMst.CompanyName == "")
                {
                    com.Parameters["in_CompanyName"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_CompanyName"].Value = ObjCompanyMst.CompanyName;
                }
               
                if (ObjCompanyMst.BranchName == null || ObjCompanyMst.BranchName == "")
                {
                    com.Parameters["in_BranchName"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_BranchName"].Value = ObjCompanyMst.BranchName;
                }
                if (ObjCompanyMst.Code == null || ObjCompanyMst.Code == "")
                {
                    com.Parameters["in_CompCode"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_CompCode"].Value = ObjCompanyMst.Code;
                }
                if (ObjCompanyMst.Address == null || ObjCompanyMst.Address == "")
                {
                    com.Parameters["in_Address"].Value = ObjCompanyMst.Address;
                }
                else
                {
                    com.Parameters["in_Address"].Value = ObjCompanyMst.Address;
                }

                if (ObjCompanyMst.PhoneNumber == 0 || ObjCompanyMst.PhoneNumber == null)
                {
                    com.Parameters["in_PhoneNumber"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_PhoneNumber"].Value = ObjCompanyMst.PhoneNumber;
                }

                if (ObjCompanyMst.EmailAddress == "" || ObjCompanyMst.EmailAddress == null)
                {
                    com.Parameters["in_EmailAddress"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_EmailAddress"].Value = ObjCompanyMst.EmailAddress;
                }

                if (ObjCompanyMst.BankBranchId == 0 || ObjCompanyMst.BankBranchId == null)
                {
                    com.Parameters["in_BankBranchId"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_BankBranchId"].Value = ObjCompanyMst.BankBranchId;
                }

                if (ObjCompanyMst.BankAccNo == "" || ObjCompanyMst.BankAccNo == null)
                {
                    com.Parameters["in_BankAccNo"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_BankAccNo"].Value = ObjCompanyMst.BankAccNo;
                }

                if (ObjCompanyMst.ProjectTypeId == 0 || ObjCompanyMst.ProjectTypeId == 0)
                {
                    com.Parameters["in_ProjectTypeId"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_ProjectTypeId"].Value = ObjCompanyMst.ProjectTypeId;
                }

                if (ObjCompanyMst.OfficerNM == "" || ObjCompanyMst.OfficerNM ==null)
                {
                    com.Parameters["in_OfficerNM"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_OfficerNM"].Value = ObjCompanyMst.OfficerNM;
                }

                if (ObjCompanyMst.PinCode == 0 || ObjCompanyMst.PinCode == null)
                {
                    com.Parameters["in_PinCode"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_PinCode"].Value = ObjCompanyMst.PinCode;
                }
                if (ObjCompanyMst.PrjCode == 0 || ObjCompanyMst.PrjCode == null)
                {
                    com.Parameters["in_PrjCode"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_PrjCode"].Value = ObjCompanyMst.PrjCode;
                }
                if (ObjCompanyMst.DistCode == 0 || ObjCompanyMst.DistCode == null)
                {
                    com.Parameters["in_DistCode"].Value = DBNull.Value;
                }
                else
                {
                    com.Parameters["in_DistCode"].Value = ObjCompanyMst.DistCode;
                }

                com.Parameters["in_Mode"].Value = ObjCompanyMst.Mode;
                com.Parameters["in_UserId"].Value = ObjCompanyMst.UserId;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjCompanyMst.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjCompanyMst.ErrMsg = Errmsg;
            }

            catch (Exception ex)
            {
                ObjCompanyMst.ErrCode = 0;
                ObjCompanyMst.ErrMsg = ex.Message;
            }

            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
