using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManagerProjet
{
    internal class Adventurer
    {
            public string Name { get; set; }
            public string Classe { get; set; }
            public string Race { get; set; }
            public int Niveau { get; set; }
            public int Experience { get; set; }
            public string Inventaire { get; set; }
            public int Bourse { get; set; }
            public string Motivation { get; set; }

            public Adventurer(string name, string classe, string race, int niveau, int experience, string inventaire, int bourse, string motivation)
            {
                Name = name;
                Classe = classe;
                Race = race;
                Niveau = niveau;
                Experience = experience;
                Inventaire = inventaire;
                Bourse = bourse;
                Motivation = motivation;
            }
        }
}
