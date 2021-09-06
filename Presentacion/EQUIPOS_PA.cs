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
    public partial class EQUIPOS_PA : UserControl
    {
    
        public EQUIPOS_PA()
        {
            InitializeComponent();
            //PDF_PANEL.Visible = false;
            BUSCAR_EQUIPOS();
        }
        List<string> fname = new List<string>();
        List<string> fmarca = new List<string>();
        List<string> fserie = new List<string>();
        List<string> fmodelo = new List<string>();
        List<string> ftipo = new List<string>();
        List<string> fid = new List<string>();
        public void BUSCAR_EQUIPOS()
        {
            try
            {
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("192.168.1.200", "pi", "RETELL");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=localhost;port=3306;username=ROOT2;password=RETELL;database=llantas";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string QUERY = @"SELECT COUNT(*) FROM datos";
                databaseConnection.Open();
                var cmd = new MySqlCommand(QUERY, databaseConnection);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                string cuenta = count.ToString();
                //B_BUSQUEDA.Text = cuenta;
                MySqlCommand cma = new MySqlCommand("SELECT* FROM datos", databaseConnection);
                MySqlDataReader reader = cma.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lista1 = new ListViewItem(reader.GetString(15));
                    lista1.SubItems.Add(reader.GetString(1));
                    lista1.SubItems.Add(reader.GetString(7));
                    lista1.SubItems.Add(reader.GetString(8));
                    lista1.SubItems.Add(reader.GetString(14));
                    lista1.SubItems.Add(reader.GetString(19));
                    string EW1="", Aw1 = reader.GetString(16);
                    string EW2="", Aw2 = reader.GetString(17);
                    if(Aw1.Length==6)
                    {
                        EW1 = Aw1[0].ToString()+ Aw1[1].ToString()+Aw1[2].ToString()+"."+ Aw1[3].ToString()+ Aw1[4].ToString()+ Aw1[5].ToString();
                    }
                    else if(Aw1.Length==5)
                    {
                        EW1 = Aw1[0].ToString() + Aw1[1].ToString() + "." + Aw1[2].ToString() + Aw1[3].ToString() + Aw1[4].ToString();
                    }
                    else if(Aw1.Length==4)
                    {
                        EW1 = Aw1[0].ToString() +"."+ Aw1[1].ToString()  + Aw1[2].ToString() + Aw1[3].ToString();
                    }
                    //ABONO
                    if (Aw2.Length == 6)
                    {
                        EW2 = Aw2[0].ToString() + Aw2[1].ToString() + Aw2[2].ToString() + "." + Aw2[3].ToString() + Aw2[4].ToString() + Aw2[5].ToString();
                    }
                    else if (Aw2.Length == 5)
                    {
                        EW2 = Aw2[0].ToString() + Aw2[1].ToString() + "." + Aw2[2].ToString() + Aw2[3].ToString() + Aw2[4].ToString();
                    }
                    else if (Aw2.Length == 4)
                    {
                        EW2 = Aw2[0].ToString() + "." + Aw2[1].ToString() + Aw2[2].ToString() + Aw2[3].ToString();
                    }

                    lista1.SubItems.Add(reader.GetString(18));
                    lista1.SubItems.Add(EW1);
                    lista1.SubItems.Add(EW2);
                    listView1.Items.Add(lista1);

                }
                databaseConnection.Close();
                client.Disconnect();
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
                System.Windows.MessageBox.Show(L1);
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
    }
}
