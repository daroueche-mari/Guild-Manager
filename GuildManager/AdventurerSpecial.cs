using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManagerProjet
{
    internal class AdventurerSpecial : Adventurer
    {
        string Personnality { get; set; }

        public AdventurerSpecial(string personnality, string name, int health, string classe, string breed, int level, int experience, string inventory, int gold, string motivation) : base(name, health , classe, breed, level, experience, inventory, gold, motivation)
        {
            Personnality = personnality;
        }
    }
}
