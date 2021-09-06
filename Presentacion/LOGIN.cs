using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Presentacion;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace Presentacion
{
    class LOGIN : CONEXION
    {
        public string username {set; get;}
        public string userpass { set; get; }
        
        public bool VALIDATED()
        {
            bool check = false;
            try
            {
                //client.Connect();
                //client.AddForwardedPort(port);
                //port.Start();
                connecDB.Open();
                MySqlDataReader rb;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT *FROM datos WHERE USUARIO=@user AND CONTRASEÑA=@pass";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connecDB;
                    //PARAMETROS
                    cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = userpass;
                    rb = cmd.ExecuteReader();
                    while (rb.Read())
                    {
                        check = true;

                    }
                    connecDB.Close();
                    //port.Stop();
                    //client.Disconnect();
                }
            }
            catch ( Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
            
            return check;
        }   
    }
}
