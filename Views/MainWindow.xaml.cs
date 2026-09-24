
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
            QuestCircle.GoldandxpCircle(180, 200, this);
            QuestGoblins.GoldandxpGoblins(280, 300, this);
            QuestZombies.GoldandxpZombies(380, 400, this);
            QuestSpiders.GoldandxpSpiders(480, 500, this);
            QuestDragon.GoldandxpDragon(580, 600, this);
            QuestTrees.GoldandxpTrees(680, 700, this);
            QuestFadriass.GoldandxpFadriass(780, 800, this);
           
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
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestCircle questCircle = new QuestCircle();
            choiceCharacter.TxtNomQuete.Text = "Quest Circle\nPuissance Requise : 150";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestGoblinsBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestGoblins questGoblins = new QuestGoblins();

            choiceCharacter.TxtNomQuete.Text = "Quest Goblins";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestTreesBtn  (object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestTrees questTrees = new QuestTrees();

            choiceCharacter.TxtNomQuete.Text = "Quest Trees";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestDragonBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestDragon questDragon = new QuestDragon();

            choiceCharacter.TxtNomQuete.Text = "Quest Dragon";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestFadriassBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestFadriass questFadriass = new QuestFadriass();

            choiceCharacter.TxtNomQuete.Text = "Quest Fadriass";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestSpidersBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestSpiders questSpiders = new QuestSpiders();

            choiceCharacter.TxtNomQuete.Text = "Quest Spiders";
            choiceCharacter.Show();
            this.Hide();
        }
        private void LoadQuestZombiesBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCharacter choiceCharacter = new ChoiceCharacter();

            QuestZombies questZombies = new QuestZombies();

            choiceCharacter.TxtNomQuete.Text = "Quest Zombies";
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