using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace GuildManager.Controls
{
    internal class QuestZombies
    {
        public static void GoldandxpZombies(int goldzombies, int xpzombies, MainWindow mainWindow)
        {

            mainWindow.GoldQuestZombies.Text = goldzombies.ToString();
            mainWindow.XpQuestZombies.Text = xpzombies.ToString();
        }
        public static async void LaunchQuestZombies(ChoiceCharacter choiceCharacter, MainWindow? mainWindow)
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

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Zombies.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Zombies.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Hordes d'Infectés";
            gameWindow.TypeEnnemi.Text = "Mort-Vivant";

            

            // Choice Adventurer 

            gameWindow.Combattant1.Source = choiceCharacter.Slot1Image.Source;
            gameWindow.NomAventurier1.Text = choiceCharacter.Slot1Name.Text;

            gameWindow.Combattant2.Source = choiceCharacter.Slot2Image.Source;
            gameWindow.NomAventurier2.Text = choiceCharacter.Slot2Name.Text;



            gameWindow.Combattant3.Source = choiceCharacter.Slot3Image.Source;
            gameWindow.NomAventurier3.Text = choiceCharacter.Slot3Name.Text;

            gameWindow.Show();

            // Config Histoire Quetes

            gameWindow.Histoire.Text =
                "Les morts se relèvent dans les tumulus sacrés. La frénésie magique libérée par les massacres récents a réveillé d'anciens cadavres profanés.\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
                "En fouillant le campement au milieu du charnier, vos aventuriers découvrent le symbole d'un groupe secret : le « Cercle de Fadriass ».\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
                "Ces cultistes semblent agir dans l'ombre pour freiner l'éradication des monstruosités. Il est temps d'aller chercher des réponses directement à leur monastère !";

            await Task.Delay(2000);
            // 4. Variables de quête et conversion sécurisée de la puissance
            int moyen = 450;
            int Goldwin = 500;
            int Xpwin = 550;

            int.TryParse(choiceCharacter.TxtTotalPower.Text, out int squadpower);

            // 5. Condition de victoire / défaite
            if (squadpower < moyen)
            {
                MessageBox.Show($"Vous n'avez pas réussi la quête.\n" +
                                $"La puissance de votre escouade ({squadpower}) est insuffisante ({moyen} requise).",
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
