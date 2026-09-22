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
            // Force la relecture des paramètres depuis le disque Windows
            Settings.Default.Reload();
            Joueur.Instance.Gold = Settings.Default.Gold;
            Joueur.Instance.Level = Settings.Default.Level;
            System.Diagnostics.Debug.WriteLine($"[CHARGEMENT] Gold: {Joueur.Instance.Gold}, Level: {Joueur.Instance.Level}");
        }
    }
}