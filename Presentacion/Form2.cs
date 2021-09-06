using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class Form2 : Form
    {
        public string MyProperty { get; set; }
        public string R12;
        private bool draggin = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Form2()
        {
            InitializeComponent();
            ver();
            iconButton4.Visible = false;
            label1.Text = R12;
            agregaR_PA1.Hide();
            equipoS_PA1.Hide();
            mantenimientO_PA1.Hide();
            notificacioneS_PA1.Hide();
            iniciaL_PA1.Show();
            iniciaL_PA1.BringToFront();
            label1.Text = "Usuario:";
            label2.Text = Form1.ALFA2;

        }
        public void ver()
        {
           if(Form1.ALFA=="A")
            {
                iconButton1.Visible = false;
                iconButton3.Visible = false;
                iconButton4.Visible = false;
            }
        }
  
  


        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PRIMAXI.Visible = false;
            PRIRESTAURAR.Visible = true;

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            PRIMAXI.Visible = true;
            PRIRESTAURAR.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            agregaR_PA1.Hide();
            iniciaL_PA1.Hide();
            notificacioneS_PA1.Hide();
            mantenimientO_PA1.Hide();
            equipoS_PA1.Show();
            equipoS_PA1.BringToFront();   
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            equipoS_PA1.Hide();
            iniciaL_PA1.Hide();
            notificacioneS_PA1.Hide();
            mantenimientO_PA1.Hide();
            agregaR_PA1.Show();
            agregaR_PA1.BringToFront();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            equipoS_PA1.Hide();
            iniciaL_PA1.Hide();
            agregaR_PA1.Hide();
            mantenimientO_PA1.Hide();
            notificacioneS_PA1.Show();
            notificacioneS_PA1.BringToFront();


        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            equipoS_PA1.Hide();
            agregaR_PA1.Hide();
            iniciaL_PA1.Hide();
            notificacioneS_PA1.Hide();
            mantenimientO_PA1.Show();
            mantenimientO_PA1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            equipoS_PA1.Hide();
            agregaR_PA1.Hide();
            notificacioneS_PA1.Hide();
            mantenimientO_PA1.Hide();
            iniciaL_PA1.Show();
            iniciaL_PA1.BringToFront();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            draggin = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggin)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            draggin = false;
        }

        private void iconButton5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
