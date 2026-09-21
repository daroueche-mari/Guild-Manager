using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class PretreStats
    {
        public static void ShowPretreStats(MainWindow mainWindow, Adventurer myPretre)
        {
            myPretre.Classe = "Pretre";
            myPretre.Experience = 0;
            myPretre.Level = 1;
            mainWindow.ClassePretre.Text = myPretre.Classe;
            mainWindow.ExpPretre.Text = myPretre.Experience.ToString();
            mainWindow.NiveauPretre.Text = myPretre.Level.ToString();
        }
    }
}
