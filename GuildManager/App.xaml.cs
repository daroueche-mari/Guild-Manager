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
        protected override void OnStartup(StartupEventArgs e)
        {
            // Intercepte les erreurs non gérées au niveau de l'application
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = (Exception)args.ExceptionObject;
                MessageBox.Show($"Erreur critique : {ex.Message}\n\nDétails : {ex.StackTrace}",
                                "Erreur au démarrage", MessageBoxButton.OK, MessageBoxImage.Error);
            };

            base.OnStartup(e);
        }
    }

}
