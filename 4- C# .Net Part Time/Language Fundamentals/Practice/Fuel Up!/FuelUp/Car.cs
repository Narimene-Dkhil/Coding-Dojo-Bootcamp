public class Car : Vehicle, INeedFuel
{
    public string Name;
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    private int Maxfuel;
    bool HasEngine;

public Car(string name, int passengers, string color, string ftype) : base( passengers, color)
    {
    Name =name;
    FuelType = ftype;
    FuelTotal = 10;
    Maxfuel = 20;
    HasEngine = true;
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
                Console.WriteLine($"{Name} Traveled {Amount}, fuel level is {FuelTotal}.");
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
                Console.WriteLine($"{Fill} litre(s) of {FuelType} put into {Name}. Level is now {FuelTotal}");
            } else{
                FuelTotal += Amount;
                Console.WriteLine($"{Amount} litre(s) of {FuelType} put into {Name}. Level is now {FuelTotal}");
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