using GuildManager.Controls;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GuildManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            // Sauvegarde globale à la fermeture
            SaveManager.SaveData();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Charger la configuration JSON
            AdventurerManager.LoadConfig();

            // 2. Charger les données sauvegardées
            SaveManager.LoadData();

            // 3. Forcer la génération si la liste ne contient que les personnages de base (<= 4)
            if (AdventurerManager.MyAdventurersList.Count <= 4)
            {
                AdventurerManager.GenerateAllAdventurers();
            }
        }
    }
}