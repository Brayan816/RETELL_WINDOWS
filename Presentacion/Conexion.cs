using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace Presentacion
{
    class CONEXION
    {
        public string USUARIOA = "";
        public string PASS;
        public string USER;
        public string Comentario_consulta;
        public MySqlConnection connection;
        public ForwardedPortLocal port;
        public SshClient client;
        private string connectionString;
        public CONEXION()
        {
            port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
            client = new SshClient(Program.DBIP, "pi", "RETELL");
            connectionString = "SERVER=localhost; DATABASE=RETELL;UID=ROOT2;PASSWORD=RETELL;";
        }
        public bool OpenConnection()
        {
            try
            {
    
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Comentario_consulta="Todo bien";
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Comentario_consulta = ex.Message;
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Comentario_consulta = ex.Message;
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                Comentario_consulta = ex.Message;
                return false;
            }
            catch (Exception e)
            {
                Comentario_consulta = e.Message;
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                client.Disconnect();
                port.Stop();
                connection.Close();
                return true;
            }
            catch (MySqlException  ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool Crear_Materiales()
        {
            bool Check = false;
            string QUERY = "insert into datos (NOMBRE,TIPO_MATERIAL,VALOR) values (@Nombre,@Tipo,@Valor)";
            string[] UR_BC = {"CAUCHO_COJIN","CAUCHO_BLANDO","CAUCHO_DURO","CORDON_FABRE","CEMENTO","DISOLVENTE" };
            try
            {
                
                if (OpenConnection())
                {
                    foreach (string COMP1 in UR_BC)
                    {
                        Check = true;
                        MySqlCommand cmd = new MySqlCommand(QUERY, connection);
                        cmd.Parameters.AddWithValue("@Nombre",COMP1);
                        cmd.Parameters.AddWithValue("@Tipo", "BASICO");
                        cmd.Parameters.AddWithValue("Valor", "0");
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                else
                {
                    Comentario_consulta = "Error al Iniciar Conexion";
                }
            }
            catch (MySqlException E)
            {
                Comentario_consulta = E.Message;
            }
            CloseConnection();
            return Check;
        }

        public bool CHECK()
        {
            bool A1 = false;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT USUARIO,CONTRASEÑA FROM usuarios WHERE USUARIO='" + USER + "'", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader.GetString("CONTRASEÑA").Equals(PASS))
                    {
                        Comentario_consulta = "Contraseña Correcta";
                        USUARIOA = reader.GetString(0);
                        A1 = true;
                    }
                    else { 
                        Comentario_consulta = "NO COINCIDE LA CONTRASEÑA";
                        A1 = false;
                    }

                }
                else
                {
                    Comentario_consulta="Reader.read Errro";
                    A1 = false;
                }
            }
            else
            {
                
            }
            CloseConnection();
            return A1;
        }

        public List<string> BUSQUEDA(string ORDENS)
        {

            List<string> DATOS = new List<string>();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *FROM datos WHERE ORDEN_S='" + ORDENS + "'", connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DATOS.Add(reader.GetString("SOLICITANTE"));
                    DATOS.Add(reader.GetString("N_IDE"));
                    DATOS.Add(reader.GetString("DIRECCION"));
                    DATOS.Add(reader.GetString("BARRIO"));
                    DATOS.Add(reader.GetString("CIUDAD"));
                    DATOS.Add(reader.GetString("TELEFONO"));
                    DATOS.Add(reader.GetString("MARCA_LLANTA"));
                    DATOS.Add(reader.GetString("TAMAÑO"));
                    DATOS.Add(reader.GetString("SERIE"));
                    DATOS.Add(reader.GetString("COSTADO"));
                    DATOS.Add(reader.GetString("BANDA"));
                    DATOS.Add(reader.GetString("HOMBRO"));
                    DATOS.Add(reader.GetString("OTRO"));
                    DATOS.Add(reader.GetString("FECHA"));
                    DATOS.Add(reader.GetString("VALOR"));
                    DATOS.Add(reader.GetString("ABONO"));
                    DATOS.Add(reader.GetString("E_A"));
                    DATOS.Add(reader.GetString("UBICACION"));
                    DATOS.Add(reader.GetString("POSICION"));
                    DATOS.Add(reader.GetString("FECHAS"));
                    DATOS.Add(reader.GetString("FECHAE"));
                    DATOS.Add(reader.GetString("TIPO_S"));
                    DATOS.Add(reader.GetString("FECHAG"));
                    DATOS.Add(reader.GetString("M1"));
                    DATOS.Add(reader.GetString("M2"));
                    DATOS.Add(reader.GetString("M3"));
                    DATOS.Add(reader.GetString("M4"));
                    DATOS.Add(reader.GetString("M5"));
                    DATOS.Add(reader.GetString("M6"));
                    DATOS.Add(reader.GetString("N1"));
                    DATOS.Add(reader.GetString("N2"));
                    DATOS.Add(reader.GetString("N3"));
                    DATOS.Add(reader.GetString("N4"));
                    DATOS.Add(reader.GetString("N5"));
                    DATOS.Add(reader.GetString("N6"));
                    DATOS.Add(reader.GetString("PM1"));
                    DATOS.Add(reader.GetString("PM2"));
                    DATOS.Add(reader.GetString("PM3"));
                    DATOS.Add(reader.GetString("PM4"));
                    DATOS.Add(reader.GetString("PM5"));
                    DATOS.Add(reader.GetString("PM6"));
                }
            }
            CloseConnection();
            //return true;
            return DATOS;
        }
        public (List<List<string>> a2,int a1, bool l)EQUIPOS()
        {
            bool L = false;
            List<List<string>> a2 = new List<List<string>>();

            List<string> F1 = new List<string>();
            List<string> F2 = new List<string>();
            List<string> F3 = new List<string>();
            List<string> F4 = new List<string>();
            List<string> F5 = new List<string>();
            List<string> F6 = new List<string>();
            List<string> F7 = new List<string>();
            List<string> F8 = new List<string>();
            List<string> F9 = new List<string>();
            int i= 0;
            if (this.OpenConnection() == true)
            {
                try { 
                    MySqlCommand cmd = new MySqlCommand("SELECT L.ORDEN_S, C.SOLICITANTE,L.MARCA, L.TAMA,L.FECHA,L.UBICACION,L.E_A,L.VALOR,L.ABONO FROM llantas L JOIN clientes C ON L.N_IDE=C.N_IDE", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
;                       F1.Add(reader.GetString(0));
                        F2.Add(reader.GetString(1));
                        F3.Add(reader.GetString(2));
                        F4.Add(reader.GetString(3));
                        F5.Add(reader.GetString(4));
                        F6.Add(reader.GetString(5));
                        string EW1 = "", Aw1 = reader.GetString(7);
                        string EW2 = "", Aw2 = reader.GetString(8);
                        if (Aw1.Length == 6)
                        {
                            EW1 = Aw1[0].ToString() + Aw1[1].ToString() + Aw1[2].ToString() + "." + Aw1[3].ToString() + Aw1[4].ToString() + Aw1[5].ToString();
                        }
                        else if (Aw1.Length == 5)
                        {
                            EW1 = Aw1[0].ToString() + Aw1[1].ToString() + "." + Aw1[2].ToString() + Aw1[3].ToString() + Aw1[4].ToString();
                        }
                        else if (Aw1.Length == 4)
                        {
                            EW1 = Aw1[0].ToString() + "." + Aw1[1].ToString() + Aw1[2].ToString() + Aw1[3].ToString();
                        }
                        //ABONO
                        if (Aw2.Length == 6)
                        {
                            EW2 = Aw2[0].ToString() + Aw2[1].ToString() + Aw2[2].ToString() + "." + Aw2[3].ToString() + Aw2[4].ToString() + Aw2[5].ToString();
                        }
                        else if (Aw2.Length == 5)
                        {
                            EW2 = Aw2[0].ToString() + Aw2[1].ToString() + "." + Aw2[2].ToString() + Aw2[3].ToString() + Aw2[4].ToString();
                        }
                        else if (Aw2.Length == 4)
                        {
                            EW2 = Aw2[0].ToString() + "." + Aw2[1].ToString() + Aw2[2].ToString() + Aw2[3].ToString();
                        }

                        F7.Add(reader.GetString(6));
                        F8.Add(EW1);
                        F9.Add(EW2);
                        i++;
                    }
                    L = true;
                }
                catch(Exception E)
                {
                    MessageBox.Show("error aqui ");
                    L = false;
                }

                List<string> A6 = new List<string>();
                for (int f=0;f<i;f++)
                {
                    a2.Add(new List<string> { F1[f], F2[f], F3[f], F4[f], F5[f], F6[f], F7[f], F8[f], F9[f] });
                }
            }
            this.CloseConnection();
            return (a2,i,L);
        }

        public bool ADDTYRE(string SOLICITANTE, string N_IDE, string DIRECCION, string BARRIO, string CIUDAD, string TELEFONO, string MARCA, string TAMAÑO, string SERIE, string COSTADO, string BANDA, string HOMBRO, string OTRO, string FECHA, string ORDEN_S, string VALOR, string ABONO, string E_A, string UBICACION, string POSICION, string FECHAS, string FECHAE, string TIPO_S, string FECHAG, string M1, string M2, string M3, string M4, string M5, string M6)
        {
            bool CHECK = false;

            if (this.OpenConnection())
            {
                try
                {
                    string QUERY = "insert into datos (SOLICITANTE,N_IDE,DIRECCION,BARRIO,CIUDAD,TELEFONO,MARCA_LLANTA,TAMAÑO,SERIE,COSTADO,BANDA,HOMBRO,OTRO,FECHA,ORDEN_S,VALOR,ABONO,E_A,UBICACION,POSICION,FECHAS,FECHAE,TIPO_S,FECHAG,M1,M2,M3,M4,M5,M6,N1,N2,N3,N4,N5,N6,PM1,PM2,PM3,PM4,PM5,PM6) values ('" + SOLICITANTE + "','" + N_IDE + "','" + DIRECCION + "','" + BARRIO + "','" + CIUDAD + "','" + TELEFONO + "','" + MARCA + "','" + TAMAÑO + "','" + SERIE + "','" + COSTADO + "','" + BANDA + "','" + HOMBRO + "','" + OTRO + "','" + FECHA + "','" + ORDEN_S + "','" + VALOR + "','" + ABONO + "','INGRESO','" + UBICACION + "','" + POSICION + "','" + FECHAS + "','" + FECHAE + "','REPERACION','" + FECHAG + "','','','','','','','','','','','','','','','','','','')";
                    MySqlCommand cmd = new MySqlCommand(QUERY,connection);
                    cmd.ExecuteNonQuery();
                    CHECK = true;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message.ToString());
                    CHECK = false;
                }               
            }
            CloseConnection();
            return CHECK;
        }
        public bool UpdateTyre(string MARCA, string TAMAÑO, string SERIE, string FECHA, string FECHAS, string VALOR, string ABONO, string SOLICITANTE, string DIRECCION, string BARRIO, string CIUDAD, string TELEFONO,string E_A,string UBICACION,string POSICION,string ORDEN_S)
        {
            bool CHECK = false;

            try
            {
                if(this.OpenConnection())
                {
                    string query = "UPDATE datos SET MARCA_LLANTA=@M1, TAMAÑO=@M2, SERIE=@M3 ,FECHA=@M4 ,FECHAS=@M5 ,VALOR=@M6,ABONO=@M7,SOLICITANTE=@M8,DIRECCION=@M9,BARRIO=@M10,CIUDAD=@M11,TELEFONO=@M12,E_A=@M13,UBICACION=@M14,POSICION=@M15 WHERE ORDEN_S=@O_S";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@O_S", ORDEN_S);
                    cmd.Parameters.AddWithValue("@M1", MARCA);
                    cmd.Parameters.AddWithValue("@M2", TAMAÑO);
                    cmd.Parameters.AddWithValue("@M3", SERIE);
                    cmd.Parameters.AddWithValue("@M4", FECHA);
                    cmd.Parameters.AddWithValue("@M5", FECHAS);
                    cmd.Parameters.AddWithValue("@M6", VALOR);
                    cmd.Parameters.AddWithValue("@M7", ABONO);
                    cmd.Parameters.AddWithValue("@M8", SOLICITANTE);
                    cmd.Parameters.AddWithValue("@M9", DIRECCION);
                    cmd.Parameters.AddWithValue("@M10", BARRIO);
                    cmd.Parameters.AddWithValue("@M11", CIUDAD);
                    cmd.Parameters.AddWithValue("@M12", TELEFONO);
                    cmd.Parameters.AddWithValue("@M13", E_A);
                    cmd.Parameters.AddWithValue("@M14", UBICACION);
                    cmd.Parameters.AddWithValue("@M15", POSICION);
                    cmd.ExecuteNonQuery();
                    CHECK = true;
                }
                else
                {
                    CHECK = false;
                }
            }
            catch (Exception E)
            {
                CHECK = false;
            }
            CloseConnection();
            return CHECK;
        }
        public bool ActualizarMateriales(List<string> LV)
        {
            bool CHECK=false;
            try
            {
                if (this.OpenConnection()==true)
                {
                    string query = "UPDATE datos SET M1=@M1, M2=@M2, M3=@M3 ,M4=@M4 ,M5=@M5 ,M6=@M6,N1=@N1, N2=@N2, N3=@N3 ,N4=@N4 ,N5=@N5 ,N6=@N6,PM1=@PM1, PM2=@PM2, PM3=@PM3 ,PM4=@PM4 ,PM5=@PM5 ,PM6=@PM6 WHERE ORDEN_S=@O_S";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@O_S", LV[0]);
                    cmd.Parameters.AddWithValue("@M1", LV[1]);
                    cmd.Parameters.AddWithValue("@M2", LV[2]);
                    cmd.Parameters.AddWithValue("@M3", LV[3]);
                    cmd.Parameters.AddWithValue("@M4", LV[4]);
                    cmd.Parameters.AddWithValue("@M5", LV[5]);
                    cmd.Parameters.AddWithValue("@M6", LV[6]);
                    cmd.Parameters.AddWithValue("@N1", LV[7]);
                    cmd.Parameters.AddWithValue("@N2", LV[8]);
                    cmd.Parameters.AddWithValue("@N3", LV[9]);
                    cmd.Parameters.AddWithValue("@N4", LV[10]);
                    cmd.Parameters.AddWithValue("@N5", LV[11]);
                    cmd.Parameters.AddWithValue("@N6", LV[12]);
                    cmd.Parameters.AddWithValue("@PM1", LV[13]);
                    cmd.Parameters.AddWithValue("@PM2", LV[14]);
                    cmd.Parameters.AddWithValue("@PM3", LV[15]);
                    cmd.Parameters.AddWithValue("@PM4", LV[16]);
                    cmd.Parameters.AddWithValue("@PM5", LV[17]);
                    cmd.Parameters.AddWithValue("@PM6", LV[18]);
                    cmd.ExecuteNonQuery();
                    CHECK = true;
                }
                else
                {
                    CHECK = false;
                }

            }
            catch (Exception e)
            {   
                CHECK = false;
                MessageBox.Show(e.Message.ToString()+LV[6]);
            }
            CloseConnection();
            return CHECK;
        }

        public List<string> MaterialesA(string ORDENS)
        {
            List<string> DATOS = new List<string>();
            if (this.OpenConnection()==true)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *FROM datos WHERE ORDEN_S='" + ORDENS + "'", connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DATOS.Add(reader.GetString("M1"));
                    DATOS.Add(reader.GetString("M2"));
                    DATOS.Add(reader.GetString("M3"));
                    DATOS.Add(reader.GetString("M4"));
                    DATOS.Add(reader.GetString("M5"));
                    DATOS.Add(reader.GetString("M6"));
                    DATOS.Add(reader.GetString("N1"));
                    DATOS.Add(reader.GetString("N2"));
                    DATOS.Add(reader.GetString("N3"));
                    DATOS.Add(reader.GetString("N4"));
                    DATOS.Add(reader.GetString("N5"));
                    DATOS.Add(reader.GetString("N6"));
                    DATOS.Add(reader.GetString("PM1"));
                    DATOS.Add(reader.GetString("PM2"));
                    DATOS.Add(reader.GetString("PM3"));
                    DATOS.Add(reader.GetString("PM4"));
                    DATOS.Add(reader.GetString("PM5"));
                    DATOS.Add(reader.GetString("PM6"));
                }
            }
            else
            {

            }
            CloseConnection();
            return (DATOS);
        }

    }
}
