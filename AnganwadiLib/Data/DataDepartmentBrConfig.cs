﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class DataDepartmentBrConfig
    {
        AnganwadiLib.Business.DepartmentBrConfig ObjDepartmentBrConfig;

        public DataDepartmentBrConfig()
        { }

        public DataDepartmentBrConfig(AnganwadiLib.Business.DepartmentBrConfig BoDepartmentBrConfig)
        {
            ObjDepartmentBrConfig = BoDepartmentBrConfig;
        }


        public void Insert(AnganwadiLib.Business.DepartmentBrConfig BoDepartmentBrConfig)
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
                com.CommandText = "aoup_department_ins";

                com.Parameters.Add(new OracleParameter("in_BrId", OracleType.VarChar));
                com.Parameters["in_BrId"].Value = ObjDepartmentBrConfig.BrId;

                com.Parameters.Add(new OracleParameter("in_DepartmentId", OracleType.VarChar));
                com.Parameters["in_DepartmentId"].Value = ObjDepartmentBrConfig.DepartmentId;



                com.Parameters.Add(new OracleParameter("in_Department", OracleType.VarChar));
                com.Parameters["in_Department"].Value = ObjDepartmentBrConfig.Department;


                com.Parameters.Add(new OracleParameter("in_UserId", OracleType.VarChar));
                com.Parameters["in_UserId"].Value = ObjDepartmentBrConfig.DepartmentId;

                com.Parameters.Add(new OracleParameter("in_Mode", OracleType.VarChar));
                com.Parameters["in_Mode"].Value = ObjDepartmentBrConfig.Mode;


                com.Parameters.Add(new OracleParameter("out_ErrorCode", OracleType.Number, 100));
                com.Parameters["out_ErrorCode"].Direction = ParameterDirection.Output;

                com.Parameters.Add(new OracleParameter("out_ErrorMsg", OracleType.VarChar, 100));
                com.Parameters["out_ErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                String Errcode = com.Parameters["out_ErrorCode"].Value.ToString();
                ObjDepartmentBrConfig.ErrCode = Convert.ToInt32(Errcode);

                String Errmsg = com.Parameters["out_ErrorMsg"].Value.ToString();
                ObjDepartmentBrConfig.ErrMsg = Errmsg;


            }
            catch (Exception ex)
            {
                ObjDepartmentBrConfig.ErrCode = 0;
                ObjDepartmentBrConfig.ErrMsg = ex.Message;
            }
            finally
            {
                com.Dispose();
                conn.Dispose();
            }
        }
    }
}
