public class MagicCaster : Enemy
{
    public MagicCaster(string n) : base(n, 80)
    {
        AttackList = new List<Attack>()
        {
            new Attack("Fireball", 25),
            new Attack("Lightning", 20),
            new Attack("Staff Strike", 10)
        };
    }

    public void Heal(Enemy Target)
    {
        if((Target._Health + 40) > Target._maxHealth)
        {
            int difference = (Target._maxHealth - Target._Health) * -1;
            Target.ChangeHealth(difference);
        } else {
            Target.ChangeHealth(-40);
        }
        Console.WriteLine($"{Name} heals {Target.Name} to {Target._Health} hp!");
    }
}