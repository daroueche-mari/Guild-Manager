
using GuildManager.Controls;
using GuildManager.Properties;
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
       


        public MainWindow()
        {
            InitializeComponent();
            // On associe l'interface à l'instance déjà chargée par App.xaml.cs
            this.DataContext = Joueur.Instance;
            NombreGoldFenetreMain.Text = myPlayer.Gold.ToString();
            NombreLvlFenetreMain.Text = myPlayer.Level.ToString();
            //NomJoueurFenetreMain.Text = Nomenvoyéàlabdd;
            QuestCircle.GoldandxpCircle(800, 900, this);
            QuestGoblins.GoldandxpGoblins(350, 400, this);
            QuestZombies.GoldandxpZombies(500, 550, this);
            QuestSpiders.GoldandxpSpiders(250, 280, this);
            QuestDragon.GoldandxpDragon(1200, 1400, this);
            QuestTrees.GoldandxpTrees(180, 200, this);
            QuestFadriass.GoldandxpFadriass(2500, 3000, this);
           
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
        private void LoadQuestCircleBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager adventurerManager = new AdventurerManager();
            QuestCircle questCircle = new QuestCircle();
            QuestCircle.LaunchQuestCircle(this, adventurerManager);
            this.Hide();
        }
        private void LoadQuestGoblinsBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestGoblins questGoblins = new QuestGoblins();

            choiceCharacter.TxtNomQuete.Text = "Quest Goblins || Puissance Requise : 300";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestTreesBtn  (object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestTrees questTrees = new QuestTrees();

            choiceCharacter.TxtNomQuete.Text = "Quest Trees || Puissance Requise : 150";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager adventurerManager = new AdventurerManager();
            QuestDragon questDragon = new QuestDragon();
            QuestDragon.LaunchQuestDragon(this, adventurerManager);
            this.Hide();
        }
        private void LoadQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager adventurerManager = new AdventurerManager();
            QuestFadriass questFadriass = new QuestFadriass();
            QuestFadriass.LaunchQuestFadriass(this, adventurerManager);
            this.Hide(); 
        }
        private void LoadQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestSpiders questSpiders = new QuestSpiders();

            choiceCharacter.TxtNomQuete.Text = "Quest Spiders || Puissance Requise : 200";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestZombies questZombies = new QuestZombies();

            choiceCharacter.TxtNomQuete.Text = "Quest Zombies || Puissance Requise : 450";
            choiceCharacter.Show();
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