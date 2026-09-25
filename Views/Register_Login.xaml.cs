using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GuildManager
{
    /// <summary>
    /// Logique d'interaction pour Register_Login.xaml
    /// </summary>
    public partial class Register_Login : Window
    {
        public Register_Login()
        {
            InitializeComponent();
        }
        private void BacktoMenuFromLogWindowBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            // Code to sending to database
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Code to need to check if the user is in the database and if the password is correct
        }
    }
}
