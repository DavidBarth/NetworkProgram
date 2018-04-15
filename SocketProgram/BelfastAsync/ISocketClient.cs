using System.Threading.Tasks;

namespace BelfastSocketAsync
{
    public interface ISocketClient
    {
        Task SendDataToServer(string userInput);
        Task ConnectToServer();
        bool SetServerIPAddress(string ipAddress);
        bool SetPortNumber(string portNumber);
    }
}