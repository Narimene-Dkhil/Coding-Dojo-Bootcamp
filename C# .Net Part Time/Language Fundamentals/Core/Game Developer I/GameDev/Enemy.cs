
class Enemy{

    public string Name;
    private int Health;
    public int _Health {get { return Health; }}
    public List<Attack> AttackList;


    public Enemy(string name){
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }


    public Attack RandomAttack(){
        Random rand = new Random();
        int randomNum = rand.Next(0,AttackList.Count);
        Console.WriteLine($"{Name} is attacked with a {AttackList[randomNum].Name}");
        Health -= AttackList[randomNum].DamageAmount;
        return AttackList[randomNum];
    }

    public Attack AddAttack(Attack name){
        AttackList.Add(name);
        return name;
    }
    public void ShowInfo(){
        Console.WriteLine($"{Name} is at {Health}% health");
        foreach(Attack action in AttackList){
            Console.WriteLine($"{action.Name} causes {action.DamageAmount}% damage");
        }
    }
    public void ShowHealth(){
        if(Health > 0){
            Console.WriteLine($"{Name} is at {Health}% health");
        } else{
            Console.WriteLine($"{Name} was not fit for this fast paced enviroment and has died.");
        
        }
    }
}