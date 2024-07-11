public class Coffee : Drink
{
    public bool Whip;
    public string Roast;
    public string Beans;

    public Coffee (string name, string color, string beans, string roast, double temp,int cals, bool whip) : base("Coffee",name,color,temp,false,cals )

    {
        Whip = whip;
        Roast = roast;
        Beans = beans;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("*****Coffee Order*****");
        base.ShowInfo();
        Console.WriteLine($"Add Whip: {Whip}");
        Console.WriteLine($"Bean Type: {Beans}");
        Console.WriteLine($"Roast Type: {Roast}");
        Console.WriteLine("*****End Coffee Order*****");
    }

}