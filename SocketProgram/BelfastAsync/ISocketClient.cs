using Common;
using System.Threading.Tasks;

namespace BelfastSocketAsync
{
    public interface ISocketClient
    {
        Task SendDataToServer(User user);
        Task ConnectToServer();
        bool SetServerIPAddress(string ipAddress);
        bool SetPortNumber(string portNumber);
        void CloseAndDisconnect();
    }
}