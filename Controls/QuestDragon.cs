using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace GuildManager.Controls
{
    internal class QuestDragon
    {
        public static void GoldandxpDragon(int golddragon, int xpdragon, MainWindow mainWindow)
        {

            mainWindow.GoldQuestDragon.Text = golddragon.ToString();
            mainWindow.XpQuestDragon.Text = xpdragon.ToString();
        }
        public static async void LaunchQuestDragon(MainWindow? mainWindow, AdventurerManager adventurerManager)
        {
            // 1. Récupération de sécurité si mainWindow est passée à null
            if (mainWindow == null)
            {
                mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            }

            // 2. Vérification de sécurité pour éviter tout crash
            if (mainWindow == null || mainWindow.myPlayer == null)
            {
                MessageBox.Show("Erreur : Impossible d'accéder aux données du joueur.",
                                "Erreur",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }
            GameWindow gameWindow = new GameWindow();

            // Config Images Quetes

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Dragon.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Dragon.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Le Dragon Primordial";
            gameWindow.TypeEnnemi.Text = "Gardien Corrompu";

            

            

            // Choice Adventurer 

            gameWindow.Combattant1.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[0].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier1.Text = AdventurerManager.MyAdventurersList[0].Name;

            gameWindow.Combattant2.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[1].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier2.Text = AdventurerManager.MyAdventurersList[1].Name;



            gameWindow.Combattant3.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[2].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier3.Text = AdventurerManager.MyAdventurersList[2].Name;

            gameWindow.Show();

            // Config Histoire Quetes

            gameWindow.Histoire.Text =
                "Le ciel au-dessus du Pic des Tempêtes vire au rouge sang. Le Dragon Primordial s'est extirpé de la montagne, rendu fou par la concentration d'énergie spirituelle.\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Zhìyuān : « Gardez votre calme ! Sa rage est alimentée par l'énergie des bêtes abattues. Je vais ériger une barrière spirituelle, ne sortez pas du cercle ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Fùchóu : *serre ses fléaux avec poigne* « Ses écailles sont d'acier ? Très bien. Ça veut juste dire qu'il va falloir frapper deux fois plus fort ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Hēi Jiǔ : *jette sa gourde vide* « Plus le temps de boire. Si cette bête descend dans la vallée, il ne restera plus une seule taverne debout ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
                "Terrassez le monstre avant qu'il ne brise le tout dernier sceau de Fadriass !";

            await Task.Delay(2000);
            // 4. Variables de quête et conversion sécurisée de la puissance
            int difficile = 1100;
            int Goldwin = 1200;
            int Xpwin = 1400;
            int squadpower = AdventurerManager.MyAdventurersList[0].Power + AdventurerManager.MyAdventurersList[1].Power + AdventurerManager.MyAdventurersList[2].Power;


            // 5. Condition de victoire / défaite
            if (squadpower < difficile)
            {
                MessageBox.Show($"Vous n'avez pas réussi la quête.\n" +
                                $"La puissance de votre escouade ({squadpower}) est insuffisante ({difficile} requise).",
                                "Défaite",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else
            {
                // Mises à jour des données du joueur
                mainWindow.myPlayer.Gold += Goldwin;
                mainWindow.myPlayer.Experience += Xpwin;
                mainWindow.myPlayer.UpLvl();

                // Mises à jour de l'UI
                mainWindow.NombreGoldFenetreMain.Text = mainWindow.myPlayer.Gold.ToString();
                mainWindow.NombreLvlFenetreMain.Text = mainWindow.myPlayer.Level.ToString();

                // Affichage garanti sans champs vides
                MessageBox.Show($"Vous avez réussi la quête !\n" +
                                $"Vous avez gagné : {Goldwin} d'Or et {Xpwin} d'expérience.\n\n" +
                                $"Vos Stats :\n" +
                                $"Niveau : {mainWindow.myPlayer.Level}\n" +
                                $"Or : {mainWindow.myPlayer.Gold}",
                                "Victoire !",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }
    }
}
