class Vehicle
{
    //Fields
    string Name;
    int Passengers;
    string Color;
    bool HasEngine;
    int MilesTraveled=0;

    //GETTERS AND SETTERS

    public string _Name
    {
        get{ return Name; }
        set{ Name = value; }
    }

    public int _Passengers
    {
        get{ return Passengers; }
        set{ Passengers = value; }
    }

    public string _Color
    {
        get{ return Color; }
        set{ Color = value; }
    }

    public bool _HasEngine
        {
        get{ return HasEngine; }
        set{ HasEngine = value; }
    }

    public int _MilesTraveled
        {
        get{ return MilesTraveled; }
        set{ MilesTraveled += value; }
    }

    //Constructors
    public Vehicle(string name, int passengers, string color, bool hasEngine){
        Name = name;
        Passengers = passengers;
        Color = color;
        HasEngine = hasEngine;
        MilesTraveled = 0;
    }

    public Vehicle(string name, string color){
    Name = name;
    Color = color;
    Passengers = 4;
    HasEngine = true;
    MilesTraveled = 0;
    }

    // METHODS

    public void ShowInfo(){
        Console.WriteLine($"{Name} is {Color} and holds {Passengers} passengers. Powered by an engine? {HasEngine}, Logged Miles: {MilesTraveled}");
    }

    public void Travel(int value){
        MilesTraveled += value;
        Console.WriteLine($"{Name} traveled {value} miles and now has a total of {MilesTraveled} miles");
    }

}