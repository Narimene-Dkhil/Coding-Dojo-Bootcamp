
public class Enemy{

    public string Name;
    private int Health;
    public int _Health {get { return Health; }}
    private int MaxHealth;
    public int _MaxHealth {get { return MaxHealth; }}

    public List<Attack> AttackList;


    public Enemy(string name){
        Name = name;
        Health = 100;
        MaxHealth = Health;
        AttackList = new List<Attack>();
    }

    public Enemy(string name, int health){
        Name = name;
        Health = health;
        MaxHealth = Health;
        AttackList = new List<Attack>();
    }


    public virtual void AddAttack(Attack name){ 
        AttackList.Add(name);
        
    }
    public virtual void ShowInfo(){
        Console.WriteLine($"{this.Name} is at {Health}% health");
        foreach(Attack action in AttackList){
            Console.WriteLine($"{this.Name} can {action.Name} and causes {action.DamageAmount}% damage");
        }
    }
    public virtual void ShowHealth(){
        if(Health > 0){
            Console.WriteLine($"{Name} is at {Health}% health");
        } else{
            Console.WriteLine($"{Name} was not fit for this fast paced enviroment and has died.");
        
        }
    }

        public virtual void RandomAttack(Enemy target){  
        if(this._Health <= 0){
            Console.WriteLine($"{this.Name} is dead, the only zombies can attack while dead.");
        } else {
            Random rand = new Random();
            int randomNum = rand.Next(0,AttackList.Count);
            if(target.Health <= 0){
                Console.WriteLine($"Starts to {AttackList[randomNum].Name} but hears someone yell 'Stop! They're already dead!'");
            } else{
                this.PerformAttack(target,AttackList[randomNum]);
                // Console.WriteLine($"The {this.Name} attackes the {target.Name} with a {AttackList[randomNum].Name}");
                // target.ReduceHealth(AttackList[randomNum].DamageAmount);
                // Console.WriteLine($"{Name} attacks {target.Name}, with a {AttackList[randomNum].Name} dealing {AttackList[randomNum].DamageAmount} damage and reducing {target.Name}'s health to {target.Health}");
                // target.ShowHealth();
                // return AttackList[randomNum];
            }
        }
    }

    public virtual void PerformAttack(Enemy target, Attack ChosenAttack)
    {
        if(this._Health <= 0){
            Console.WriteLine($"{this.Name} is dead, the only zombies can attack while dead.");
        } else {
            if(target.Health <= 0){
                Console.WriteLine($"{this.Name} starts to attack {target.Name} but hears someone yell 'Stop! They're already dead!'");
            } else{
                target.ReduceHealth(ChosenAttack.DamageAmount);
                if(target._Health >0){
                    Console.WriteLine($"{Name} attacks {target.Name}, with a {ChosenAttack.Name} dealing {ChosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!!");
                } else if(target._Health <=0) {Console.WriteLine($"{Name} deals {target.Name} his last blow, killing him with a {ChosenAttack.Name}!!");}
            }
        }
    }

    public void ReduceHealth(int Amount)
    {
        if(this.Health < 0){
            Console.WriteLine("Starts to attack but hears someone yell 'Stop! They're already dead!'");
        } else if(Health > _MaxHealth){ 
            Health = MaxHealth;
            Console.WriteLine($"Maximum Health Level Of {_MaxHealth} has been reached!");
        }else{
        Health-= Amount;
        }
    }
}