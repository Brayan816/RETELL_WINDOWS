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

        public AGREGAR_PA()
        {
            InitializeComponent();
            //COM
            //OTRO
            AGG_P1.Visible = false;
            AGG_CHECK.Visible = false;
            AGG_P2.Visible = false;
        }


        private void AGG_P1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AGREGAR_PA_Load(object sender, EventArgs e)
        {
            string[] Sexo_A = { "Hombre", "Mujer", "Prefiero no decirlo", "Otros" };
            Sexo_CB.Items.AddRange(Sexo_A);
            string[] INC = { "Clinica medico quirurgica S.A", "IPS ASSOT SAS"};
            //CB_INSCRITO.Items.AddRange(INC);
            string AñoE = DateTime.Now.Year.ToString();
            string[] CMESES= { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            //MESES_CB.Items.AddRange(CMESES);
            int AÑO_A = Int32.Parse(AñoE);
            int B1 = 0;
            string[] AÑO_DA, DIA_DA;
            int CF = AÑO_A - 1950, C2;
            AÑO_DA = new string[CF + 1];
            DIA_DA = new string[31];
            //DateTime dateValue = new DateTime(2020, 9, 22);
            //MES.Text = dateValue.ToString("dddd");
            for (int i = 1950; i <= AÑO_A; i++)
            {
                B1 = i - 1950;
                AÑO_DA[B1] = i.ToString();
            }
            AÑO_CB.Items.AddRange(AÑO_DA);

            for (int i = 0; i <= 30; i++)
            {
                C2 = i + 1;
                DIA_DA[i] = C2.ToString();
            }
            DIA_CB.Items.AddRange(DIA_DA);
            string[] MES_DA = { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
            MES_CB.Items.AddRange(MES_DA);
            string[] TU_DA = { "MAESTRO", "CASUAL" };
            TU_CB.Items.AddRange(TU_DA);
            string[] TE_DA = { "CAMA ELECTRICA", "DESFIBRADOR", "DOPPLER", "ECG", "ELECTROBISTUN", "ECOGRAFO", "INCUBADORA", "LAMPARA CIELITICA", "LAMPARA DE FOTOTERAPIA", "MAQUINA DE ANESTESIA", "MESA DE CIRUGIA", "MONITOR MULTIPARAMETRO", "MONITOR FETAL", "RAYOS X", "OTRO" };

        }

        private void AGG_US1_Click(object sender, EventArgs e)
        {

            AGG_US1.Visible = false;
            AGG_US2.Visible = true;
            AGG_E1.Visible = true;
            AGG_E2.Visible = false;
            AGG_P1.Visible = true;
            AGG_P2.Visible = false;
        }

        private void AGG_US2_Click(object sender, EventArgs e)
        {
            AGG_US1.Visible = true;
            AGG_US2.Visible = false;
            AGG_E1.Visible = true;
            AGG_E2.Visible = false;
            AGG_P1.Visible = false;
            AGG_P2.Visible = false;
        }

        private void AGG_E1_Click(object sender, EventArgs e)
        {
            //COM

            //r1
            AGG_US1.Visible = true;
            AGG_US2.Visible = false;
            AGG_E1.Visible = false;
            AGG_E2.Visible = true;
            AGG_P1.Visible = false;
            AGG_P2.Visible = true;
        }

        private void AGG_E2_Click(object sender, EventArgs e)
        {
            AGG_US1.Visible = true;
            AGG_US2.Visible = false;
            AGG_E1.Visible = true;
            AGG_E2.Visible = false;
            AGG_P2.Visible = false;
            AGG_P1.Visible = false;

        }

        private void AGG_AGE_Click(object sender, EventArgs e)
        {

            //QR_O.Visible = true;
            //QR_CODE.Visible = false;
            Zen.Barcode.CodeQrBarcodeDraw CODIGOQR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            //QR_O.Image = CODIGOQR.Draw(PQR,150);

        }

        private void TE_CB_ValueMemberChanged(object sender, EventArgs e)
        {
            //OTROS_E.Visible = false;
        }

        private void TE_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void MANT_GUARDARB_Click(object sender, EventArgs e)
        {
            Boolean Result = String.Equals(textBox4.Text, AGG_CONTRASEÑA.Text, StringComparison.Ordinal);
            if (Result == true && AGG_NOMBRES.Text != "" && AGG_APELLIDOS.Text != "" && AGG_CONTRASEÑA.Text != "" && AGG_CORREO.Text != "" && AGG_TEL.Text != "" && Sexo_CB.Text != "" && DIA_CB.Text != "" && MES_CB.Text != "" && AÑO_CB.Text != "" && TU_CB.Text != "")
            {
                try
                {
                    //CONEXIONSSH
                    ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                    client.Connect();
                    client.AddForwardedPort(port);
                    port.Start();
                    //MYSQL
                    string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=USUARIOS";
                    string NOMBRES = AGG_NOMBRES.Text, APELLIDOS = AGG_APELLIDOS.Text, CORREO = AGG_CORREO.Text, CONTRASEÑA = AGG_CONTRASEÑA.Text, TELEFONO = AGG_TEL.Text, SEXO = Sexo_CB.Text, DIA = DIA_CB.Text, MES = MES_CB.Text, AÑO = AÑO_CB.Text, PERMISOS = TU_CB.Text;
                    string query = "INSERT INTO DATOS(`NOMBRES`, `APELLIDOS`, `CORREO`, `CONTRASEÑA`,`TELEFONO`,`SEXO`,`DIA`,`MES`,`AÑO`,`PERMISOS`) VALUES ('" + NOMBRES + "','" + APELLIDOS + "','" + CORREO + "','" + CONTRASEÑA + "','" + TELEFONO + "','" + SEXO + "','" + DIA + "','" + MES + "','" + AÑO + "','" + PERMISOS + "')";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                    ard.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = ard.ExecuteReader();
                    AGG_CHECK.Visible = true;
                    MessageBox.Show("Usuario registrado satisfactoriamente");
                    databaseConnection.Close();
                    AGG_NOMBRES.Text = "";
                    AGG_APELLIDOS.Text = "";
                    AGG_CORREO.Text = "";
                    AGG_CONTRASEÑA.Text = "";
                    AGG_TEL.Text = "";
                    Sexo_CB.Text = "";
                    DIA_CB.Text = "";
                    MES_CB.Text = "";
                    AÑO_CB.Text = "";
                    TU_CB.Text = "";
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

        private void AGG_NOMBRES_TextChanged(object sender, EventArgs e)
        {
            AGG_CHECK.Visible = false;
        }

        private void AGG_APELLIDOS_TextChanged(object sender, EventArgs e)
        {

        }

        private void AGG_CORREO_TextChanged(object sender, EventArgs e)
        {

        }

        private void AGG_CONTRASEÑA_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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

       


        private void REGISTRAR_AGG_Click(object sender, EventArgs e)
        {
            string TIPE;
            //if (E_NOMBRE.Text != "" && E_MARCA.Text != "" && E_MODELO.Text != "" && E_SERIE.Text != "" && MESES_CB.Text != "" && TIPE != "" && ACTIVO_FIJO.Text != "" && UBICACION.Text != "" && CB_INSCRITO.Text != "")
            //{
                string AñoE = DateTime.Now.Year.ToString();
                string MesE = DateTime.Now.Month.ToString();
                string DiaE = DateTime.Now.Day.ToString();
                int HA1 = Convert.ToInt32(MesE);
                //int MES_1A = Convert.ToInt32(MESES_CB.Text);
                int MESM, AÑOM, DIAM;
                //DateTime F2 = DateTime.Now.AddMonths(Convert.ToInt32(MESES_CB.Text));
  
                int AÑOA = Convert.ToInt32(AñoE);
                int MESA = Convert.ToInt32(MesE);
                int DIAA = Convert.ToInt32(AñoE);
                try
                {
                    //CONEXION SSH
                    //string SMES = MESES_CB.Text;
                    //int SMES1 = Convert.ToInt32(SMES);
                    ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                    client.Connect();
                    client.AddForwardedPort(port);
                    port.Start();
                    //OBTENER LA EQIQUETA
                    string connectionStrin = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS";
                    MySqlConnection databaseConnectio = new MySqlConnection(connectionStrin);
                    string QUER = @"SELECT COUNT(*) FROM DATOS";
                    databaseConnectio.Open();
                    var cmd = new MySqlCommand(QUER, databaseConnectio);
                    int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    string cuenta = count.ToString();
                    CONTADOR = cuenta;
                    databaseConnectio.Close();
                //CREAR BASE DE DATOS
                    TIPE = "";
                    string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS";
                    string NOMBRE = E_NOMBRE.Text, TAG = "fgar" + cuenta, MARCA = E_MARCA.Text, MODELO = E_MODELO.Text, SERIE = E_SERIE.Text, FRECUENCIA = "", DIAB = "", MESB = "", AÑOB = "", ACTIVO = "", UBICA = "", INSCRITO = "";
                    string query = "INSERT INTO DATOS(`TAG`, `NOMBRE`, `MARCA`,`MODELO`,`SERIE`,`FRECUENCIA`,`TEQUIPO`,`DIA`,`MES`,`AÑO`,`UBICACION`,`ACTIVO`,`INSCRITO`) VALUES ('" + TAG + "','" + NOMBRE + "','" + MARCA + "','" + MODELO + "','" + SERIE + "','" + FRECUENCIA + "','" + TIPE + "','" + DIAB + "','" + MESB + "','" + AÑOB + "','" + UBICA + "','" + ACTIVO + "','" + INSCRITO + "')";
                    TAGR = TAG;
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                    ard.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = ard.ExecuteReader();
                    databaseConnection.Close();
                    AGG_CHECK.Visible = true;
                    PQR = TAG;
                    client.Disconnect();
                    E_NOMBRE.Text = "";
                    E_MARCA.Text = "";
                    E_MODELO.Text = "";
                    E_SERIE.Text = "";
                    MessageBox.Show("Equipo registrado satisfactoriamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
         
        //}

        private void MESES_CB_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TE_CB_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void crear_tabla_Click(object sender, EventArgs e)
        {

        }

        private void QR_CODE_Click(object sender, EventArgs e)
        {

        }

       
        private void iconButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void AGG_CONFIRMACION_Enter(object sender, EventArgs e)
        {
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {

                textBox4.UseSystemPasswordChar = true;

        }

        private void AGG_CONTRASEÑA_Enter(object sender, EventArgs e)
        {

                AGG_CONTRASEÑA.UseSystemPasswordChar = true;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //string SMES = MESES_CB.Text;
                //int SMES1 = Convert.ToInt32(SMES);
                

                OpenFileDialog fad = new OpenFileDialog();
                fad.Filter = "All files (*.*)|*.*";
                fad.FilterIndex = 1;
                string ND = "", PATHFILE = "";
                if (fad.ShowDialog() == DialogResult.OK)
                {
                    PATHFILE = System.IO.Path.GetFullPath(fad.FileName);
                    ND = fad.SafeFileName;
                }

                string host = "jfingfgar.duckdns.org";
                string username = "pi";
                string password = "JFing";
                //string remoteDirectory = @"/media/pi/RS1/DataBase/EQUIPOS/" + TAGR + "/HistorialMantenimientos/" + "Historico_" + cuenta + ".pdf";
                string remoteDirectory2 = "/home/pi/DataBase/EQUIPOS/" + TAGR + "/Anexos/" + ND;
                string pathLocalFile = PATHFILE;
                //COMENTARIOS_MAN.Text = remoteDirectory;
                using (SftpClient sftp = new SftpClient(host, username, password))
                {
                    sftp.Connect();
                    using (Stream fileStream = File.OpenRead(pathLocalFile))
                    {
                        sftp.UploadFile(fileStream, remoteDirectory2);
                    }
                    sftp.Disconnect();
                }
                
                //CREAR BASE DE DATOS
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=ANEXOS";
                string query = "INSERT INTO "+TAGR+"(`PATH`) VALUES ('"+ND+"')";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                ard.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = ard.ExecuteReader();
                databaseConnection.Close();
                client.Disconnect();
                MessageBox.Show("Archivo Cargado Exitosamente");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            
        }



        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
