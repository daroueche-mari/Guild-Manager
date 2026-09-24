using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GuildManager.Controls
{
    public class Adventurer
    {
        public string ImagePath { get; set; } = "";
        public string Name { get; set; } = "";
        public int Ameliorate { get; set; } = 0;
        public string Breed { get; set; } = "";
        public string Classe { get; set; } = "";
        public int Level { get; set; } = 1;
        public string Type { get; set; } = "";
        public string Inventory { get; set; } = "";
        public int Power { get; set; } = 0;
        public string Infos { get; set; } = "";

        public Adventurer() { }
        public Adventurer(string imagepath, string name, int ameliorate, string breed, string classe, int level, string type, string infos, string inventory, int power)
        {
            ImagePath = imagepath;
            Name = name;
            Ameliorate = ameliorate;
            Breed = breed;
            Classe = classe;
            Level = level;
            Type = type;
            Infos = infos;
            Inventory = inventory;
            Power = power;
        }



        

        




    }
}
