public class Melee : Enemy
{
    public Melee(string n) : base(n, 120)
    {
        AttackList = new List<Attack>()
        {
            new Attack("Punch", 20),
            new Attack("Kick", 15),
            new Attack("Tackle", 25),
        };
    }

    public void Rage(Enemy Target)
    {
        Attack randomAttack = RandomAttack();
        int dmgAmount = randomAttack.DamageAmount + 10;
        Target.ChangeHealth(dmgAmount);
    }
}