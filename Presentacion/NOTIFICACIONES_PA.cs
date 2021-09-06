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
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;

namespace Presentacion
{
    public partial class NOTIFICACIONES_PA : UserControl
    {
        public NOTIFICACIONES_PA()
        {
            InitializeComponent();
            //BUSCAR_EQUIPOS();
        }

        private void NOTIFICACIONES_PA_Load(object sender, EventArgs e)
        {

        }
        public void BUSCAR_EQUIPOS()
        {
            try
            {
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=EQUIPOS";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string QUERY = @"SELECT COUNT(*) FROM DATOS";
                databaseConnection.Open();
                var cmd = new MySqlCommand(QUERY, databaseConnection);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                string cuenta = count.ToString();
                //B_BUSQUEDA.Text = cuenta;
                MySqlCommand cma = new MySqlCommand("SELECT* FROM DATOS", databaseConnection);
                MySqlDataReader reader = cma.ExecuteReader();
                DateTime Ahora = DateTime.Now;
                DateTime PROX;
                while (reader.Read())
                {
                    string f1, f2, f3, f4;
                    f1 = reader.GetString(8);
                    f2 = reader.GetString(9);
                    f3 = reader.GetString(10);
                    PROX = new DateTime(Convert.ToInt32(f3),Convert.ToInt32(f2),Convert.ToInt32(f1));
                    if (Convert.ToInt32(f1) < 10)
                    {
                        f1 = "0" + f1;
                    }
                    if (Convert.ToInt32(f2) < 10)
                    {
                        f2 = "0" + f2;
                    }
                    f4 = f1 + "/" + f2 + "/" + f3;
                    ListViewItem lista1= new ListViewItem(f4);
                    lista1.SubItems.Add(reader.GetString(2));
                    lista1.SubItems.Add(reader.GetString(3));
                    lista1.SubItems.Add(reader.GetString(5));
                    lista1.SubItems.Add(reader.GetString(4));
                    //lista1.SubItems.Add(reader.GetString(7));
                    lista1.SubItems.Add(reader.GetString(11));
                    lista1.SubItems.Add(reader.GetString(13));
                    lista1.SubItems.Add(reader.GetString(0));
                    lista1.SubItems.Add(reader.GetString(1));
                    int rsult = DateTime.Compare(Ahora, PROX);
                    double DRA = (PROX-Ahora).TotalDays;
                    if(DRA<14 && DRA>7)
                    {
                        lista1.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if(DRA<7 && DRA>0)
                    {
                        lista1.BackColor = System.Drawing.Color.Orange;
                    }
                    else if(DRA<0)
                    {
                        lista1.BackColor = System.Drawing.Color.Red;
                    }    
                    listView1.Items.Add(lista1);
                    

                }
                databaseConnection.Close();
                client.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem Valores = listView1.SelectedItems[0];
                string L1 = Valores.SubItems[8].Text;
                DATOS_2 DMenu = new DATOS_2();
                DMenu.M1 = L1;
                DMenu.Visible = true;
                DMenu.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un equipo de la lista");
            }
        }
    }
}
