using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManagerProjet
{
    public class Adventurer
    {
            public string Nom { get; set; }
            public string Classe { get; set; }
            public string ImagePath { get; set; }

        public Adventurer(string nom, string classe, string imagePath)
            {
                Nom = nom;
                Classe = classe;
                ImagePath = imagePath;
            }
        


    }
}
