using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GuildManager.Properties;

namespace GuildManager.Controls
{
    public static class SaveManager
    {
        // Fichier JSON où sera stockée la liste des aventuriers
        private static readonly string AdventurersFilePath = "adventurers_save.json";

        /// <summary>
        /// Sauvegarde l'or, le niveau du joueur et la liste complète des aventuriers.
        /// </summary>
        public static void SaveData()
        {
            try
            {
                // 1. Sauvegarde des stats du joueur dans les Settings
                Settings.Default.Gold = Joueur.Instance.Gold;
                Settings.Default.Level = Joueur.Instance.Level;
                Settings.Default.Save();

                // 2. Sérialisation JSON de la liste des aventuriers
                string json = JsonSerializer.Serialize(AdventurerManager.MyAdventurersList, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(AdventurersFilePath, json);

                System.Diagnostics.Debug.WriteLine($"[SAUVEGARDE RÉUSSIE] Gold: {Joueur.Instance.Gold}, Level: {Joueur.Instance.Level}, Aventuriers: {AdventurerManager.MyAdventurersList.Count}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERREUR SAUVEGARDE] {ex.Message}");
            }
        }

        /// <summary>
        /// Charge l'or, le niveau du joueur et la liste des aventuriers sauvegardée.
        /// </summary>
        public static void LoadData()
        {
            try
            {
                // 1. Chargement des stats du joueur depuis les Settings
                Settings.Default.Reload();
                Joueur.Instance.Gold = Settings.Default.Gold;
                Joueur.Instance.Level = Settings.Default.Level;

                // 2. Chargement des aventuriers depuis le fichier JSON
                if (File.Exists(AdventurersFilePath))
                {
                    string json = File.ReadAllText(AdventurersFilePath);
                    var loadedAdventurers = JsonSerializer.Deserialize<List<Adventurer>>(json);

                    if (loadedAdventurers != null && loadedAdventurers.Count > 0)
                    {
                        AdventurerManager.MyAdventurersList.Clear();
                        foreach (var adventurer in loadedAdventurers)
                        {
                            AdventurerManager.MyAdventurersList.Add(adventurer);
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"[CHARGEMENT RÉUSSI] Gold: {Joueur.Instance.Gold}, Level: {Joueur.Instance.Level}, Aventuriers: {AdventurerManager.MyAdventurersList.Count}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERREUR CHARGEMENT] {ex.Message}");
            }
        }

        // Alias de rétrocompatibilité (si ton code appelait déjà Sauvegarder/Charger)
        public static void Sauvegarder() => SaveData();
        public static void Charger() => LoadData();
    }
}