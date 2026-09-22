using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager
{
    public class Joueur
    {
        public static Joueur Instance { get; set; } = new Joueur();
        public int Gold { get; set; } = 50;
        public int Experience { get; set; } = 10;
        public int Level { get; set; } = 1;

        public Joueur(){}

        public void UpLvl()
        {
            if (Experience > 200)
            {
                Level += 1;
                Experience = 0;
            }
        }
    }

    
}
