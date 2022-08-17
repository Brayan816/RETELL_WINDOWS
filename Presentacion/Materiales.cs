using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Materiales : Form
    {
        private int borderRadius = 15;
        private int borderSize = 3;
        private Color borderColor = Color.FromArgb(242,161,84);
        public string M1;
        LLANTA llanta = new LLANTA();
        CONEXION N1 = new CONEXION();
        private string[] UR_CR = {"", "No Aplica", "RETELL", "CR1", "CR2", "CR3", "CR4", "CR5", "CR5+", "CR6", "CR6+", "CR7", "CR8", "CR8+", "CR9", "CR9+"};
        private string[] UR_P = { "","No Aplica", "RETELL", "P1A", "P2A", "P2AA", "P2B", "P3A", "P3AA", "P3B", "P4A", "P4B", "P4C", "P5A", "P5B", "P5C", "PXL", "PT5A", "PT5B", "PT5C", "PT6A", "PT6B", "PT6C", "PT7A", "PT7B", "PT7C", "PT8A", "PT8B", "PT8C", "PT9A", "PT9B", "PT9C" };
        private string[] UR_U = { "","No Aplica", "RETELL", "U1", "U2", "U3", "U4", "U5", "U6", "U7", "U8", "U9", "U10", "U11", "U12", "U13"};
        private string[] UR_F = { "","No Aplica", "RETELL", "F000", "F00", "F0", "F0sp", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13"};
        private string[] UR_MC = { "","No Aplica", "RETELL", "M-C2", "M-C3", "M-C4", "M-C5", "M-C6", "M-C7", "M-C8", "M-C9", "M-C10", "C001", "C000+", "C0", "CR1" };
        private string[] UR_BC = { "","No Aplica", "RETELL", "BC2", "BC3", "BC4", "BC5", "BC6", "BC7", "BC8", "BC9", "BC10", "BCXL", "BCi", "BCe"};


        public Materiales()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            comboBox1.Items.AddRange(UR_CR);
            comboBox2.Items.AddRange(UR_P);
            comboBox3.Items.AddRange(UR_U);
            comboBox4.Items.AddRange(UR_F);
            comboBox5.Items.AddRange(UR_MC);
            comboBox6.Items.AddRange(UR_BC);

        }

        private void Materiales_Load(object sender, EventArgs e)

        {
            label27.Text ="MATERIALES O.S: "+ M1;
            llanta.ORDEN_S = M1;
            ActualizarValor();
        }
        private async void ActualizarValor()
        {
            Task<string> task = new Task<string>(Set_data);
            task.Start();
            label29.Visible = true;
            timer1.Start();
            _GANANCIA.Text = "Cargandoo";
            string rr = await task;
            _VALOR.Text = "VALOR: " + llanta.P_UR1;
            _ABONO.Text = "Abono: " + llanta.P_UR2;
            _GANANCIA.Text = "Ganancia: "+llanta.P_UR3;
            timer1.Stop();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.SelectedIndex = comboBox1.FindString(llanta.M1);
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.SelectedIndex = comboBox2.FindString(llanta.M2);
            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.SelectedIndex = comboBox3.FindString(llanta.M3);
            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox4.SelectedIndex = comboBox4.FindString(llanta.M4);
            comboBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox5.SelectedIndex = comboBox5.FindString(llanta.M5);
            comboBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox6.SelectedIndex = comboBox6.FindString(llanta.M6);
            TEXT_N1.Text = llanta.N1;
            TEXT_N2.Text = llanta.N2;
            TEXT_N3.Text = llanta.N3;
            TEXT_N4.Text = llanta.N4;
            TEXT_N5.Text = llanta.N5;
            TEXT_N6.Text = llanta.N6;
            TEXT_COJIN.Text = llanta.PM1;
            TEXT_CBLANDO.Text = llanta.PM2;
            TEXT_CDURO.Text = llanta.PM3;
            TEXT_CORDONFABRE.Text = llanta.PM4;
            TEXT_CEMENTO.Text = llanta.PM5;
            TEXT_DISOLVENTE.Text = llanta.PM6;
            progressBar1.Visible = false;
            label29.Visible = false;
            CalcularValores();
        }
        private string Set_data()
        {
            llanta.Buscar_Materiales();
            llanta.Precios_2();
            return "Termino la solicitud";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CalcularValores()
        {
            float GANANCIA = 0,PV1=0,PV2=0,PV3=0,PV4=0,PV5=0,PV6=0;
            PV1 = float.Parse("123")*(float.Parse("0"));
            GANANCIA = float.Parse(llanta.VALOR)-PV1;
            _GANANCIA.Text = "GANANCIA: "+GANANCIA.ToString();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp; 
            }
        }

        private void Materiales_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }   
                }
            }
        }

        private void Materiales_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this,borderRadius,e.Graphics,borderColor,borderSize);
        }

        private void PRIMINI_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PRICERRAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
        

        private void iconButton2_Click(object sender, EventArgs e)
        {
            List<string> LV=new List<string>();
            LV.Add(M1);
            LV.Add(comboBox1.Text);
            LV.Add(comboBox2.Text);
            LV.Add(comboBox3.Text);
            LV.Add(comboBox4.Text);
            LV.Add(comboBox5.Text);
            LV.Add(comboBox6.Text);
            LV.Add(TEXT_N1.Text);
            LV.Add(TEXT_N2.Text);
            LV.Add(TEXT_N3.Text);
            LV.Add(TEXT_N4.Text);
            LV.Add(TEXT_N5.Text);
            LV.Add(TEXT_N6.Text);
            LV.Add(TEXT_COJIN.Text);
            LV.Add(TEXT_CBLANDO.Text);
            LV.Add(TEXT_CDURO.Text);
            LV.Add(TEXT_CORDONFABRE.Text);
            LV.Add(TEXT_CEMENTO.Text);
            LV.Add(TEXT_DISOLVENTE.Text);
            CONEXION MD = new CONEXION();
            if(MD.ActualizarMateriales(LV))
            {
               MessageBox.Show("Materiales actualizados extitosamente");
            }
            else
            {
                MessageBox.Show("Error al actualizar materiales");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            ProgressBar pbar = new ProgressBar();
        }
    }
}
