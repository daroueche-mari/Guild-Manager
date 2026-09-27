using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GuildManager.Controls
{
    public static class SaveManager
    {
        private static readonly string SaveFilePath = "save_game.json";

        // Déverrouillage des chapitres accessible globalement
        public static bool IsChapitre5Unlocked { get; set; } = false;
        public static bool IsChapitre6Unlocked { get; set; } = false;
        public static bool IsChapitre7Unlocked { get; set; } = false;

        /// <summary>
        /// Sauvegarde toutes les données du jeu (Joueur, Chapitres, Aventuriers) dans un unique fichier JSON.
        /// </summary>
        public static void SaveData()
        {
            try
            {
                var saveData = new GameSaveData
                {
                    Gold = Joueur.Instance.Gold,
                    Level = Joueur.Instance.Level,
                    IsChapitre5Unlocked = IsChapitre5Unlocked,
                    IsChapitre6Unlocked = IsChapitre6Unlocked,
                    IsChapitre7Unlocked = IsChapitre7Unlocked,
                    Adventurers = AdventurerManager.MyAdventurersList != null
                        ? new List<Adventurer>(AdventurerManager.MyAdventurersList)
                        : new List<Adventurer>()
                };

                string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(SaveFilePath, json);

                System.Diagnostics.Debug.WriteLine($"[SAUVEGARDE JSON RÉUSSIE] Gold: {saveData.Gold}, Lvl: {saveData.Level}, Aventuriers: {saveData.Adventurers.Count}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERREUR SAUVEGARDE] {ex.Message}");
            }
        }

        /// <summary>
        /// Charge toutes les données du jeu depuis le fichier JSON.
        /// </summary>
        public static void LoadData()
        {
            try
            {
                if (!File.Exists(SaveFilePath))
                {
                    System.Diagnostics.Debug.WriteLine("[CHARGEMENT] Aucun fichier de sauvegarde trouvé, initialisation par défaut.");
                    return;
                }

                string json = File.ReadAllText(SaveFilePath);
                var saveData = JsonSerializer.Deserialize<GameSaveData>(json);

                if (saveData != null)
                {
                    // 1. Restauration des stats Joueur
                    Joueur.Instance.Gold = saveData.Gold;
                    Joueur.Instance.Level = saveData.Level;

                    // 2. Restauration des chapitres
                    IsChapitre5Unlocked = saveData.IsChapitre5Unlocked;
                    IsChapitre6Unlocked = saveData.IsChapitre6Unlocked;
                    IsChapitre7Unlocked = saveData.IsChapitre7Unlocked;

                    // 3. Restauration des aventuriers
                    if (saveData.Adventurers != null)
                    {
                        AdventurerManager.MyAdventurersList.Clear();
                        foreach (var adventurer in saveData.Adventurers)
                        {
                            AdventurerManager.MyAdventurersList.Add(adventurer);
                        }
                    }

                    System.Diagnostics.Debug.WriteLine($"[CHARGEMENT JSON RÉUSSI] Gold: {saveData.Gold}, Lvl: {saveData.Level}, Aventuriers: {AdventurerManager.MyAdventurersList.Count}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERREUR CHARGEMENT] {ex.Message}");
            }
        }

        // Alias de rétrocompatibilité
        public static void Sauvegarder() => SaveData();
        public static void Charger() => LoadData();
    }
}