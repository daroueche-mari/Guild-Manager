using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Basic Adventurer Data Retriever generator

public struct BasicAdventurerData
{
    public Names names {get; set;}
    public List<string> classes {get; set;}
    public List<string> races {get; set;} 
    public PowerCurves power_curves {get; set;}
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
    public List<int> Warrior {get; set;}
    public List<int> Barbarian {get; set;}
    public List<int> Tank {get; set;}
    public List<int> Rogue {get; set;}
    public List<int> Ranger {get; set;}
    public List<int> Mage {get; set;}
    public List<int> Priest {get; set;}
}

public class BasicAdventurerDataRetriever
{
    Random rnd = new Random();
    BasicAdventurerData data;

    // public string name {get; set;}
    // public string advClass {get; set;}
    // public string race {get; set;}
    // public List<int> powerCurve {get; set;}
    // public string pathImage {get; set;}
    // public string motivation {get; set;}


    public BasicAdventurerDataRetriever(BasicAdventurerData basicData)
    {
        this.data = basicData;
        // this.race = data.races[rnd.Next(data.races.Count())];
        // this.name = ChooseName(data.names);
        // this.advClass = data.classes[rnd.Next(data.classes.Count())];
        // this.powerCurve = ChoosePowerCurve(data.power_curves);
        // this.pathImage = ChoosePathImage(data.path_images);
        // this.motivation = data.motivations[rnd.Next(data.motivations.Count())];
    }

    public (string race, string name, string advClass, List<int> powerCurve, string pathImage, string motivation) ReturnBasicAdv()
    {
        string race = this.data.races[rnd.Next(this.data.races.Count())];
        string name = ChooseName(this.data.names, race);
        string advClass = this.data.classes[rnd.Next(this.data.classes.Count())];
        List<int> powerCurve = ChoosePowerCurve(this.data.power_curves, advClass);
        string pathImage = ChoosePathImage(race, advClass);
        string motivation = this.data.motivations[rnd.Next(this.data.motivations.Count())];
        return (race, name, advClass, powerCurve, pathImage, motivation);
    }

    public string ChooseName(Names listsNames, string race)
    {
        var property = typeof(Names).GetProperty(race);
        List<string> listNames = (List<string>)property.GetValue(listsNames);
        string finalName = listNames[rnd.Next(listNames.Count())];
        return finalName;
    }

    public List<int> ChoosePowerCurve(PowerCurves listPowerC, string advClass)
    {
        var property = typeof(PowerCurves).GetProperty(advClass);
        List<int> finalPowerC = (List<int>)property.GetValue(listPowerC);
        return finalPowerC;
    }

    public string ChoosePathImage(string race, string advClass)
    {
        string sourcePath = $"../Assets/Images/Personnages/Aventuriers/{race}/{advClass}";
        int countFiles = System.IO.Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Count();
        string finalImagePath =
        $"../Assets/Images/Personnages/Aventuriers/{race}/{advClass}/Profile_{race}_{advClass}{rnd.Next(1, countFiles+1)}";
        return finalImagePath;
    }
}

// Special Adventurer Data Retriever Generator

public class SpecialAdventurersData
{
    public SpecialAdventurerData Fuchou { get; set;}
    public SpecialAdventurerData Hei_Jiu { get; set;}
    public SpecialAdventurerData Zhiyuan { get; set;}
}

public struct SpecialAdventurerData
{
    public string name {get; set;}
    public string advClass {get; set;}
    public string race {get; set;} 
    public List<int> power_curve {get; set;}
    public string path_image {get; set;}
    public string motivation {get; set;}
}

public class SpecialAdventurerDataRetriever
{
    Random rnd = new Random();
    SpecialAdventurersData specialData;
    SpecialAdventurersData data;

    // public string specialName {get; set;}
    // public string name {get; set;}
    // public string advClass {get; set;}
    // public string race {get; set;}
    // public List<int> powerCurve {get; set;}
    // public string pathImage {get; set;}
    // public string motivation {get; set;}


    public SpecialAdventurerDataRetriever(SpecialAdventurersData specialData)
    {
        this.data = specialData;
        // this.data = ChooseSpecialAdventurer(specialName, specialData);
        // this.race = data.race;
        // this.name = data.name;
        // this.advClass = data.advClass;
        // this.powerCurve = data.power_curve;
        // this.pathImage = data.path_image;
        // this.motivation = data.motivation;
    }

    public (string race, string name, string advClass, List<int> powerCurve, string pathImage, string motivation) ReturnSpecialAdv(string specialName)
    {
        var property = typeof(SpecialAdventurersData).GetProperty(specialName);
        SpecialAdventurerData selectedSpecChar = (SpecialAdventurerData)property.GetValue(this.data);
        string race = selectedSpecChar.race;
        string name = selectedSpecChar.name;
        string advClass = selectedSpecChar.advClass;
        List<int> powerCurve = selectedSpecChar.power_curve;
        string pathImage = $"../Assets/Images/Personnages/Aventuriers Spéciaux/{specialName}";
        string motivation = selectedSpecChar.motivation;
        return (race, name, advClass, powerCurve, pathImage, motivation);
    }

    public List<int> ReturnPowerCurve(List<int> power_curve)
    {
        List<int> powerCurve = new List<int> {};
        foreach (int power in powerCurve) {powerCurve.Add(power);}
        return powerCurve;
    }
}


// Main code

class Retrieve
{
    static void Main ()
    {
        BasicAdventurerData basicData = RetrieveBasicData();

        BasicAdventurerDataRetriever basicAdvRetriever = new BasicAdventurerDataRetriever(basicData);
        var basicAdv1 = basicAdvRetriever.ReturnBasicAdv();
        Console.WriteLine(basicAdv1.name + ", " + basicAdv1.advClass + ", " + basicAdv1.race + ", " +
                          basicAdv1.pathImage + ", " + basicAdv1.motivation);
        Console.WriteLine(string.Join(", ", basicAdv1.powerCurve));
        var basicAdv2 = basicAdvRetriever.ReturnBasicAdv();
        Console.WriteLine(basicAdv2.name + ", " + basicAdv2.advClass + ", " + basicAdv2.race + ", " +
                          basicAdv2.pathImage + ", " + basicAdv2.motivation);
        Console.WriteLine(string.Join(", ", basicAdv2.powerCurve));


        SpecialAdventurersData specialData = RetrieveSpecialData();

        SpecialAdventurerDataRetriever specialAdvRetriever = new SpecialAdventurerDataRetriever(specialData);
        var specialAdv1 = specialAdvRetriever.ReturnSpecialAdv("Fuchou");
        Console.WriteLine(specialAdv1.name + ", " + specialAdv1.advClass + ", " + specialAdv1.race + ", " +
                          specialAdv1.pathImage + ", " + specialAdv1.motivation);
        Console.WriteLine(string.Join(", ", specialAdv1.powerCurve));
        var specialAdv2 = specialAdvRetriever.ReturnSpecialAdv("Zhiyuan");
        Console.WriteLine(specialAdv2.name + ", " + specialAdv2.advClass + ", " + specialAdv2.race + ", " +
                          specialAdv2.pathImage + ", " + specialAdv2.motivation);
        Console.WriteLine(string.Join(", ", specialAdv2.powerCurve));
    }

    public static BasicAdventurerData RetrieveBasicData()
    {
        BasicAdventurerData basicData;
        using (StreamReader r = new StreamReader("./assets/JSON/BasicAdventurers.json"))
        {
            string basicJson = r.ReadToEnd();
            basicData = JsonSerializer.Deserialize<BasicAdventurerData>(basicJson);
        }
        return basicData;
    }

    public static SpecialAdventurersData RetrieveSpecialData()
    {
        SpecialAdventurersData specialData;
        using (StreamReader r = new StreamReader("./assets/JSON/SpecialAdventurers.json"))
        {
            string specialJson = r.ReadToEnd();
            specialData = JsonSerializer.Deserialize<SpecialAdventurersData>(specialJson);
        }
        return specialData;
    }
}
