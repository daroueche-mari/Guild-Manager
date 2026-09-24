using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GuildManager.Controls
{
    internal class QuestGoblins
    {
        public static void GoldandxpGoblins(int goldgoblins, int xpgoblins, MainWindow mainWindow)
        {

            mainWindow.GoldQuestGoblins.Text = goldgoblins.ToString();
            mainWindow.XpQuestGoblins.Text = xpgoblins.ToString();
        }
        public static void LaunchQuestGoblins(ChoiceCharacter choiceCharacter, MainWindow? mainWindow)
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

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Circle.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Meurtrier.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Meurtrier";
            gameWindow.TypeEnnemi.Text = "Monstre";

            // Config Histoire Quetes

            gameWindow.Histoire.Text = "Histoire Quetes Goblins";


            // Choice Adventurer 

            gameWindow.Combattant1.Source = choiceCharacter.Slot1Image.Source;
            gameWindow.NomAventurier1.Text = choiceCharacter.Slot1Name.Text;

            gameWindow.Combattant2.Source = choiceCharacter.Slot2Image.Source;
            gameWindow.NomAventurier2.Text = choiceCharacter.Slot2Name.Text;



            gameWindow.Combattant3.Source = choiceCharacter.Slot3Image.Source;
            gameWindow.NomAventurier3.Text = choiceCharacter.Slot3Name.Text;

            gameWindow.Show();

            // 4. Variables de quête et conversion sécurisée de la puissance
            int facile = 150;
            int Goldwin = 180;
            int Xpwin = 200;

            int.TryParse(choiceCharacter.TxtTotalPower.Text, out int squadpower);

            // 5. Condition de victoire / défaite
            if (squadpower < facile)
            {
                MessageBox.Show($"Vous n'avez pas réussi la quête.\n" +
                                $"La puissance de votre escouade ({squadpower}) est insuffisante ({facile} requise).",
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
