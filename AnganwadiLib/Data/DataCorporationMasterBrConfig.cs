using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataCorporationMasterBrConfig
    {
        CorporationMasterBrConfig ObjCorporationMasterBrConfig;        
        
        public DataCorporationMasterBrConfig()
        { }

        public DataCorporationMasterBrConfig(CorporationMasterBrConfig BoCorporationMasterBrConfig)
        {
            ObjCorporationMasterBrConfig = BoCorporationMasterBrConfig;
        }

        public void Insert(CorporationMasterBrConfig BoCorporationMasterBrConfig)
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
                com.CommandText = "aoup_corporation_master_ins";

                com.Parameters.Add(new OracleParameter("in_BrId", OracleType.Number));
                com.Parameters["in_BrId"].Value = ObjCorporationMasterBrConfig.BrId;

                //com.Parameters.Add(new OracleParameter("in_CorpId", OracleType.Number));
                //com.Parameters["in_CorpId"].Value = ObjCorporationMasterBrConfig.CorpId;

                com.Parameters.Add(new OracleParameter("in_ParentId", OracleType.Number));
                com.Parameters["in_ParentId"].Value = ObjCorporationMasterBrConfig.ParentID;

                com.Parameters.Add(new OracleParameter("in_CorporationName", OracleType.VarChar));
                com.Parameters["in_CorporationName"].Value = ObjCorporationMasterBrConfig.CorporationName;

                com.Parameters.Add(new OracleParameter("in_Class", OracleType.VarChar));
                com.Parameters["in_Class"].Value = ObjCorporationMasterBrConfig.Class;

                com.Parameters.Add(new OracleParameter("in_CorpBranch", OracleType.VarChar));
                com.Parameters["in_CorpBranch"].Value = ObjCorporationMasterBrConfig.CorpBranch;

                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjCorporationMasterBrConfig.UserId;

                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjCorporationMasterBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjCorporationMasterBrConfig.ErrMsg = Errmsg;
            }
            catch (Exception ex)
            {
                ObjCorporationMasterBrConfig.ErrCode = 0;
                ObjCorporationMasterBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
