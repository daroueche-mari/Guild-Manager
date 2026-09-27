using GuildManager.Controls;
using System.Windows;
using System.Windows.Media;

namespace GuildManager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Joueur myPlayer => Joueur.Instance;

        // Redirection des propriétés vers la sauvegarde JSON
        public bool IsChapitre5Unlocked
        {
            get => SaveManager.IsChapitre5Unlocked;
            private set => SaveManager.IsChapitre5Unlocked = value;
        }

        public bool IsChapitre6Unlocked
        {
            get => SaveManager.IsChapitre6Unlocked;
            private set => SaveManager.IsChapitre6Unlocked = value;
        }

        public bool IsChapitre7Unlocked
        {
            get => SaveManager.IsChapitre7Unlocked;
            private set => SaveManager.IsChapitre7Unlocked = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            // Binding du joueur
            this.DataContext = Joueur.Instance;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();

            // Synchronisation de l'affichage des chapitres débloqués
            MettreAJourEtatsChapitres();

            GameOver();
        }

        /// <summary>
        /// Applique le visuel des chapitres achetés au chargement
        /// </summary>
        private void MettreAJourEtatsChapitres()
        {
            if (IsChapitre5Unlocked) UnlockChapitre5();
            if (IsChapitre6Unlocked) UnlockChapitre6();
            if (IsChapitre7Unlocked) UnlockChapitre7();
        }

        private void GiveLvlBtn(object sender, RoutedEventArgs e)
        {
            if (myPlayer.Gold < 1000)
            {
                MessageBox.Show("Vous n'avez pas assez d'or pour acheter ce bonus.", "Or insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            myPlayer.Gold -= 1000;
            myPlayer.Level += 1;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();

            SaveManager.SaveData();
        }

        private void GameOver()
        {
            if (myPlayer.Gold < 0)
            {
                MessageBox.Show("Vous avez perdu !", "Game Over", MessageBoxButton.OK, MessageBoxImage.Error);
                myPlayer.Gold = 50;
                myPlayer.Level = 1;
                myPlayer.Experience = 0;
                NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
                NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
                AdventurerManager.MyAdventurersList.Clear();

                SaveManager.SaveData();
            }
        }

        private void QuitBtn(object sender, RoutedEventArgs e)
        {
            SaveManager.SaveData();
            Application.Current.Shutdown();
        }

        private void NewGameBtn(object sender, RoutedEventArgs e)
        {
            myPlayer.Gold = 50;
            myPlayer.Level = 1;
            myPlayer.Experience = 10;
            IsChapitre5Unlocked = false;
            IsChapitre6Unlocked = false;
            IsChapitre7Unlocked = false;

            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();

            SaveManager.SaveData();
        }

        // --- BOUTONS DE LANCEMENT DE QUÊTES (CHAPITRES DE BASE 1 À 4) ---

        private void LoadQuestTreesBtn(object sender, RoutedEventArgs e)
        {
            if (myPlayer == null || myPlayer.Level < 1)
            {
                MessageBox.Show("Vous devez être niveau 1 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ChoiceCharacter choiceCharacter = new ChoiceCharacter();
            choiceCharacter.TxtNomQuete.Text = "Quest Trees || Puissance Requise : 150";
            choiceCharacter.Show();
            this.Hide();
        }

        private void LoadQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            if (myPlayer == null || myPlayer.Level < 2)
            {
                MessageBox.Show("Vous devez être niveau 2 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ChoiceCharacter choiceCharacter = new ChoiceCharacter();
            choiceCharacter.TxtNomQuete.Text = "Quest Spiders || Puissance Requise : 200";
            choiceCharacter.Show();
            this.Hide();
        }

        private void LoadQuestGoblinsBtn(object sender, RoutedEventArgs e)
        {
            if (myPlayer == null || myPlayer.Level < 3)
            {
                MessageBox.Show("Vous devez être niveau 3 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ChoiceCharacter choiceCharacter = new ChoiceCharacter();
            choiceCharacter.TxtNomQuete.Text = "Quest Goblins || Puissance Requise : 300";
            choiceCharacter.Show();
            this.Hide();
        }

        private void LoadQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            if (myPlayer == null || myPlayer.Level < 4)
            {
                MessageBox.Show("Vous devez être niveau 4 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ChoiceCharacter choiceCharacter = new ChoiceCharacter();
            choiceCharacter.TxtNomQuete.Text = "Quest Zombies || Puissance Requise : 450";
            choiceCharacter.Show();
            this.Hide();
        }

        // --- BOUTONS DE LANCEMENT DE QUÊTES (CHAPITRES DÉVERROUILLABLES 5 À 7) ---

        private void LoadQuestCircleBtn(object sender, RoutedEventArgs e)
        {
            if (!IsChapitre5Unlocked)
            {
                MessageBox.Show("Vous devez acheter ce contrat dans la boutique pour lancer cette quête !", "Contrat Verrouillé", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (myPlayer == null || myPlayer.Level < 5)
            {
                MessageBox.Show("Vous devez être niveau 5 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            AdventurerManager advman = Application.Current.Windows.OfType<AdventurerManager>().FirstOrDefault() ?? new AdventurerManager();
            QuestCircle.LaunchQuestCircle(this, advman);
            this.Hide();
        }

        private void LoadQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            if (!IsChapitre6Unlocked)
            {
                MessageBox.Show("Vous devez acheter ce contrat dans la boutique pour lancer cette quête !", "Contrat Verrouillé", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (myPlayer == null || myPlayer.Level < 6)
            {
                MessageBox.Show("Vous devez être niveau 6 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AdventurerManager advman = Application.Current.Windows.OfType<AdventurerManager>().FirstOrDefault() ?? new AdventurerManager();
            QuestDragon.LaunchQuestDragon(this, advman);
            this.Hide();
        }

        private void LoadQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            if (!IsChapitre7Unlocked)
            {
                MessageBox.Show("Vous devez acheter ce contrat dans la boutique pour lancer cette quête !", "Contrat Verrouillé", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (myPlayer == null || myPlayer.Level < 7)
            {
                MessageBox.Show("Vous devez être niveau 7 de guilde pour accéder à cette quête.", "Niveau insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AdventurerManager advman = Application.Current.Windows.OfType<AdventurerManager>().FirstOrDefault() ?? new AdventurerManager();
            QuestFadriass.LaunchQuestFadriass(this, advman);
            this.Hide();
        }

        // --- MÉTHODES DE DÉVERROUILLAGE (APPELÉES DEPUIS LE SHOP) ---

        public void UnlockChapitre5()
        {
            IsChapitre5Unlocked = true;

            ImgQuestCircle.Opacity = 1.0;
            TitleQuestCircle.Text = "Quest Circle";
            TitleQuestCircle.Foreground = Brushes.White;
            DiffQuestCircle.Text = "Diff. H";
            DiffQuestCircle.Foreground = Brushes.Orange;
            SubTitleQuestCircle.Text = "Chapitre 5 : Le Cercle Invoqué";
            DescQuestCircle.Text = "Démantelez le rituel sectaire avant l'invocation suprême.";
            DescQuestCircle.Foreground = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            RewardQuestCircle.Visibility = Visibility.Visible;
        }

        public void UnlockChapitre6()
        {
            IsChapitre6Unlocked = true;

            ImgQuestDragon.Opacity = 1.0;
            TitleQuestDragon.Text = "Quest Dragon";
            TitleQuestDragon.Foreground = Brushes.White;
            DiffQuestDragon.Text = "Diff. H+";
            DiffQuestDragon.Foreground = Brushes.OrangeRed;
            SubTitleQuestDragon.Text = "Chapitre 6 : La Cime Désolée";
            DescQuestDragon.Text = "Traquez le dragon rouge qui ravage les terres du Nord.";
            DescQuestDragon.Foreground = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            RewardQuestDragon.Visibility = Visibility.Visible;
        }

        public void UnlockChapitre7()
        {
            IsChapitre7Unlocked = true;

            ImgQuestFadriass.Opacity = 1.0;
            TitleQuestFadriass.Text = "Quest Fadriass";
            TitleQuestFadriass.Foreground = Brushes.White;
            DiffQuestFadriass.Text = "Diff. S";
            DiffQuestFadriass.Foreground = Brushes.Red;
            SubTitleQuestFadriass.Text = "Chapitre 7 : L'Ombre de Fadriass";
            DescQuestFadriass.Text = "Affrontez le seigneur démon Fadriass dans son sanctuaire.";
            DescQuestFadriass.Foreground = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            RewardQuestFadriass.Visibility = Visibility.Visible;
        }

        // --- BOUTONS NAVIGATION INTERFACES ---

        private void ShowQuestManagerBtn(object sender, RoutedEventArgs e)
        {
            QuestShopWindow shop = new QuestShopWindow(this);
            shop.ShowDialog();
        }

        private void ShowLogRegisterWindowBtn(object sender, RoutedEventArgs e)
        {
            Register_Login reglog = new Register_Login();
            reglog.Show();
            this.Hide();
        }

        private void ShowAdventurerManagerBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager adventurerManager = new AdventurerManager();
            adventurerManager.Show();
            this.Hide();
        }
    }
}