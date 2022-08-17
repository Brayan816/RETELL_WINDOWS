using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//SSH
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;
using System.Drawing.Drawing2D;

namespace Presentacion
{
    
    public partial class Login : Form
    {
        CONEXION con = new CONEXION();
        public static string ALFA = "";
        public static string ALFA2="";
        private bool draggin = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private int borderRadius = 15;
        private int borderSize = 3;
        private Color borderColor = Color.FromArgb(242, 161, 84);
        public Login()
        {

            //con.DATABASE = "usuarios";
            InitializeComponent();
            mSerror(Program.DBIP);
            incontra.UseSystemPasswordChar = true;
            MANT_CC.Visible = false;
            VER_CONTRA.Visible = true;
            VER_CONTRA.TabStop = false;
            bla.Visible = false;
            bla.TabStop = false;
            inusuario.Text = "Brayan.garcia";
            incontra.Text = "P12";
            if (Properties.Settings.Default.name != "")
            {
                inusuario.Text = Properties.Settings.Default.name;
                incontra.Text = Properties.Settings.Default.pass;
            }
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            //AUTO();
        }

        public void AUTO()
        {
            if (inusuario.Text == "USUARIO")
            {
                mSerror("Por favor ingrese el ususario");
            }
            else if (incontra.Text == "CONTRASEÑA")
            {
                mSerror("Por favor ingrese la contraseña ");
            }
            else
            {

                con.USER = inusuario.Text;
                con.PASS = incontra.Text;

                bool CHECK = con.CHECK();
                ALFA = con.USUARIOA;
                if (CHECK)
                {
                    INTERFAZ mainMenu = new INTERFAZ();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    mSerror("Usuario o Contraseña Incorrecto");
                }

            }
        }

        
        private void inusuario_Enter(object sender, EventArgs e)
        {
            if(inusuario.Text=="USUARIO")
            {
                inusuario.Text = "";
                inusuario.ForeColor = Color.LightGray;
            }
        }

        private void inusuario_Leave(object sender, EventArgs e)
        {
            if (inusuario.Text == "")
            {
                inusuario.Text = "USUARIO";
                inusuario.ForeColor = Color.DimGray;
            }
        }

        private void incontra_Enter(object sender, EventArgs e)
        {
            if (incontra.Text == "CONTRASEÑA")
            {
                incontra.Text = "";
                incontra.ForeColor = Color.DimGray;
                incontra.UseSystemPasswordChar = true;
                VER_CONTRA.Visible = true;
            }
        }

        private void incontra_Leave(object sender, EventArgs e)
        {
            if (incontra.Text == "")
            {
                incontra.Text = "CONTRASEÑA";
                incontra.ForeColor = Color.DimGray;
                incontra.UseSystemPasswordChar = false;
            }
        }

        private void incerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inusuario.Text =="USUARIO") 
            {
                mSerror("Por favor ingrese el ususario");
            }
            else if(incontra.Text=="CONTRASEÑA")
            {
                mSerror("Por favor ingrese la contraseña ");
            }
            else 
            {
                con.USER = inusuario.Text;
                con.PASS = incontra.Text;
                
                bool CHECK = con.CHECK();
                ALFA = con.USUARIOA;
                if (CHECK)
                {
                    Properties.Settings.Default.name=inusuario.Text;
                    Properties.Settings.Default.pass=incontra.Text;
                    Properties.Settings.Default.Save();
                    INTERFAZ mainMenu = new INTERFAZ();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    mSerror(con.Comentario_consulta);
                }
            }
        }
       

        private void mSerror(string msg)
        {
            mserror.Text = msg;
            mserror.Visible = true; 
        }

        private void VER_CONTRA_Click(object sender, EventArgs e)
        {
            incontra.UseSystemPasswordChar = false;
            bla.Visible = true;
            VER_CONTRA.Visible = false;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            incontra.UseSystemPasswordChar = true;
            bla.Visible = false;
            VER_CONTRA.Visible = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            draggin = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggin)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            draggin = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {/*
            try
            {
                con.connecDB.Open();
                linkLabel1.Text = "b";
            }
            catch
            {
                linkLabel1.Text = "error";
            }*/
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draggin = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggin)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draggin = false;
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (inusuario.Text == "USUARIO")
            {
                mSerror("Por favor ingrese el ususario");
            }
            else if (incontra.Text == "CONTRASEÑA")
            {
                mSerror("Por favor ingrese la contraseña ");
            }
            else
            {

                con.USER = inusuario.Text;
                con.PASS = incontra.Text;

                bool CHECK = con.CHECK();
                ALFA = con.USUARIOA;
                if (CHECK)
                {
                    Properties.Settings.Default.name = inusuario.Text;
                    Properties.Settings.Default.pass = incontra.Text;
                    Properties.Settings.Default.Save();
                    INTERFAZ mainMenu = new INTERFAZ();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    mSerror("Usuario o Contraseña Incorrecto");
                }

            }
        }

        private void inusuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
