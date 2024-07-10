
// 1 - Create at least 4 different vehicles using any of the constructors (use each constructor at least once)

Vehicle Truck = new Vehicle("Dodge Truck", "White");
Vehicle Outback = new Vehicle("Subaru Outback" ,4 ,"Grey",true);
Vehicle MtnBike = new Vehicle("Yeti Mountain Bike", 1, "Black", false);
Vehicle SchoolBus = new Vehicle("School Bus", 30, "Yellow", true);

// 2 - Put all the vehicles you created into a List

List<object> MyVehicals = new List<object>();
MyVehicals.Add(Truck);
MyVehicals.Add(Outback);
MyVehicals.Add(MtnBike);
MyVehicals.Add(SchoolBus);

// 3 - Loop through the List and have each vehicle run its ShowInfo() method

foreach(Vehicle v in MyVehicals){
    v.ShowInfo();
}

// 4 - Make one of the vehicles Travel 100 miles

Truck.Travel(100);

// 5 - Print the information of the vehicle to verify the distance traveled went up

Truck.ShowInfo();

