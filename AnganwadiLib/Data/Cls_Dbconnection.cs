using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class Cls_Dbconnection
    {
        ~Cls_Dbconnection() { }
        public static OracleConnection dbconn()
        {
            try
            {
                OracleConnection conn;
                conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProjectMgmttest"].ConnectionString);
                return conn;
            }
            catch { return null; }
        }

    }
}
