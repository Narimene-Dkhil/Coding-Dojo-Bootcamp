public class Player
{
    public string Name;
    private int health;
    public int _Health {get {return health;}}
    private int maxHealth;
    public int _maxHealth {get {return maxHealth;}}
    public List<Attack> AttackList;

    public Player(string n)
    {
        Name = n;
        health = 100;
        maxHealth = 100;
        AttackList = new List<Attack>()
        {
            new Attack("Punch", 15),
            new Attack("Kick", 20),
            new Attack("Lightning", 25),
            new Attack("Shoot Arrow", 15),
        };
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        int randomNum = rand.Next(0,AttackList.Count);
        Console.WriteLine($"{Name} performs {AttackList[randomNum].Name}");
        return AttackList[randomNum];
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if(Target._Health <= 0 || health <= 0)
        {
            Console.WriteLine("Cannot attack");
        } else {
            Target.ChangeHealth(ChosenAttack.DamageAmount);
            Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target._Health}!!");
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void ChangeHealth(int Amount)
    {
        health-=Amount;
        Console.WriteLine($"{Name}'s health is now {health}");
    }


}