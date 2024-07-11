public class Wine : Drink
{
    public string Region;
    public int Year;

    public Wine (string name, string color, double temp, int cals, string region, int year) : base("Wine", name, color, temp, false, cals)
{
    Region=region;
    Year=year;
}

    public override void ShowInfo()
    {
        Console.WriteLine("*****Wine Order*****");
        base.ShowInfo();    
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year Bottled: {Year}");
        Console.WriteLine("*****End Wine Order*****");
    }
}