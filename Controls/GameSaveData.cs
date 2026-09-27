using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Controls
{
    public class GameSaveData
    {
        public int Gold { get; set; } = 0;
        public int Level { get; set; } = 1;
        public bool IsChapitre5Unlocked { get; set; } = false;
        public bool IsChapitre6Unlocked { get; set; } = false;
        public bool IsChapitre7Unlocked { get; set; } = false;
        public List<Adventurer> Adventurers { get; set; } = new List<Adventurer>();
    }
}
