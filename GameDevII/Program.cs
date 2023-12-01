
MeleeFighter Hercules = new MeleeFighter("Hercules");

Hercules.ShowInfo();

RangedFighter RobinHood = new RangedFighter("Robin Hood");

RobinHood.ShowInfo();

MagicCaster Merlin = new MagicCaster("Merlin");

Merlin.ShowInfo();

Hercules.PerformAttack(RobinHood, "Kick");
Hercules.RageAttack(Merlin);
RobinHood.PerformAttack(Hercules,"Shoot Arrow");
RobinHood.Dash();
RobinHood.PerformAttack(Hercules,"Shoot Arrow");
Merlin.PerformAttack(Hercules, "Fireball");
Merlin.Heal(RobinHood);
Merlin.Heal(Merlin);