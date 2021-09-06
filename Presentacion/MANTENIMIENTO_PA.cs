using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.VisualBasic.Devices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System.Threading;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Renci.SshNet.Sftp;
using Aspose.Words.Fields;
//using Word = Microsoft.Office.Interop.Word;
//using System.IO;
//using System.Reflection;

namespace Presentacion
{
    public partial class MANTENIMIENTO_PA : UserControl
    {
        public string TAGL = "";
        public string TAG_NOMBRE = "";
        public string TAG_MODELO = "";
        public string TAG_SERIE = "";
        public string TAG_MARCA = "";
        public string TAG_ACTIVO= "";
        public string DIA_A = "";
        public string MES_A = "";
        public string AÑO_A= "";
        public string FRE_A = "";
        public string T1="", T2="", T3="", T4="", T5="", T11="", T22="", T33="", T44="", T55="";

        public MANTENIMIENTO_PA()
        {
            
            InitializeComponent();
            MANT_CORRE.Visible = false;
            MANT_PRE.Visible = false;
            MANT_GA.Visible = false;
            MANT_CORRE2.Visible = true;
            MANT_PRE2.Visible = true;
            MANT_GA2.Visible = true;
            MC_11.Visible = true;
            MC_21.Visible = false;
            MC_12.Visible = true;
            MC_22.Visible = false;
            MC_13.Visible = true;
            MC_23.Visible = false;
            MC_14.Visible = true;
            MC_24.Visible = false;
            MC_15.Visible = true;
            MC_25.Visible = false;
            MC_16.Visible = true;
            MC_26.Visible = false;
            MC_17.Visible = true;
            MC_27.Visible = false;
            MC_18.Visible = true;
            MC_28.Visible = false;
            MC_19.Visible = true;
            MC_29.Visible = false;
            MC_110.Visible = true;
            MC_210.Visible = false;
            MC_111.Visible = true;
            MC_211.Visible = false;
            MC_112.Visible = true;
            MC_212.Visible = false;
            MC_113.Visible = true;
            MC_213.Visible = false;
            MC_114.Visible = true;
            MC_214.Visible = false;
            MC_115.Visible = true;
            MC_215.Visible = false;
            MC_116.Visible = true;
            MC_216.Visible = false;
            MC_117.Visible = true;
            MC_217.Visible = false;
            MC_118.Visible = true;
            MC_218.Visible = false;
            MC_119.Visible = true;
            MC_219.Visible = false;
            MC_120.Visible = true;
            MC_220.Visible = false;
            MANT_NC.Visible = true;
            MANT_CC.Visible = false;
            MANT_BUSCAR.Visible = true;
            PARAR.Visible = false;

        }
        private void MANTENIMIENTO_PA_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            Puertos_BOX.Items.AddRange(puertos);
            //SepararTexto();
            label25.Text = "";
            label28.Text = "";
            label30.Text = "";
            
        }
        private void MANT_BUSCAR_Click(object sender, EventArgs e)
        {

            try
            {
                serialPort1.PortName = Puertos_BOX.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.Open();
                MANT_NC.Visible = false;
                MANT_CC.Visible = true;
                MANT_BUSCAR.Visible = false;
                PARAR.Visible = true;
               
            }
            catch
            {
                MessageBox.Show("Error al conectar");
            }
        }
        private void MANT_CORRE2_Click(object sender, EventArgs e)
        {
            MANT_CORRE.Visible = true;
            MANT_PRE.Visible = false;
            MANT_GA.Visible = false;
            MANT_CORRE2.Visible = false;
            MANT_PRE2.Visible = true;
            MANT_GA2.Visible = true;
        }

        private void MANT_PRE2_Click(object sender, EventArgs e)
        {
            MANT_CORRE.Visible =false;
            MANT_PRE.Visible = true;
            MANT_GA.Visible = false;
            MANT_CORRE2.Visible = true;
            MANT_PRE2.Visible = false;
            MANT_GA2.Visible = true;

        }

        private void MANT_GA2_Click(object sender, EventArgs e)
        {
            MANT_CORRE.Visible = false;
            MANT_PRE.Visible = false;
            MANT_GA.Visible = true;
            MANT_CORRE2.Visible = true;
            MANT_PRE2.Visible = true;
            MANT_GA2.Visible = false;
        }

        private void MANT_CORRE_Click(object sender, EventArgs e)
        {
            MANT_CORRE2.Visible = true;
            MANT_CORRE.Visible = false;
        }

        private void MANT_PRE_Click(object sender, EventArgs e)
        {
            MANT_PRE.Visible = false;
            MANT_PRE2.Visible = true;
        }

        private void MANT_GA_Click(object sender, EventArgs e)
        {
            MANT_GA2.Visible = true;
            MANT_GA.Visible = false;
        }

        private void MC_11_Click(object sender, EventArgs e)
        {
            MC_11.Visible = false;
            MC_21.Visible = true;
        }

        private void MC_21_Click(object sender, EventArgs e)
        {
            MC_11.Visible = true;
            MC_21.Visible = false;
        }

        private void MC_12_Click(object sender, EventArgs e)
        {
            MC_12.Visible = false;
            MC_22.Visible = true;
        }

        private void MC_22_Click(object sender, EventArgs e)
        {
            MC_12.Visible = true;
            MC_22.Visible = false;
        }

        private void MC_13_Click(object sender, EventArgs e)
        {
            MC_13.Visible = false;
            MC_23.Visible = true;
        }

        private void MC_23_Click(object sender, EventArgs e)
        {
            MC_13.Visible = true;
            MC_23.Visible = false;
        }

        private void MC_14_Click(object sender, EventArgs e)
        {
            MC_14.Visible = false;
            MC_24.Visible = true;
        }

        private void MC_24_Click(object sender, EventArgs e)
        {
            MC_14.Visible = true;
            MC_24.Visible = false;
        }

        private void MC_15_Click(object sender, EventArgs e)
        {
            MC_15.Visible = false;
            MC_25.Visible = true;
        }

        private void MC_25_Click(object sender, EventArgs e)
        {
            MC_15.Visible = true;
            MC_25.Visible = false;
        }

        private void MC_16_Click(object sender, EventArgs e)
        {
            MC_16.Visible = false;
            MC_26.Visible = true;
        }

        private void MC_26_Click(object sender, EventArgs e)
        {
            MC_16.Visible = true;
            MC_26.Visible = false;
        }

        private void MC_17_Click(object sender, EventArgs e)
        {
            MC_17.Visible = false;
            MC_27.Visible = true;
        }

        private void MC_27_Click(object sender, EventArgs e)
        {
            MC_17.Visible = true;
            MC_27.Visible = false;
        }

        private void MC_18_Click(object sender, EventArgs e)
        {
            MC_18.Visible = false;
            MC_28.Visible = true;
        }

        private void MC_28_Click(object sender, EventArgs e)
        {
            MC_18.Visible = true;
            MC_28.Visible = false;
        }

        private void MC_19_Click(object sender, EventArgs e)
        {
            MC_19.Visible = false;
            MC_29.Visible = true;
        }

        private void MC_29_Click(object sender, EventArgs e)
        {
            MC_19.Visible = true;
            MC_29.Visible = false;
        }

        private void MC_110_Click(object sender, EventArgs e)
        {
            MC_110.Visible = false;
            MC_210.Visible = true;
        }

        private void MC_210_Click(object sender, EventArgs e)
        {
            MC_110.Visible = true;
            MC_210.Visible = false;
        }

        private void MC_111_Click(object sender, EventArgs e)
        {
            MC_111.Visible = false;
            MC_211.Visible = true;
        }

        private void MC_211_Click(object sender, EventArgs e)
        {
            MC_111.Visible = true;
            MC_211.Visible = false;
        }

        private void MC_112_Click(object sender, EventArgs e)
        {
            MC_112.Visible = false;
            MC_212.Visible = true;
        }

        private void MC_212_Click(object sender, EventArgs e)
        {
            MC_112.Visible = true;
            MC_212.Visible = false;
        }

        private void MC_113_Click(object sender, EventArgs e)
        {
            MC_113.Visible = false;
            MC_213.Visible = true;
        }

        private void MC_213_Click(object sender, EventArgs e)
        {
            MC_113.Visible = true;
            MC_213.Visible = false;
        }

        private void MC_116_Click(object sender, EventArgs e)
        {
            MC_116.Visible = false;
            MC_216.Visible = true;
        }

        private void MC_216_Click(object sender, EventArgs e)
        {
            MC_116.Visible = true;
            MC_216.Visible = false;
        }

        private void MC_117_Click(object sender, EventArgs e)
        {
            MC_117.Visible = false;
            MC_217.Visible = true;
        }

        private void MC_217_Click(object sender, EventArgs e)
        {
            MC_117.Visible = true;
            MC_217.Visible = false;
        }

        private void MC_118_Click(object sender, EventArgs e)
        {
            MC_118.Visible = false;
            MC_218.Visible = true;
        }

        private void MC_218_Click(object sender, EventArgs e)
        {
            MC_118.Visible = true;
            MC_218.Visible = false;
        }

        private void MC_119_Click(object sender, EventArgs e)
        {
            MC_119.Visible = false;
            MC_219.Visible = true;
        }

        private void MC_219_Click(object sender, EventArgs e)
        {
            MC_119.Visible = true;
            MC_219.Visible = false;
        }
        private void MC_120_Click(object sender, EventArgs e)
        {
            MC_120.Visible = false;
            MC_220.Visible = true;
        }
        private void MC_220_Click(object sender, EventArgs e)
        {
            MC_120.Visible = true;
            MC_220.Visible = false;
        }
        private void MC_114_Click(object sender, EventArgs e)
        {
            MC_114.Visible = false;
            MC_214.Visible = true;
        }
        private void MC_214_Click(object sender, EventArgs e)
        {
            MC_114.Visible = true;
            MC_214.Visible = false;
        }
        private void MC_115_Click(object sender, EventArgs e)
        {
            MC_115.Visible = false;
            MC_215.Visible = true;
        }

        private void MC_215_Click(object sender, EventArgs e)
        {
            MC_115.Visible = true;
            MC_215.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("C");
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                Thread.Sleep(120);
                byte[] ha3 = { 0, 0, 0, 0 ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
                serialPort1.Read(ha3, 0, 21);
                serialPort1.Write("C");
                if (ha3[0]==1)
                {
                    MANT_CORRE.Visible = true;
                    MANT_PRE.Visible = false;
                    MANT_GA.Visible = false;
                    MANT_CORRE2.Visible = false;
                    MANT_PRE2.Visible = true;
                    MANT_GA2.Visible = true;
                }
                if(ha3[1]==1)
                {
                    MC_11.Visible = false;
                    MC_21.Visible = true;
                }
                else if (ha3[1] == 0)
                {
                    MC_11.Visible = true;
                    MC_21.Visible = false;
                }
                if (ha3[2] == 1)
                {
                    MC_12.Visible = false;
                    MC_22.Visible = true;
                }
                else if (ha3[2] == 0)
                {
                    MC_12.Visible = true;
                    MC_22.Visible = false;
                }
                if (ha3[3] == 1)
                {
                    MC_13.Visible = false;
                    MC_23.Visible = true;
                }
                else if (ha3[3] == 0)
                {
                    MC_13.Visible = true;
                    MC_23.Visible = false;
                }
                if (ha3[4] == 1)
                {
                    MC_14.Visible = false;
                    MC_24.Visible = true;
                }
                else if (ha3[4] == 0)
                {
                    MC_14.Visible = true;
                    MC_24.Visible = false;
                }
                if (ha3[5] == 1)
                {
                    MC_15.Visible = false;
                    MC_25.Visible = true;
                }
                else if (ha3[5] == 0)
                {
                    MC_15.Visible = true;
                    MC_25.Visible = false;
                }
                if (ha3[6] == 1)
                {
                    MC_16.Visible = false;
                    MC_26.Visible = true;
                }
                else if (ha3[6] == 0)
                {
                    MC_16.Visible = true;
                    MC_26.Visible = false;
                }
                if (ha3[7] == 1)
                {
                    MC_17.Visible = false;
                    MC_27.Visible = true;
                }
                else if (ha3[7] == 0)
                {
                    MC_17.Visible = true;
                    MC_27.Visible = false;
                }
                if (ha3[8] == 1)
                {
                    MC_18.Visible = false;
                    MC_28.Visible = true;
                }
                else if (ha3[8] == 0)
                {
                    MC_18.Visible = true;
                    MC_28.Visible = false;
                }
                if (ha3[9] == 1)
                {
                    MC_19.Visible = false;
                    MC_29.Visible = true;
                }
                else if (ha3[9] == 0)
                {
                    MC_19.Visible = true;
                    MC_29.Visible = false;
                }
                //
                if (ha3[10] == 1)
                {
                    MC_110.Visible = false;
                    MC_210.Visible = true;
                }
                else if (ha3[10] == 0)
                {
                    MC_110.Visible = true;
                    MC_210.Visible = false;
                }
                //
                if (ha3[11] == 1)
                {
                    MC_111.Visible = false;
                    MC_211.Visible = true;
                }
                else if (ha3[11] == 0)
                {
                    MC_111.Visible = true;
                    MC_211.Visible = false;
                }
                if (ha3[12] == 1)
                {
                    MC_112.Visible = false;
                    MC_212.Visible = true;
                }
                else if (ha3[12] == 0)
                {
                    MC_112.Visible = true;
                    MC_212.Visible = false;
                }
                if (ha3[13] == 1)
                {
                    MC_113.Visible = false;
                    MC_213.Visible = true;
                }
                else if (ha3[13] == 0)
                {
                    MC_113.Visible = true;
                    MC_213.Visible = false;
                }
                if (ha3[14] == 1)
                {
                    MC_114.Visible = false;
                    MC_214.Visible = true;
                }
                else if (ha3[14] == 0)
                {
                    MC_114.Visible = true;
                    MC_214.Visible = false;
                }
                if (ha3[15] == 1)
                {
                    MC_115.Visible = false;
                    MC_215.Visible = true;
                }
                else if (ha3[15] == 0)
                {
                    MC_115.Visible = true;
                    MC_215.Visible = false;
                }
                if (ha3[16] == 1)
                {
                    MC_116.Visible = false;
                    MC_216.Visible = true;
                }
                else if (ha3[16] == 0)
                {
                    MC_116.Visible = true;
                    MC_216.Visible = false;
                }
                if (ha3[17] == 1)
                {
                    MC_117.Visible = false;
                    MC_217.Visible = true;
                }
                else if (ha3[17] == 0)
                {
                    MC_117.Visible = true;
                    MC_217.Visible = false;
                }
                if (ha3[18] == 1)
                {
                    MC_118.Visible = false;
                    MC_218.Visible = true;
                }
                else if (ha3[18] == 0)
                {
                    MC_118.Visible = true;
                    MC_218.Visible = false;
                }
                if (ha3[19] == 1)
                {
                    MC_119.Visible = false;
                    MC_219.Visible = true;
                }
                else if (ha3[19] == 0)
                {
                    MC_119.Visible = true;
                    MC_219.Visible = false;
                }
                if (ha3[20] == 1)
                {
                    MC_120.Visible = false;
                    MC_220.Visible = true;
                }
                else if (ha3[20] == 0)
                {
                    MC_120.Visible = true;
                    MC_220.Visible = false;
                }

            }
            else
            {
                MessageBox.Show("No esta conectado el dispositivo", "Alerta");
            }
        }

        private void ACTUALIZAR_Click(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            Puertos_BOX.Items.AddRange(puertos);
        }

        private void ENVIAR_Click(object sender, EventArgs e)
        {
            try
            {   if(textBox1.Text !="")
                {
                    DatosE(textBox1.Text);
                    TAGL = textBox1.Text;
                }
                else 
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("B");
                        serialPort1.DiscardOutBuffer();
                        serialPort1.DiscardInBuffer();
                        Thread.Sleep(120);
                        byte[] ha2 = { 0, 0, 0, 0 };
                        serialPort1.Read(ha2, 0, 4);
                        serialPort1.Write("B");
                        if (ha2[1] == 255 && ha2[2] == 255 && ha2[3] == 255)
                        {
                            textBox1.Text = "fgar" + ha2[0].ToString();
                        }
                        else if (ha2[1] != 255 && ha2[2] == 255 && ha2[3] == 255)
                        {
                            textBox1.Text = "fgar" + ha2[0].ToString() + ha2[1].ToString();
                        }
                        else if (ha2[1] != 255 && ha2[2] != 255 && ha2[3] == 255)
                        {
                            textBox1.Text = "fgar" + ha2[0].ToString() + ha2[1].ToString() + ha2[2].ToString();
                        }
                        else if (ha2[1] != 255 && ha2[2] != 255 && ha2[3] == 255)
                        {
                            textBox1.Text = "fgar" + ha2[0].ToString() + ha2[1].ToString() + ha2[2].ToString() + ha2[3].ToString();
                        }
                        TAGL = textBox1.Text;
                        DatosE(textBox1.Text);
                    }
                    else
                    {
                        MessageBox.Show("No esta conectado el dispositivo", "Alerta");
                    }

                }

            }
            catch
            {
                MessageBox.Show("error al leer");
            }
        }
        private void DatosE(string TAGH)
        {
            string QUERY = "SELECT *FROM DATOS WHERE TAG='" + TAGH + "'";
            try
            {
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                //CONEXION MYSQL
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand COMMAND = new MySqlCommand(QUERY, databaseConnection);
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = COMMAND.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NOMBRE_M.Text = reader.GetString(2);
                        MARCA_M.Text = reader.GetString(3);
                        MODELO_M.Text = reader.GetString(4);
                        SERIE_M.Text = reader.GetString(5);
                        ACTIVO_FIJO.Text = reader.GetString(12);
                    }
                }
                databaseConnection.Close();
                client.Disconnect();
                TAGL = TAG_MA.Text;
                TAG_NOMBRE = NOMBRE_M.Text;
                TAG_MARCA = MARCA_M.Text;
                TAG_MODELO = MODELO_M.Text;
                TAG_SERIE = SERIE_M.Text;
                TAG_ACTIVO = ACTIVO_FIJO.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PARAR_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            { 
                serialPort1.Close();
                MANT_CC.Visible = false;
                MANT_NC.Visible = true;
                PARAR.Visible = false;
                MANT_BUSCAR.Visible = true;
            }
        }

        private void MANT_GUARDARB_Click(object sender, EventArgs e)
        {
            if (MANT_GA.Visible == true || MANT_CORRE.Visible == true || MANT_PRE.Visible == true)
            {
                if(MessageBox.Show("Desea Registrar el Matenimiento?", "Alerta", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    string D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, D16, D17, D18, D19, D20, D21, D22, D23, M1;
                    if (MC_21.Visible == true)
                    { D1 = "X"; ; }
                    else { D1 = ""; }
                    if (MC_22.Visible == true)
                    { D2 = "X"; }
                    else { D2 = ""; }
                    if (MC_23.Visible == true)
                    { D3 = "X"; }
                    else { D3 = ""; }
                    if (MC_24.Visible == true)
                    { D4 = "X"; }
                    else { D4 = ""; }
                    if (MC_25.Visible == true)
                    { D5 = "X"; }
                    else { D5 = ""; }
                    if (MC_26.Visible == true)
                    { D6 = "X"; }
                    else { D6 = ""; }
                    if (MC_27.Visible == true)
                    { D7 = "X"; }
                    else { D7 = ""; }
                    if (MC_28.Visible == true)
                    { D8 = "X"; }
                    else { D8 = ""; }
                    if (MC_29.Visible == true)
                    { D9 = "X"; }
                    else { D9 = ""; }
                    if (MC_210.Visible == true)
                    { D10 = "X"; }
                    else { D10 = ""; }
                    if (MC_211.Visible == true)
                    { D11 = "X"; }
                    else { D11 = ""; }
                    if (MC_212.Visible == true)
                    { D12 = "X"; }
                    else { D12 = ""; }
                    if (MC_212.Visible == true)
                    { D12 = "X"; }
                    else { D12 = ""; }
                    if (MC_213.Visible == true)
                    { D13 = "X"; }
                    else { D13 = ""; }
                    if (MC_214.Visible == true)
                    { D14 = "X"; }
                    else { D14 = ""; }
                    if (MC_215.Visible == true)
                    { D15 = "X"; }
                    else { D15 = ""; }
                    if (MC_216.Visible == true)
                    { D16 = "X"; }
                    else { D16 = ""; }
                    if (MC_217.Visible == true)
                    { D17 = "X"; }
                    else { D17 = ""; }
                    if (MC_218.Visible == true)
                    { D18 = "X"; }
                    else { D18 = ""; }
                    if (MC_219.Visible == true)
                    { D19 = "X"; }
                    else { D19 = ""; }
                    if (MC_220.Visible == true)
                    { D20 = "X"; }
                    else { D20 = ""; }

                    if (MANT_CORRE.Visible == true)
                    {
                        D21 = "X";
                        D22 = "";
                        D23 = "";
                    }
                    else if (MANT_PRE.Visible == true)
                    {
                        D21 = "";
                        D22 = "X";
                        D23 = "";
                    }
                    else
                    {
                        D21 = "";
                        D22 = "";
                        D23 = "X";
                    }
                    try {        
                        M1 = COMENTARIOS_MAN.Text;
                        string tag2 = TAG_MA.Text, NombreE = "HYUNDAI_M", MarcaE = "HYUNDAI", SerieE = "14584166", ModeloE = "H-501", RespondableE = "LA", EncargadoE = "LB";
                        string AÑO = DateTime.Now.Year.ToString();
                        string MES = DateTime.Now.Month.ToString();
                        string DIA = DateTime.Now.Day.ToString();
                        //SSH CONEXION
                        ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                        client.Connect();
                        client.AddForwardedPort(port);
                        port.Start();
                        //CONEXION A MYSQL
                        string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=MANTENIMIENTO;";
                        string query = "INSERT INTO "+textBox1.Text+ "(CORRECTIVO, PREVENTIVO, GARANTIA,ITEM1,ITEM2,ITEM3,ITEM4,ITEM5,ITEM6,ITEM7,ITEM8,ITEM9,ITEM10,ITEM11,ITEM12,ITEM13,ITEM14,ITEM15,ITEM16,ITEM17,ITEM18,ITEM19,ITEM20,TEXTO,DIA,MES,AÑO,NOMBRE, MARCA,SERIE,MODELO,RESPONSABLE,ENCARGADO, ACTIVO) VALUES ('" + D21 + "','" + D22 + "','" + D23 + "','" + D1 + "','" + D2 + "','" + D3 + "','" + D4 + "','" + D5 + "','" + D6 + "','" + D7 + "','" + D8 + "','" + D9 + "','" + D10 + "','" + D11 + "','" + D12 + "','" + D13 + "','" + D14 + "','" + D15 + "','" + D16 + "','" + D17 + "','" + D18 + "','" + D19 + "','" + D20 + "','" + tag2 + "','" + DIA + "','" + MES + "','" + AÑO + "','" + NombreE + "','" + MarcaE + "','" + SerieE + "','" + ModeloE + "','" + RespondableE + "','" + EncargadoE + "','"+ACTIVO_FIJO.Text+"')";
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                        ard.CommandTimeout = 60;
                        databaseConnection.Open();
                        MySqlDataReader myReader = ard.ExecuteReader();
                        databaseConnection.Close();
                        //OBTENER NOMBRE DEL ARCVHIVO A SUBIR AL SERVER 
                        //string connectionString2 = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=MANTENIMIENTO;";
                        MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                        databaseConnection2.Open();
                        string QUER = @"SELECT COUNT(*) FROM "+textBox1.Text;
                        MySqlCommand cmd = new MySqlCommand(QUER, databaseConnection2);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        string cuenta = count.ToString();
                        //ACTIVO_FIJO.Text = cuenta;
                        //MySqlDataReader myreader2 = cmd.ExecuteReader();
                        databaseConnection2.Close();
                        //
                        string QUERY = "SELECT *FROM DATOS WHERE TAG='" + TAG_MA.Text + "'";
                        string connectionString3 = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS;";
                        MySqlConnection databaseConnection3 = new MySqlConnection(connectionString3);
                        MySqlCommand COMMAND = new MySqlCommand(QUERY, databaseConnection3);
                        databaseConnection3.Open();
                        MySqlDataReader reader;
                        reader = COMMAND.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FRE_A = reader.GetString(6);
                                DIA_A = reader.GetString(8);
                                MES_A = reader.GetString(9);
                                AÑO_A = reader.GetString(10);
                            }
                        }
                        SepararTexto();
                        //ACTUALIZAR FECHA DE MANTENIMIENTO 
                        ACTUALIZAR_DA();
                        //DESCONECTAR EL SERVIDOR SSH 
                        client.Disconnect();
                        //CREAR PDF
                        string NOMBRE = NOMBRE_M.Text, MARCA = MARCA_M.Text, MODELO = MODELO_M.Text, SERIE = SERIE_M.Text, RESPONSABLE = "LAA1", ENCARGADO = "LA3", ACTIVO = ACTIVO_FIJO.Text;
                        string[] DatosPDF = { D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, D16, D17, D18, D19, D20, D21, D22, D23, M1, DIA, MES, AÑO, NOMBRE, MARCA, SERIE, MODELO, RESPONSABLE, ENCARGADO, ACTIVO };
                        CrearPDF(DatosPDF);
                        //DIRECCION DE EL PDF
                        String PA = AppDomain.CurrentDomain.BaseDirectory;
                        String AA = @PA + @"\MR.pdf";
                        //SFTP
                        string host = "jfingfgar.duckdns.org";
                        string username = "pi";
                        string password = "JFing";
                        string remoteDirectory = @"/media/pi/RS1/DataBase/EQUIPOS/" + textBox1.Text + "/HistorialMantenimientos/" + "Historico_" + cuenta + ".pdf";
                        string remoteDirectory2 = "/home/pi/DataBase/EQUIPOS/" + textBox1.Text + "/HistorialMantenimientos/Historico_" + cuenta + ".pdf";
                        string pathLocalFile = @"C:\Users\galan\Desktop\Programa WINDOWS\JF_INGIENERIA\Presentacion\bin\Debug\MR.pdf";
                        string pathLocalFil2 = AA;
                    //CONEXION SFTP
                        using (SftpClient sftp = new SftpClient(host, username, password))
                            {
                                sftp.Connect();
                                using (Stream fileStream = File.OpenRead(AA))
                                {
                                    sftp.UploadFile(fileStream, remoteDirectory2);
                                }
                                sftp.Disconnect();
                            }
                            MessageBox.Show("Registrado con exito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message+"h1s");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de servicio");
            }
        }
        private void ACTUALIZAR_DA()
        {
            int A4;
            label25.Text = FRE_A;
            //A4 = Convert.ToInt32(FRE_A);
            DateTime F1 = DateTime.Now;
            DateTime F2 = DateTime.Now.AddMonths(6);
            string G1, G2, G3;
            G1 = F2.Day.ToString();
            G2 = F2.Month.ToString();
            G3 = F2.Year.ToString();
            try
            {
                string FA = "UPDATE DATOS SET DIA='" +G1+ "',MES='" +G2+ "',AÑO='" +G3+ "' WHERE TAG='" + TAG_MA.Text + "'";
                string connectionString3 = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS;";
                MySqlConnection databaseConnection3 = new MySqlConnection(connectionString3);
                MySqlCommand COMMAND = new MySqlCommand(FA, databaseConnection3);
                databaseConnection3.Open();
                MySqlDataReader reader;
                reader = COMMAND.ExecuteReader();
                databaseConnection3.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+"g2");
            }


        }
        public void SepararTexto()
        {
            string gh = COMENTARIOS_MAN.Text;
            string[] palabras = gh.Split(' ');
            int CFA = gh.Length;
            string FGA = CFA.ToString();
          
            int i1=0, i2, i3, i4, i5;
            if(gh.Length<80)
            {
                for(int i =0;i<gh.Length;i++)
                {
                    T1 = T1 + gh[i];
                }
                T2 = "   ";
                T3 = "   ";
                T4 = "   ";
                T5 = "   ";
            }
            else if(CFA>80 && CFA<160)
            {
                for (int i = 0; i < 80; i++)
                {
                    T1 = T1 + gh[i];
                }
                for (int i =80; i < gh.Length; i++)
                {
                    T2 = T2 + gh[i];
                }
                T3 = "   ";
                T4 = "   ";
                T5 = "   ";
            }
            else if (CFA > 160 && CFA < 240)
            {
                for (int i = 0; i < 80; i++)
                {
                    T1 = T1 + gh[i];
                }
                for (int i = 80; i < 160; i++)
                {
                    T2 = T2 + gh[i];
                }
                for (int i = 160; i < gh.Length; i++)
                {
                    T3 = T3 + gh[i];
                }
                T4 = "   ";
                T5 = "   ";
            }
            else if (CFA > 240 && CFA < 320)
            {
                for (int i = 0; i < 80; i++)
                {
                    T1 = T1 + gh[i];
                }
                for (int i = 80; i < 160; i++)
                {
                    T2 = T2 + gh[i];
                }
                for (int i = 160; i < 240; i++)
                {
                    T3 = T3 + gh[i];
                }
                for (int i = 240; i < gh.Length; i++)
                {
                    T4 = T4 + gh[i];
                }
                T5 = "   ";
            }
            else if (CFA > 320 && CFA < 400)
            {
                for (int i = 0; i < 80; i++)
                {
                    T1 = T1 + gh[i].ToString();
                }
                for (int i = 80; i < 160; i++)
                {
                    T2 = T2 + gh[i].ToString();
                }
                for (int i = 160; i < 240; i++)
                {
                    T3 = T3 + gh[i].ToString();
                }
                for (int i = 240; i < 320; i++)
                {
                    T4 = T4 + gh[i].ToString();
                }
                for (int i = 320; i < gh.Length; i++)
                {
                    T5 = T5 + gh[i].ToString();
                }
            }

        }
        private void CrearPDF(string[] datosPDF)
        {
            string M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12, M13, M14, M15, M16, M17, M18, M19, M20, TM1, TM2, TM3,CM1,DiaE,MesE,AñoE,NOMBRE,MARCA,SERIE,MODELO,RESPONSABLE,ENCARGADO,ACTIVO;
            M1 = datosPDF[0];
            M2 = datosPDF[1];
            M3 = datosPDF[2];
            M4 = datosPDF[3];
            M5 = datosPDF[4];
            M6 = datosPDF[5];
            M7 = datosPDF[6];
            M8 = datosPDF[7];
            M9 = datosPDF[8];
            M10 = datosPDF[9];
            M11 = datosPDF[10];
            M12 = datosPDF[11];
            M13 = datosPDF[12];
            M14 = datosPDF[13];
            M15 = datosPDF[14];
            M16 = datosPDF[15];
            M17 = datosPDF[16];
            M18 = datosPDF[17];
            M19 = datosPDF[18];
            M20 = datosPDF[19];
            TM1 = datosPDF[20];
            TM2 = datosPDF[21];
            TM3 = datosPDF[22];
            CM1 = datosPDF[23];
            DiaE= datosPDF[24];
            MesE= datosPDF[25];
            AñoE= datosPDF[26];
            NOMBRE= datosPDF[27];
            MARCA= datosPDF[28];
            SERIE= datosPDF[29];
            MODELO=datosPDF[30];
            RESPONSABLE=datosPDF[31];
            ENCARGADO= datosPDF[32];
            ACTIVO = datosPDF[33];
            //GENERAR PDF
            try
            {
                String PA = AppDomain.CurrentDomain.BaseDirectory;
                String AA = @PA + @"\MR.pdf";
                Document pdoc = new Document(PageSize.A4, 20f, 20f, 30f, 30f);
                PdfWriter pWriter = PdfWriter.GetInstance(pdoc, new FileStream(AA, FileMode.Create));
                pdoc.Open();
                // CREAR MEMBRETE
                PdfPTable TABLA1 = new PdfPTable(new float[] { 25f, 55f, 20f });
                TABLA1.HorizontalAlignment = 1;
                //CARGAR IMAGEN DE LA IPS
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(@PA+@"\IMG1.png");
                PdfPCell celda = new PdfPCell(myImage);
                celda.PaddingBottom = 2;
                celda.PaddingTop = 2;
                celda.PaddingLeft = 2;
                //FUENTE PARA EL TITULO
                var FC = new BaseColor(136, 136, 136);
                BaseFont Titulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font fuente = new iTextSharp.text.Font(Titulo, 22);
                PdfPCell dos = new PdfPCell(new Phrase("FORMATO MANTENIMIENTO PREVENTIVO", fuente));
                dos.HorizontalAlignment = Element.ALIGN_CENTER;
                dos.VerticalAlignment = Element.ALIGN_MIDDLE;
                dos.BackgroundColor = new BaseColor(228, 237, 242);
                //FUENTE PARA EL COSTADO DERECHO
                iTextSharp.text.Font der = new iTextSharp.text.Font(Titulo, 10);
                celda.Rowspan = 3;
                dos.Rowspan = 3;
                TABLA1.AddCell(celda);
                TABLA1.AddCell(dos);
                //COSTADO DERECHO
                PdfPCell tres = new PdfPCell();
                tres = new PdfPCell(new Phrase("CODIGO: FT-GT-008", der));
                tres.HorizontalAlignment = Element.ALIGN_CENTER;
                TABLA1.AddCell(tres);
                //VERSION 01
                PdfPCell tres2 = new PdfPCell();
                tres2 = new PdfPCell(new Phrase("Version 01", der));
                tres2.HorizontalAlignment = Element.ALIGN_CENTER;
                TABLA1.AddCell(tres2);
                PdfPCell tres3 = new PdfPCell();
                tres3 = new PdfPCell(new Phrase("Fecha de\r\nAprobacion:\r\n5/02/2019", der));
                tres3.HorizontalAlignment = Element.ALIGN_CENTER;
                tres3.VerticalAlignment = Element.ALIGN_MIDDLE;
                TABLA1.AddCell(tres3);
                TABLA1.WidthPercentage = 90f;
                pdoc.Add(TABLA1);
                //Fin del membrete
                //espacio
                Paragraph pp4 = new Paragraph("     ");
                pp4.Leading = 15;
                pdoc.Add(pp4);
                //tabla2,DATOS DEL EQUIPO
                PdfPTable TABLA2 = new PdfPTable(new float[] { 40f, 30f, 30f });
                TABLA2.HorizontalAlignment = 1;
                TABLA2.WidthPercentage = 90f;
                BaseFont T21 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, true);
                iTextSharp.text.Font D21 = new iTextSharp.text.Font(T21, 13);
                PdfPCell DATOSE = new PdfPCell();
                DATOSE = new PdfPCell(new Phrase("DATOS DE EQUIPO:", D21));
                DATOSE.Colspan = 3;
                DATOSE.Border = PdfPCell.NO_BORDER;
                DATOSE.BorderWidthLeft = 0.1f;
                DATOSE.BorderWidthRight = 0.1f;
                DATOSE.BorderWidthTop = 0.1f;
                //DATOSE.Border = PdfPCell.LEFT_BORDER-PdfPCell.RIGHT_BORDER-PdfPCell.TOP_BORDER;
                //TABLA2,NOMBRE DEL EQUIPO
                PdfPCell NombreE = new PdfPCell();
                iTextSharp.text.Font D22 = new iTextSharp.text.Font(Titulo, 13);
                NombreE = new PdfPCell(new Phrase("Nombre: "+TAG_NOMBRE, D22));
                NombreE.Border = PdfPCell.NO_BORDER;
                NombreE.BorderWidthLeft = 0.1f;
                //TABLA2,MARCA 
                PdfPCell MarcaE = new PdfPCell();
                MarcaE = new PdfPCell(new Phrase("Marca: "+TAG_MARCA, D22));
                MarcaE.Colspan = 2;
                MarcaE.Border = PdfPCell.NO_BORDER;
                MarcaE.BorderWidthRight = 0.1f;
                //TABLA2,SERIE
                PdfPCell SERIEE = new PdfPCell();
                SERIEE = new PdfPCell(new Phrase("Serie: "+TAG_SERIE, D22));
                SERIEE.Border = PdfPCell.NO_BORDER;
                SERIEE.BorderWidthLeft = 0.1f;
                //SERIEE.BorderWidthBottom = 0.1f;
                //TABLA2,MODELO
                PdfPCell MODELOE = new PdfPCell();
                MODELOE = new PdfPCell(new Phrase("Modelo: "+TAG_MODELO, D22));
                MODELOE.Border = PdfPCell.NO_BORDER;
                //MODELOE.BorderWidthBottom = 0.1f;
                //TABLA2,ACTIVO FIJO
                PdfPCell ACTIVOE = new PdfPCell();
                ACTIVOE = new PdfPCell(new Phrase("Activo fijo:"+TAG_ACTIVO, D22));
                ACTIVOE.Border = PdfPCell.NO_BORDER;
                //ACTIVOE.BorderWidthBottom = 0.1f;
                ACTIVOE.BorderWidthRight = 0.1f;
                iTextSharp.text.Font D23 = new iTextSharp.text.Font(Titulo, 8);
                PdfPCell D1 = new PdfPCell();
                D1 = new PdfPCell(new Phrase(" ", D23));
                D1.Colspan = 3;
                D1.Border = PdfPCell.NO_BORDER;
                D1.BorderWidthLeft = 0.1f;
                D1.BorderWidthRight = 0.1f;
                D1.BorderWidthBottom = 0.1f;
                //CARGAR DATOS
                TABLA2.AddCell(DATOSE);
                TABLA2.AddCell(NombreE);
                TABLA2.AddCell(MarcaE);
                TABLA2.AddCell(SERIEE);
                TABLA2.AddCell(MODELOE);
                TABLA2.AddCell(ACTIVOE);
                TABLA2.AddCell(D1);
                pdoc.Add(TABLA2);

                //espacio
                pdoc.Add(pp4);
                //TABLA3,TIPOS DE SERVICIO
                PdfPTable TABLA3 = new PdfPTable(new float[] { 30f, 20f, 4f, 46f });
                PdfPCell TIPOS = new PdfPCell();
                TABLA3.HorizontalAlignment = 1;
                TABLA3.WidthPercentage = 90f;
                TIPOS = new PdfPCell(new Phrase("TIPOS DE SERVICIO:", D21));
                TIPOS.Rowspan = 7;
                TIPOS.Border = PdfPCell.NO_BORDER;
                TIPOS.BorderWidthLeft = 0.1f;
                TIPOS.BorderWidthBottom = 0.1f;

                //TABLA3,CORRECTIVO
                PdfPCell CORRE = new PdfPCell();
                CORRE = new PdfPCell(new Phrase("CORRECTIVO", D22));
                CORRE.Border = PdfPCell.NO_BORDER;
                //CORRE.HorizontalAlignment = Element.ALIGN_CENTER;

                //TABLA3,ESPACIO CORRECTIVO
                PdfPCell ECORRE = new PdfPCell(new Phrase(TM1));
                ECORRE.HorizontalAlignment = Element.ALIGN_CENTER;
                //TABLA3 ESPACIO CORRECTIVO BLANCO
                PdfPCell BLANCOS = new PdfPCell(new Phrase("    "));
                BLANCOS.Border = PdfPCell.NO_BORDER;
                BLANCOS.BorderWidthRight = 0.1f;
                BLANCOS.HorizontalAlignment = Element.ALIGN_CENTER;

                //TABLA3,ESPACIO PREVENTIVO
                PdfPCell PREVE = new PdfPCell();
                PREVE = new PdfPCell(new Phrase("PREVENTIVO", D22));
                PREVE.Border = PdfPCell.NO_BORDER;
                PdfPCell EPRE = new PdfPCell(new Phrase(TM2));
                EPRE.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell EGAR = new PdfPCell(new Phrase(TM3));
                EGAR.HorizontalAlignment = Element.ALIGN_CENTER;
                //TABLA3 GARANTIA
                PdfPCell GARA = new PdfPCell();
                GARA = new PdfPCell(new Phrase("GARANTIA", D22));
                GARA.Border = PdfPCell.NO_BORDER;
                GARA.HorizontalAlignment = Element.ALIGN_CENTER;    

                iTextSharp.text.Font D24 = new iTextSharp.text.Font(Titulo, 1);
                iTextSharp.text.Font D25 = new iTextSharp.text.Font(Titulo, 11);
                PdfPCell D2 = new PdfPCell();
                D2 = new PdfPCell(new Phrase(" ", D24));
                D2.Colspan = 4;
                D2.Border = PdfPCell.NO_BORDER;
                D2.BorderWidthTop = 0.1f;
                D2.BorderWidthLeft = 0.1f;
                D2.BorderWidthRight = 0.1f;

                PdfPCell D3 = new PdfPCell();
                D3 = new PdfPCell(new Phrase(" ", D24));
                D3.Colspan = 3;
                D3.Border = PdfPCell.NO_BORDER;
                D3.BorderWidthRight = 0.1f;

                PdfPCell D4 = new PdfPCell();
                D4 = new PdfPCell(new Phrase(" ", D24));
                D4.Colspan = 3;
                D4.Border = PdfPCell.NO_BORDER;
                D4.BorderWidthRight = 0.1f;
                D4.BorderWidthBottom = 0.1f;

                TABLA3.AddCell(D2);
                TABLA3.AddCell(TIPOS);
                TABLA3.AddCell(CORRE);
                TABLA3.AddCell(ECORRE);
                TABLA3.AddCell(BLANCOS);
                TABLA3.AddCell(D3);
                TABLA3.AddCell(PREVE);
                TABLA3.AddCell(EPRE);
                TABLA3.AddCell(BLANCOS);
                TABLA3.AddCell(D3);
                TABLA3.AddCell(GARA);
                TABLA3.AddCell(EGAR);
                TABLA3.AddCell(BLANCOS);
                TABLA3.AddCell(D4);
                pdoc.Add(TABLA3);

                pdoc.Add(pp4);

                PdfPTable TABLA4 = new PdfPTable(new float[] { 35f, 5f, 51f, 5f, 4f });
                TABLA4.WidthPercentage = 90f;

                PdfPCell F1 = new PdfPCell();
                F1 = new PdfPCell(new Phrase("RUTINAS DE MANTENIMIENTO", D21));
                F1.Colspan = 5;
                F1.HorizontalAlignment = Element.ALIGN_CENTER;
                F1.VerticalAlignment = Element.ALIGN_MIDDLE;
                F1.BackgroundColor = new BaseColor(228, 237, 242);

                PdfPCell W1 = new PdfPCell();
                W1 = new PdfPCell(new Phrase("  ", D24));
                W1.Border = PdfPCell.NO_BORDER;
                W1.BorderWidthLeft = 0.1f;
                W1.BorderWidthRight = 0.1f;
                W1.Colspan = 5;

                PdfPCell X1 = new PdfPCell();
                X1 = new PdfPCell(new Phrase("LIMPIEZA INTERNA", D22));
                X1.Border = PdfPCell.NO_BORDER;
                X1.BorderWidthLeft = 0.1f;

                PdfPCell Z1 = new PdfPCell();
                Z1 = new PdfPCell(new Phrase(M1, D22));
                Z1.HorizontalAlignment = Element.ALIGN_CENTER;
                Z1.VerticalAlignment = Element.ALIGN_MIDDLE;

                PdfPCell X2 = new PdfPCell();
                X2 = new PdfPCell(new Phrase("  DESPEGUE DE DATOS", D22));
                X2.Border = PdfPCell.NO_BORDER;

                PdfPCell Z2 = new PdfPCell();
                Z2 = new PdfPCell(new Phrase(M11, D22));
                Z2.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell YW = new PdfPCell();
                YW = new PdfPCell(new Phrase(" ", D22));
                YW.Border = PdfPCell.NO_BORDER;
                YW.BorderWidthRight = 0.1f;

                PdfPCell X3 = new PdfPCell();
                X3 = new PdfPCell(new Phrase("LIMPIEZA EXTERNA", D22));
                X3.Border = PdfPCell.NO_BORDER;
                X3.BorderWidthLeft = 0.1f;

                PdfPCell Z3 = new PdfPCell();
                Z3 = new PdfPCell(new Phrase(M2, D22));
                Z3.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X4 = new PdfPCell();
                X4 = new PdfPCell(new Phrase("  CABLES DE PACIENTE", D22));
                X4.Border = PdfPCell.NO_BORDER;
                X4.BorderWidthLeft = 0.1f;

                PdfPCell Z4 = new PdfPCell();
                Z4 = new PdfPCell(new Phrase(M12, D22));
                Z4.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X5 = new PdfPCell();
                X5 = new PdfPCell(new Phrase("LUBRICACION", D22));
                X5.Border = PdfPCell.NO_BORDER;
                X5.BorderWidthLeft = 0.1f;

                PdfPCell Z5 = new PdfPCell();
                Z5 = new PdfPCell(new Phrase(M3, D22));
                Z5.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X6 = new PdfPCell();
                X6 = new PdfPCell(new Phrase("  TRANSDUCTORES Y SENSORES", D22));
                X6.Border = PdfPCell.NO_BORDER;
                X6.BorderWidthLeft = 0.1f;

                PdfPCell Z6 = new PdfPCell();
                Z6 = new PdfPCell(new Phrase(M13, D22));
                Z6.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X7 = new PdfPCell();
                X7 = new PdfPCell(new Phrase("AJUSTE GENERAL", D22));
                X7.Border = PdfPCell.NO_BORDER;
                X7.BorderWidthLeft = 0.1f;

                PdfPCell Z7 = new PdfPCell();
                Z7 = new PdfPCell(new Phrase(M4, D22));
                Z7.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X8 = new PdfPCell();
                X8 = new PdfPCell(new Phrase("  CABLES Y CONECTORES", D22));
                X8.Border = PdfPCell.NO_BORDER;
                X8.BorderWidthLeft = 0.1f;

                PdfPCell Z8 = new PdfPCell();
                Z8 = new PdfPCell(new Phrase(M14, D22));
                Z8.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X9 = new PdfPCell();
                X9 = new PdfPCell(new Phrase("ENCENDIDO", D22));
                X9.Border = PdfPCell.NO_BORDER;
                X9.BorderWidthLeft = 0.1f;

                PdfPCell Z9 = new PdfPCell();
                Z9 = new PdfPCell(new Phrase(M5, D22));
                Z9.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X10 = new PdfPCell();
                X10 = new PdfPCell(new Phrase("  VERIFICACION SETUP", D22));
                X10.Border = PdfPCell.NO_BORDER;
                X10.BorderWidthLeft = 0.1f;

                PdfPCell Z10 = new PdfPCell();
                Z10 = new PdfPCell(new Phrase(M15, D22));
                Z10.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X11 = new PdfPCell();
                X11 = new PdfPCell(new Phrase("FUGAS DE CORRIENTE", D22));
                X11.Border = PdfPCell.NO_BORDER;
                X11.BorderWidthLeft = 0.1f;

                PdfPCell Z11 = new PdfPCell();
                Z11 = new PdfPCell(new Phrase(M6, D22));
                Z11.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X12 = new PdfPCell();
                X12 = new PdfPCell(new Phrase("  REALIZACION DE PRUEBAS", D22));
                X12.Border = PdfPCell.NO_BORDER;
                X12.BorderWidthLeft = 0.1f;

                PdfPCell Z12 = new PdfPCell();
                Z12 = new PdfPCell(new Phrase(M16, D22));
                Z12.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X13 = new PdfPCell();
                X13 = new PdfPCell(new Phrase("FUNCIONALES", D22));
                X13.Border = PdfPCell.NO_BORDER;
                X13.BorderWidthLeft = 0.1f;

                PdfPCell Z13 = new PdfPCell();
                Z13 = new PdfPCell(new Phrase(M7, D22));
                Z13.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X14 = new PdfPCell();
                X14 = new PdfPCell(new Phrase("  VERIFICACION DE ALARMAS", D22));
                X14.Border = PdfPCell.NO_BORDER;
                X14.BorderWidthLeft = 0.1f;

                PdfPCell Z14 = new PdfPCell();
                Z14 = new PdfPCell(new Phrase(M17, D22));
                Z14.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X15 = new PdfPCell();
                X15 = new PdfPCell(new Phrase("CALIBRACION", D22));
                X15.Border = PdfPCell.NO_BORDER;
                X15.BorderWidthLeft = 0.1f;

                PdfPCell Z15 = new PdfPCell();
                Z15 = new PdfPCell(new Phrase(M8, D22));
                Z15.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X16 = new PdfPCell();
                X16 = new PdfPCell(new Phrase("  ACCESORIOS", D22));
                X16.Border = PdfPCell.NO_BORDER;
                X16.BorderWidthLeft = 0.1f;

                PdfPCell Z16 = new PdfPCell();
                Z16 = new PdfPCell(new Phrase(M18, D22));
                Z16.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X17 = new PdfPCell();
                X17 = new PdfPCell(new Phrase("ESTADO DE BATERIA", D22));
                X17.Border = PdfPCell.NO_BORDER;
                X17.BorderWidthLeft = 0.1f;

                PdfPCell Z17 = new PdfPCell();
                Z17 = new PdfPCell(new Phrase(M9, D22));
                Z17.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X18 = new PdfPCell();
                X18 = new PdfPCell(new Phrase("  REVISION DEL SISTEMA ELECTRONICO", D25));
                X18.Border = PdfPCell.NO_BORDER;
                X18.BorderWidthLeft = 0.1f;

                PdfPCell Z18 = new PdfPCell();
                Z18 = new PdfPCell(new Phrase(M19, D22));
                Z18.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X19 = new PdfPCell();
                X19 = new PdfPCell(new Phrase("INTERNO", D22));
                X19.Border = PdfPCell.NO_BORDER;
                X19.BorderWidthLeft = 0.1f;

                PdfPCell Z19 = new PdfPCell();
                Z19 = new PdfPCell(new Phrase(M10, D22));
                Z19.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell X20 = new PdfPCell();
                X20 = new PdfPCell(new Phrase("  REPOSICION DE PARTES", D22));
                X20.Border = PdfPCell.NO_BORDER;
                X20.BorderWidthLeft = 0.1f;

                PdfPCell Z20 = new PdfPCell();
                Z20 = new PdfPCell(new Phrase(M20, D22));
                Z20.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell YW1 = new PdfPCell();
                YW1 = new PdfPCell(new Phrase(" ", D22));
                YW1.Colspan = 5;
                YW1.Border = PdfPCell.NO_BORDER;
                YW1.BorderWidthRight = 0.1f;
                YW1.BorderWidthBottom = 0.1f;
                YW1.BorderWidthLeft = 0.1f;

                //PRIMERA FILA
                TABLA4.AddCell(F1);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F2,C1-C2
                TABLA4.AddCell(X1);
                TABLA4.AddCell(Z1);
                //F2,C3-4
                TABLA4.AddCell(X2);
                TABLA4.AddCell(Z2);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F3,C1-C2
                TABLA4.AddCell(X3);
                TABLA4.AddCell(Z3);
                //F3,C3-C4
                TABLA4.AddCell(X4);
                TABLA4.AddCell(Z4);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F4,C1-C2
                TABLA4.AddCell(X5);
                TABLA4.AddCell(Z5);
                //F4,C3-C4
                TABLA4.AddCell(X6);
                TABLA4.AddCell(Z6);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F5,C1-C2
                TABLA4.AddCell(X7);
                TABLA4.AddCell(Z7);
                //F5,C3-C4
                TABLA4.AddCell(X8);
                TABLA4.AddCell(Z8);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F6,C1-C2
                TABLA4.AddCell(X9);
                TABLA4.AddCell(Z9);
                //F6,C3-C4
                TABLA4.AddCell(X10);
                TABLA4.AddCell(Z10);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F7,C1-C2
                TABLA4.AddCell(X11);
                TABLA4.AddCell(Z11);
                //F7,C3-C4
                TABLA4.AddCell(X12);
                TABLA4.AddCell(Z12);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F8,C1-C2
                TABLA4.AddCell(X13);
                TABLA4.AddCell(Z13);
                //F8,C3-C4
                TABLA4.AddCell(X14);
                TABLA4.AddCell(Z14);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F9,C1-C2
                TABLA4.AddCell(X15);
                TABLA4.AddCell(Z15);
                //F9,C3-C4
                TABLA4.AddCell(X16);
                TABLA4.AddCell(Z16);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F10,C1-C2
                TABLA4.AddCell(X17);
                TABLA4.AddCell(Z17);
                //F10,C3-C4
                TABLA4.AddCell(X18);
                TABLA4.AddCell(Z18);
                TABLA4.AddCell(YW);
                //ESPACIO
                TABLA4.AddCell(W1);
                //F11,C1-C2
                TABLA4.AddCell(X19);
                TABLA4.AddCell(Z19);
                //F11,C3-C4
                TABLA4.AddCell(X20);
                TABLA4.AddCell(Z20);
                TABLA4.AddCell(YW);
                TABLA4.AddCell(YW1);

                pdoc.Add(TABLA4);

                pdoc.Add(pp4);
 

                PdfPCell BLANCOS1 = new PdfPCell();
                BLANCOS1 = new PdfPCell(new Phrase(T1, D25));
                PdfPCell BLANCOS2 = new PdfPCell();
                BLANCOS2 = new PdfPCell(new Phrase(T2, D25));
                PdfPCell BLANCOS3 = new PdfPCell();
                BLANCOS3 = new PdfPCell(new Phrase(T3, D25));
                PdfPCell BLANCOS4 = new PdfPCell();
                BLANCOS4 = new PdfPCell(new Phrase(T4, D25));
                PdfPCell BLANCOS5 = new PdfPCell();
                BLANCOS5 = new PdfPCell(new Phrase(T5, D25));
                PdfPTable TABLA5 = new PdfPTable(1);

                TABLA5.WidthPercentage = 90f;
                PdfPCell DM = new PdfPCell();
                DM = new PdfPCell(new Phrase("DESCRIPCION DEL MANTENIMIENTO Y REPUESTOS INSTALADOS", D22));
                DM.HorizontalAlignment = Element.ALIGN_CENTER;
                DM.VerticalAlignment = Element.ALIGN_MIDDLE;
                DM.BackgroundColor = new BaseColor(228, 237, 242);
                TABLA5.AddCell(DM);
                TABLA5.AddCell(BLANCOS1);
                TABLA5.AddCell(BLANCOS2);
                TABLA5.AddCell(BLANCOS3);
                TABLA5.AddCell(BLANCOS4);
                TABLA5.AddCell(BLANCOS5);
                pdoc.Add(TABLA5);

                //TABLA 6
                PdfPTable TABLA6 = new PdfPTable(new float[] { 44f, 2f, 44f });
                TABLA6.WidthPercentage = 90f;
                PdfPCell E1 = new PdfPCell();
                E1 = new PdfPCell(new Phrase("Reporte Elaborado por:", D22));
                E1.Border = PdfPCell.NO_BORDER;
                PdfPCell E11 = new PdfPCell();
                E11 = new PdfPCell(new Phrase(" ", D22));
                E11.Border = PdfPCell.NO_BORDER;
                PdfPCell E2 = new PdfPCell();
                E2 = new PdfPCell(new Phrase("Vo. Bo. Responsable de Área:", D22));
                E2.Border = PdfPCell.NO_BORDER;
                PdfPCell E3 = new PdfPCell();
                E3 = new PdfPCell(new Phrase("      ", D22));
                E3.Border = PdfPCell.NO_BORDER;
                E3.FixedHeight = 10f;
                PdfPCell E4 = new PdfPCell();
                iTextSharp.text.Image myImage2 = iTextSharp.text.Image.GetInstance(@PA + @"\F23.png");
                PdfPCell E10 = new PdfPCell(myImage2);
                E10.PaddingBottom = 2;
                E10.PaddingTop = 2;
                E10.PaddingLeft = 2;
                E4 = new PdfPCell(new Phrase("", D22));
                E10.Border = PdfPCell.NO_BORDER;
                E10.BorderWidthBottom = 0.1f;
                E10.FixedHeight = 80f;

                PdfPCell E5 = new PdfPCell();
                E5 = new PdfPCell(new Phrase("Ing. Jorge Leonardo Fuentes Fuentes", D22));
                E5.Border = PdfPCell.NO_BORDER;
                PdfPCell E6 = new PdfPCell();
                
                E6 = new PdfPCell(new Phrase("Fecha: "+DiaE+"/"+MesE+"/"+AñoE, D22));
                E6.Border = PdfPCell.NO_BORDER;
                PdfPCell E7 = new PdfPCell();
                E7 = new PdfPCell(new Phrase("Profesional Biomédico", D22));
                E7.Border = PdfPCell.NO_BORDER;

                //E4.FixedHeight = 12;
                E1.FixedHeight =25 ;
                E2.FixedHeight = 25;
                TABLA6.AddCell(E1);
                TABLA6.AddCell(E11);
                TABLA6.AddCell(E2);
                //TABLA6.AddCell(E3);
                //TABLA6.AddCell(E11);
                //TABLA6.AddCell(E3);
                TABLA6.AddCell(E10);
                TABLA6.AddCell(E11);
                TABLA6.AddCell(E10);
                TABLA6.AddCell(E5);
                TABLA6.AddCell(E11);
                TABLA6.AddCell(E6);
                TABLA6.AddCell(E7);
                TABLA6.AddCell(E11);
                TABLA6.AddCell(E3);
                pdoc.Add(TABLA6);
                pdoc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void COMENTARIOS_MAN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
