
Bike MtnBike = new Bike("My Yeti Mountain Bike", "Black");
Car SchoolBus = new Car("School Bus", 30, "Yellow", "Diesel");
Car Miata = new Car("Miata",2, "Red","Race Gas");
Horse Horse = new Horse("Mr. Ed", "Brown", "Hay");
// Vehicle MyCar = new Vehicle(2, "Red");  // // Cannot create an instance of the abstract type


MtnBike.ShowInfo();
Horse.ShowInfo();
Miata.ShowInfo();
SchoolBus.ShowInfo();

Miata.Travel(20);
Miata.GiveFuel(5);
Miata.GiveFuel(8);
Miata.GiveFuel(8);
Miata.GiveFuel(8);
Horse.Travel(7);
Horse.GiveFuel(5);
Horse.Travel(18);
Horse.GiveFuel(5);
Horse.GiveFuel(10);
Horse.GiveFuel(10);


List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(MtnBike);
AllVehicles.Add(Horse);
AllVehicles.Add(SchoolBus);
AllVehicles.Add(Miata);


List<INeedFuel> FuelRequired = new List<INeedFuel>();

foreach(Vehicle v in AllVehicles)
{
    if( v is INeedFuel){
        FuelRequired.Add((INeedFuel)v);
    }
}

    Console.WriteLine("**********************");
foreach(INeedFuel fuel in FuelRequired)
{
    Console.WriteLine(fuel);
}