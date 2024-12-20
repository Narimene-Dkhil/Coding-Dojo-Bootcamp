
// // // Coin Flip

static String FlipCoin(){
    Random rand = new Random();
    int result = rand.Next(1,3);
    if(result == 1){
        return "Heads";
    }
    return "Tails";
}

Console.WriteLine(FlipCoin());


// // // Dice Roll

static int ShakeDice(){
    Random rand = new Random();
    int result = rand.Next(1,7);
    return result;
}

Console.WriteLine(ShakeDice());


// // // Stat Roll

static List<int> ThrowDice(int times){
    Random rand = new Random();
    List<int> results = new List<int>();
    for(int idx = 1; idx<=times; idx++){
        results.Add(rand.Next(1,7));
    }
    return results;
}

Console.WriteLine(string.Join(", ",ThrowDice(8)));


Console.WriteLine("Lets roll for a number!");
// // // Roll Until...

static string RollTil(int MyNum, int diceSides){
    if(MyNum < 1 || MyNum > diceSides){ 
        return $"The number must be between 1 and {diceSides}, Try again!"; 
    }
    Random rand = new Random();
    int count = 1; 
    int result = 0; 
    for(int idx = 0; idx < count; idx++){
        result = rand.Next(1,diceSides+1); 
        Console.WriteLine("you rolled a " + result);
        if(MyNum != result){ 
            Console.WriteLine("Thats " + count + "! Roll again!"); 
            count++; 
        }
    }
    return $"Rolled a {MyNum} after {count} tries"; 
}

Console.WriteLine(RollTil(14, 20));



// // // Optional Bonus!
///////////////////////Create a dice roll game to allow user input to pick dice sides and number to match. 

static string RollTil(int MyNum, int diceSides){
    if(MyNum < 1 || MyNum > diceSides){ 
        return $"The number must be between 1 and {diceSides}, Exiting!"; 
    }
    Random rand = new Random();
    int count = 1; 
    int result = 0; 
    for(int idx = 0; idx < count; idx++){
        result = rand.Next(1,diceSides+1);
        Console.WriteLine("you rolled a " + result);
        if(MyNum != result){ 
            Console.WriteLine("Thats " + count + "! Roll again!"); 
            count++; 
        }
    }
    return $"Rolled a {MyNum} after {count} tries"; 
}


// Pick Sides
Console.WriteLine("Tell me what is the size of dice you want to roll, then hit enter"); 
string SidesInput = Console.ReadLine(); 
int sides = 0; 
if(Int32.TryParse(SidesInput, out int j)){ 
    Console.WriteLine($"The dice size is set to {j}");
    sides = j; 
}
else { 
    Console.WriteLine("C'mon, just give me a dice size, then hit enter.");
    Console.WriteLine("I'll give you one last chance!");
    string SidesInput2 = Console.ReadLine();
    if(Int32.TryParse(SidesInput2, out int i)){ 
        Console.WriteLine($"The dice size is set to {i}");
        sides = i; 
    }else{ 
        Console.WriteLine("Too many invalid entries, Exiting....");
    }
}


// Pick Number
    int numToMatch = 0;
if(sides != 0){
    Console.WriteLine("Type a number to match, then hit enter");
    string NumberInput = Console.ReadLine();
    if(Int32.TryParse(NumberInput, out int j2)){ 
        Console.WriteLine($"The number was {j2}");
        numToMatch = j2; 
    }
    else { 
        Console.WriteLine("C'mon, just give me a number to match, then hit enter.");
        Console.WriteLine("I'll give you one last chance!");
        string NumberInput2 = Console.ReadLine();
        if(Int32.TryParse(NumberInput2, out int i2)){ 
            Console.WriteLine($"The number selected is {i2}");
            numToMatch = i2; 
        }else{
            Console.WriteLine("Too many invalid entries, Exiting....");
        }
    }
    if(numToMatch <= sides){ 
        if(numToMatch !=0 && sides !=0){
            Console.WriteLine(RollTil(numToMatch, sides)); 
        }
    } else {
        Console.WriteLine("Number to Match must not exceed the number of dice sides, Exiting...."); 
    }
}


