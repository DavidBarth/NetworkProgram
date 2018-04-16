using System.Net;

namespace BelfastSocketAsync
{
    public interface ISocketServer
    {
        //async will create code behing
        void StartListeningFoIncommingConnection(IPAddress ipAddress = null, int port = 23000);
        void StopServer();
        //make method async to be able to perfom async read op in the method
        void SendToAllClients(string message);
        
    }
}