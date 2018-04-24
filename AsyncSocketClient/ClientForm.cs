using BelfastSocketAsync;
using System;
using System.Net;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    public partial class ClientForm : Form
    {
        private const string staticPortNumber = "23000";

        private ISocketClient socketClient;
        public ClientForm()
        {
            InitializeComponent();
            InitializeClient();
        }

        private void InitializeClient()
        {
            socketClient = new BelfastSocketClient();

            string ipAddress = GetLocalIPAddress();

            if (!socketClient.SetServerIPAddress(ipAddress) || !socketClient.SetPortNumber(staticPortNumber))
            {
                Console.WriteLine(string.Format("Wrong IP Address or port number supplied - {0} - {1} Press key to exit",
                    ipAddress, staticPortNumber));
                Console.ReadKey();
                return;
            }
            socketClient.ConnectToServer();
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No N/W adapters with an IPv4 address in the system!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = messageToSendTextBox.Text;
            socketClient.SendDataToServer(message);
        }
    }
}
