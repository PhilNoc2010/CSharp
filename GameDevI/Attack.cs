class Attack
{
    public string Name;
    public int DamageAmount;

    public Attack(string name, int damageAmount)
    {
        Name = name;
        DamageAmount = damageAmount;
    }
    public void ShowInfo()
    {
        Console.WriteLine("------ Enemy Information ------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Damage Amount: {this.DamageAmount}");
    }
}