class MagicCaster : Enemy
{
    public MagicCaster(string name) : base(name)
    {
        _Health = 80;
        Attack Fireball = new Attack("Fireball", 25);
        Attack LightningBolt = new Attack("Lightning Bolt", 20);
        Attack StaffStrike = new Attack("Staff Strike", 10);
        AttackList.Add(Fireball);
        AttackList.Add(LightningBolt);
        AttackList.Add(StaffStrike);
    }
    public void Heal(Enemy Target)
    {
        Target._Health = Target._Health + 40;
        Console.WriteLine($"{Target.Name} now has {Target._Health} Health.");
    }

}