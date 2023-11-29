
Attack StrongPunch = new Attack("Shor-u-ken", 20);
Attack StrongKick = new Attack("Sweeping Leg Kick", 10);
Attack StrongBlast = new Attack("Had-u-ken", 10);
Attack WeakPunch = new Attack("Punch", 5);
Attack WeakKick = new Attack("Kick", 3);
Attack WeakBlast = new Attack("Spit", 4);

Enemy Bandit = new Enemy("Bandit");
Enemy Guard = new Enemy("City Guard");
Enemy Boss = new Enemy("Mafia Boss");

Bandit.AttackList.Add(StrongPunch);
Bandit.AttackList.Add(StrongKick);
Bandit.AttackList.Add(WeakBlast);

Guard.AttackList.Add(StrongPunch);
Guard.AttackList.Add(StrongBlast);
Guard.AttackList.Add(WeakPunch);

Boss.AttackList.Add(StrongBlast);
Boss.AttackList.Add(WeakBlast);
Boss.AttackList.Add(StrongKick);

Bandit.ShowInfo();
Guard.ShowInfo();
Boss.ShowInfo();

Bandit.RandomAttack();
Bandit.RandomAttack();
Bandit.RandomAttack();

Bandit.NewAttack(StrongBlast);
Bandit.ShowInfo();