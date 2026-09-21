using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class HeijiuStats
    {
        public static void ShowHeijiuStats(MainWindow mainWindow, AdventurerSpecial myHeijiu)
        {
            myHeijiu.Classe = "Maitre Brasseur";
            myHeijiu.Experience = 0;
            myHeijiu.Level = 1;
            mainWindow.ClasseHeiJiu.Text = myHeijiu.Classe;
            mainWindow.ExpHeiJiu.Text = myHeijiu.Experience.ToString();
            mainWindow.NiveauHeiJiu.Text = myHeijiu.Level.ToString();
        }
    }
}
