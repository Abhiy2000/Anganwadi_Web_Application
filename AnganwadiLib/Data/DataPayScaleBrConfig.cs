using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using AnganwadiLib.Business;

namespace AnganwadiLib.Data
{
    public class DataPayScaleBrConfig
    {
        PayScaleBrConfig ObjPayBrConfig;

        public DataPayScaleBrConfig()
        { }

        public DataPayScaleBrConfig(AnganwadiLib.Business.PayScaleBrConfig BoPayBrConfig)
        {
            ObjPayBrConfig = BoPayBrConfig;
        }
        public void Insert(AnganwadiLib.Business.PayScaleBrConfig BoPayBrConfig)
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
                com.CommandText = "aoup_payscal_ins";

                com.Parameters.Add(new OracleParameter("in_BrId", OracleType.Number));
                com.Parameters["in_BrId"].Value = ObjPayBrConfig.BrId;
                com.Parameters.Add(new OracleParameter("in_payscalid", OracleType.Number));
                com.Parameters["in_payscalid"].Value = ObjPayBrConfig.PayId;
                com.Parameters.Add(new OracleParameter("in_PrjTypeId", OracleType.Number));
                com.Parameters["in_PrjTypeId"].Value = ObjPayBrConfig.ProjId;
                com.Parameters.Add(new OracleParameter("in_EduId", OracleType.Number));
                com.Parameters["in_EduId"].Value = ObjPayBrConfig.EduId;
                com.Parameters.Add(new OracleParameter("in_payscal", OracleType.VarChar));
                com.Parameters["in_payscal"].Value = ObjPayBrConfig.Pay;
                com.Parameters.Add(new OracleParameter("in_wages", OracleType.Number));
                com.Parameters["in_wages"].Value = ObjPayBrConfig.Wages;
                com.Parameters.Add(new OracleParameter("in_central", OracleType.Number));
                com.Parameters["in_central"].Value = ObjPayBrConfig.Central;
                com.Parameters.Add(new OracleParameter("in_state", OracleType.Number));
                com.Parameters["in_state"].Value = ObjPayBrConfig.State;
                com.Parameters.Add(new OracleParameter("in_fixed", OracleType.Number));
                com.Parameters["in_fixed"].Value = ObjPayBrConfig.fixed1;
                com.Parameters.Add(new OracleParameter("in_Active", OracleType.VarChar));
                com.Parameters["in_Active"].Value = ObjPayBrConfig.Active;
                com.Parameters.Add(new OracleParameter("in_desigid", OracleType.Number));
                com.Parameters["in_desigid"].Value = ObjPayBrConfig.Desigid;
                com.Parameters.Add(new OracleParameter("in_expfrom", OracleType.Number));
                com.Parameters["in_expfrom"].Value = ObjPayBrConfig.Expfrom;
                com.Parameters.Add(new OracleParameter("in_expto", OracleType.Number));
                com.Parameters["in_expto"].Value = ObjPayBrConfig.Expto;
                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjPayBrConfig.UserId;
                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.Number));
                com.Parameters["in_Mode"].Value = ObjPayBrConfig.Mode;
                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjPayBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjPayBrConfig.ErrMsg = Errmsg;


            }
            catch (Exception ex)
            {
                ObjPayBrConfig.ErrCode = 0;
                ObjPayBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
