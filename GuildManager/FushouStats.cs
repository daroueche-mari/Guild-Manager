using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    internal class FushouStats
    {
        public static void ShowFushouStats(MainWindow mainWindow, AdventurerSpecial myFushou)
        {
            myFushou.Classe = "Berserker";
            myFushou.Experience = 0;
            myFushou.Level = 1;
            mainWindow.ClasseFushou.Text = myFushou.Classe;
            mainWindow.ExpFushou.Text = myFushou.Experience.ToString();
            mainWindow.NiveauFushou.Text = myFushou.Level.ToString();
        }
    }
}
