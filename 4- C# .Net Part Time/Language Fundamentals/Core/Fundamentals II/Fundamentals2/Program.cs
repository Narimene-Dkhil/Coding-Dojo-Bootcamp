// 1 - Three Basic Arrays
//Create an integer array with the values 0 through 9 inside.
int[] myArray = {0,1,2,3,4,5,6,7,8,9};
int[] myOtherArray = new int[10];
myOtherArray[0] = 0;
myOtherArray[1] = 1;
myOtherArray[2] = 2;
myOtherArray[3] = 3;
myOtherArray[4] = 4;
myOtherArray[5] = 5;
myOtherArray[6] = 6;
myOtherArray[7] = 7;
myOtherArray[8] = 8;
myOtherArray[9] = 9;

Console.WriteLine("declared array");
foreach(int num in myArray){
    Console.WriteLine(num);
}

Console.WriteLine("pushed array");
foreach(int num in myOtherArray){
    Console.WriteLine(num);
}

//Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] names = {"Tim","Martin","Nikki", "Sara"};
Console.WriteLine("Name Array");
foreach(string name in names){
    Console.WriteLine(name);
}

//Create a boolean array of length 10. Then fill it with alternating true/false values, starting with true. (Tip: do this using logic! Do not hard-code the values in!)
bool[] myTFArray = new bool[10];
myTFArray[0] = true ;
myTFArray[1] = false;
myTFArray[2] = false;
myTFArray[3] = true;
myTFArray[4] = true;
myTFArray[5] = true;
myTFArray[6] = false;
myTFArray[7] = false;
myTFArray[8] = true;
myTFArray[9] = false;

Console.WriteLine("My True/False array");
foreach(bool TF in myTFArray){
    Console.WriteLine(TF);
}

// 2 - List of Flavors
//Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
List<string> iceCreamFlavors = new List<string>();
iceCreamFlavors.Add("Chocolate");
iceCreamFlavors.Add("Rocky Road");
iceCreamFlavors.Add("Cookie Dough");
iceCreamFlavors.Add("Strawberry");
iceCreamFlavors.Add("Mint Chocolate Chip");
iceCreamFlavors.Add("Rainbow");
iceCreamFlavors.Add("Oreo Swirl");
iceCreamFlavors.Add("Vanilla");

//Output the length of the List after you added the flavors.
Console.WriteLine("Length of ice cream flavor list - " + iceCreamFlavors.Count);

//Output the third flavor in the List.
Console.WriteLine("Ice cream flavor #3 - " +iceCreamFlavors[2]);

//Now remove the third flavor using its index location.
iceCreamFlavors.RemoveAt(3);

//Output the length of the List again. It should now be one fewer.
foreach(string flavor in iceCreamFlavors){
    Console.WriteLine("- " + flavor);
}


// 3 - User Dictionary
//Create a dictionary that will store string keys and string values.
Dictionary<string,string> MyDictionary = new Dictionary<string, string>();

//Add key/value pairs to the dictionary where:
//Each key is a name from your names array (this can be done by hand or using logic)
//Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
Random flavorPicker = new Random();

foreach(string name in names){
MyDictionary.Add(name, iceCreamFlavors[flavorPicker.Next(0,7)]);
}

//Loop through the dictionary and print out each user's name and their associated ice cream flavor.
Console.WriteLine("User - Random Ice Cream");
foreach(KeyValuePair<string,string> selection in MyDictionary){
    Console.WriteLine($"{selection.Key} - {selection.Value}");
}



