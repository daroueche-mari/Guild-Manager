
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
        public MainWindow()
        {
            InitializeComponent();
            ConfigCheckBoxMain();
        }


        private void LancerQuestCircleBtn(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
           
            // Config Images Quetes

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Circle.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Meurtrier.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Meurtrier";
            gameWindow.TypeEnnemi.Text = "Monstre";

            // Config Histoire Quetes

            gameWindow.Histoire.Text = "ssssssssssssssssssssssssssssssssssssssssssssss";

            
            // CheckBox Aventurier Spéciaux

            if (CheckFushou.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = NomFushou.Text;
            }
            if (CheckHeiJiu.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Hēi Jiǔ.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = NomHeiJiu.Text;
            }
            if (CheckZhiyuan.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Zhìyuān.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = NomZhiyuan.Text;
            }
            // CheckBox Aventurier 1

            if (CheckVoyou.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRogue1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = NomVoyou.Text;
            }
            if (CheckTank.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HTank1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = NomTank.Text;
            }
            if (CheckChevalier.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profil_HWarrior1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = NomChevalier.Text;
            }

            // CheckBox Aventurier 2

            if (CheckMage.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HMage1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = NomMage.Text;
            }
            if (CheckPretre.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HPriest1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = NomPretre.Text;
            }
            if (CheckArcher.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRanger1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = NomArcher.Text;
            }
            if (CheckBarbare.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HBarabarian1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = NomBarbare.Text;

            }
            gameWindow.Show();
        }

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