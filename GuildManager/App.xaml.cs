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
            SaveManager.Sauvegarder();
            base.OnExit(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Charger les paramètres enregistrés avant d'afficher l'interface
            SaveManager.Charger();
        }

    }

}
