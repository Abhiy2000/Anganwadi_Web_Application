using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class DataProjectBrConfig
    {
         AnganwadiLib.Business.ProjectBrConfig ObjProjectBrConfig;
         public DataProjectBrConfig()
        { }

         public DataProjectBrConfig(AnganwadiLib.Business.ProjectBrConfig BoProjectBrConfig)
        {
            ObjProjectBrConfig = BoProjectBrConfig;
        }

         public void Insert(AnganwadiLib.Business.ProjectBrConfig BoProjectBrConfig)
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
                com.CommandText = "aoup_projecttype_ins";

                com.Parameters.Add(new OracleParameter("in_BrId", OracleType.VarChar));
                com.Parameters["in_BrId"].Value = ObjProjectBrConfig.BrId;



                com.Parameters.Add(new OracleParameter("in_ProjTypeId", OracleType.VarChar));
                com.Parameters["in_ProjTypeId"].Value = ObjProjectBrConfig.ProjectId;



                com.Parameters.Add(new OracleParameter("in_ProjectType", OracleType.VarChar));
                com.Parameters["in_ProjectType"].Value = ObjProjectBrConfig.Project;


                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjProjectBrConfig.UserId;

                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.VarChar));
                com.Parameters["in_Mode"].Value = ObjProjectBrConfig.Mode;

                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjProjectBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjProjectBrConfig.ErrMsg = Errmsg;


            }
            catch (Exception ex)
            {
                ObjProjectBrConfig.ErrCode = 0;
                ObjProjectBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }

    }
}
