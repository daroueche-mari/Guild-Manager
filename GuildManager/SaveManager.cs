using GuildManager.Properties;

namespace GuildManager
{
    public static class SaveManager
    {
        /// <summary>
        /// Sauvegarde l'or et le niveau du joueur dans les paramètres de l'application.
        /// </summary>
        public static void Sauvegarder()
        {
            Settings.Default.Gold = Joueur.Instance.Gold;
            Settings.Default.Level = Joueur.Instance.Level;

            // Enregistrement définitif sur le système
            Settings.Default.Save();
        }

        /// <summary>
        /// Charge l'or et le niveau sauvegardés au démarrage.
        /// </summary>
        public static void Charger()
        {
            Joueur.Instance.Gold = Settings.Default.Gold;
            Joueur.Instance.Level = Settings.Default.Level;
        }
    }
}