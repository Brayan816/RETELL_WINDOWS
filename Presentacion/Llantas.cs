using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.IO.Ports;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;
using System.Threading;
using System.Windows;

namespace Presentacion
{
    public partial class Llantas : UserControl
    {
        CONEXION conn = new CONEXION();
        List<string> fname = new List<string>();
        List<string> fmarca = new List<string>();
        List<string> fserie = new List<string>();
        List<string> fmodelo = new List<string>();
        List<string> ftipo = new List<string>();
        List<string> fid = new List<string>();

        public Llantas()
        {
            InitializeComponent();
            BUSCAR_EQUIPOS();
        }
        
        public void BUSCAR_EQUIPOS()
        {
            try
            {
                List<List<string>> a2=new List<List<string>>();
                bool L;
                int CONTADOR=0;
                (a2, CONTADOR, L) = conn.EQUIPOS();

                if (L)
                {
                    for (int i = 0; i <CONTADOR; i++)
                    {
                        ListViewItem lista1 = new ListViewItem(a2[i][0]);
                        lista1.SubItems.Add(a2[i][1]);
                        lista1.SubItems.Add(a2[i][2]);
                        lista1.SubItems.Add(a2[i][3]);
                        lista1.SubItems.Add(a2[i][4]);
                        lista1.SubItems.Add(a2[i][5]);
                        lista1.SubItems.Add(a2[i][6]);
                        lista1.SubItems.Add(a2[i][7]);
                        lista1.SubItems.Add(a2[i][8]);
                        listView1.Items.Add(lista1);

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void EQUIPOS_BUSCAR_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                if(!item.ToString().ToLower().Contains(B_BUSQUEDA.Text.ToLower()))
                {
                    listView1.Items.Remove(item);
                }
            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem Valores = listView1.SelectedItems[0];
                string L1 = Valores.SubItems[0].Text ;
                DATOS_2 DMenu = new DATOS_2();
                DMenu.M1 = L1;
                DMenu.Visible = true;
                DMenu.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Seleccione un equipo de la lista");
            }
            

        }

        private void EQUIPOS_PA_Load(object sender, EventArgs e)
        {

        }

        private void B_BUSQUEDA_TextChanged(object sender, EventArgs e)
        {
            if(B_BUSQUEDA.Text=="")
            {
                BUSCAR_EQUIPOS();
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (!item.ToString().ToLower().Contains(B_BUSQUEDA.Text.ToLower()))
                    {
                        listView1.Items.Remove(item);
                    }
                }
            }
        }
        void reftable()
        {
            listView1.Clear();
            for(int i=0; i<fname.Count;i++)
            {
                string[] row = { fname[i], fmarca[i], fserie[i], fmodelo[i], ftipo[i], fid[i] };
                var litems = new ListViewItem(row);  
                listView1.Items.Add(litems);
            }
        }

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem Valores = listView1.SelectedItems[0];
                string L1 = Valores.SubItems[0].Text;
                DATOS_2 DMenu = new DATOS_2();
                DMenu.M1 = L1;
                DMenu.Visible = true;
                DMenu.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Seleccione un equipo de la lista");
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
