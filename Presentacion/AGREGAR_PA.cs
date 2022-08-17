using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Text;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;
//COM
using System.IO.Ports;
using System.Threading;
//using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using System.IO;


namespace Presentacion
{
    public partial class AGREGAR_PA : UserControl
    {
        public string PQR;
        public string TAGH;
        public string TAGR ;
        public string CONTADOR;
        public string NOMBRE_X;
        public string MARCA_X;
        public string MODELO_X;
        public string SERIE_X;
        public string COSTADOX="NO";
        public string BANDAX="NO";
        public string HOMBROX="NO";
        LLANTA llanta = new LLANTA();
        USUARIOS usuario = new USUARIOS();

        public AGREGAR_PA()
        {
            InitializeComponent();

            AGG_P1.Visible = false;
            USER_CHECK.Visible = false;
            AGG_P2.Visible = false;
            A_COSTADOT.Visible = false;
            A_COSTADOF.Visible = true;
            A_BANDAT.Visible = false;
            A_BANDAF.Visible = true;
            A_HOMBROT.Visible = false;
            A_HOMBROF.Visible = true;
            string[] TU_DA = { "ADMINISTRADOR", "COORDINADOR", "EMPLEADO" };
            U_PERMISOS.Items.AddRange(TU_DA);
        }


        private void AGG_P1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void AGG_US1_Click(object sender, EventArgs e)
        {

            AGG_USER_F.Visible = false;
            AGG_USER_T.Visible = true;
            AGG_LLANTA_F.Visible = true;
            AGG_LLANTA_T.Visible = false;
            AGG_P1.Visible = true;
            AGG_P2.Visible = false;
        }

        private void AGG_US2_Click(object sender, EventArgs e)
        {
            AGG_USER_F.Visible = true;
            AGG_USER_T.Visible = false;
            AGG_LLANTA_F.Visible = true;
            AGG_LLANTA_T.Visible = false;
            AGG_P1.Visible = false;
            AGG_P2.Visible = false;
        }

        private void AGG_E1_Click(object sender, EventArgs e)
        {
            AGG_USER_F.Visible = true;
            AGG_USER_T.Visible = false;
            AGG_LLANTA_F.Visible = false;
            AGG_LLANTA_T.Visible = true;
            AGG_P1.Visible = false;
            AGG_P2.Visible = true;
        }

        private void AGG_E2_Click(object sender, EventArgs e)
        {
            AGG_USER_F.Visible = true;
            AGG_USER_T.Visible = false;
            AGG_LLANTA_F.Visible = true;
            AGG_LLANTA_T.Visible = false;
            AGG_P2.Visible = false;
            AGG_P1.Visible = false;

        }


        private void ELIMINAR_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=usuarios";           
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query= "DELETE FROM `datos` WHERE id=1";
            MySqlCommand ard = new MySqlCommand(query, databaseConnection);
            ard.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = ard.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         

        private void MESES_CB_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TE_CB_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void A_COSTADO_CLICK(object sender, EventArgs e)
        {
            COSTADOX = "NO";
            A_COSTADOT.Visible = false;
            A_COSTADOF.Visible = true;
        }

        private void A_COSTADOF_CLICK(object sender, EventArgs e)
        {
            COSTADOX = "SI";
            A_COSTADOF.Visible = false;
            A_COSTADOT.Visible = true;
        }

        private void A_BANDAT_CLICK(object sender, EventArgs e)
        {
            BANDAX = "NO";
            A_BANDAT.Visible = false;
            A_BANDAF.Visible = true;
        }

        private void A_BANDAF_CLICK(object sender, EventArgs e)
        {
            BANDAX = "SI";
            A_BANDAF.Visible = false;
            A_BANDAT.Visible = true;
        }

        private void A_HOMBROT_CLICK(object sender, EventArgs e)
        {
            HOMBROX = "NO";
            A_HOMBROT.Visible = false;
            A_HOMBROF.Visible = true;
        }

        private void A_HOMBROF_CLICK(object sender, EventArgs e)
        {
            HOMBROX = "SI";
            A_HOMBROF.Visible = false;
            A_HOMBROT.Visible = true;
        }

        private void U_REGISTRAR_CLICK(object sender, EventArgs e)
        {
            Boolean Result = String.Equals(U_CCONTRASENA.Text, U_CONTRASEÑA.Text, StringComparison.Ordinal);
            if (Result == true && U_NOMBRE.Text != "" && U_IDENTIFICACION.Text != "" && U_CONTRASEÑA.Text != "" && AGG_CORREO.Text != "" && U_TELEFONO.Text != "" && U_PERMISOS.Text != "" && U_USUARIO.Text!="")
            {
                try
                {
                    usuario = new USUARIOS(U_NOMBRE.Text, U_IDENTIFICACION.Text, U_CONTRASEÑA.Text, AGG_CORREO.Text, U_TELEFONO.Text, U_USUARIO.Text, U_PERMISOS.Text);
                    if (usuario.RegisterUser())
                    {
                        MessageBox.Show("USUARIO REGISTRADO CON EXITO");
                    }
                    else
                    {
                        MessageBox.Show(usuario.CONSULTA_LLANTA);
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (Result == false)
            {
                MessageBox.Show("La contraseña no coincide");
            }
            else
            {
                MessageBox.Show("Llene todos los campos");
            }
        
        }

        private void L_REGISTRAR_CLICK(object sender, EventArgs e)
        {
            MessageBoxButtons MB = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("¿CONFRIMA EL REGISTRO DE LA LLANTA?", "CONFIRMACION", MB);
            if (result == DialogResult.Yes)
            {
                bool CHECK;
                string FECHA = L_DT_FECHA.Value.Day + "/" + L_DT_FECHA.Value.Month + "/" + L_DT_FECHA.Value.Year;
                string FECHAS = L_DT_FECHAS.Value.Day + "/" + L_DT_FECHAS.Value.Month + "/" + L_DT_FECHAS.Value.Year;
                LLANTA LA = new LLANTA(L_SOLICITANTE.Text, L_MARCA.Text, A_DIRECCION.Text, L_BARRIO.Text, L_CIUDAD.Text, L_TELEFONO.Text, L_N_IDE.Text, L_TAMA.Text, L_SERIE.Text, COSTADOX, BANDAX, HOMBROX, L_OTRO.Text, FECHA, L_ORDEN_S.Text, L_VALOR.Text, L_ABONO.Text, "", "", "", FECHAS, "", "INGRESO", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                CHECK = LA.REGISTRAR();
                if (CHECK)
                {
                    MessageBox.Show("LLANTA REGISTRADA CON EXITO", "RESULTADO DE REGISTRO");
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA LLANTA", "RESULTADO DE REGISTRO");
                }
            }
            else
            {
                MessageBox.Show("XD");
            }


        }
    }
}
