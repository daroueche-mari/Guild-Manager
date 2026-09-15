using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManagerProjet
{
    internal class Adventurer
    {
            public string Name { get; set; }
            public int Health { get; set; }
            public string Classe { get; set; }
            public string Breed { get; set; }
            public int Level { get; set; }
            public int Experience { get; set; }
            public string Inventory { get; set; }
            public int Gold { get; set; }
            public string Motivation { get; set; }

            public Adventurer(string name,int health, string classe, string breed, int level, int experience, string inventory, int gold, string motivation)
            {
                Name = name;
                Health = health;
                Classe = classe;
                Breed = breed;
                Level = level;
                Experience = experience;
                Inventory = inventory;
                Gold = gold;
                Motivation = motivation;
            }
        }
}
