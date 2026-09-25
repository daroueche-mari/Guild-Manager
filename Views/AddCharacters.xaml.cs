using GuildManager.Controls;
using Microsoft.Win32;
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
    /// Logique d'interaction pour AddCharacters.xaml
    /// </summary>
    public partial class AddCharacters : Window
    {
        public AddCharacters()
        {
            InitializeComponent();
        }
        private void BackToAdventurerManageFromAddCharacterBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager am = new AdventurerManager();
            am.Show();
            this.Hide();
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Sélectionner le portrait de l'aventurier",
                Filter = "Fichiers Image (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tous les fichiers (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Injecte directement le chemin du fichier sélectionné dans ton TextBox
                Imagepathforaddcharacter.Text = openFileDialog.FileName;
            }
        }

        private void NewAdventurerBtn(object sender, RoutedEventArgs e)
        {
            AdventurerManager adventurerManager = new AdventurerManager();
            // 1. Validation des champs texte obligatoires
            if (string.IsNullOrWhiteSpace(Nomforaddcharacter.Text) ||
                string.IsNullOrWhiteSpace(Imagepathforaddcharacter.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Champ manquant", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Conversion sécurisée des TextBlock/TextBox fixes
            int.TryParse(Levelforaddcharacter.Text, out int level);
            int.TryParse(Powerforaddcharacter.Text, out int power);
            int.TryParse(Ameliorateforaddcharacter.Text, out int ameliorate);

            // 3. Extraction propre des valeurs sélectionnées dans les ComboBox
            string breed = (Breedforaddcharacter.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Humain";
            string classe = (Classeforaddcharacter.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Guerrier";

            // 4. Création de l'objet Adventurer
            Adventurer newHero = new Adventurer
            {
                Name = Nomforaddcharacter.Text,
                ImagePath = Imagepathforaddcharacter.Text,
                Level = level,
                Power = power,
                Ameliorate = ameliorate,
                Breed = breed,
                Classe = classe,
                Type = Typeforaddcharacter.Text, // TextBlock fixe ("Classique")
                Inventory = Inventoryforaddcharacter.Text,
                Infos = Infosforaddcharacter.Text
            };

            // 5. Ajout à la liste via ton manager
            
            adventurerManager.AddNewAdventurer(newHero);

            MessageBox.Show("Aventurier créé avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            adventurerManager.Show();
            this.Close();
            
        }



    }
}
