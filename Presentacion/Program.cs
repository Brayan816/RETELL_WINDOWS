
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Presentacion
{
    static class Program
    {
        public static string DBIP = "192.168.0.200";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        ///

        [STAThread]
        static void Main()
        {
            string S2 = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            string[] words = S2.Split('.');
            if (words[2] == "1")
            {
                DBIP = "192.168.1.200";
            }
            else
            {
                DBIP = "192.168.0.200";
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}