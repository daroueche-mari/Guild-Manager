
using GuildManagerProjet;
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
        // Instance des classes
        QuestCircle questCircle = new QuestCircle();
        QuestDragon questDragon = new QuestDragon();
        QuestFadriass questFadriass = new QuestFadriass();
        QuestGoblins questGoblins = new QuestGoblins();
        QuestSpiders questSpiders = new QuestSpiders();
        QuestTrees questTrees = new QuestTrees();
        QuestZombies questZombies = new QuestZombies();
        Adventurer myBarbare = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myMage = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myPretre = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myArcher = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myVoyou = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myTank = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        Adventurer myChevalier = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        AdventurerSpecial myFushou = new AdventurerSpecial("", "", 0, "", "", 0, 0, "", 0, "");
        AdventurerSpecial myHeijiu = new AdventurerSpecial("", "", 0, "", "", 0, 0, "", 0, "");
        AdventurerSpecial myZhiyuan = new AdventurerSpecial("", "", 0, "", "", 0, 0, "", 0, "");
       public Adventurer myPlayer = new Adventurer("", 0, "", "", 0, 0, "", 0, "");

        public MainWindow()
        {
            InitializeComponent();
            StatFushou();
            StatHeijiu();
            StatZhiyuan();
            StatBarbare();
            StatMage();
            StatPretre();
            StatArcher();
            StatVoyou();
            StatTank();
            StatChevalier();
            myPlayer.Gold = 50;
            myPlayer.Level = 1;
            myPlayer.Experience = 10;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
            QuestCircle.GoldandxpCircle(180, 200, this);
            QuestGoblins.GoldandxpGoblins(280, 300, this);
            QuestZombies.GoldandxpZombies(380, 400, this);
            QuestSpiders.GoldandxpSpiders(480, 500, this);
            QuestDragon.GoldandxpDragon(580, 600, this);
            QuestTrees.GoldandxpTrees(680, 700, this);
            QuestFadriass.GoldandxpFadriass(780, 800, this);
            
        }
       
        // Stat Aventurier Speciaux
        private void StatFushou()
        {
            FushouStats.ShowFushouStats(this, myFushou);
        }
        private void StatHeijiu()
        {
            HeijiuStats.ShowHeijiuStats(this, myHeijiu);
        }
        private void StatZhiyuan()
        {
            ZhiyuanStats.ShowZhiyuanStats(this, myZhiyuan);
        }

        // Stat Aventurier Basique
        private void StatBarbare()
        {
            BarbareStats.ShowBarbareStats(this, myBarbare);
        }
        private void StatMage()
        {
            MageStats.ShowMageStats(this, myMage);
        }
        private void StatPretre()
        {
            PretreStats.ShowPretreStats(this, myPretre);
        }
        private void StatArcher()
        {
            ArcherStats.ShowArcherStats(this, myArcher);
        }
        private void StatVoyou()
        {
            VoyouStats.ShowVoyouStats(this, myVoyou);
        }
        private void StatTank()
        {
            TankStats.ShowTankStats(this, myTank);
        }
        private void StatChevalier()
        {
            ChevalierStats.ShowChevalierStats(this, myChevalier);
        }

        // Bouton lancement de Quest

        private void LancerQuestCircleBtn(object sender, RoutedEventArgs e)
        {
            if(Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return; 
            }
            QuestCircle.LaunchQuestCircle(this);
            this.Hide();
        }
        private void LancerQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestDragon.LaunchQuestDragon(this);
            this.Hide();
        }
        private void LancerQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestFadriass.LaunchQuestFadriass(this);
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
        private void LancerQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestSpiders.LaunchQuestSpiders(this);
            this.Hide();
        }
        private void LancerQuestTreesBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestTrees.LaunchQuestTrees(this);
            this.Hide();
        }
        private void LancerQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            if (Aventurier1Choix.SelectedIndex == -1 || Aventurier2Choix.SelectedIndex == -1 || Aventurier3Choix.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir des aventuriers !");
                return;
            }
            QuestZombies.LaunchQuestZombies(this);
            this.Hide();
        }

        // Bouton pour Register/Login & Ajouter Aventurier
        private void ShowLogRegisterWindowBtn(object sender, RoutedEventArgs e)
        {
            Register_Login reglog = new Register_Login();
            reglog.Show();
            this.Hide();
        }
        private void ShowAddAdventurerWindowBtn(object sender, RoutedEventArgs e)
        {
            AddCharacters addCharacters = new AddCharacters();
            addCharacters.Show();
            this.Hide();
        }


       
    }
}