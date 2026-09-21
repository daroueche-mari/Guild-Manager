using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class ArcherStats
    {
        public static void ShowArcherStats(MainWindow mainWindow, Adventurer myArcher)
        {
            myArcher.Classe = "Archer";
            myArcher.Experience = 0;
            myArcher.Level = 1;
            mainWindow.ClasseArcher.Text = myArcher.Classe;
            mainWindow.ExpArcher.Text = myArcher.Experience.ToString();
            mainWindow.NiveauArcher.Text = myArcher.Level.ToString();
        }
    }
}
