using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class ChevalierStats
    {
        public static void ShowChevalierStats(MainWindow mainWindow, Adventurer myChevalier)
        {
            myChevalier.Classe = "Chevalier";
            myChevalier.Experience = 0;
            myChevalier.Level = 1;
            mainWindow.ClasseChevalier.Text = myChevalier.Classe;
            mainWindow.ExpChevalier.Text = myChevalier.Experience.ToString();
            mainWindow.NiveauChevalier.Text = myChevalier.Level.ToString();
        }
    }
}
