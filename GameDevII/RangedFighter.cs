using System.Security.Cryptography.X509Certificates;

class RangedFighter : Enemy
{
    public int Distance = 5;
    public RangedFighter(string name) : base(name)
    {
        Attack ShootArrow = new Attack("Shoot Arrow", 20);
        Attack ThrowKnife = new Attack("Throw Knife", 15);
        AttackList.Add(ShootArrow);
        AttackList.Add(ThrowKnife);
    }
    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Distance > 10)
        {
            base.PerformAttack(Target, ChosenAttack);
        }
        else
        {
            Console.WriteLine($"You are {this.Distance} feet from your opponent. You are too close to perform an attack.");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Distance Away: {this.Distance} feet");
    }
    public void Dash()
    {
        this.Distance = 20;
        Console.WriteLine($"{this.Name} is now {this.Distance} feet away");
    }
}