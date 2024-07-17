public class Ranged : Enemy
{
    public int Distance;

    public Ranged(string n) : base(n)
    {
        Distance = 5;
        AttackList = new List<Attack>()
        {
            new Attack("Shoot Arrow", 20),
            new Attack("Throw Knife", 15)
        };
    }

    public override void PerformAttack(Player Target, Attack ChosenAttack)
    {
        if(Distance < 10)
        {
            Console.WriteLine("Too close to attack!");
        } else {
            Target.ChangeHealth(ChosenAttack.DamageAmount);
            Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target._Health}!!");
        }
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashed away!");
    }
}