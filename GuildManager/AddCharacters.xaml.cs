using GuildManagerProjet;
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
    /// Logique d'interaction pour AddCharacters.xaml
    /// </summary>
    public partial class AddCharacters : Window
    {
        public AddCharacters()
        {
            InitializeComponent();
        }
        private void BackToMenuFromCharacterWindowBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Show();
            this.Hide();
        }

        private void NewAdventurerBtn(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mys)
            {
                mys.AventuriersClassiques.Add(new Adventurer(
                    Nomforaddcharacter.Text,
                    Classeforaddcharacter.Text,
                    Imagepathforaddcharacter.Text
                ));
                Nomforaddcharacter.Clear();
                Imagepathforaddcharacter.Clear();                
            }
        }
    }
}
