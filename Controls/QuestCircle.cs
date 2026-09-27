using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace GuildManager.Controls
{
    internal class QuestCircle
    {
       

        public static async void LaunchQuestCircle(MainWindow? mainWindow, AdventurerManager? adventurerManager)
        {
            Adventurer myadventurer = new Adventurer();
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

            // 3. Configuration de l'affichage de la fenêtre de combat
            GameWindow gameWindow = new GameWindow();
            gameWindow.TypeQueteActuelle = "Circle";
            gameWindow.FondQueteChoisi.Source = new BitmapImage(new Uri("/assets/UI/Quest_Illustrations/Quest_Circle.png", UriKind.Relative));
            gameWindow.Ennemi.Source = new BitmapImage(new Uri("/assets/Personnages/Personnages-Importants/Meurtrier.png", UriKind.Relative));
            gameWindow.NomEnnemi.Text = "Le Meurtrier";
            gameWindow.TypeEnnemi.Text = "Haut Gradé du Cercle";

           

            gameWindow.Combattant1.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[0].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier1.Text = AdventurerManager.MyAdventurersList[0].Name;

            gameWindow.Combattant2.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[1].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier2.Text = AdventurerManager.MyAdventurersList[1].Name;

            gameWindow.Combattant3.Source = new BitmapImage(new Uri(AdventurerManager.MyAdventurersList[2].ImagePath, UriKind.RelativeOrAbsolute));
            gameWindow.NomAventurier3.Text = AdventurerManager.MyAdventurersList[2].Name;

            gameWindow.Show();

            // Config Histoire Quete

            gameWindow.Histoire.Text =
               "Ganam : « Suivez-moi sans bruit. J'ai mémorisé chaque patrouille pendant mon infiltration. Le haut gradé du Cercle est dans le sanctuaire. »\n\n";
            await Task.Delay(1500);
            gameWindow.Histoire.Text +=
                "Fùchóu : *enclenche ses fléaux avec rage* « Enfin ! C'est lui qui a massacré notre famille... Il va payer ! »\n\n";
            await Task.Delay(1500);
            gameWindow.Histoire.Text +=
                "Le Meurtrier : « Aveugles que vous êtes... Vous éliminez les monstres en croyant bien faire, mais vous nourrissez Fadriass avec leur énergie ! Le Cercle tente juste de stopper le réveil du Démon ! »\n\n";
            await Task.Delay(1500);
            gameWindow.Histoire.Text +=
                "Hēi Jiǔ : *boit une gorgée* « Vos méthodes éco-terroristes et vos crimes ne vous sauveront pas. On règle ça maintenant ! »";

            await Task.Delay(1500);
            // --- CHOIX DÉCISIONNEL ---
            MessageBoxResult choix = MessageBox.Show(
                "Le Meurtrier tente de vous faire douter sur vos actions et le réveil de Fadriass.\n\n" +
                "[Oui] : Écouter ses révélations \n" +
                "[Non] : L'attaquer sans écouter ses mensonges.",
                "Choix Tactique — Chapitre 5",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
           

            await Task.Delay(700);
            // 4. Variables de quête et conversion sécurisée de la puissance
            int difficile = 700;
            int Goldwin = 800;
            int Xpwin = 900;
            int squadpower = AdventurerManager.MyAdventurersList[0].Power + AdventurerManager.MyAdventurersList[1].Power + AdventurerManager.MyAdventurersList[2].Power;
            if (choix == MessageBoxResult.Yes)
            {
                gameWindow.Histoire.Text += "\n\n*Vous hésitez et écoutez ses explications. Son discours vous donne un avantage tactique, mais seme le doute dans les rangs.*";
                Goldwin -= 200;
            }
            else
            {
                gameWindow.Histoire.Text += "\n\n*Fùchóu refuse de l'écouter et se jette immédiatement au combat dans une fureur vengeresse !*";
                Goldwin += 500;
            }

            // 5. Condition de victoire / défaite
            if (squadpower < difficile)
            {
                MessageBox.Show($"Vous n'avez pas réussi la quête.\n" +
                                $"La puissance de votre escouade ({squadpower}) est insuffisante ({difficile} requise).",
                                "Défaite !\n Vous avez perdu 100 Or",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                mainWindow.myPlayer.Gold -= 100;
                if (mainWindow.myPlayer.Gold < 0) mainWindow.myPlayer.Gold = 0;
                mainWindow.NombreGoldFenetreMain.Text = mainWindow.myPlayer.Gold.ToString();
                gameWindow.BtnRetourQuest.IsEnabled = true;
                gameWindow.BtnRetourQuest.Visibility = Visibility.Visible;
                gameWindow.BtnRejouerQuest.IsEnabled = true;
                gameWindow.BtnRejouerQuest.Visibility = Visibility.Visible;
            }
            else
            {
                gameWindow.BtnRetourQuest.IsEnabled = true;
                gameWindow.BtnRetourQuest.Visibility = Visibility.Visible;
                gameWindow.BtnRejouerQuest.IsEnabled = true;
                gameWindow.BtnRejouerQuest.Visibility = Visibility.Visible;
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