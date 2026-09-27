using GuildManager.Controls;
using System.Linq;
using System.Windows;

namespace GuildManager
{
    /// <summary>
    /// Logique d'interaction pour AddCharacters.xaml (Taverne de Recrutement)
    /// </summary>
    public partial class AddCharacters : Window
    {
        private MainWindow? _mainWindow;

        public AddCharacters(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            InitTavern();
        }

        public AddCharacters()
        {
            InitializeComponent();
            _mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            InitTavern();
        }

        /// <summary>
        /// Initialise la taverne en générant les 9 aventuriers si la liste est vide
        /// </summary>
        private void InitTavern()
        {
            // Ne génère de nouveaux aventuriers QUE SI la liste de la taverne est vide
            if (AdventurerManager.AvailableShopAdventurers.Count == 0)
            {
                AdventurerManager.GenerateShopAdventurers();
                SaveManager.SaveData(); // Sauvegarde l'état initial
            }

            UpdateGoldDisplay();
            RefreshShopList();
        }

        /// <summary>
        /// Met à jour l'affichage de l'or local (CopyTotalGold)
        /// </summary>
        private void UpdateGoldDisplay()
        {
            if (_mainWindow != null && _mainWindow.myPlayer != null)
            {
                CopyTotalGold.Text = _mainWindow.myPlayer.Gold.ToString();
            }
        }

        private void RefreshShopList()
        {
            ShopAdventurersListView.ItemsSource = null;
            ShopAdventurersListView.ItemsSource = AdventurerManager.AvailableShopAdventurers;
        }

        private void BuyAdventurer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is Adventurer selectedAdventurer)
            {
                // 1. Vérification de sécurité de MainWindow
                if (_mainWindow?.myPlayer == null) return;

                // 2. Vérification de l'or
                if (_mainWindow.myPlayer.Gold >= selectedAdventurer.Price)
                {
                    // Déduction de l'or
                    _mainWindow.myPlayer.Gold -= selectedAdventurer.Price;

                    // Transfert de la taverne vers la guilde
                    AdventurerManager.MyAdventurersList.Add(selectedAdventurer);
                    AdventurerManager.AvailableShopAdventurers.Remove(selectedAdventurer);

                    // Sauvegarde globale (Données du joueur + Guilde + Taverne)
                    SaveManager.SaveData();

                    // Synchronisation de l'affichage
                    UpdateGoldDisplay();
                    if (_mainWindow.NombreGoldFenetreMain != null)
                    {
                        _mainWindow.NombreGoldFenetreMain.Text = _mainWindow.myPlayer.Gold.ToString();
                    }

                    // Rafraîchissement du DataGrid/ListView
                    RefreshShopList();

                    MessageBox.Show($"{selectedAdventurer.Name} le {selectedAdventurer.Classe} a rejoint votre guilde !",
                                    "Recrutement réussi", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Vous n'avez pas assez d'or pour recruter cet aventurier !\nPrix : {selectedAdventurer.Price} Or.",
                                    "Fonds insuffisants", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BackToAdventurerManageFromAddCharacterBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager? am = Application.Current.Windows.OfType<AdventurerManager>().FirstOrDefault();

            if (am == null)
            {
                am = new AdventurerManager();
            }
            else
            {
                am.UpdatedTotalGold();
            }

            am.Show();
            this.Close();
        }
    }
}