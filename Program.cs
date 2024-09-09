﻿class Program
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

            if (player.Location == "bar")
            {
                Bar(player);
            }

            if (player.Location == "bathroom")
            {
                Bathroom(player);
            }
            else
            {
                Console.Error.WriteLine($"You forgot to implement '{player.Location}'!");
            }
        }
        
    }
    
    class Player
    {
        public string Name = "";
        public string FinalOpponentName = "";
        public int Popularity = 0;
        public int Courage = 50;
        public List<string> Items = new List<string>();
        public string Location = "newgame";
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
        
        // Taget från https://stackoverflow.com/a/723219
        List<string> availableLocations = new List<string> { "bathroom", "dancefloor" };
        
        player.Location = GetListValue("Where do you go next? Bathroom or Dancefloor? ", availableLocations);
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
            
            string choice = GetListValue("Shot or a ticket, the choice is yours... ", options);
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
        
        player.Location = GetListValue("Where do you go next? Bar or Wardrobe? ", availableLocations);
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
    
    static string GetListValue(string question, List<string> list)
    {
        string returnValue = "";
        do
        {
            returnValue = Ask(question).ToLower();
        } while(!list.Contains(returnValue));

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
