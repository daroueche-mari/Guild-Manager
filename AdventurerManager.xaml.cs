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
    /// Logique d'interaction pour AdventurerManager.xaml
    /// </summary>
    public partial class AdventurerManager : Window
    {
        public AdventurerManager()
        {
            InitializeComponent();
        }
        private void BackToMenuFromAdventurerManagerBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Show();
            this.Hide();
        }
    }
}
