using GuildManager.Controls;
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
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public string TypeQueteActuelle { get; set; } = "";
        public GameWindow()
        {
            InitializeComponent();
        }
        private void BackToQuestBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mWin = new MainWindow();
            mWin.Show();
            this.Hide();
        }
        private void ReplayCurrentQuestBtn(object sender, RoutedEventArgs e)
        {
            // 1. Récupération de l'instance de MainWindow
            MainWindow? mainWin = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            // 2. Création de la fenêtre de choix
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            // 3. Configuration du titre de la quête selon la quête actuelle
            switch (TypeQueteActuelle)
            {
                case "Trees":
                    choiceCharacter.TxtNomQuete.Text = "Quest Trees || Puissance Requise : 150";
                    break;
                case "Spiders":
                    choiceCharacter.TxtNomQuete.Text = "Quest Spiders || Puissance Requise : 200";
                    break;
                case "Goblins":
                    choiceCharacter.TxtNomQuete.Text = "Quest Goblins || Puissance Requise : 300";
                    break;
                case "Zombies":
                    choiceCharacter.TxtNomQuete.Text = "Quest Zombies || Puissance Requise : 450";
                    break;
                case "Circle":
                    choiceCharacter.TxtNomQuete.Text = "Quest Circle || Puissance Requise : 1000";
                    break;
                case "Dragon":
                    choiceCharacter.TxtNomQuete.Text = "Quest Dragon || Puissance Requise : 1500";
                    break;
                case "Fadriass":
                    choiceCharacter.TxtNomQuete.Text = "Quest Fadriass || Puissance Requise : 2000";
                    break;
            }

            // 4. Affichage du choix et fermeture de la fenêtre actuelle
            choiceCharacter.Show();
            this.Close();
        }
    }
}
