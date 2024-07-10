//Create an instance of Enemy
Enemy Guard = new Enemy("Guard");
// Guard.ShowInfo();

//Create instances of Attack:
Attack Punch = new Attack("Punch", 10);
Guard.AddAttack(Punch);
Attack Kick = new Attack("Kick", 15);
Guard.AddAttack(Kick);
Attack FireBall = new Attack("Fire Ball", 25);
Guard.AddAttack(FireBall);

//Add these attacks to the enemy's AttackList:
Guard.AddAttack(Punch);
Guard.AddAttack(Kick);
Guard.AddAttack(FireBall);

//Display enemy information and perform random attacks:

Guard.ShowInfo();

Guard.RandomAttack();
Guard.ShowHealth();
Guard.RandomAttack();
Guard.ShowHealth();
Guard.RandomAttack();
Guard.ShowHealth();
Guard.RandomAttack();
Guard.ShowHealth();
Guard.RandomAttack();
Guard.ShowHealth();
Guard.RandomAttack();
Guard.ShowHealth();