using GuildManager.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace GuildManager
{
    public partial class AdventurerManager : Window
    {
        public static CharactersConfig Config { get; set; } = new CharactersConfig();
        private static readonly Random rng = new Random();

        // 1. LISTES STATIQUES (Guilde du joueur & Taverne d'achat)
        public static ObservableCollection<Adventurer> MyAdventurersList { get; set; } = new ObservableCollection<Adventurer>();
        public static ObservableCollection<Adventurer> AvailableShopAdventurers { get; set; } = new ObservableCollection<Adventurer>();

        public AdventurerManager()
        {
            InitializeComponent();
            DataGridAdventurers.ItemsSource = MyAdventurersList;
            UpdatedTotalGold();
        }

        public void UpdatedTotalGold()
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
                    selectedAdventurer.Power += 100;

                    DataGridAdventurers.Items.Refresh();
                    UpdatedTotalGold();
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
            Adventurer? selectedAdventurer = null;

            if (sender is Button clickedButton && clickedButton.DataContext is Adventurer advFromBtn)
            {
                selectedAdventurer = advFromBtn;
            }
            else if (DataGridAdventurers.SelectedItem is Adventurer advFromGrid)
            {
                selectedAdventurer = advFromGrid;
            }

            if (selectedAdventurer != null)
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
        }

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

        // GENERATION DES AVENTURIERS EN DEPART DE PARTIE (SEULEMENT LES SPECIAUX EN DUR)
        public static void GenerateAllAdventurers()
        {
            MyAdventurersList.Clear();

            // Personnages Spéciaux uniquement (Note l'utilisation du slash au début '/assets/...')
            MyAdventurersList.Add(new Adventurer
            {
                ImagePath = GetAbsolutePath("assets/Personnages/Aventuriers-Spéciaux/Fùchóu.png"),
                Name = "Fùchóu",
                Ameliorate = 500,
                Price = 1000,
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
                Price = 1000,
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
                Price = 1000,
                Breed = "Panda",
                Classe = "Archimage",
                Level = 1,
                Type = "Special",
                Inventory = "Baguette magique, Robe en tissu, Potion de soin",
                Power = 100,
                Infos = "Venger la mort de sa famille\nSage, Empathique"
            });
            MyAdventurersList.Add(new Adventurer
            {
                ImagePath = GetAbsolutePath("assets/Personnages/Aventuriers/Profile_HRogue1.png"),
                Name = "Ganam",
                Ameliorate = 100,
                Price = 200,
                Breed = "Humain",
                Classe = "Voyou",
                Level = 1,
                Type = "Classique",
                Inventory = "Dague d'infiltré",
                Power = 100,
                Infos = "Agent d'élite envoyé en couverture au cœur du Cercle de Fadriass.\nObservateur, Solitaire, Il ne laisse rien au hasard."
            });

            SaveManager.SaveData();
        }

        // GENERATION DES 9 AVENTURIERS POUR LA TAVERNE (ACHAT DYNAMIQUE D'APRES LE JSON)
        public static void GenerateShopAdventurers()
        {
            if (Config.Races.Count == 0) LoadConfig();

            AvailableShopAdventurers.Clear();
            List<Adventurer> pool = new List<Adventurer>();

            // Liste des noms déjà possédés par le joueur
            HashSet<string> myOwnedNames = MyAdventurersList.Select(a => a.Name).ToHashSet();

            foreach (var race in Config.Races)
            {
                if (!Config.Names.ContainsKey(race)) continue;

                foreach (var name in Config.Names[race])
                {
                    if (myOwnedNames.Contains(name)) continue;

                    string classe = Config.Classes[rng.Next(Config.Classes.Count)];
                    int initialPower = 50;

                    if (Config.PowerCurves.ContainsKey(classe) && Config.PowerCurves[classe].Count > 0)
                    {
                        initialPower = Config.PowerCurves[classe][0] * 50;
                    }

                    string info = Config.Motivations.Count > 0
                        ? Config.Motivations[rng.Next(Config.Motivations.Count)]
                        : "Aventurier motivé.";

                    // L'IMAGE EST FIXÉE ICI UNE FOIS POUR TOUTES
                    string imagePath = GetRandomImageForRaceAndClass(race, classe);

                    pool.Add(new Adventurer
                    {
                        Name = name,
                        Breed = race,
                        Classe = classe,
                        Level = 1,
                        Power = initialPower,
                        Ameliorate = 100,
                        Price = initialPower * 2,
                        Type = "Classique",
                        ImagePath = imagePath,
                        Inventory = "Équipement de base",
                        Infos = info
                    });
                }
            }

            // Tirage aléatoire de 9 aventuriers pour la taverne
            var selected9 = pool.OrderBy(_ => rng.Next()).Take(9);
            foreach (var adv in selected9)
            {
                AvailableShopAdventurers.Add(adv);
            }
        }

        private static string GetRandomImageForRaceAndClass(string race, string classe)
        {
            // 1. Mappage de la Race
            string raceFolder = race?.Trim().ToLower() switch
            {
                "human" or "humain" => "Profils_Humains",
                "elf" or "elfe" => "Profils_Elfes",
                "dwarf" or "nain" => "Profils_Nains",
                _ => "Profils_Humains"
            };

            // 2. Mappage de la Classe
            string classFolder = classe?.Trim().ToLower() switch
            {
                "ranger" or "rôdeur" or "rodeur" or "archer" => "Archer",
                "barbarian" or "barbare" => "Barbare",
                "warrior" or "guerrier" or "chevalier" => "Chevalier",
                "mage" or "archimage" => "Mage",
                "priest" or "prêtre" or "pretre" => "Pretre",
                "tank" => "Tank",
                "rogue" or "voyou" or "voleur" => "Voyou",
                _ => "Chevalier"
            };

            // Filtre cible : cherche juste "profils_elfes/pretre/" dans la clé de ressource
            string targetPattern = $"{raceFolder}/{classFolder}".ToLower();

            // 3. Récupération des ressources matching
            List<string> matchingImages = GetEmbeddedImagePaths(targetPattern);

            if (matchingImages.Count > 0)
            {
                string selectedResourcePath = matchingImages[rng.Next(matchingImages.Count)];
                return $"pack://application:,,,/{selectedResourcePath}";
            }

            // 4. Fallback sécurisé vers une image existante
            return $"pack://application:,,,/assets/Personnages/Aventuriers/Profils_Elfes/Pretre/Profile_EPriest2.png";
        }

        private static List<string> GetEmbeddedImagePaths(string folderPathLower)
        {
            List<string> results = new List<string>();

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resName = assembly.GetName().Name + ".g.resources";

                using (Stream? stream = assembly.GetManifestResourceStream(resName))
                {
                    if (stream != null)
                    {
                        using (ResourceReader reader = new ResourceReader(stream))
                        {
                            foreach (DictionaryEntry entry in reader)
                            {
                                string? keyString = entry.Key?.ToString();

                                if (keyString != null)
                                {
                                    string resourceKey = keyString.ToLower();

                                    if (resourceKey.Contains(folderPathLower) &&
                                       (resourceKey.EndsWith(".png") || resourceKey.EndsWith(".jpg") || resourceKey.EndsWith(".jpeg")))
                                    {
                                        results.Add(keyString);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur lors de la lecture des ressources : {ex.Message}");
            }

            return results;
        }

        private static string GetAbsolutePath(string relativePath)
        {
            // S'assure que les slashes soient au bon format WPF
            string cleanRelativePath = relativePath.Replace('\\', '/').TrimStart('/');
            string binFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cleanRelativePath);

            // Si le fichier existe physiquement sur le disque, on renvoie une URI file:///
            if (File.Exists(binFile))
            {
                return new Uri(binFile).AbsoluteUri;
            }

            // Sinon on renvoie l'URI relative WPF de secours avec un slash initial
            return "/" + cleanRelativePath;
        }

        
    }
}