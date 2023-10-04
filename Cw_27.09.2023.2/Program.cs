using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Cw_27._09._2023._2
{
    internal class Program
    {
        static int port = 8080;
        static string IP = "127.0.0.1";
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), port);
            TcpClient client = new TcpClient();
            client.Connect(ipPoint);
            string VIN = ".";
            try
            {
                do
                {
                    Console.Write("Enter VIN to find a car: ");
                    VIN = Console.ReadLine();
                    NetworkStream ns = client.GetStream();
                    StreamWriter sw= new StreamWriter(ns);
                    sw.WriteLine(VIN);
                    sw.Flush();

                    StreamReader sr = new StreamReader(ns); 
                    string response = sr.ReadLine();
                    Console.WriteLine(response);
                } while (VIN != " ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}