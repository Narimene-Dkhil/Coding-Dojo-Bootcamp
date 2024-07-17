
public class Enemy
{
    public string Name;
    private int health;
    public int _Health {get {return health;}}
    private int maxHealth;
    public int _maxHealth {get {return maxHealth;}}
    public List<Attack> AttackList;

    public Enemy(string n)
    {
        Name = n;
        health = 100;
        maxHealth = 100;
        AttackList = new List<Attack>();
    }

    public Enemy(string n, int h)
    {
        Name = n;
        health = h;
        maxHealth = h;
        AttackList = new List<Attack>();
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        int randomNum = rand.Next(0,AttackList.Count);
        Console.WriteLine($"{Name} performs {AttackList[randomNum].Name}");
        return AttackList[randomNum];
    }

    public virtual void PerformAttack(Player Target, Attack ChosenAttack)
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