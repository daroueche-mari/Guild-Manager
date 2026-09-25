using GuildManager.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GuildManager
{
    /// <summary>
    /// Logique d'interaction pour ChoiceCharacter.xaml
    /// </summary>
    public partial class ChoiceCharacter : Window
    {

        public List<Adventurer> SelectedAdventurers { get; private set; } = new List<Adventurer>();
        public ChoiceCharacter()
        {
            InitializeComponent();
            ListViewAdventurers.ItemsSource = AdventurerManager.MyAdventurersList;
            UpdateSlotsUI();
        }
       

        private void DeclineQuestBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();

            mainWin.Show();
            this.Hide();
        }

        // Événement déclenché à chaque clic sur la ListView
        private void ListViewAdventurers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Bloque la sélection si l'utilisateur essaie de choisir plus de 3 aventuriers
            if (ListViewAdventurers.SelectedItems.Count > 3)
            {
                MessageBox.Show("Vous ne pouvez pas sélectionner plus de 3 aventuriers pour une expédition.", "Escouade complète", MessageBoxButton.OK, MessageBoxImage.Warning);

                // Annule la sélection du dernier élément ajouté
                foreach (var item in e.AddedItems)
                {
                    ListViewAdventurers.SelectedItems.Remove(item);
                }
                return;
            }

            // Met à jour la liste C# des aventuriers sélectionnés
            SelectedAdventurers = ListViewAdventurers.SelectedItems.Cast<Adventurer>().ToList();

            // Met à jour l'affichage des 3 cases en bas à droite
            UpdateSlotsUI();
        }

        // Met à jour l'UI des 3 slots dynamiques
        private void UpdateSlotsUI()
        {
            // 1. Récupération sécurisée de l'instance MainWindow ouverte dans l'application
            MainWindow? mainWin = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            // 2. Mise à jour du compteur
            TxtCountSelection.Text = $"{SelectedAdventurers.Count} / 3";

            // 3. Calcul de la puissance de base des aventuriers
            int basePower = SelectedAdventurers.Sum(myselectedAdventurer => myselectedAdventurer.Power);
            int bonusPower = 0;

            // 4. Calcul du bonus uniquement si le joueur et l'instance existent
            if (mainWin?.myPlayer != null)
            {
                int level = mainWin.myPlayer.Level;

                if (level >= 1 && level <= 10)
                {
                    TxtBonusPower.Text = "+50";
                    bonusPower = 50;
                }
                else if (level >= 11 && level <= 20)
                {
                    TxtBonusPower.Text = "+100";
                    bonusPower = 100;
                }
                else if (level >= 21 && level <= 30)
                {
                    TxtBonusPower.Text = "+150";
                    bonusPower = 150;
                }
                else if (level >= 31 && level <= 40)
                {
                    TxtBonusPower.Text = "+200";
                    bonusPower = 200;
                }
            }

            // 5. Affichage final du total (Base + Bonus)
            int totalPower = basePower + bonusPower;
            TxtTotalPower.Text = totalPower.ToString();

            // 6. Mise à jour des cartes visuelles (Slots 1, 2 et 3)
            SetSlotData(Slot1Image, Slot1Name, Slot1Level, Slot1Border, SelectedAdventurers.Count > 0 ? SelectedAdventurers[0] : null);
            SetSlotData(Slot2Image, Slot2Name, Slot2Level, Slot2Border, SelectedAdventurers.Count > 1 ? SelectedAdventurers[1] : null);
            SetSlotData(Slot3Image, Slot3Name, Slot3Level, Slot3Border, SelectedAdventurers.Count > 2 ? SelectedAdventurers[2] : null);
        }

        // Injecte les données d'un aventurier dans les composants d'un Slot
        private void SetSlotData(Image imgSlot, TextBlock txtName, TextBlock txtLevel, Border borderSlot, Adventurer? adv)
        {
            if (adv != null)
            {
                // Chargement de l'image du portrait
                try
                {
                    imgSlot.Source = new BitmapImage(new Uri(adv.ImagePath, UriKind.RelativeOrAbsolute));
                }
                catch
                {
                    imgSlot.Source = null;
                }

                txtName.Text = adv.Name;
                txtName.Foreground = Brushes.White;
                txtLevel.Text = $"Niv. {adv.Level}";
                borderSlot.BorderBrush = Brushes.Gold; // Bordure dorée si le slot est occupé
            }
            else
            {
                // Slot vide
                imgSlot.Source = null;
                txtName.Text = "[Vide]";
                txtName.Foreground = Brushes.Gray;
                txtLevel.Text = "";
                borderSlot.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#55FFFFFF") ?? Brushes.Gray);
            }
        }
        private void LaunchQuestBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWin = Application.Current.MainWindow as MainWindow;
            GameWindow? gameWin = new GameWindow();
            AdventurerManager adventurerManager = new AdventurerManager();
            QuestCircle questCircle = new QuestCircle();
            QuestDragon questDragon = new QuestDragon();
            QuestFadriass questFadriass = new QuestFadriass();
            QuestGoblins questGoblins = new QuestGoblins();
            QuestSpiders questSpiders = new QuestSpiders();
            QuestTrees questTrees = new QuestTrees();
            QuestZombies questZombies = new QuestZombies();

           if (SelectedAdventurers.Count == 0)
            {
                MessageBox.Show("Vous devez sélectionner au moins un aventurier pour lancer la quête.", "Aucun aventurier sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           if (TxtNomQuete.Text == "Quest Goblins || Puissance Requise : 300")
            {
                QuestGoblins.LaunchQuestGoblins(this, mainWin);
                this.Hide();
            }
            else if (TxtNomQuete.Text == "Quest Zombies || Puissance Requise : 450")
            {
                QuestZombies.LaunchQuestZombies(this, mainWin);
                this.Hide();
            }
            else if (TxtNomQuete.Text == "Quest Spiders || Puissance Requise : 200")
            {
                QuestSpiders.LaunchQuestSpiders(this, mainWin);
                this.Hide();
            } 
            else if (TxtNomQuete.Text == "Quest Trees || Puissance Requise : 150")
            {
                QuestTrees.LaunchQuestTrees(this, mainWin);
                this.Hide();
            }
          
            
        }

        }
    }
