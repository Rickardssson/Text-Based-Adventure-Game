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
            Console.Write($"Well {player.Name} pick your poison? ");
            player.FinalOpponentName = "Mr. " + Console.ReadLine();
            Console.WriteLine("We don't have that so have this instead.");
        }

        Console.WriteLine("The bartender hands you a shot of some indistinguishable liquid.");

        ObtainShot(player);

        List<string> availableLocations = new List<string> { "bathroom", "dancefloor" };
        
        player.Location = AskBetweenOptions("Where do you go next? Bathroom or Dancefloor? ", availableLocations);
    }

    static void Bathroom(Player player)
    {
        Console.WriteLine("You enter the bathroom.");
        if (player.Items.Contains("Jacket") || player.Items.Contains("Wardrobe Ticket"))
        {
            Console.WriteLine("Nothing happens");
        }
        else
        {
            Console.WriteLine("A shady figure approaches from one of the stalls.");
            List<string> options = new List<string> { "shot", "ticket" };
            
            string choice = AskBetweenOptions("Shot or a ticket, the choice is yours... ", options);
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
