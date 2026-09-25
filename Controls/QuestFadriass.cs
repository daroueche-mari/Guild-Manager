using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace GuildManager.Controls
{
    internal class QuestFadriass
    {
        public static void GoldandxpFadriass(int goldfadriass, int xpfadriass, MainWindow mainWindow)
        {

            mainWindow.GoldQuestFadriass.Text = goldfadriass.ToString();
            mainWindow.XpQuestFadriass.Text = xpfadriass.ToString();
        }
        public static async void LaunchQuestFadriass(MainWindow? mainWindow, AdventurerManager adventurerManager)
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

            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Fadriass.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Fadriass.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Fadriass";
            gameWindow.TypeEnnemi.Text = "Démon Sauvage(Boss Final)";

            

           


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
               "La mort du Dragon a libéré la totalité de l'énergie spirituelle accumulée. Le sceau millénaire s'effondre, et de la terre déchirée surgit Fadriass dans toute sa puissance ancienne.\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Fadriass : « Enfin... L'énergie de toutes ces bêtes sacrifiées m'a régénéré. Cette terre qui porte mon nom va redevenir mon domaine ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Zhìyuān : « Canalisez votre énergie spirituelle. Mes barrières ne tiendront pas éternellement face à une telle puissance ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Fùchóu : *saisit ses fléaux avec fureur* « Démon ou non, c'est ici que ton règne s'achève ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
            "Hēi Jiǔ : « On donne tout ce qu'on a, jusqu'à la dernière goutte ! Pour l'avenir de Fadriann ! »\n\n";
            await Task.Delay(2000);
            gameWindow.Histoire.Text +=
               "C'est le combat ultime pour le destin du royaume !";

            await Task.Delay(2000);
            // 4. Variables de quête et conversion sécurisée de la puissance
            int difficile = 2000;
            int Goldwin = 2500;
            int Xpwin = 3000;
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
