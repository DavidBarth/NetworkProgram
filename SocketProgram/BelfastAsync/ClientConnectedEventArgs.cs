using System;

namespace BelfastSocketAsync
{
    public class ClientConnectedEventArgs : EventArgs
    {
        public string ConnectedClient { get; set; }

        public ClientConnectedEventArgs(string client)
        {
            ConnectedClient = client;
        }
    }
}