
public class MagicCaster : Enemy
{

Attack Fireball = new Attack("Fireball", 25);
    public MagicCaster(string Name) : base(Name, 80)
    {
        AttackList = new List<Attack>()
        {
            Fireball,
            new Attack("Lightning Bolt", 20),
            new Attack("Staff Strike", 10)
        };
    }

    public void Heal(Enemy Target)
    {
        if(this._Health <= 0){
            Console.WriteLine($"{this.Name} is dead, there is no healing that. Health is still 0");
        } 
        else if(Target._Health <= 0){
            Console.WriteLine($"{this.Name}, {Target.Name} is dead, there is no healing that. Health is still 0");
        }
        else {
            if(Target._Health >= Target._MaxHealth){
                Console.WriteLine($"{Target.Name}'s health is already at maximum of {_MaxHealth}");
            } else{
                Target.ReduceHealth(-40);
                Console.WriteLine($"{Target.Name}'s health is increased by 40 to {Target._Health}");
            }
        }
    }


}