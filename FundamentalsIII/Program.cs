
using System.Xml;

static void PrintList(List<string> MyList)
{
    foreach (string name in MyList)
    {
        Console.WriteLine(name);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (int num in IntList)
    {
        sum = sum + num;
    }
    Console.WriteLine($"Sum of numbers is: {sum}");
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    for (int i = 1; i <= IntList.Count -1 ; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    }
    return max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
Console.WriteLine(FindMax(TestIntList2));

static List<int> SquareValues(List<int> IntList)
{
    List<int> SquaredValues = new List<int>();
    foreach (int value in IntList)
    {
        SquaredValues.Add(value * value);
    }
    return SquaredValues;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
Console.WriteLine("Squared Values: ");
foreach(int SquareValue in SquareValues(TestIntList3))
{
    Console.WriteLine(SquareValue);
}

static int[] NonNegatives(int[] IntArray)
{
    // int[] noNegs = new int[IntArray.Length];
    for (int i = 0; i <= IntArray.Length-1; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
Console.WriteLine("Array with Negative Values removed: ");
foreach(int value in NonNegatives(TestIntArray))
{
    Console.WriteLine(value);
}

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string, string> datapoint in MyDictionary)
    {
        Console.WriteLine($"{datapoint.Key} - {datapoint.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// }
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> output = new Dictionary<string,int>();
    // if names and ages are not paired up, exit function and report an error
    if (Names.Count != Numbers.Count)
    {
        Console.WriteLine("Names and Ages are not paired up.  Please review input data.");
        output.Add("Errors Detected", 0);
        return output;
    }
    for (int i = 0; i <= Names.Count-1; i ++)
    {
        output.Add(Names[i], Numbers[i]);
    }
    return output;
}
List<int> ages = new List<int>() {6,12,7,10};
List<string> names = new List<string>() {"Julie", "Harold", "James", "Monica"};

foreach (KeyValuePair<string, int> child in GenerateDictionary(names, ages))
{
    Console.WriteLine($"Name: {child.Key} - Age: {child.Value}");
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here






