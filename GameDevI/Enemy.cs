class Enemy
{
    public string Name;
    private int Health = 100;
    public int _Health
    {
        get { return Health; }
        set { Health = value; }
    }
    public List<Attack> AttackList = new List<Attack>();

    public Enemy(string name)
    {
        Name = name;
    }
    public void ShowInfo(){
        Console.WriteLine("------ Enemy Information ------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Health: {this.Health}");
        Console.WriteLine("List of Attacks:");
        foreach (Attack attack in this.AttackList)
        {
            Console.WriteLine($"{attack.Name} for {attack.DamageAmount} Damage");
        }
    }
    public void RandomAttack()
    {
        Random rand = new Random();
        Attack attack = AttackList[rand.Next(0,AttackList.Count)];
        Console.WriteLine($"The {this.Name} used {attack.Name} for {attack.DamageAmount} damage.");
    }
    public void NewAttack(Attack attack)
    {
        this.AttackList.Add(attack);
    }
}