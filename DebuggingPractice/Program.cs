// Challenge 1
//bool amProgrammer = "true";  // should be true (without double quotes)

bool amProgrammer = true;
//int Age = 27.9;  // should be rounded to 28, or data type changed to float or double
int Age = 28;
List<string> Names = new List<string>();
// Names = "Monica"; // should be Names.add("Monica")
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
//MyDictionary.Add("Hi there", 0);  // the 0 should be in tick marks since data type is a string
MyDictionary.Add("Hi There", "0");
// This is a tricky one! Hint: look up what a char is in C#
//string MyName = 'MyName';  // single quotes should be changed to double
string MyName = "MyName";

// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
//for(int i = Numbers.Count; i >= 0; i--)
for(int i = Numbers.Count-1; i >= 0; i--)  // index was out of range as provided.  the starting value has to be 1 less than the count
{
    Console.WriteLine(Numbers[i]);
}

// Challenge 3
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    //Console.WriteLine(MoreNumbers[i]);  //when foreach is used, and index value is not required,so just WriteLining i is sufficient
    Console.WriteLine(i);
}

// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
//rewrite as standard for loop to allow re-assigning values during iteration
//foreach(int num in EvenMoreNumbers)
for (int i = 0; i < EvenMoreNumbers.Count; i++)
{
    // if(num % 3 == 0)
    // {
    //     num = 0;
    // }
    if (EvenMoreNumbers[i] % 3 == 0)
    {
        EvenMoreNumbers[i] = 0;
    }
    Console.WriteLine(EvenMoreNumbers[i]);
}
// Challenge 5
// What can we learn from this error message?
// Strings are read only (i.e. immutable) in c#
string MyString = "superduberawesome";
//MyString[7] = "p";

// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(12); // if only 1 value is provided to the Next method, the result will always be less than the number provided.
                                // this is a logic error, and not generally catchable via the debugger
if(randomNum == 12)
{
    Console.WriteLine("Hello");
}

