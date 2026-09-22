using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GuildManager
{
    internal class QuestZombies
    {
        public static void GoldandxpZombies(int goldzombies, int xpzombies, MainWindow mainWindow)
        {

            mainWindow.GoldQuestZombies.Text = goldzombies.ToString();
            mainWindow.XpQuestZombies.Text = xpzombies.ToString();
        }
        public static void LaunchQuestZombies(MainWindow mainWindow)
        {
            GameWindow gameWindow = new GameWindow();

            // Config Images Quetes

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Zombies.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Meurtrier.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Meurtrier";
            gameWindow.TypeEnnemi.Text = "Monstre";

            // Config Histoire Quetes

            gameWindow.Histoire.Text = "Histoire Quete Zombies";

            // ComboBox Aventurier Spéciaux

            if (mainWindow.Aventurier1Choix.SelectedIndex == 0)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.AventuriersSpeciaux[0].Nom;
            }
            if (mainWindow.Aventurier1Choix.SelectedIndex == 1)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Hēi Jiǔ.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.AventuriersSpeciaux[1].Nom;
            }
            if (mainWindow.Aventurier1Choix.SelectedIndex == 2)
            {
                gameWindow.Combattant1.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers-Spéciaux/Zhìyuān.png", UriKind.Relative));
                gameWindow.NomAventurier1.Text = mainWindow.AventuriersSpeciaux[2].Nom;
            }
            // ComboBox Aventurier 2

            if (mainWindow.Aventurier2Choix.SelectedIndex == 0)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRogue1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.AventuriersClassiques[0].Nom;
            }
            if (mainWindow.Aventurier2Choix.SelectedIndex == 1)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HTank1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.AventuriersClassiques[1].Nom;
            }
            if (mainWindow.Aventurier2Choix.SelectedIndex == 2)
            {
                gameWindow.Combattant2.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HWarrior1.png", UriKind.Relative));
                gameWindow.NomAventurier2.Text = mainWindow.AventuriersClassiques[2].Nom;
            }

            // ComboBox Aventurier 3

            if (mainWindow.Aventurier3Choix.SelectedIndex == 0)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HMage1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.AventuriersClassiques[3].Nom;
            }
            if (mainWindow.Aventurier3Choix.SelectedIndex == 1)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HPriest1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.AventuriersClassiques[4].Nom;
            }
            if (mainWindow.Aventurier3Choix.SelectedIndex == 2)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HRanger1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.AventuriersClassiques[5].Nom;
            }
            if (mainWindow.Aventurier3Choix.SelectedIndex == 3)
            {
                gameWindow.Combattant3.Source = new BitmapImage(new Uri("/assets/Personnages/Aventuriers/Profile_HBarabarian1.png", UriKind.Relative));
                gameWindow.NomAventurier3.Text = mainWindow.AventuriersClassiques[6].Nom;
            }
            gameWindow.Show();

            var moyen = 10;


            if (mainWindow.myPlayer.Level < moyen)
            {
                MessageBox.Show("Vous n'avez pas reussi la quete");
            }
            else if (mainWindow.myPlayer.Level >= moyen)
            {
                var lootgold = mainWindow.myPlayer.Gold += 380;
                var lootexp = mainWindow.myPlayer.Experience += 400;
                mainWindow.myPlayer.UpLvl();
                mainWindow.NombreGoldFenetreMain.Text = mainWindow.myPlayer.Gold.ToString();
                mainWindow.NombreLvlFenetreMain.Text = mainWindow.myPlayer.Level.ToString();
                MessageBox.Show("Vous avez réussi la quête !\n" +
                    "Vous avez gagné : " + mainWindow.GoldQuestCircle.Text + " d'Or et " +
                    mainWindow.XpQuestCircle.Text + " d'expérience.\n\n" +
                    "Vos Stats :\n" +
                    "Niveau : " + mainWindow.NombreLvlFenetreMain.Text + "\n" +
                    "Or : " + mainWindow.NombreGoldFenetreMain.Text);
            }
        }
    }
}
