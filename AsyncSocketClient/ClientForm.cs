using BelfastSocketAsync;
using Common;
using System;
using System.Net;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    public partial class ClientForm : Form
    {
        private const string staticPortNumber = "23000";

        private User user;

        private ISocketClient socketClient;
        public ClientForm()
        {
            InitializeComponent();
            InitializeClient();
            user = new User();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                user.Name = userNameTextBox.Text; 
            }
        }

        private void messageToSendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            user.Message = messageToSendTextBox.Text;
            socketClient.SendDataToServer(user);
        }
    }
}
