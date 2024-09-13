class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        while (player.Location != "quit")
        {
            if (player.Location == "newgame")
            {
                NewGame(player);
            }
			else if (player.Location == "gameover")
			{
				Console.WriteLine("\n--------------------------------------------");
				Console.WriteLine("You got kicked out!");
				if (AskYesOrNo("Do you want to try again? ")) 
				{
					player.Location = "newgame";
				}
				else
				{
					player.Location = "quit";
				}
			}
			else if (player.Location == "victory")
			{
				Console.WriteLine("\n--------------------------------------------");
				Console.WriteLine($"Congratulations {player.Name}!");
				Console.WriteLine("You are now the top of the 'food chain' here at the dance club!");
				if (AskYesOrNo("Do you want to play again? ")) 
				{
					player.Location = "newgame";
				}
				else
				{
					player.Location = "quit";
				}
			}
            else if (player.Location == "bar")
            {
                Bar(player);
            }
            else if (player.Location == "bathroom")
            {
                Bathroom(player);
            }
            else if (player.Location == "wardrobe")
            {
                Wardrobe(player);
            }
            else if (player.Location == "dancefloor")
            {
                Dancefloor(player);
            }
            else if (player.Location == "lounge")
            {
                Lounge(player);
            }
            else
            {
                Console.Error.WriteLine($"You forgot to implement '{player.Location}'!");
            }
        }
    }

    static void NewGame(Player player)
    {
        Console.Clear();
        Console.WriteLine("You find yourself in a bar and see the bartender aproach you.");
        string name = "";
        do
        {
            name = Ask("What's your name kid? ");
        } while (!AskYesOrNo($"{name} is it? "));

        int initialPopularity;

        while (!int.TryParse(Ask("How many friends did you come with? "), out initialPopularity))
        {
            Console.WriteLine("Are you that drunk already? That is not a number.");
        }

        player.Name = name;
        player.Location = "bar";
        player.Popularity = initialPopularity;
    }

    static void Bar(Player player)
    {
        if (player.FinalOpponentName == "")
        {
            Console.Write($"Well {player.Name} pick your poison. ");
            player.FinalOpponentName = "Mr. " + Console.ReadLine();
            Console.WriteLine("We don't have that so have this instead.");
        }
        else
        {
			Console.WriteLine("--------------------------------------------");
            Console.WriteLine("You approach the bartender.");
            Console.WriteLine("Take this, it's on the house");
        }
        
        Console.WriteLine("The bartender hands you a shot of some indistinguishable liquid.");

        ObtainShot(player);

        List<string> availableLocations = new List<string> { "bathroom", "dancefloor" };
        
        player.Location = AskBetweenOptions("Where do you go next? Bathroom or Dancefloor? ", availableLocations);
    }

    static void Bathroom(Player player)
    {
		Console.WriteLine("--------------------------------------------");
        Console.WriteLine("You enter the bathroom.");
        if (player.Items.Contains("Jacket") || player.Items.Contains("Wardrobe Ticket"))
        {
            Console.WriteLine("Nothing happens");
        }
        else
        {
            Console.WriteLine("A shady figure approaches from one of the stalls.");
            List<string> options = new List<string> { "shot", "ticket" };
            
            string choice = AskBetweenOptions("Shot or ticket, the choice is yours... ", options);
            if (choice == "shot")
            {
                ObtainShot(player);
            } else
            {
                player.Items.Add("Wardrobe Ticket");
                Console.WriteLine("You have obtained a ticket.");
                Console.WriteLine("What is it for?");
            }

        }

        List<string> availableLocations = new List<string> { "bar", "wardrobe" };
        
        player.Location = AskBetweenOptions("Where do you go next? Bar or Wardrobe? ", availableLocations);
    }

    static void Wardrobe(Player player)
    {
		Console.WriteLine("--------------------------------------------");
        Console.WriteLine("You enter the wardrobe.");
        if (player.Items.Contains("Jacket"))
        {
            Console.WriteLine("Nothing more to do here.");
        }
        else
        {
            Console.WriteLine("There is someone attending the wardrobe.");
            if (AskYesOrNo("Do you want to exchange your clothes? For that you need a ticket. "))
            {
                if (player.Items.Contains("Wardrobe Ticket"))
                {
                    player.Items.Remove("Wardrobe Ticket");
                    player.Items.Add("Jacket");
                    player.Courage += 20;

                    Console.WriteLine("You lost your ticket but gained a Jacket!");
                    Console.WriteLine("With your new Jacket you gain 20 Courage!");
                }
                else
                {
                    Console.WriteLine("Comeback when you actually have a ticket!");
                    player.Courage -= 1;
                    Console.WriteLine("For lying and getting caught you lost 1 Courage");
                }
            }
        }
        
        List<string> availableLocations = new List<string> { "dancefloor", "bathroom" };
        
        player.Location = AskBetweenOptions("Where do you go next? Dancefloor or Bathroom? ", availableLocations);
    }

    static void Dancefloor(Player player)
    {
		Console.WriteLine("--------------------------------------------");
        Console.WriteLine("You enter the dancefloor.");
		Console.WriteLine("A crowd gathers around you and a stranger approaches you.");
        Console.WriteLine("The stranger challenges you to a dance off!");

        if (AskYesOrNo("Do you accept the challenge? "))
        {
            BasicOpponent opponent = new BasicOpponent("The Stranger", player.Popularity + 5, 15, "tiktok_dance", 2);
            DanceBattle(player, opponent);
			if (player.Location == "gameover")
			{
				return;
			}
        }

        List<string> availableLocations = new List<string> { "bar", "wardrobe", "lounge"};

        bool playerCanEnterLocation = false;
        do
        {
            player.Location = AskBetweenOptions("Where do you go next? Bar, Wardrobe or Lounge (requires VIP Card)? ", availableLocations);
            if (player.Location == "lounge" && !player.Items.Contains("VIP Card"))
            {
                Console.WriteLine("You do not have a VIP card.");
                continue;
            }

            playerCanEnterLocation = true;
        } while (!playerCanEnterLocation);
    }

    static void Lounge(Player player)
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("You enter the lounge.");
        Console.WriteLine("Before you there is an even larger dancefloor with an even larger crowd.");
        Console.WriteLine("The crowd slowly opens up and a hooded figure emerges.");
        Console.WriteLine("The figure unveils and introduces themself.");
        Console.WriteLine($"'The name is {player.FinalOpponentName}, and you have entered my domain.'");
        
        FinalOpponent opponent = new FinalOpponent(player.FinalOpponentName, player.Popularity + 10, 50, "breakdance", 3);
        DanceBattle(player, opponent);
        if (player.Location == "gameover")
        {
            return;
        }
    }

    static void DanceBattle(Player player, Opponent opponent)
    {
        Console.WriteLine($"Let the dance battle between {player.Name} and {opponent.Name} begin!");
		Thread.Sleep(1500);
		// Loops while the battle should be active
        do
        {
            Console.WriteLine($"\n{opponent.Name}'s turn:");
            opponent.PickAction(player);
            Thread.Sleep(1500);
            Console.WriteLine($"\n{player.Name}'s turn:");
            ChoosePlayerAction(player, opponent);
            Thread.Sleep(1500);
        } while (GetPositiveDifference(player.Popularity, opponent.Popularity) < opponent.PopularityDifference);

        Console.WriteLine("The Crowd declares a clear winner!");
		if (player.Popularity < opponent.Popularity)
		{
			Console.WriteLine($"{player.Name} was deafeated by {opponent.Name}!");
			player.Location = "gameover";
		} 
		else
		{
            Console.WriteLine($"{opponent.Name} was deafeated by {player.Name}!");
            opponent.Defeat(player);
		}
    }

    static void ChoosePlayerAction(Player player, Opponent opponent)
    {
        List<string> playerActions = new List<string> { "modern", "disco", "folk" };
        Console.WriteLine("---\nDances: Modern | Disco | Folk\n---");
        string action = AskBetweenOptions("Which dance do you choose? ", playerActions);

        if (action == "modern")
        {
            player.Action1(opponent);
        }
        
        if (action == "disco")
        {
            player.Action2(opponent);
        }
        
        if (action == "folk")
        {
            player.Action3(opponent);
        }
    }
    
    static int GetPositiveDifference(int x, int y)
    {
        if (x >= y)
        {
            return x - y;
        }
        else
        {
            return y - x;
        }
    }
    
    static void ObtainShot(Player player)
    {
        if (AskYesOrNo("Do you want to drink the shot? "))
        {
            DrinkShot(player);
        } else
        {
            player.Items.Add("Shot");
            Console.WriteLine("You gained a shot!");
        }
    }

    static void DrinkShot(Player player)
    {
        player.Courage += 5;
        player.Items.Add("Empty Shot Glass");
        Console.WriteLine("You gained 5 Courage and an empty shot glass!");
    }

    static string AskBetweenOptions(string question, List<string> options)
    {
        string returnValue = "";
        do
        {
            returnValue = Ask(question).ToLower();
        } while(!options.Contains(returnValue));

        return returnValue;
    }

    static string Ask(string question)
    {
        string response = "";
        while (response == "")
        {
            Console.Write(question);
            response = Console.ReadLine().Trim();
        }

        return response;
    }

    static bool AskYesOrNo(string question)
    {
        while (true)
        {
            string response = Ask(question).ToLower();
            switch (response)
            {
                case "yes":
                    case "ok":
                    return true;
                case "no":
                    return false;
            }
        }
    }
}
