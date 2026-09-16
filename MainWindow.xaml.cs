
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
        Adventurer myPlayer = new Adventurer("", 0, "", "", 0, 0, "", 0, "");
        

        public MainWindow()
        {
            InitializeComponent();
            ConfigCheckBoxMain();
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
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
            QuestCircle.GoldandxpCircle(180, 200, this);   
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
            QuestCircle.LaunchQuestCircle(this);
            this.Hide();
        }
        private void LancerQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            QuestDragon.LaunchQuestDragon(this);
            this.Hide();
        }
        private void LancerQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            QuestFadriass.LaunchQuestFadriass(this);
            this.Hide();
        }
        private void LancerQuestGoblinsBtn(object sender, RoutedEventArgs e)
        {
            QuestGoblins.LaunchQuestGoblins(this);
            this.Hide();
        }
        private void LancerQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            QuestSpiders.LaunchQuestSpiders(this);
            this.Hide();
        }
        private void LancerQuestTreesBtn(object sender, RoutedEventArgs e)
        {
            QuestTrees.LaunchQuestTrees(this);
            this.Hide();
        }
        private void LancerQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            QuestZombies.LaunchQuestZombies(this);
            this.Hide();
        }

        // Config des checkbox(à finir)
        private void ConfigCheckBoxMain()
        {
            // Check Aventurier Spéciaux
            if(CheckFushou.IsChecked == true)
            {
                CheckHeiJiu.IsChecked = false;
                CheckZhiyuan.IsChecked = false;
            }
            if (CheckHeiJiu.IsChecked == true)
            {
                CheckFushou.IsChecked = false;
                CheckZhiyuan.IsChecked = false;
            }
            if (CheckZhiyuan.IsChecked == true)
            {
                CheckHeiJiu.IsChecked = false;
                CheckFushou.IsChecked = false;
            }
            // Check Aventurier 1
            if (CheckVoyou.IsChecked == true)
            {
                CheckTank.IsChecked = false;
                CheckChevalier.IsChecked = false;
            }
            if (CheckTank.IsChecked == true)
            {
                CheckVoyou.IsChecked = false;
                CheckChevalier.IsChecked = false;
            }
            if (CheckChevalier.IsChecked == true)
            {
                CheckTank.IsChecked = false;
                CheckVoyou.IsChecked = false;
            }
            // Check Aventurier 2

            if (CheckMage.IsChecked == true)
            {
                CheckPretre.IsChecked = false;
                CheckArcher.IsChecked = false;
                CheckBarbare.IsChecked = false;

            }
            if (CheckArcher.IsChecked == true)
            {
                CheckPretre.IsChecked = false;
                CheckMage.IsChecked = false;
                CheckBarbare.IsChecked = false;

            }
            if (CheckPretre.IsChecked == true)
            {
                CheckMage.IsChecked = false;
                CheckArcher.IsChecked = false;
                CheckBarbare.IsChecked = false;

            }
            if (CheckBarbare.IsChecked == true)
            {
                CheckPretre.IsChecked = false;
                CheckArcher.IsChecked = false;
                CheckMage.IsChecked = false;

            }

        }

       
    }
}