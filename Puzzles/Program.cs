// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;

static void CoinFlip()
{
    Random rand = new Random();
    int flip = rand.Next(1,3);
    if (flip == 1)
    {
        Console.WriteLine("Heads");
    }
    else
    {
        Console.WriteLine("Tails");
    }
}

CoinFlip();
CoinFlip();
CoinFlip();

static void SixSidedDiceRoll()
{
    Random rand = new Random();
    int roll = rand.Next(1,7);
    Console.WriteLine($"You Rolled a {roll}");
}

SixSidedDiceRoll();

static int DiceRoll(int NumSides)
{
    Random rand = new Random();
    int roll = rand.Next(1,NumSides+1);
    return roll;
}

Console.WriteLine($"You Rolled a {DiceRoll(4)}");
Console.WriteLine($"You Rolled a {DiceRoll(6)}");
Console.WriteLine($"You Rolled a {DiceRoll(8)}");
Console.WriteLine($"You Rolled a {DiceRoll(10)}");
Console.WriteLine($"You Rolled a {DiceRoll(20)}");
Console.WriteLine($"You Rolled a {DiceRoll(100)}");

static List<int> StatRoll(int NumRolls)
{
    List<int> myRolls = new List<int>();
    for (int i = 1; i <= NumRolls; i++)
    {
        myRolls.Add(DiceRoll(20));
    }
    return myRolls;
}

List<int> AllMyRolls = StatRoll(6);
Console.WriteLine("My Rolls were:");
foreach(int roll in AllMyRolls)
{
    Console.WriteLine(roll);
}
Console.WriteLine($"My largest roll was {AllMyRolls.Max()}");

static void RollUntil(int target)
{
    int count = 0;
    int result = 0;
    while (result != target)
    {
        count++;
        result = DiceRoll(6);
    }
    Console.WriteLine($"You Rolled a {target} after {count} attempt(s)");
}

RollUntil(5);
RollUntil(4);
RollUntil(2);