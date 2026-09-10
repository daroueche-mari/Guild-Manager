using System;

namespace GuildManager.Model
{
    public class AdventurerSpacial : Adventurer
    {
        string Personnalite{get;set;}

        public AdventurerSpacial(string personnalite, string name, string classe, string race, int niveau, int experience, string inventaire, int bourse, string motivation) : base(name, classe, race, niveau, experience, inventaire, bourse, motivation)
        {
            Personnalite = personnalite;
        }

    }
}