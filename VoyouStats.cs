using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class VoyouStats
    {
        public static void ShowVoyouStats(MainWindow mainWindow, Adventurer myVoyou)
        {
            myVoyou.Classe = "Voyou";
            myVoyou.Experience = 0;
            myVoyou.Level = 1;
            mainWindow.ClasseVoyou.Text = myVoyou.Classe;
            mainWindow.ExpVoyou.Text = myVoyou.Experience.ToString();
            mainWindow.NiveauVoyou.Text = myVoyou.Level.ToString();
        }
    }
}
