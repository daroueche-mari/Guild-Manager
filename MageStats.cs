using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class MageStats
    {
        public static void ShowMageStats(MainWindow mainWindow, Adventurer myMage)
        {
            myMage.Classe = "Mage";
            myMage.Experience = 0;
            myMage.Level = 1;
            mainWindow.ClasseMage.Text = myMage.Classe;
            mainWindow.ExpMage.Text = myMage.Experience.ToString();
            mainWindow.NiveauMage.Text = myMage.Level.ToString();
        }
    }
}
