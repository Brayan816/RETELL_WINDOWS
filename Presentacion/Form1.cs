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

namespace Presentacion
{
    
    public partial class Form1 : Form
    {
        CONEXION con = new CONEXION();
        LOGIN LOG = new LOGIN();
        SSHCONNECT F1 = new SSHCONNECT();
        public static string ALFA = "";
        public static string ALFA2="";
        private bool draggin = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            //con.DATABASE = "usuarios";
            InitializeComponent();
            MANT_CC.Visible = false;
            VER_CONTRA.Visible = false;
            VER_CONTRA.TabStop = false;
            bla.Visible = false;
            bla.TabStop = false;
            if (Properties.Settings.Default.name != "")
            {
                inusuario.Text = Properties.Settings.Default.name;
                incontra.Text = Properties.Settings.Default.pass;
            }
        }

        
        private void inusuario_Enter(object sender, EventArgs e)
        {
            if(inusuario.Text=="CORREO")
            {
                inusuario.Text = "";
                inusuario.ForeColor = Color.LightGray;
            }
        }

        private void inusuario_Leave(object sender, EventArgs e)
        {
            if (inusuario.Text == "")
            {
                inusuario.Text = "CORREO";
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
            if (inusuario.Text =="CORREO") 
            {
                mSerror("Por favor ingrese el ususario");
            }
            else if(incontra.Text=="CONTRASEÑA")
            {
                mSerror("Por favor ingrese la contraseña ");
            }
            else 
            {
                
                LOG.username = inusuario.Text;
                LOG.userpass = incontra.Text;
               
                bool CHECK = LOG.VALIDATED();
                if (CHECK)
                {
                    Form2 mainMenu = new Form2();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    mSerror("Usuario o Contraseña Incorrecto");
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
        {
            try
            {
                con.connecDB.Open();
                linkLabel1.Text = "b";
            }
            catch
            {
                linkLabel1.Text = "error";
            }
        }
    }
}
