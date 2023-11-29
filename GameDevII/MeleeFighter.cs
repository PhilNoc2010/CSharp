class MeleeFighter : Enemy
{
    public MeleeFighter (string name) : base(name)
    {
        _Health = 120;
        Attack Punch = new Attack("Punch", 20);
        Attack Kick = new Attack("Kick", 15);
        Attack Tackle = new Attack("Tackle", 25);
        AttackList.Add(Punch);
        AttackList.Add(Kick);
        AttackList.Add(Tackle);
    }
    public void RageAttack(Enemy Target)
    {
        Random rand = new Random();
        Attack attack = AttackList[rand.Next(0,AttackList.Count)];
        int rageDamage = attack.DamageAmount + 10;
        Target._Health = Target._Health - rageDamage;
        Console.WriteLine($"{this.Name} used {attack.Name} for {rageDamage} damage.");
        Console.WriteLine($"{Target.Name} has {Target._Health} Health remaining");
    }
}