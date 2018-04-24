using BelfastSocketAsync;
using System;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        BelfastSocketServer server;
        public Form1()
        {
            InitializeComponent();
            server = new BelfastSocketServer();
            SubscribeToClientEvents();
        }

        private void SubscribeToClientEvents()
        {
            server.ClientConnected += Server_ClientConnected;
            server.MessageReceived += Server_MessageReceived;
        }

        private void Server_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            clientConnectedTextBox.AppendText(string.Format("New client connected: {0} - At: {1} "
                , e.ConnectedClient
                , DateTime.UtcNow
                , Environment.NewLine));
        }

        private void Server_MessageReceived(object sender, TextReceivedEventArgs e)
        {
            messageReceivedTextBox.AppendText(string.Format("From client: {0}, Message: {1}"
                , e.ClientWhoSentText
                , e.TextReceived
                , Environment.NewLine));
        }

        private void buttonAccceptAsync_Click(object sender, EventArgs e)
        {            
            server.StartListeningFoIncommingConnection();
        }

        private void sendAllButton_Click(object sender, EventArgs e)
        {
            server.SendToAllClients(messageTextBox.Text);
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            UnsubscribeFromClientEventsAndStopServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsubscribeFromClientEventsAndStopServer();
        }

        private void UnsubscribeFromClientEventsAndStopServer()
        {
            server.ClientConnected -= Server_ClientConnected;
            server.MessageReceived -= Server_MessageReceived;
            server.StopServer();

        }
    }
}
