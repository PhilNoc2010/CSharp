using System.Security.Cryptography.X509Certificates;

class Vehicle
{
    public string Name;
    public int Passengers = 4;
    public string Color;
    public bool HasEngine = true;
    private int Mileage = 0;
    public int _Mileage
    {
        get { return Mileage; }
        set { Mileage = value; }
    }

    public Vehicle(string name, int passengers, string color, bool hasEngine)
    {
        Name = name;
        Passengers = passengers;
        Color = color;
        HasEngine = hasEngine;
    }
    public Vehicle(string name, string color)
    {
        Name = name;
        Color = color;
    }
    public void Travel(int distance)
    {
        this.Mileage = this.Mileage + distance;
        Console.WriteLine($"{this.Name} has traveled {this.Mileage} miles.");
    }
    public void ShowInfo()
    {
        Console.WriteLine("---- Vehicle Info ----");
        Console.WriteLine($"Name: {this.Name}\nNumber of Passengers: {this.Passengers}\nColor: {this.Color}\nHas an Engine: {this.HasEngine}\nMileage: {this.Mileage}");
    }
}