using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Cw06._10._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string username = "ksenzhakmax@gmail.com";
        const string password = "grngoyjnilidjwao";
        private ImapClient client = new();
        public MainWindow()
        {
            InitializeComponent();
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

            client.Authenticate(username, password);

            foreach (var fl in client.GetFolders(client.PersonalNamespaces[0]))
            {
                folderList.Items.Add(fl.Name);
            }
            if(folderList.SelectedIndex < 0)
            {
                foreach(var fl in client.GetFolder(client.PersonalNamespaces[folderList.SelectedIndex]))
                {
                     messageList.Items.Add(fl.TextBody);
                }
            }

        }

        private void addFileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
