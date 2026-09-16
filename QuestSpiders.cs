using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace GuildManager
{
    internal class QuestSpiders
    {
        public static void LaunchQuestSpiders(MainWindow mainWindow)
        {
            GameWindow gameWindow = new GameWindow();

            // Config Images Quetes

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Spiders.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Meurtrier.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Meurtrier";
            gameWindow.TypeEnnemi.Text = "Monstre";

            // Config Histoire Quetes

            gameWindow.Histoire.Text = "Histoire Quete Spiders";


            // CheckBox Aventurier Spéciaux

            if (mainWindow.CheckFushou.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.NomFushou.Text;
            }
            if (mainWindow.CheckHeiJiu.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Hēi Jiǔ.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.NomHeiJiu.Text;
            }
            if (mainWindow.CheckZhiyuan.IsChecked == true)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Zhìyuān.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.NomZhiyuan.Text;
            }
            // CheckBox Aventurier 1

            if (mainWindow.CheckVoyou.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRogue1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.NomVoyou.Text;
            }
            if (mainWindow.CheckTank.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HTank1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.NomTank.Text;
            }
            if (mainWindow.CheckChevalier.IsChecked == true)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HWarrior1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.NomChevalier.Text;
            }

            // CheckBox Aventurier 2

            if (mainWindow.CheckMage.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HMage1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.NomMage.Text;
            }
            if (mainWindow.CheckPretre.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HPriest1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.NomPretre.Text;
            }
            if (mainWindow.CheckArcher.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRanger1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.NomArcher.Text;
            }
            if (mainWindow.CheckBarbare.IsChecked == true)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HBarabarian1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.NomBarbare.Text;

            }
            gameWindow.Show();
        }
    }
}
