using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuildManager.Controls
{
    public class Joueur : INotifyPropertyChanged
    {
        // 1. Singleton propre (lecture seule depuis l'extérieur)
        private static Joueur? _instance;
        public static Joueur Instance => _instance ??= new Joueur();

        private int _gold = 50;
        private int _experience = 10;
        private int _level = 1;

        // Constructeur privé pour empêcher de faire "new Joueur()" ailleurs dans le code
        private Joueur() { }

        public int Gold
        {
            get => _gold;
            set
            {
                if (_gold != value)
                {
                    _gold = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Experience
        {
            get => _experience;
            set
            {
                if (_experience != value)
                {
                    _experience = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }

        public void UpLvl()
        {
            
            if (Experience > 200)
            {
                Level += 1;
                Experience = 0;
            }
        }

        // Événement pour mettre à jour l'affichage WPF automatiquement
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}