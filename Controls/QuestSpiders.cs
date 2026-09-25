using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace GuildManager.Controls
{
    internal class QuestSpiders
    {
        public static void GoldandxpSpiders(int goldspiders, int xpspiders, MainWindow mainWindow)
        {

            mainWindow.GoldQuestSpiders.Text = goldspiders.ToString();
            mainWindow.XpQuestSpiders.Text = xpspiders.ToString();
        }
        public static async void LaunchQuestSpiders(ChoiceCharacter choiceCharacter, MainWindow? mainWindow)
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

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Spiders.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Spiders.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Arachnide Mutante";
            gameWindow.TypeEnnemi.Text = "Bête Sauvage";

            

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
             "L'élimination des premiers monstres a libéré une onde d'énergie spirituelle... Exactement comme le prévoyait le lore antique.\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Nourries par cette énergie ambiante, les araignées des profondeurs ont muté et envahissent les galeries minières du sud. ";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Elles sont devenues plus agressives et plus rapides.\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Nettoyez les galeries pour protéger les ouvriers, mais gardez en tête que chaque bête abattue renforce l'éveil du Démon Sauvage.";

            await Task.Delay(2000);
            // 4. Variables de quête et conversion sécurisée de la puissance
            int facile = 200;
            int Goldwin = 250;
            int Xpwin = 280;

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
