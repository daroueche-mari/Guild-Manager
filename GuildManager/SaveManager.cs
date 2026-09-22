using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GuildManager
{
    public static class SaveManager
    {
        // Le fichier savegame.json sera stocké directement à côté du fichier .exe du jeu
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savegame.json");

        /// <summary>
        /// Sauvegarde les données actuelles du joueur dans le fichier JSON.
        /// </summary>
        public static void Sauvegarder()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Joueur.Instance, options);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        /// <summary>
        /// Charge les données du fichier JSON s'il existe.
        /// </summary>
        public static void Charger()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    Joueur? loadedJoueur = JsonSerializer.Deserialize<Joueur>(jsonString);

                    if (loadedJoueur != null)
                    {
                        Joueur.Instance = loadedJoueur;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
        }
    }
}