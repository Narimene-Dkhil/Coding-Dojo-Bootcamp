
public class Ranged : Enemy
{

    public int Distance;
    public Ranged(string Name) : base(Name, 120)
    {
        Distance = 5;
        AttackList = new List<Attack>()
            {
                new Attack("Arrow Shot", 20),
                new Attack("Knife Throw", 15)
            };
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Target._Health <= 0)
        {
            Console.WriteLine("Starts to attack but hears someone yell 'Stop! They're already dead!'");
        }
        else
        {
            if (Distance < 10)
            {
                Console.WriteLine("Too Close For Attack!");
            }
            else
            {
                Target.ReduceHealth(ChosenAttack.DamageAmount);
                if (Target._Health > 0)
                {
                    Console.WriteLine($"{Name} attacks {Target.Name} with a {ChosenAttack.Name} causing {ChosenAttack.DamageAmount} damage, reducing {Target.Name}'s health to {Target._Health}!!");
                }
                else if (Target._Health <= 0) { Console.WriteLine($"{Name} deals {Target.Name} his last blow, killing him with a {ChosenAttack.Name}!!"); }
            }
        }
    }

    public void Dash()
    {
        Distance += 20;
        Console.WriteLine($"{Name} dashes back 20 steps to {Distance}");
    }
}