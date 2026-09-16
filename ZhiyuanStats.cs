using GuildManagerProjet;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    class ZhiyuanStats
    {
        public static void ShowZhiyuanStats(MainWindow mainWindow, AdventurerSpecial myZhiyuan)
        {
            myZhiyuan.Classe = "Archimage";
            myZhiyuan.Experience = 0;
            myZhiyuan.Level = 1;
            mainWindow.ClasseZhiyuan.Text = myZhiyuan.Classe;
            mainWindow.ExpZhiyuan.Text = myZhiyuan.Experience.ToString();
            mainWindow.NiveauZhiyuan.Text = myZhiyuan.Level.ToString();
        }
    }
}
