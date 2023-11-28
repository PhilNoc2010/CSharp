// See https://aka.ms/new-console-template for more information
// using Internal;

int[] numArray = {0,1,2,3,4,5,6,7,8,9};

string[] nameArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};

bool[] boolArray = new bool[10];

for (int i = 0; i < boolArray.Length; i++)
{
    if (i % 2 == 0)
    {
        boolArray[i] = true;
    }
    else
    {
        boolArray[i] = false;
    }
    Console.WriteLine(boolArray[i]);
}
Console.WriteLine("List of Ice Cream Flavors");
List<string> flavors = new List<string>();
flavors.Add("Vanilla");
flavors.Add("Chocolate");
flavors.Add("Strawberry");
flavors.Add("Butterscotch");
flavors.Add("Superman");
flavors.Add("Neopolitan");

Console.WriteLine($"We have a total of {flavors.Count} ice cream flavors.");
Console.WriteLine($"Our most popular flavor is {flavors[2]}");
flavors.RemoveAt(2);
Console.WriteLine($"After selling out, we have a total of {flavors.Count} ice cream flavors.");

Console.WriteLine("A dictionary of users and their favorite Ice Cream Flavors");
Dictionary<string, string> profile = new Dictionary<string, string>();
foreach (string name in nameArray)
{
    Random rand = new Random();
    profile.Add(name, flavors[rand.Next(0,flavors.Count)]);
}

foreach (KeyValuePair<string,string> person in profile)
{
    Console.WriteLine($"{person.Key} - {person.Value}");
}