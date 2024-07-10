class Attack{

    public string Name;
    public int DamageAmount;

    public Attack(string name, int damage){
        Name = name;
        DamageAmount = damage;
    }

    public void ShowAttackInfo(){
        Console.WriteLine($"{Name} causes {DamageAmount}% damage");
    }

}