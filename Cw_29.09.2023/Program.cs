using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Cw_29._09._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int port = 3737;
            const string JOIN_CMD = "<join>";
            const string LEAVE_CMD = "<leave>";

            UdpClient server = new(port);
            // HashSet<> can not contains duplicates
            HashSet<IPEndPoint> members = new();

            while (true)
            {
                IPEndPoint clientIp = null;
                byte[] data = server.Receive(ref clientIp);

                string message = Encoding.UTF8.GetString(data);

                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {message} from {clientIp}");

                switch (message)
                {
                    case JOIN_CMD:
                        members.Add(clientIp);
                        break;
                    case LEAVE_CMD:
                        members.Remove(clientIp);
                        break;
                    default:
                        foreach (var m in members)
                            server.Send(data, m);
                        break;
                }
            }
        }
    }
}