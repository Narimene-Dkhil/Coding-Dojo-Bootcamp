public class Soda : Drink
{
    public bool Diet;

    public Soda (string name, string color, bool diet, double temp, int cals) : base("Soda", name, color, temp, true, cals)

    {
        Diet = diet;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("*****Soda Order*****");
        base.ShowInfo();    
        Console.WriteLine($"Diet: {Diet}");
        Console.WriteLine("*****End Soda Order*****");
    }
}