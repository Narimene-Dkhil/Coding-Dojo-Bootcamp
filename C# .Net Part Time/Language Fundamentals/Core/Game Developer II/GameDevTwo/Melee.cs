
public class Melee : Enemy{

    public Melee(string Name) : base(Name, 120)
    {
        AttackList = new List<Attack>()
        {
            new Attack("Punch", 20),
            new Attack("Kick", 15),
            new Attack("Tackle", 25)
        };
    }

    public void Rage(Enemy target){  
        if(this._Health >0)
        {
            if(target._Health <= 0){
                Console.WriteLine($"{this.Name} throws {target.Name}'s lifeless body to the ground");
            } else {
                int RageValue = 10;
                target.ReduceHealth(RageValue);
                Console.WriteLine($"{this.Name} fills with rage and attacks {target.Name}, increasing damage ability by 10...");
                RandomAttack(target);
            }
        } else {Console.WriteLine($"{this.Name} is dead, the only zombies can attack while dead.");
}
    }

}