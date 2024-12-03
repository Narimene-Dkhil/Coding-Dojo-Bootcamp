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
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions:");
// Execute Assignment Tasks here!




//Assignment:

// 1 - Use LINQ to find the first eruption that is in Chile and print the result.
IEnumerable<Eruption> FirstChileErupt = eruptions.Where(c => c.Location == "Chile").OrderBy(y => y.Year).Take(1);
PrintEach(FirstChileErupt, "First Chile Eruption");

// 2 - Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
IEnumerable<Eruption> FirstHIErupt = eruptions.Where(e => e.Location == "Hawaiian Is").OrderBy(y => y.Year).Take(1);
if(FirstHIErupt.Any() == false)
    {
        Console.WriteLine("No Hawaiian Is Eruption Found.");
    }
    else
    {
        PrintEach(FirstHIErupt, "First Hawaiian Is Eruption.");
    }


// 3 - Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
IEnumerable<Eruption> Greenland = eruptions.Where(e => e.Location == "Greenland").OrderBy(y => y.Year).Take(1);
if(Greenland.Any() == false)
    {
        PrintEach(Greenland, "No Greenland Eruption Found.");
    }
    else
    {
        PrintEach(Greenland, "First Greenland Eruption.");
    }


// 4 - Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> First1900Eruption = eruptions.Where(e => e.Year >1900 && e.Location == "New Zealand").OrderBy(y => y.Year).Take(1);
PrintEach(First1900Eruption, "First Eruption after 1900");


// 5 - Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> Over2000m = eruptions.Where(m => m.ElevationInMeters >2000);
PrintEach(Over2000m, "Eruption Over 2000m");


// 6 - Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> StartsL = eruptions.Where(n => n.Volcano.StartsWith("L"));
PrintEach(StartsL, "Name starts with 'L'");
Console.WriteLine($"Volcanos that start with an L = {StartsL.Count()}");


// 7 - Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int Tallest = eruptions.Max(h => h.ElevationInMeters);
Console.WriteLine($"The Highest Elevation volcano is at: {Tallest} meters");

// 8 - Use the highest elevation variable to find and print the name of the Volcano with that elevation.
IEnumerable<Eruption> TallestName = eruptions.Where(m => m.ElevationInMeters == Tallest);
foreach(Eruption t in TallestName){
Console.WriteLine($"The Highest Elevation volcano is: {t.Volcano}");
}


// 9 - Print all Volcano names alphabetically.
IEnumerable<Eruption> AllAlphabetically = eruptions.OrderBy(v => v.Volcano);
PrintEach(AllAlphabetically, "All Volcano's alphabetically");


// 10 - Print the sum of all the elevations of the volcanoes combined.
int TotalElevation = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Total sum of the volcano elevations = {TotalElevation} meters");


// 11 - Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool AnyAfter2000 = eruptions.Any(d => d.Year == 2000);
if(AnyAfter2000 == true)
{
    Console.WriteLine("Yes Volcanos erupted in the year 2000");
}
else
{
    Console.WriteLine("No Volcanos erupted in the year 2000");
}


// 12 - Find all stratovolcanoes and print just the first three (Hint: look up Take)
IEnumerable<Eruption> top3StratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(top3StratovolcanoEruptions, "Stratovolcano eruptions.");


// 13 - Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> before1000CE = eruptions.Where(e => e.Year <1000).OrderBy(n => n.Volcano);
PrintEach(before1000CE, "Eruptions before 1000 ce alphabetically");


// 14 - Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
List<string> VolcanoNames = eruptions.Where(e => e.Year <1000).OrderBy(n => n.Volcano).Select(c => c.Volcano).ToList();
foreach(string n in VolcanoNames){
    Console.WriteLine(n);
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
