using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW_25._09._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            string adress = ipTb.Text;
            int port = Convert.ToInt32(portTb.Text);
            IPEndPoint sendPoint = new IPEndPoint(IPAddress.Parse(adress), port);
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress iPAddress = IPAddress.Parse(adress);
            IPEndPoint getPoint = new IPEndPoint(iPAddress, port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            List<string> Hellolist = new List<string>();
            Hellolist.Add("hello");
            Hellolist.Add("Hi");
            Hellolist.Add("Good Afternon");
            List<string> hayList = new List<string>();
            hayList.Add("I'm fine");
            hayList.Add("I'm ok");
            hayList.Add("Nothing special");
            string bye = "bye";
            Random rnd = new Random();
            try
            {
                string message = "";
                while(message != "goodbye")
                {
                    dialogList.Items.Add(message);
                    message = messageTb.Text;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.SendTo(data, sendPoint);
                    listenSocket.Bind(getPoint);
                    int bytes = 0;
                    byte[] dataa = new byte[1024];
                    bytes = listenSocket.ReceiveFrom(dataa, ref remoteEndPoint);
                    string msg = Encoding.Unicode.GetString(dataa, 0, bytes);
                    if(msg == "Hello")
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
