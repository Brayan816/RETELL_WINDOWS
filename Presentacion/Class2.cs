using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;

namespace Presentacion
{
    class CONEXION2
    {
        public ForwardedPort port2;
        public SshClient client2;
        public MySqlConnection connecDB2;
        public string HOST = "localhost";
        public string DATABASE = "llantas";
        public string USERNAME = "root";
        public string PASSWORD = "";
        public CONEXION2()
        {
            string connectionString = "SERVER=" + HOST + ";port=3306;username=" + USERNAME + ";password=" + PASSWORD + ";database=" + DATABASE;
            connecDB2 = new MySqlConnection(connectionString);
            //port2 = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
            //client2 = new SshClient("192.168.1.200", "pi", "RETELL");
        }

    }
}
