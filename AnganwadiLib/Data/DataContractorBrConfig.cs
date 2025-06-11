using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class DataContractorBrConfig
    {
        AnganwadiLib.Business.ConractorBrConfig ObjContractorBrConfig;

        public DataContractorBrConfig()
        { }

        public DataContractorBrConfig(AnganwadiLib.Business.ConractorBrConfig BoConttractorBrConfig)
        {
            ObjContractorBrConfig = BoConttractorBrConfig;
        }

        public void Insert(AnganwadiLib.Business.ConractorBrConfig BoDepartmentBrConfig)
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
                com.CommandText = "aoup_contract_ins";

                com.Parameters.Add(new OracleParameter("in_BrId", OracleType.VarChar));
                com.Parameters["in_BrId"].Value = ObjContractorBrConfig.BrId;

                com.Parameters.Add(new OracleParameter("in_ContractName", OracleType.VarChar));
                com.Parameters["in_ContractName"].Value = ObjContractorBrConfig.ContractName;


             
                com.Parameters.Add(new OracleParameter("in_Address", OracleType.VarChar));
                com.Parameters["in_Address"].Value = ObjContractorBrConfig.Address;
        
                com.Parameters.Add(new OracleParameter("in_Email", OracleType.VarChar));
                com.Parameters["in_Email"].Value = ObjContractorBrConfig.Email;

                com.Parameters.Add(new OracleParameter("in_ContPerson", OracleType.Number));
                com.Parameters["in_ContPerson"].Value = ObjContractorBrConfig.ContactPerson;

                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.Number));
                com.Parameters["in_Mode"].Value = 1;

                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjContractorBrConfig.UserId;


                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjContractorBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjContractorBrConfig.ErrMsg = Errmsg;


            }
            catch (Exception ex)
            {
                ObjContractorBrConfig.ErrCode = 0;
                ObjContractorBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }

    }
}
