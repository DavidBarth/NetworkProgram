using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BelfastSocketAsync
{
    public class BelfastSocketClient
    {
        IPAddress myServerIPAddress;
        int serverPort;
        TcpClient myClient;

        public IPAddress MyServerIPAddress
        {
            get
            {
                return myServerIPAddress;
            }
        }

        public bool SetServerIPAddress(string ipAddress)
        {
            IPAddress ip = null;
            if(!IPAddress.TryParse(ipAddress, out ip))
            {
                Console.WriteLine("Invalid server IP supplied.");
                return false;
            }
            myServerIPAddress = ip;
            return true;
        }

        public int ServerPort
        {
            get
            {
                return serverPort;
            }
        }

        public bool SetPortNumber(string portNumber)
        {
            int portNr = 0;
            if (!int.TryParse(portNumber, out portNr))
            {
                Console.WriteLine("Invalid port number supplied.");
                return false;
            }
            if(portNr <= 0 || portNr > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535");
            }
            serverPort = portNr;
            return true;
        }

        public TcpClient MyClient
        {
            get
            {
                return myClient;
            }
        }

        public BelfastSocketClient()
        {
            myClient = null;
            serverPort = -1;
            myServerIPAddress = null;
        }

        public async Task ConnectToServer()
        {
            if(myClient == null)
            {
                myClient = new TcpClient();

                try
                {
                    await myClient.ConnectAsync(MyServerIPAddress, serverPort);
                    Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}", 
                        MyServerIPAddress, ServerPort));

                    ReadDataAsync(myClient);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private async void ReadDataAsync(TcpClient myClient)
        {
            try
            {
                StreamReader streamReader = new StreamReader(myClient.GetStream());
                char[] buffer = new char[64];
                int readByteCount = 0;
                while (true)
                {
                     readByteCount = await streamReader.ReadAsync(buffer, 0, buffer.Length);

                    if(readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server");
                        myClient.Close();
                        break;
                    }

                    Console.WriteLine(string.Format("Bytes sent: {0} , String: {1} ", readByteCount.ToString(), new string(buffer)));
                }
                Array.Clear(buffer, 0, buffer.Length);
            }  
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
