
MeleeFighter Hercules = new MeleeFighter("Hercules");

Hercules.ShowInfo();

RangedFighter RobinHood = new RangedFighter("Robin Hood");

RobinHood.ShowInfo();

MagicCaster Merlin = new MagicCaster("Merlin");

Merlin.ShowInfo();

Hercules.PerformAttack(RobinHood, Hercules.AttackList[1]);
Hercules.RageAttack(Merlin);
RobinHood.PerformAttack(Hercules,RobinHood.AttackList[0]);
RobinHood.Dash();
RobinHood.PerformAttack(Hercules,RobinHood.AttackList[0]);
Merlin.PerformAttack(Hercules, Merlin.AttackList[0]);
Merlin.Heal(RobinHood);
Merlin.Heal(Merlin);