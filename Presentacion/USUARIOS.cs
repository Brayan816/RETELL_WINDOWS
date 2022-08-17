using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class USUARIOS : CONEXION
    {
        public string NOMBRE { get; set; }
        public string CEDULA { get; set; }
        public string PASSWORD { get; set; }
        public string CORREO { get; set; }
        public string CELULAR { get; set; }
        public string USUARIO { get; set; }
        public string CARGO { get; set; }

        public int E_CHECK { get; set; }

        public string CONSULTA_LLANTA { get; set; }

        public USUARIOS(string NOMBRE, string CEDULA, string PASSWORD, string CORREO, string CELULAR, string USUARIO, string CARGO)
        {
            this.NOMBRE = NOMBRE;
            this.CEDULA = CEDULA;
            this.PASSWORD = PASSWORD;
            this.CORREO = CORREO;
            this.CELULAR = CELULAR;
            this.USUARIO = USUARIO;
            this.CARGO = CARGO;
            this.E_CHECK = 0;
        }
        public USUARIOS(){
        }

        public bool RegisterUser()
        {
            bool CHECK=false;
            try
            {
                bool User_1 = CheckUser();
                if (OpenConnection() && User_1 && E_CHECK==0)
                {
                    string QUERY = "INSERT INTO usuarios ( NOMBRE, CEDULA, CONTRASEÑA,CORREO, CELULAR, USUARIO, CARGO) VALUES (@NOMBRE,@CEDULA,@PASS,@CELULAR,@USUARIO,@CARGO)";
                    MySqlCommand CM1 = new MySqlCommand(QUERY);
                    CM1.Parameters.AddWithValue("@NOMBRE", this.NOMBRE);
                    CM1.Parameters.AddWithValue("@CEDULA", this.CEDULA);
                    CM1.Parameters.AddWithValue("@PASS", this.PASSWORD);
                    CM1.Parameters.AddWithValue("@CELULAR", this.CELULAR);
                    CM1.Parameters.AddWithValue("@USUARIO", this.USUARIO);
                    CM1.Parameters.AddWithValue("@CARGO", this.CARGO);
                    CM1.ExecuteNonQuery();
                    CHECK = true;
                }
                else if(E_CHECK==1)
                {
                    CONSULTA_LLANTA = "EL USUARIO SE REGISTRO PREVIAMENTE";
                }
            }
            catch(Exception E)
            {
                CONSULTA_LLANTA=E.Message;
            }
            CloseConnection();
            return CHECK;
        }
        public bool CheckUser()
        {
            bool CHECK = false;
            try
            {
                if(OpenConnection())
                {
                    string Query = "SELECT CEDULA FROM USUARIOS WHERE CEDULA="+this.CEDULA;
                    MySqlCommand CM1 = new MySqlCommand(Query);
                    MySqlDataReader Reader = CM1.ExecuteReader();
                    if (Reader.Read())
                    {
                        CHECK = true;
                        E_CHECK = 1;
                    }
                    else
                    {
                        E_CHECK = 0;
                    }

                }
                else
                {
                    CONSULTA_LLANTA = "Ocurrio un error al conectarse con el servidor ";
                }
            }
            catch (Exception E)
            {
                CloseConnection();
                CONSULTA_LLANTA = E.Message;
            }
            return CHECK;
         }
    }
    
}
