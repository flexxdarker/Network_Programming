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
using System.Windows.Shapes;

namespace Cw04._10._2023
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            emailTb.Text = "tmvlad33@gmail.com";
            passwordTb.Text = "gxknljmktrlthlyx";
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
