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
    class LLANTA : CONEXION
    {
        public string Comentario_llanta { get; set; }
        public string P_UR1 { set; get;}
        public string P_UR2 { get; set; }
        public string P_UR3 { get; set; }
        public string P_UR4 { get; set; }
        public string P_UR5 { get; set; }
        public string P_UR6 { get; set; }

        public string SOLICITANTE { set; get; }
        public string N_IDE { set; get; }
        public string DIRECCION { set; get; }
        public string BARRIO { set; get; }
        public string CIUDAD { set; get; }
        public string TELEFONO { set; get; }
        public string MARCA{ set; get; }
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
        public string TIPO_S { set; get; }
        public string FECHAG { set; get; }
        public string M1 { set; get; }
        public string M2 { set; get; }
        public string M3 { set; get; }
        public string M4 { set; get; }
        public string M5 { set; get; }
        public string M6 { set; get; }
        public string N1 { set; get; }
        public string N2 { set; get; }
        public string N3 { set; get; }
        public string N4 { set; get; }
        public string N5 { set; get; }
        public string N6 { set; get; }
        public string PM1 { set; get; }
        public string PM2 { set; get; }
        public string PM3 { set; get; }
        public string PM4 { set; get; }
        public string PM5 { set; get; }
        public string PM6 { set; get; }
        public string Comentario_Consulta { set; get;}
        

        public LLANTA(string SOLICITANTE, string N_IDE, string DIRECCION, string BARRIO, string CIUDAD, string TELEFONO, string MARCA, string TAMAÑO ,string SERIE, string COSTADO, 
        string BANDA, string HOMBRO, string OTRO,string FECHA , string ORDEN_S, string VALOR, string ABONO, string E_A,
        string UBICACION,string POSICION,string FECHAS,string FECHAE, string TIPO_S, string FECHAG,
        string M1,string M2,string M3,string M4,string M5,string M6, string N1, string N2, string N3, string N4, string N5, string N6,
        string PM1, string PM2, string PM3, string PM4, string PM5, string PM6)
        {
            this.SOLICITANTE = SOLICITANTE;
            this.N_IDE = N_IDE;
            this.DIRECCION = DIRECCION;
            this.BARRIO = BARRIO;
            this.CIUDAD = CIUDAD;
            this.TELEFONO = TELEFONO;
            this.MARCA = MARCA;
            this.TAMAÑO = TAMAÑO;
            this.SERIE = SERIE;
            this.COSTADO = COSTADO;
            this.BANDA = BANDA;
            this.HOMBRO = HOMBRO;
            this.OTRO = OTRO;
            this.FECHA = FECHA;
            this.ORDEN_S = ORDEN_S;
            this.VALOR = VALOR;
            this.ABONO = ABONO;
            this.E_A = E_A;
            this.UBICACION = UBICACION;
            this.POSICION = POSICION;
            this.FECHAS = FECHAS;
            this.FECHAE = FECHAE;
            this.TIPO_S = TIPO_S;
            this.FECHAG = FECHAG;
            this.M1 = M1;
            this.M2 = M2;
            this.M3 = M3;
            this.M4 = M4;
            this.M5 = M5;
            this.M6 = M6;
            this.N1 = N1;
            this.N2 = N2;
            this.N3 = N3;
            this.N4 = N4;
            this.N5 = N5;
            this.N6 = N6;
            this.PM1 = PM1;
            this.PM2 = PM2;
            this.PM3 = PM3;
            this.PM4 = PM4;
            this.PM5 = PM5;
            this.PM6 = PM6;
        }

        public LLANTA()
        {
        }
       
        public Boolean B_Datos()
        {
            Boolean Check = false;
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT C.SOLICITANTE, C.N_IDE,C.DIRECCION,C.BARRIO,C.CIUDAD,C.TELEFONO,L.MARCA,L.TAMA,L.SERIE,L.COSTADO,L.BANDA,L.HOMBRO,L.OTRO,L.FECHA,L.VALOR,L.ABONO,L.E_A,L.UBICACION,L.POSICION,L.FECHAS,L.FECHAE,L.TIPO_S,L.FECHAG,L.M1,L.M2,L.M3,L.M4,L.M5,L.M6,L.N1,L.N2,L.N3,L.N4,L.N5,L.N6,L.PM1,L.PM2,L.PM3,L.PM4,L.PM5,L.PM6 FROM llantas L JOIN clientes C ON L.N_IDE = C.N_IDE WHERE L.ORDEN_S =" + this.ORDEN_S, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.SOLICITANTE=reader.GetString(0);
                        this.N_IDE=reader.GetString(1);
                        this.DIRECCION=reader.GetString(2);
                        this.BARRIO=reader.GetString(3);
                        this.CIUDAD=reader.GetString(4);
                        this.TELEFONO=reader.GetString(5);
                        this.MARCA=reader.GetString(6);
                        this.TAMAÑO=reader.GetString(7);
                        this.SERIE=reader.GetString(8);
                        this.COSTADO=reader.GetString(9);
                        this.BANDA=reader.GetString(10);
                        this.HOMBRO=reader.GetString(11);
                        this.OTRO=reader.GetString(12);
                        this.FECHA=reader.GetString(13);
                        this.VALOR=reader.GetString(14);
                        this.ABONO=reader.GetString(15);
                        this.E_A=reader.GetString(16);
                        this.UBICACION=reader.GetString(17);
                        this.POSICION=reader.GetString(18);
                        this.FECHAS=reader.GetString(19);
                        this.FECHAE=reader.GetString(20);
                        this.TIPO_S=reader.GetString(21);
                        this.FECHAG=reader.GetString(22);
                        this.M1=reader.GetString(23);
                        this.M2=reader.GetString(24);
                        this.M3=reader.GetString(25);
                        this.M4=reader.GetString(26);
                        this.M5=reader.GetString(27);
                        this.M6=reader.GetString(28);
                        this.N1=reader.GetString(29);
                        this.N2 = reader.GetString(30);
                        this.N3 = reader.GetString(31);
                        this.N4 = reader.GetString(32);
                        this.N5 = reader.GetString(33);
                        this.N6 = reader.GetString(34);
                        this.PM1= reader.GetString(35);
                        this.PM2 = reader.GetString(36);
                        this.PM3 = reader.GetString(37);
                        this.PM4 = reader.GetString(38);
                        this.PM5 = reader.GetString(39);
                        this.PM6 = reader.GetString(40);
                        Check = true;
                    }
                }
                else
                {
                    this.Comentario_Consulta = "Error al Establecer la conexion";
                }
            }
            catch (Exception E)
            {
                this.Comentario_Consulta = E.Message.ToString();   
            }
            CloseConnection();
            return Check;
        }
        public Boolean Buscar_Materiales()
        {
            bool Check = false;
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT *FROM datos WHERE ORDEN_S='" + this.ORDEN_S + "'", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        VALOR = reader.GetString("VALOR");
                        ABONO = reader.GetString("ABONO");
                        M1 = reader.GetString("M1");
                        M2 = reader.GetString("M2");
                        M3 = reader.GetString("M3");
                        M4 = reader.GetString("M4");
                        M5 = reader.GetString("M5");
                        M6 = reader.GetString("M6");
                        N1 = reader.GetString("N1");
                        N2 = reader.GetString("N2");
                        N3 = reader.GetString("N3");
                        N4 = reader.GetString("N4");
                        N5 = reader.GetString("N5");
                        N6 = reader.GetString("N6");
                        PM1 = reader.GetString("PM1");
                        PM2 = reader.GetString("PM2");
                        PM3 = reader.GetString("PM3");
                        PM4 = reader.GetString("PM4");
                        PM5 = reader.GetString("PM5");
                        PM6 = reader.GetString("PM6");
                        Check = true;
                    }
                }
                else
                {
                    Comentario_Consulta = "Error al realizar la conexion con el servidor";
                }
            }
            catch(Exception E)
            { 
                Comentario_Consulta = E.Message.ToString();
            }
            CloseConnection();
            return Check;
        }
        public bool R_egistrar()
        {
            Boolean Check = false;

            return Check;
        }
        public void Precios_2()
        {
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='CR'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M1);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR1 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR1 = "0";
                    }
                    reader.Close();
                    cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='P'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M2);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR2 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR2 = "0";
                    }
                    reader.Close();
                    cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='U'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M3);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR3 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR3 = "0";
                    }
                    reader.Close(); 
                    cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='F'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M4);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR4 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR4 = "0";
                    }
                    reader.Close();
                    cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='MC'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M5);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR5 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR5 = "0";
                    }
                    reader.Close();
                    cmd = new MySqlCommand("SELECT *FROM datos WHERE NOMBRE=@Nombre AND TIPO_MATERIAL='BC'", connection);
                    cmd.Parameters.AddWithValue("@Nombre", M6);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        P_UR6 = reader.GetString("VALOR");
                    }
                    else
                    {
                        P_UR6 = "0";
                    }

                }
            }
            catch (Exception E)
            {
                P_UR1 = E.Message;
            }
            CloseConnection();
        }
        public bool REGISTRAR()
        {
            bool CHECK;
            CHECK=ADDTYRE(this.SOLICITANTE, this.N_IDE, this.DIRECCION, this.BARRIO, this.CIUDAD, this.TELEFONO, this.MARCA, this.TAMAÑO, this.SERIE, this.COSTADO, this.BANDA, this.HOMBRO, this.OTRO, this.FECHA, this.ORDEN_S, this.VALOR, this.ABONO, this.E_A, this.UBICACION, this.POSICION, this.FECHAS, this.FECHAE, this.TIPO_S, this.FECHAG, this.M1, this.M2, this.M3, this.M4, this.M5, this.M6);
            return CHECK;
        }
        public bool VerificarDatos()
        {
            bool CHECK = false;
            try
            {
                if (OpenConnection())
                {
                    string Query = "SELECT SOLICITANTE,DIRECCION,BARRIO,CIUDAD,TELEFONO FROM clientes WHERE N_IDE=10"+this.N_IDE;
                    MySqlCommand CM1=new MySqlCommand(Query);
                    MySqlDataReader Reader=CM1.ExecuteReader();
                    if (Reader.Read())
                    {
                        this.SOLICITANTE=Reader.GetString(0);
                        this.DIRECCION=Reader.GetString(1);
                        this.BARRIO=Reader.GetString(2);
                        this.CIUDAD = Reader.GetString(3);
                        this.TELEFONO=Reader.GetString(4);
                        CHECK = true;
                    }
                }
                else
                {
                    CHECK = false;
                }
            }
            catch (Exception E)
            {
                Comentario_llanta =E.Message;
                CHECK = false;
            }
            CloseConnection();
            return true;
        }
        public bool Actualizar()
        {
            Boolean CHECK;
            try
            {
                if (OpenConnection())
                {
                    string Query1 = "UPDATE llantas SET N_IDE=@M0, MARCA=@M1,TAMA=@M2,SERIE=@M3,FECHA=@M4,FECHAS=@M5,VALOR=@M6,ABONO=@M7,E_A=@M8,UBICACION=@M9,POSICION=@M10 WHERE ORDEN_S = @M11";
                    MySqlCommand cmd = new MySqlCommand(Query1, connection);
                    cmd.Parameters.AddWithValue("M0", N_IDE);
                    cmd.Parameters.AddWithValue("@M1", MARCA);
                    cmd.Parameters.AddWithValue("@M2", TAMAÑO);
                    cmd.Parameters.AddWithValue("@M3", SERIE);
                    cmd.Parameters.AddWithValue("@M4", FECHA);
                    cmd.Parameters.AddWithValue("@M5", FECHAS);
                    cmd.Parameters.AddWithValue("@M6", VALOR);
                    cmd.Parameters.AddWithValue("@M7", ABONO);
                    cmd.Parameters.AddWithValue("@M8", E_A);
                    cmd.Parameters.AddWithValue("@M9", UBICACION);
                    cmd.Parameters.AddWithValue("@M10", POSICION);
                    cmd.Parameters.AddWithValue("@M11", ORDEN_S);
                    cmd.ExecuteNonQuery();
                    string Query2 = "UPDATE clientes SET N_IDE=@M0,SOLICITANTE=@M1,DIRECCION=@M2,BARRIO=@M3,CIUDAD=@M4,TELEFONO=@M5 WHERE N_IDE = @M6";
                    MySqlCommand CMD2 = new MySqlCommand(Query2, connection);
                    CMD2.Parameters.AddWithValue("@M0",N_IDE);
                    CMD2.Parameters.AddWithValue("@M1",SOLICITANTE);
                    CMD2.Parameters.AddWithValue("@M2",DIRECCION);
                    CMD2.Parameters.AddWithValue("@M3",BARRIO);
                    CMD2.Parameters.AddWithValue("@M4",CIUDAD);
                    CMD2.Parameters.AddWithValue("@M5",TELEFONO);
                    CMD2.Parameters.AddWithValue("@M6",N_IDE);
                    CMD2.ExecuteNonQuery();
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
                Comentario_llanta = E.Message;
            }
            CloseConnection();
            return CHECK;
        }
    }
}
