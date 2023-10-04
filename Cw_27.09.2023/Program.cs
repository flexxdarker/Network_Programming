using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Cw_27._09._2023
{
    internal class Program
    {
        static int port = 8080;
        static string IP = "127.0.0.1";
        static List<Car> cars = new List<Car>()
        {
            new Car() { Id = 1, Model = "C-Class", Name = "Mercedess", VIN = "WDB2030081A861349", },
            new Car() { Id = 2, Model = "5 series", Name = "BMW", VIN = "WBAFV31090DP46576"},
            new Car() { Id = 3, Model = "Mustang", Name = "Ford", VIN = "WBAFV31090DP46576"}
        };
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), port);
            TcpListener listener = new TcpListener(ipPoint);
            listener.Start(10);
            while (true)
            {
                Console.WriteLine("Server started! Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                try
                {
                    while(client.Connected)
                    {
                        //Console.WriteLine("Got 1");
                        NetworkStream ns = client.GetStream();
                        //JsonSerializer.Serialize(ns, cars);
                        //string VIN = (string)JsonSerializer.Deserialize(ns, typeof(string));
                        StreamReader sr = new StreamReader(ns);
                        string VIN = sr.ReadLine();

                        string result = "";
                        //Console.WriteLine("Got 2");
                        foreach (var item in cars)
                        {
                            if(VIN == item.VIN)
                            {
                                result = $"{item.Name} - {item.Model} - {item.VIN}";
                                break;
                            }
                            else
                            {
                                result = "NOT FOUND!!!";
                            }
                        }
                        Console.WriteLine(result);
                        StreamWriter sw = new StreamWriter(ns);
                        sw.WriteLine(result);
                        sw.Flush();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}