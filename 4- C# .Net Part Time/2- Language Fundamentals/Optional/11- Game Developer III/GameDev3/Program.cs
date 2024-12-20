// Welcome player
Console.WriteLine("Welcome! What is your name:");
string InputLine = Console.ReadLine();
Player player = new Player(InputLine);
Console.WriteLine($"Welcome {player.Name}!");
Console.WriteLine("Prepare for battle!");

// Create the enemy
Melee EnemyFighter = new Melee("Enemy");
Console.WriteLine("You will be fighting a melee character");

void GameLoop()
{
    int round = 1;
    while(player._Health > 0 && EnemyFighter._Health > 0)
    {
        Console.WriteLine($"*********** Round {round} ****************");
        Console.WriteLine("*************** Select Move *****************");
        for(int i = 0; i < player.AttackList.Count; i++)
        {
            Console.WriteLine($"{i} - {player.AttackList[i].Name}");
        }
        Console.WriteLine("Type your number choice");
        string choice = Console.ReadLine();
        if(Int32.TryParse(choice, out int j))
        {
            if(j < player.AttackList.Count && j > -1)
            {
                player.PerformAttack(EnemyFighter, player.AttackList[j]);
            } else {
                Console.WriteLine("Invalid choice, turn skipped");
            }
        } else {
            Console.WriteLine("Invalid choice, turn skipped");
        }

        Attack rand = EnemyFighter.RandomAttack();
        EnemyFighter.PerformAttack(player, rand);
        Console.WriteLine("********** RESULTS OF THE ROUND ************");
        Console.WriteLine($"***** {player.Name}'s health: {player._Health} *******");
        Console.WriteLine($"***** {EnemyFighter.Name}'s health: {EnemyFighter._Health} *******");
        round++;
    }
}

GameLoop();
CheckResults();

void CheckResults()
{
    if(player._Health <= 0)
    {
        Console.WriteLine("Enemy wins!");
    } else {
        Console.WriteLine("You win!");
    }

    Console.WriteLine("Would you like to play again? Type:");
    Console.WriteLine("yes");
    Console.WriteLine("no");
    string PlayAgain = Console.ReadLine();
    if(PlayAgain.ToLower() == "yes")
    {
        // Restart the game
        Console.WriteLine("Playing again");
        player.ResetHealth();
        EnemyFighter.ResetHealth();
        GameLoop();
        CheckResults();
    } else {
        Console.WriteLine("Goodbye");
    }
}