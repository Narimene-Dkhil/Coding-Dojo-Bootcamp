public class Horse : Vehicle, INeedFuel
{
    public string Name;
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    private int Maxfuel;
    public bool HasEngine = false;

public Horse(string name, string color, string ftype) : base( 1, color)
    {
        Name =name;
        FuelType = ftype;
        FuelTotal = 10;
        Maxfuel = 20;
    }

    public override void Travel(int Amount)
    {
        if(FuelTotal <= 0){
            Console.WriteLine($"{Name} is out of energy! More {FuelType} is required before you can travel ");
        }else {
            if(FuelTotal - Amount <= 0){
                FuelTotal -= Amount;
                int BeforeEmpty = (Amount - (0 - FuelTotal));
                FuelTotal = 0;
                Console.WriteLine($"{Name} Traveled {BeforeEmpty}, {Name} is out of {FuelType}!");
            } else{
                FuelTotal -= Amount;
                Console.WriteLine($"{Name} Traveled {Amount}, energy level is {FuelTotal}.");
            }
        }
    }

    public void GiveFuel(int Amount)
    {
        if(FuelTotal == Maxfuel){
                Console.WriteLine($"{Name} is full! No {FuelType} required!");
        }else {
            if(Amount+FuelTotal >Maxfuel){
                int Fill = Amount -((FuelTotal + Amount) -Maxfuel);
                FuelTotal += Fill;
                Console.WriteLine($"{Fill} bites of {FuelType} given to {Name}. Energy level is now {FuelTotal}");
            } else{
                FuelTotal += Amount;
                Console.WriteLine($"{Amount} bites of {FuelType} given to {Name}. Energy level is now {FuelTotal}");
            }
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Fuel Total: {FuelTotal}");
        Console.WriteLine($"Fuel Type: {FuelType}");
        Console.WriteLine($"Has Engine: {HasEngine}");
    }

}