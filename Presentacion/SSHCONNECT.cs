using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;

namespace Presentacion
{
    class SSHCONNECT
    {
        public ForwardedPort port;
        public SshClient client;

        public SSHCONNECT()
        {
            port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
            client = new SshClient("192.168.1.200", "pi", "RETELL");
            //client.AddForwardedPort(port);
        }

    }
}
