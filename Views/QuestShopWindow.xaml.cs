using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GuildManager.Controls;

namespace GuildManager
{
    /// <summary>
    /// Logique d'interaction pour QuestShopWindow.xaml
    /// </summary>
    public partial class QuestShopWindow : Window
    {
        private MainWindow _mainWindow;

        public QuestShopWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            MettreAJourInterface();
            VerifierQuetesAchetees();
        }

        /// <summary>
        /// Rafraîchit l'affichage de l'or du joueur
        /// </summary>
        private void MettreAJourInterface()
        {
            // Utilisation du Singleton Joueur.Instance pour la cohérence globale
            TxtOrDisponible.Text = $"{Joueur.Instance.Gold} Or";
            _mainWindow.NombreGoldFenetreMain.Text = Joueur.Instance.Gold.ToString();
        }

        /// <summary>
        /// Bloque les boutons des quêtes déjà déverrouillées au chargement depuis le SaveManager
        /// </summary>
        private void VerifierQuetesAchetees()
        {
            if (SaveManager.IsChapitre5Unlocked)
            {
                MarquerCommeAchete(BtnAchatCircle);
            }

            if (SaveManager.IsChapitre6Unlocked)
            {
                MarquerCommeAchete(BtnAchatDragon);
            }

            if (SaveManager.IsChapitre7Unlocked)
            {
                MarquerCommeAchete(BtnAchatFadriass);
            }
        }

        private void MarquerCommeAchete(Button bouton)
        {
            bouton.IsEnabled = false;
            bouton.Content = "Acheté";
            bouton.Background = new SolidColorBrush(Colors.Gray);
        }

        private void AcheterCircle_Click(object sender, RoutedEventArgs e)
        {
            int prix = 1000;

            if (Joueur.Instance.Gold >= prix)
            {
                Joueur.Instance.Gold -= prix;

                // Déverrouillage dans le SaveManager et mise à jour de la MainWindow
                SaveManager.IsChapitre5Unlocked = true;
                _mainWindow.UnlockChapitre5();

                // Sauvegarde immédiate dans le JSON
                SaveManager.SaveData();

                MarquerCommeAchete(BtnAchatCircle);
                MettreAJourInterface();

                MessageBox.Show("Contrat 'Quest Circle' acheté avec succès !", "Achat Réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Vous n'avez pas assez d'or pour acheter le contrat 'Quest Circle'.\nPrix : {prix} Or", "Fonds Insuffisants", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AcheterDragon_Click(object sender, RoutedEventArgs e)
        {
            int prix = 2500;

            if (Joueur.Instance.Gold >= prix)
            {
                Joueur.Instance.Gold -= prix;

                // Déverrouillage dans le SaveManager et mise à jour de la MainWindow
                SaveManager.IsChapitre6Unlocked = true;
                _mainWindow.UnlockChapitre6();

                // Sauvegarde immédiate dans le JSON
                SaveManager.SaveData();

                MarquerCommeAchete(BtnAchatDragon);
                MettreAJourInterface();

                MessageBox.Show("Contrat 'Quest Dragon' acheté avec succès !", "Achat Réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Vous n'avez pas assez d'or pour acheter le contrat 'Quest Dragon'.\nPrix : {prix} Or", "Fonds Insuffisants", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AcheterFadriass_Click(object sender, RoutedEventArgs e)
        {
            int prix = 5000;

            if (Joueur.Instance.Gold >= prix)
            {
                Joueur.Instance.Gold -= prix;

                // Déverrouillage dans le SaveManager et mise à jour de la MainWindow
                SaveManager.IsChapitre7Unlocked = true;
                _mainWindow.UnlockChapitre7();

                // Sauvegarde immédiate dans le JSON
                SaveManager.SaveData();

                MarquerCommeAchete(BtnAchatFadriass);
                MettreAJourInterface();

                MessageBox.Show("Contrat 'Quest Fadriass' acheté avec succès !", "Achat Réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Vous n'avez pas assez d'or pour acheter le contrat 'Quest Fadriass'.\nPrix : {prix} Or", "Fonds Insuffisants", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}