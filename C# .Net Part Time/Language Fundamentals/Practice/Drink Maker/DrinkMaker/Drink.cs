
public class Drink{

    public string Type;
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;

    public Drink(string type, string name, string color, double temp, bool iscarb, int calories)
    {
        Type=type;
        Name=name;
        Color=color;
        Temperature=temp;
        IsCarbonated= iscarb;
        Calories=calories;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Drink Type: {Type}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Temperature: {Temperature}");
        Console.WriteLine($"Carbonated: {IsCarbonated}");
        Console.WriteLine($"Calories: {Calories}");
    }

}