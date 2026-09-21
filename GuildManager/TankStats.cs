using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class TankStats
    {
        public static void ShowTankStats(MainWindow mainWindow, Adventurer myTank)
        {
            myTank.Classe = "Tank";
            myTank.Experience = 0;
            myTank.Level = 1;
            mainWindow.ClasseTank.Text = myTank.Classe;
            mainWindow.ExpTank.Text = myTank.Experience.ToString();
            mainWindow.NiveauTank.Text = myTank.Level.ToString();
        }
    }
}
