using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Presentacion;
using System.Data;

namespace Presentacion
{
    class LLANTA : CONEXION2
    {
        public string SOLICITANTE { set; get; }
        public string N_IDE { set; get; }
        public string DIRECCION { set; get; }
        public string BARRIO { set; get; }
        public string CIUDAD { set; get; }
        public string TELEFONO { set; get; }
        public string MARCA_LLANTA { set; get; }
        public string TAMAÑO { set; get; }
        public string SERIE { set; get; }
        public string COSTADO { set; get; }
        public string BANDA { set; get; }
        public string HOMBRO { set; get; }
        public string OTRO { set; get; }
        public string FECHA { set; get; }
        public string ORDEN_S { set; get; }
        public string VALOR { set; get; }
        public string ABONO { set; get; }
        public string E_A { set; get; }
        public string UBICACION { set; get; }
        public string POSICION { set; get; }
        public string FECHAS { set; get; }
        public string FECHAE { set; get; }
        public string TIPOS_S { set; get; }
        public string FECHAG { set; get; }
        public string M1 { set; get; }
        public string M2 { set; get; }
        public string M3 { set; get; }
        public string M4 { set; get; }
        public string M5 { set; get; }
        public string M6 { set; get; }

        public bool  DATOS()
        {

            bool check = false;
            //client2.Connect();
            //client2.AddForwardedPort(port2);
            //port2.Start();
            connecDB2.Open();
            MySqlDataReader rb;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT *FROM datos WHERE ORDEN_S=@user";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connecDB2;
                //PARAMETROS
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = ORDEN_S;
                rb = cmd.ExecuteReader();
                while (rb.Read())
                {
                    check = true;
                    SOLICITANTE = rb.GetString("SOLICITANTE");
                    N_IDE= rb.GetString("N_IDE");
                    DIRECCION= rb.GetString("DIRECCION");
                    BARRIO=rb.GetString("BARRIO");
                    CIUDAD=rb.GetString("CIUDAD");
                    TELEFONO= rb.GetString("TELEFONO");
                    MARCA_LLANTA= rb.GetString("MARCA_LLANTA");
                    TAMAÑO= rb.GetString("TAMAÑO");
                    SERIE= rb.GetString("SERIE");
                    COSTADO=rb.GetString("COSTADO");
                    BANDA= rb.GetString("BANDA");
                    HOMBRO=rb.GetString("HOMBRO");
                    OTRO= rb.GetString("OTRO");
                    FECHA= rb.GetString("FECHA");
                    VALOR= rb.GetString("VALOR");
                    ABONO= rb.GetString("ABONO");
                    E_A=rb.GetString("E_A");
                    UBICACION= rb.GetString("UBICACION");
                    POSICION= rb.GetString("POSICION");
                    FECHAS=rb.GetString("FECHAS");
                    FECHAE= rb.GetString("FECHAE");
                    TIPOS_S= rb.GetString("TIPO_S");
                    FECHAG= rb.GetString("FECHAG");
                    M1 = rb.GetString("M1");
                    M2 = rb.GetString("M2");
                    M3 = rb.GetString("M3");
                    M4 = rb.GetString("M4");
                    M5 = rb.GetString("M5");
                    M6 = rb.GetString("M6");
                }
                connecDB2.Close();
                //port2.Stop();
                //client2.Disconnect();
            }
            return check;
        }
    }
}
