using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Security.Policy;

namespace Cw04._10._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string myMailAddress;
        public static string myPassword;
        public List<string> filePaths = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            addFileBtn.IsEnabled = false;
            sendBtn.IsEnabled = false;
            mailTb.IsEnabled = false;
            subjectTb.IsEnabled = false;
        }

        private void addFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            fileLb.Items.Add(fd.FileName);
            filePaths.Add(fd.FileName);
        }


        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            MailMessage mail = new MailMessage(myMailAddress, mailTb.Text)
            {
                Subject = subjectTb.Text,
                Body = $"\n<h1>My Mail Message from C#</h1> {messegesTb.Text}<p>",
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            // add attachments
            if (fileLb.Items.Count != 0)
            {
                foreach(var item in filePaths)
                {
                    mail.Attachments.Add(new Attachment(item));
                }    
            }
            

            // send mail message
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myMailAddress, myPassword),
                EnableSsl = true
            };

            client.Send(mail);
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            myMailAddress = loginWindow.emailTb.Text;
            myPassword = loginWindow.passwordTb.Text;
            if (myMailAddress != "" && myPassword != "")
            {
                addFileBtn.IsEnabled = true;
                sendBtn.IsEnabled = true;
                mailTb.IsEnabled = true;
                subjectTb.IsEnabled = true;
            }
        }
    }
}
