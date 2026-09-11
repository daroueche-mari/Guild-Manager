using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManagerProjet
{
    internal class AdventurerSpecial : Adventurer
    {
        string Personnalite { get; set; }

        public AdventurerSpecial(string personnalite, string name, string classe, string race, int niveau, int experience, string inventaire, int bourse, string motivation) : base(name, classe, race, niveau, experience, inventaire, bourse, motivation)
        {
            Personnalite = personnalite;
        }
    }
}
