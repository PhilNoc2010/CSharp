// See https://aka.ms/new-console-template for more information

Console.WriteLine("All numbers 1 to 255");
for (int i = 1 ; i <= 255; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("Five Random Numbers from 10 to 20");
Random rand = new Random();
for (int j = 1 ; j <=5 ; j++)
{
    Console.WriteLine(rand.Next(10,21));
}

Console.WriteLine("Five Random Numbers from 10 to 20 added together");
int sum = 0;
for (int j = 1 ; j <=5 ; j++)
{
    sum = sum + rand.Next(10,21);
}
Console.WriteLine(sum);

Console.WriteLine("printing multiples of 3 or 5, but not both");
for (int k = 1; k <=100; k++)
{
    if (k % 3 == 0 || k % 5 == 0)
    {
        if (k % 3 != 0 || k % 5 != 0)
        {
            Console.WriteLine(k);
        }
    }
}

Console.WriteLine("Fizz for Multiples of 3, Buzz for multiples of 5, FizzBuzz if both");
for (int m = 1; m <= 100; m++)
{
    if (m % 3 == 0 && m % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (m % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (m % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(m);
        }
}

