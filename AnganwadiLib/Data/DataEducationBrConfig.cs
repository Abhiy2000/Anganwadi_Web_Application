﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class DataEducationBrConfig
    {
        AnganwadiLib.Business.EducationBrConfig ObjEducationBrConfig;
        public DataEducationBrConfig()
        { }

        public DataEducationBrConfig(AnganwadiLib.Business.EducationBrConfig BoEducationBrConfig)
        {
            ObjEducationBrConfig = BoEducationBrConfig;
        }

        public void Insert(AnganwadiLib.Business.EducationBrConfig BoEducationBrConfig)
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
                com.CommandText = "aoup_education_ins";

                //com.Parameters.Add(new OracleParameter("in_BrId", OracleType.VarChar));
                //com.Parameters["in_BrId"].Value = ObjEducationBrConfig.BrId;



                com.Parameters.Add(new OracleParameter("in_EducationId", OracleType.VarChar));
                com.Parameters["in_EducationId"].Value = ObjEducationBrConfig.EducationId;



                com.Parameters.Add(new OracleParameter("in_EducationName", OracleType.VarChar));
                com.Parameters["in_EducationName"].Value = ObjEducationBrConfig.Education;


                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjEducationBrConfig.UserId;

                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.VarChar));
                com.Parameters["in_Mode"].Value = ObjEducationBrConfig.Mode;


                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjEducationBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjEducationBrConfig.ErrMsg = Errmsg;


            }
            catch (Exception ex)
            {
                ObjEducationBrConfig.ErrCode = 0;
                ObjEducationBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
