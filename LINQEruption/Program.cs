using System.Runtime.CompilerServices;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!
Eruption? chileanEruption = eruptions.FirstOrDefault(l => l.Location == "Chile");
Console.WriteLine(chileanEruption.ToString());

Eruption? hawaiianEruption = eruptions.FirstOrDefault(l => l.Location == "Hawaiian Is");
if (hawaiianEruption == null)
{
    Console.WriteLine("No Hawaiian Eruption Found");
}
else
{
    Console.WriteLine(hawaiianEruption.ToString());
}

Eruption? greenlandEruption = eruptions.FirstOrDefault(l => l.Location == "Greenland");
if (greenlandEruption == null)
{
    Console.WriteLine("No Greenland Eruptions on Record.");
}
else
{
    Console.WriteLine(greenlandEruption.ToString());
}


Eruption? nzEruption = eruptions.Where(l => l.Location == "New Zealand").OrderBy(y => y.Year).FirstOrDefault(y => y.Year > 1900);
Console.WriteLine("First Eruption in New Zealand after 1900:");
Console.WriteLine(nzEruption.ToString());

IEnumerable<Eruption> tallEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(tallEruptions, "Eruptions over 2000 meters:");

IEnumerable<Eruption> lNames = eruptions.Where(v => v.Volcano.StartsWith("L"));
PrintEach(lNames, "Volcanoes starting with L");
Console.WriteLine($"{lNames.Count()} volcanoes starting with L were found");

int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"the highest Elevation is {highestElevation} meters");

string? highestVolcano = eruptions.FirstOrDefault(e => e.ElevationInMeters == highestElevation).Volcano;
Console.WriteLine($"The highest volcano is {highestVolcano}");

IEnumerable<Eruption> alphabeticalEruptions = eruptions.OrderBy(v => v.Volcano);
PrintEach(alphabeticalEruptions, "Alphabetical Eruptions");

int sumOfElevations = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Combined elevation for all eruptions: {sumOfElevations} meters");

List<Eruption> Y2KEruption = eruptions.Where(y => y.Year == 2000).ToList();
if (!Y2KEruption.Any())
{
    Console.WriteLine("No Eruptions in the year 2000");
}
else
{
    PrintEach(Y2KEruption, "Eruptions in the Year 2000:");
}

IEnumerable<Eruption> Take3StratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(Take3StratovolcanoEruptions,"Three Strato Volcano Eruptions");

IEnumerable<Eruption> ancientEruptions = eruptions.Where(y => y.Year < 1000).OrderBy(v => v.Volcano);
PrintEach(ancientEruptions, "Eruptions before the year 1000 CE");

List<string> strAncientEruptions = eruptions.Where(y => y.Year < 1000).OrderBy(v => v.Volcano).Select(v => v.Volcano).ToList();
Console.WriteLine("Ancient Eruptions as Strings:");
foreach(string v in strAncientEruptions)
{
    Console.WriteLine(v);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
