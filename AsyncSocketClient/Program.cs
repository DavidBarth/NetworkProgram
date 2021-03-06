﻿using BelfastSocketAsync;
using System;

namespace AsyncSocketClient
{
    class Program
    {
        private const string exitString = "<EXIT>";

        static void Main(string[] args)
        {
            ISocketClient client = new BelfastSocketClient();
            Console.WriteLine("Please type in a valid IP address and press enter!");
            string ipAddress = Console.ReadLine();
            Console.WriteLine("Please type in a valid Port number 0 - 65535");
            string portNumber = Console.ReadLine();


            if (!client.SetServerIPAddress(ipAddress) || !client.SetPortNumber(portNumber))
            {
                Console.WriteLine(string.Format("Wrong IP Address or port number supplied - {0} - {1} Press key to exit",
                    ipAddress, portNumber));
                Console.ReadKey();
                return;
            }
            client.ConnectToServer();

            string userInput = null;
            do
            {
                userInput = Console.ReadLine();
                if (userInput.Trim() != exitString)
                {
                    client.SendDataToServer(userInput);
                }
            } while (userInput != exitString);
        }
    }
}
