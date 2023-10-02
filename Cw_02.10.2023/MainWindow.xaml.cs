using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Cw_02._10._2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WebClient client = new();
        public MainWindow()
        {
            InitializeComponent();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
        }

        private void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (client.IsBusy)
            {
                MessageBox.Show("Try again later!");
                return;
            }
            string width = widthTb.Text;
            string height = heightTb.Text;
            string category = typeTb.Text;
            string url = $"https://source.unsplash.com/random/{height}x{width}/?{category}&1";
            DownloadFileAsync(url);
        }
        private async Task DownloadFileAsync(string url)
        {
            string destionation = pathToSaveTb.Text;
            string name = Path.GetFileName(url);
            string dest = Path.Combine(destionation, name);
            await client.DownloadFileTaskAsync(url, dest);
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
