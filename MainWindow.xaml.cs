
using GuildManager.Properties;
using GuildManagerProjet;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace GuildManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Joueur myPlayer => Joueur.Instance;
        // Instance des classes
        QuestCircle questCircle = new QuestCircle();
        QuestDragon questDragon = new QuestDragon();
        QuestFadriass questFadriass = new QuestFadriass();
        QuestGoblins questGoblins = new QuestGoblins();
        QuestSpiders questSpiders = new QuestSpiders();
        QuestTrees questTrees = new QuestTrees();
        QuestZombies questZombies = new QuestZombies();
        
        public ObservableCollection<AdventurerSpecial> AventuriersSpeciaux { get; set; } = new ObservableCollection<AdventurerSpecial>();
        public ObservableCollection<Adventurer> AventuriersClassiques { get; set; } = new ObservableCollection<Adventurer>();

        public MainWindow()
        {
            InitializeComponent();
            // On associe l'interface à l'instance déjà chargée par App.xaml.cs
            this.DataContext = Joueur.Instance;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
            //NomJoueurFenetreMain.Text = Nomenvoyéàlabdd;
            QuestCircle.GoldandxpCircle(180, 200, this);
            QuestGoblins.GoldandxpGoblins(280, 300, this);
            QuestZombies.GoldandxpZombies(380, 400, this);
            QuestSpiders.GoldandxpSpiders(480, 500, this);
            QuestDragon.GoldandxpDragon(580, 600, this);
            QuestTrees.GoldandxpTrees(680, 700, this);
            QuestFadriass.GoldandxpFadriass(780, 800, this);
            ListAventuriersSpeciaux.ItemsSource = AventuriersSpeciaux;
            ListAventuriersClassiques.ItemsSource = AventuriersClassiques;
            LoadData();
        }
        private void LoadData()
        {
            // Spéciaux
            AventuriersSpeciaux.Add(new AdventurerSpecial("Fùchóu", "Berserker", "/assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png"));
            AventuriersSpeciaux.Add(new AdventurerSpecial("Hēi Jiǔ", "Maître Brasseur", "/assets/Personnages/Aventuriers-Spéciaux/Hēi Jiǔ.png"));
            AventuriersSpeciaux.Add(new AdventurerSpecial("Zhìyuān", "Archimage", "/assets/Personnages/Aventuriers-Spéciaux/Zhìyuān.png"));
            // Classiques
            AventuriersClassiques.Add(new Adventurer("Dwargo", "Voyou", "/assets/Personnages/Aventuriers/Profile_HRogue1.png"));
            AventuriersClassiques.Add(new Adventurer("Sulvar", "Tank", "/assets/Personnages/Aventuriers/Profile_HTank1.png"));
            AventuriersClassiques.Add(new Adventurer("Stark", "Chevalier", "/assets/Personnages/Aventuriers/Profile_HWarrior1.png"));
            AventuriersClassiques.Add(new Adventurer("Ualiar", "Mage", "/assets/Personnages/Aventuriers/Profile_HMage1.png"));
            AventuriersClassiques.Add(new Adventurer("Eryndel", "Prêtre", "/assets/Personnages/Aventuriers/Profile_HPriest1.png"));
            AventuriersClassiques.Add(new Adventurer("Salgar", "Archer", "/assets/Personnages/Aventuriers/Profile_HRanger1.png"));
            AventuriersClassiques.Add(new Adventurer("Thalion", "Barbare", "/assets/Personnages/Aventuriers/Profile_HBarabarian1.png"));
            
        }

        private void GiveLvlBtn(object sender, RoutedEventArgs e)
        {
           if (myPlayer.Gold < 1000)
            {
                MessageBox.Show("Vous n'avez pas assez d'or pour acheter ce bonus.");
                return;
            }
            myPlayer.Gold -= 1000;
            myPlayer.Level += 1;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();

        }

        private void QuitBtn(object sender, RoutedEventArgs e)
        {
            SaveManager.Sauvegarder();
            Application.Current.Shutdown();
        }

        private void NewGameBtn(object sender, RoutedEventArgs e)
        {
            myPlayer.Gold = 50;
            myPlayer.Level = 1;
            myPlayer.Experience = 10;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
            SaveManager.Sauvegarder();
        }
        // Bouton lancement de Quest

        private void LancerQuestCircleBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestCircle.LaunchQuestCircle(this);
            this.Hide();
        }

        private void LancerQuestGoblinsBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }

            QuestGoblins.LaunchQuestGoblins(this);
            this.Hide();
        }


        private void LancerQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            if (myPlayer.Level < 10)
            {
                MessageBox.Show("Vous devez être au moins niveau 10 pour lancer cette quête !");
                return;
            }

            QuestZombies.LaunchQuestZombies(this);
            this.Hide();
        }

        private void LancerQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            if (myPlayer.Level < 10)
            {
                MessageBox.Show("Vous devez être au moins niveau 10 pour lancer cette quête !");
                return;
            }

            QuestSpiders.LaunchQuestSpiders(this);
            this.Hide();
        }


        private void LancerQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            if (myPlayer.Level < 20)
            {
                MessageBox.Show("Vous devez être au moins niveau 20 pour lancer cette quête !");
                return;
            }
            
            QuestDragon.LaunchQuestDragon(this);
            this.Hide();
        }

        private void LancerQuestTreesBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            if (myPlayer.Level < 20)
            {
                MessageBox.Show("Vous devez être au moins niveau 20 pour lancer cette quête !");
                return;
            }

            QuestTrees.LaunchQuestTrees(this);
            this.Hide();
        }


        private void LancerQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            if (myPlayer.Level < 20)
            {
                MessageBox.Show("Vous devez être au moins niveau 20 pour lancer cette quête !");
                return;
            }

            QuestFadriass.LaunchQuestFadriass(this);
            this.Hide();
        }
        
        
        
        

        // Bouton pour Register/Login & Ajouter Aventurier
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