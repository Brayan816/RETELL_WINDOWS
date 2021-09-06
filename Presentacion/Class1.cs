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
using System.Windows;

namespace Presentacion
{
    class CONEXION
    {
        public ForwardedPort port;
        public SshClient client;
        public MySqlConnection connecDB;
        public string HOST = "localhost";
        public string DATABASE = "usuarios";
        public string USERNAME = "ROOT2";
        public string PASSWORD = "RETELL";
        public CONEXION()
        {   
            string connectionString = "SERVER=" + HOST + ";port=3306;username=" + USERNAME + ";password=" + PASSWORD + ";database=" + DATABASE;
            connecDB = new MySqlConnection(connectionString);
            port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
            client = new SshClient("192.168.1.200", "pi", "RETELL");
        }
    }
}
