
Coffee BlackCoffee = new Coffee("Black Coffee", "Black","Arabica", "Dark" , 100, 0, false);
Soda MtDew = new Soda("Mt. Dew", "Yellow", false, 30, 180);
Wine Merlot = new Wine("Merlot", "Red", 40, 122, "Napa Valley", 2019);


List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(BlackCoffee);
AllBeverages.Add(MtDew);
AllBeverages.Add(Merlot);

foreach(Drink d in AllBeverages)
{
    d.ShowInfo();
}





// These are invalid because we cannot make instances across child classes
// Coffee MyDrink = new Soda(); // // error CS7036: There is no argument given that corresponds to the required formal parameter 'name' of 'Soda.Soda(string, string, bool, double, int)'
// Coffee MyDrink = new Soda("Coke", "Brown", false, 30, 190); // // Cannot implicitly convert type 'Soda' to 'Coffee'// See https://aka.ms/new-console-template for more information

