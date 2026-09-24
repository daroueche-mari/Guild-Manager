using GuildManager.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GuildManager
{
    public partial class AdventurerManager : Window
    {
        public static CharactersConfig Config { get; set; } = new CharactersConfig();
        private static readonly Random rng = new Random();

        public AdventurerManager()
        {
            InitializeComponent();
            DataGridAdventurers.ItemsSource = MyAdventurersList;
            UpdatedTotalGold();
        }

        private void UpdatedTotalGold()
        {
            MainWindow? mainWdw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWdw != null && mainWdw.myPlayer != null)
            {
                CopyTotalGold.Text = mainWdw.myPlayer.Gold.ToString();
            }
        }

        private void BackToMenuFromAdventurerManagerBtn(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWdw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWdw == null)
            {
                mainWdw = new MainWindow();
            }
            mainWdw.Show();
            this.Hide();
        }

        private void ShowAddAdventurerWindowBtn(object sender, RoutedEventArgs e)
        {
            AddCharacters addCharactersWindow = new AddCharacters();
            addCharactersWindow.Show();
            this.Hide();
        }

        private void AmeliorateAdventurerBtn(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWdw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWdw == null || mainWdw.myPlayer == null) return;

            if (sender is Button clickedButton && clickedButton.DataContext is Adventurer selectedAdventurer)
            {
                if (mainWdw.myPlayer.Gold >= selectedAdventurer.Ameliorate)
                {
                    mainWdw.myPlayer.Gold -= selectedAdventurer.Ameliorate;
                    selectedAdventurer.Level += 1;

                    DataGridAdventurers.Items.Refresh();
                    CopyTotalGold.Text = mainWdw.myPlayer.Gold.ToString();
                    mainWdw.NombreGoldFenetreMain.Text = mainWdw.myPlayer.Gold.ToString();

                    SaveManager.SaveData();

                    MessageBox.Show($"{selectedAdventurer.Name} a été amélioré au niveau {selectedAdventurer.Level} !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas assez d'or !", "Or insuffisant", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteAdventurerBtn(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.DataContext is Adventurer selectedAdventurer)
            {
                var result = MessageBox.Show($"Voulez-vous vraiment renvoyer {selectedAdventurer.Name} ?",
                                             "Confirmation de renvoi",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    RemoveAdventurer(selectedAdventurer);
                }
            }
            else if (DataGridAdventurers.SelectedItem is Adventurer selectedFromGrid)
            {
                var result = MessageBox.Show($"Voulez-vous vraiment renvoyer {selectedFromGrid.Name} ?",
                                             "Confirmation de renvoi",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    RemoveAdventurer(selectedFromGrid);
                }
            }
        }

        public static ObservableCollection<Adventurer> MyAdventurersList { get; set; } = new ObservableCollection<Adventurer>();

        public void AddNewAdventurer(Adventurer newAdventurer)
        {
            if (newAdventurer != null)
            {
                MyAdventurersList.Add(newAdventurer);
                SaveManager.SaveData();
            }
        }

        public void RemoveAdventurer(Adventurer adventurer)
        {
            if (adventurer != null && MyAdventurersList.Contains(adventurer))
            {
                MyAdventurersList.Remove(adventurer);
                SaveManager.SaveData();
            }
        }

        public static void LoadConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "character_config.json");

            if (File.Exists(configPath))
            {
                try
                {
                    string json = File.ReadAllText(configPath);
                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Config = System.Text.Json.JsonSerializer.Deserialize<CharactersConfig>(json, options) ?? new CharactersConfig();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[ERREUR CONFIG JSON] {ex.Message}");
                    Config = new CharactersConfig();
                }
            }
        }

        // GENERATION : UN SEUL AVENTURIER PAR NOM UNIQUE
        public static void GenerateAllAdventurers()
        {
            if (Config.Races.Count == 0) LoadConfig();

            MyAdventurersList.Clear();

            // 1. Personnages Spéciaux
            MyAdventurersList.Add(new Adventurer
            {
                ImagePath = GetAbsolutePath("assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png"),
                Name = "Fùchóu",
                Ameliorate = 500,
                Breed = "Panda",
                Classe = "Berserker",
                Level = 1,
                Type = "Special",
                Inventory = "Hache de guerre, Armure en cuir, Potion de soin",
                Power = 100,
                Infos = "Venger la mort de sa famille\nRancunier, Impulsif"
            });
            MyAdventurersList.Add(new Adventurer
            {
                ImagePath = GetAbsolutePath("assets/Personnages/Aventuriers-Spéciaux/Hēi Jiǔ.png"),
                Name = "Hēi Jiǔ",
                Ameliorate = 500,
                Breed = "Panda",
                Classe = "Maitre Brasseurs",
                Level = 1,
                Type = "Special",
                Inventory = "Bière artisanale, Armure en cuir, Potion de soin",
                Power = 100,
                Infos = "Venger la mort de sa famille\nAlcoolique, Stoïque sobre, Girouette Émotionnelle bourré, Loyal"
            });
            MyAdventurersList.Add(new Adventurer
            {
                ImagePath = GetAbsolutePath("assets/Personnages/Aventuriers-Spéciaux/Zhìyuān.png"),
                Name = "Zhìyuān",
                Ameliorate = 500,
                Breed = "Panda",
                Classe = "Archimage",
                Level = 1,
                Type = "Special",
                Inventory = "Baguette magique, Robe en tissu, Potion de soin",
                Power = 100,
                Infos = "Venger la mort de sa famille\nSage, Empathique"
            });

            // 2. Génération : Un seul personnage par nom unique du JSON
            foreach (var race in Config.Races)
            {
                if (!Config.Names.ContainsKey(race)) continue;

                foreach (var name in Config.Names[race])
                {
                    string classe = Config.Classes[rng.Next(Config.Classes.Count)];

                    int initialPower = 50;
                    if (Config.PowerCurves.ContainsKey(classe) && Config.PowerCurves[classe].Count > 0)
                    {
                        initialPower = Config.PowerCurves[classe][0] * 50;
                    }

                    string info = Config.Motivations.Count > 0
                        ? Config.Motivations[rng.Next(Config.Motivations.Count)]
                        : "Aventurier motivé.";

                    string imagePath = GetRandomImageForRaceAndClass(race, classe);

                    MyAdventurersList.Add(new Adventurer
                    {
                        Name = name,
                        Breed = race,
                        Classe = classe,
                        Level = 1,
                        Power = initialPower,
                        Ameliorate = 100,
                        Type = "Classique",
                        ImagePath = imagePath,
                        Inventory = "Équipement de base",
                        Infos = info
                    });
                }
            }

            SaveManager.SaveData();
        }

        private static string GetRandomImageForRaceAndClass(string race, string classe)
        {
            string raceFolder = race switch
            {
                "Human" or "Humain" => "Profils_Humains",
                "Elf" or "Elfe" => "Profils_Elfes",
                "Dwarf" or "Nain" => "Profils_Nains",
                _ => "Profils_Humains"
            };

            string classFolder = classe switch
            {
                "Ranger" or "Rôdeur" or "Archer" => "Archer",
                "Barbarian" or "Barbare" => "Barbare",
                "Warrior" or "Guerrier" or "Chevalier" => "Chevalier",
                "Mage" => "Mage",
                "Priest" or "Prêtre" or "Pretre" => "Pretre",
                "Tank" => "Tank",
                "Rogue" or "Voyou" or "Voleur" => "Voyou",
                _ => "Chevalier"
            };

            string relativeSubPath = Path.Combine("assets", "Personnages", "Aventuriers", raceFolder, classFolder);

            // Recherche dans le dossier de build et dans le dossier du projet
            string binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeSubPath);
            string projectPath = Path.Combine(@"C:\CoursJVSIB2\GuildManager", relativeSubPath);

            string targetFolder = Directory.Exists(binPath) ? binPath : (Directory.Exists(projectPath) ? projectPath : "");

            if (!string.IsNullOrEmpty(targetFolder))
            {
                var files = Directory.GetFiles(targetFolder, "*.*")
                                     .Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                 s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                 s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                     .ToArray();

                if (files.Length > 0)
                {
                    // Sélection d'une vraie image disponible dans le sous-dossier
                    return files[rng.Next(files.Length)];
                }
            }

            return GetAbsolutePath("assets/Personnages/Aventuriers/Default_Avatar.png");
        }

        private static string GetAbsolutePath(string relativePath)
        {
            string binFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            string projectFile = Path.Combine(@"C:\CoursJVSIB2\GuildManager", relativePath);

            if (File.Exists(binFile)) return binFile;
            if (File.Exists(projectFile)) return projectFile;
            return relativePath;
        }
    }
}