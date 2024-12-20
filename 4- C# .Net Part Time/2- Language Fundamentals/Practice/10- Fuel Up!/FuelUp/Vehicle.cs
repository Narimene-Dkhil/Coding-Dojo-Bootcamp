
public abstract class Vehicle{

    int Passengers;
    string Color;
    int MilesTraveled = 0;

    public Vehicle(int passengers, string color){
        Passengers = passengers;
        Color = color;
        MilesTraveled = 0;
    }

        public Vehicle( string color){
        Color = color;
        Passengers = 4;
        MilesTraveled = 0;
    }

    public virtual void ShowInfo(){
        Console.WriteLine($"{Color} and holds {Passengers} passengers. Logged Miles: {MilesTraveled}");
    }

    public virtual void Travel(int value){
        MilesTraveled += value;
        Console.WriteLine($"Traveled {value} miles and now has a total of {MilesTraveled} miles");
    }

}