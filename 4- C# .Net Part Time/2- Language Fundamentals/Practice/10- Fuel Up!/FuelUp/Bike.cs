public class Bike : Vehicle
{
    public string Name;
    public Bike(string name , string color) : base( 1, color)
    {
        Name = name;
    }
}