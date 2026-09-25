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

        //public void UpLvlAdventurerSelected(int Experience)
        //{
        //    ChoiceCharacter choiceCharacter = new ChoiceCharacter();
        //    if (Experience > 200)
        //    {
        //        choiceCharacter.SelectedAdventurers[0].Level += 1;
        //        choiceCharacter.SelectedAdventurers[1].Level += 1;
        //        choiceCharacter.SelectedAdventurers[2].Level += 1;
        //        Experience = 0;

        //    }
        //}
        //public void UpLvlAdventurerElite(int Experience)
        //{
        //    AdventurerManager adventurerManager = new AdventurerManager();
            
        //    if (Experience < 200)
        //    {
        //        AdventurerManager.MyAdventurersList[0].Level += 1;
        //        AdventurerManager.MyAdventurersList[1].Level += 1;
        //        AdventurerManager.MyAdventurersList[2].Level += 1;
        //        Experience = 0;
        //    }
        //}
    }

}
