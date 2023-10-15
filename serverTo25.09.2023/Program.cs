using CW_25._09._2023.Data;
using CW_25._09._2023.Entities;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace serverTo25._09._2023
{
    internal class Program
    {
        static string address = "127.0.0.1"; // поточний адрес
        static int port = 8080;
        
        static void Main(string[] args)
        {
            GovorunDbContext dbContext = new GovorunDbContext();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            IPEndPoint remoteEndPoint = null;
            UdpClient listener = new UdpClient(ipPoint);
            try
            {
                Console.WriteLine("Server started! Waiting for connection...");

                while (true)
                {
                    byte[] data = listener.Receive(ref remoteEndPoint);
                    string msg = Encoding.Unicode.GetString(data);
                    Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {msg} from {remoteEndPoint}");
                    string message = "";
                    Random rnd = new Random();
                    if (msg == "Hello")
                    {
                        //dbContext.Greets.Select(x => x.Id == rnd.Next(1, 3));
                        Greeting gr = dbContext.Greets.First(x=> x.Id == rnd.Next(1,3));
                        message = gr.Answer;
                        data = Encoding.Unicode.GetBytes(message);
                    }
                    else if (msg == "How are you")
                    {
                        AnswerFelling ad = dbContext.FellAnswers.First(x => x.Id == rnd.Next(1, 4));
                        message = ad.Answers;
                        data = Encoding.Unicode.GetBytes(message);
                    }
                    else if (msg == "What the weather is")
                    {
                        WeatherAnswer wa = dbContext.WeatherAnswers.First(x => x.Id == rnd.Next(1, 4));
                        message = wa.Answer;
                        data = Encoding.Unicode.GetBytes(message);
                    }
                    else if(msg == "Goodbye")
                    {
                        Farewell fw = dbContext.Farewells.First(x=>x.Id == rnd.Next(1, 3));
                        message = fw.Farewells;
                        data = Encoding.Unicode.GetBytes(message);
                    }
                    listener.Send(data, data.Length, remoteEndPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            listener.Close();
        }
    }
}