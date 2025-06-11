using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace AnganwadiLib.Data
{
    public class GetCon
    {
        public OracleConnection connection = new OracleConnection();

        public GetCon()
        {
            connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProjectMgmttest"].ConnectionString);
        }

        public void OpenConn()
        {
            connection.Open();
        }

        public void CloseConn()
        {
            connection.Close();
        }
    }
}
