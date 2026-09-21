using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public struct AdventurerData
{
    public Names names {get; set;}
    public List<string> classes {get; set;}
    public List<string> races {get; set;} 
    public PowerCurves power_curves {get; set;}
    public string path_images {get; set;}
    public List<string> motivations {get; set;}
}

public class Names
{
    public List<string> Human {get; set;}
    public List<string> Elf {get; set;}
    public List<string> Dwarf {get; set;}
}

public class PowerCurves
{
    // public List<int> Default {get; set;}
    // "Default" : [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19, 21, 23],
    public List<int> Warrior {get; set;}
    public List<int> Barbarian {get; set;}
    public List<int> Tank {get; set;}
    public List<int> Rogue {get; set;}
    public List<int> Ranger {get; set;}
    public List<int> Mage {get; set;}
    public List<int> Priest {get; set;}
}

public class Adventurer
{
    Random rnd = new Random();
    AdventurerData data;

    public string name {get; set;}
    public string advClass {get; set;}
    public string race {get; set;}
    public List<int> powerCurve {get; set;}
    public string motivation {get; set;}


    public Adventurer(AdventurerData data)
    {
        this.data = data;
        int raceChoice = rnd.Next(data.races.Count());
        this.race = data.races[raceChoice];
        this.name = ChooseName(raceChoice, data.names);
        int classChoice = rnd.Next(data.classes.Count());
        this.advClass = data.classes[classChoice];
        this.powerCurve = ChoosePowerCurve(classChoice, data.power_curves);
        // this.path_image = "";
        this.motivation = data.motivations[rnd.Next(data.motivations.Count())];
    }

    public string ChooseName(int raceChoice, Names listsNames)
    {
        var properties = typeof(Names)
            .GetProperties()
            .Where(p => p.PropertyType == typeof(List<string>))
            .ToList();
        var property = properties[raceChoice];
        List<string> listNames = (List<string>)property.GetValue(listsNames);
        string finalName = listNames[rnd.Next(listNames.Count())];
        return finalName;
    }

    public List<int> ChoosePowerCurve(int classChoice, PowerCurves listPowerC)
    {
        var properties = typeof(PowerCurves)
            .GetProperties()
            .Where(p => p.PropertyType == typeof(List<int>))
            .ToList();
        var property = properties[classChoice];
        List<int> finalPowerC = (List<int>)property.GetValue(listPowerC);
        return finalPowerC;
    }
}


class Retrieve
{
    static void Main ()
    {
        AdventurerData source;

        using (StreamReader r = new StreamReader("./assets/JSON/BasicAdventurers.json"))
        {
            string json = r.ReadToEnd();
            source = JsonSerializer.Deserialize<AdventurerData>(json);
        }

        Adventurer adv1 = new Adventurer(source);
        Console.WriteLine(adv1.name);
        Console.WriteLine(adv1.advClass);
        Console.WriteLine(adv1.race);
        Console.WriteLine(string.Join(", ", adv1.powerCurve));
        // Console.WriteLine(adv1.powerCurve);
        Console.WriteLine(adv1.motivation);
    }
}
