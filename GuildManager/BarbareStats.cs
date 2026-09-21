using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class BarbareStats
    {
        public static void ShowBarbareStats(MainWindow mainWindow, Adventurer myBarbare)
        {
            myBarbare.Classe = "Barbare";
            myBarbare.Experience = 0;
            myBarbare.Level = 1;
            mainWindow.ClasseBarbare.Text = myBarbare.Classe;
            mainWindow.ExpBarbare.Text = myBarbare.Experience.ToString();
            mainWindow.NiveauBarbare.Text = myBarbare.Level.ToString();
        }
    }
}
