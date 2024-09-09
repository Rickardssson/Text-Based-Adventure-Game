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

            if (player.Location == "bar")
            {
                Bar(player);
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

        int initialPopularity = 0;
        do
        {
            try
            {
                initialPopularity = int.Parse(Ask("How many friends did you come with? "));
                if (initialPopularity == 0)
                {
                    //
                    initialPopularity = 1;
                }
            }
            catch (Exception e)
            {
                continue;
            }
        } while (initialPopularity == 0);

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

        Console.WriteLine("\nThe bartender hands you a shot of some indistinguishable liquid.");
                
        if (AskYesOrNo("Do you want to drink the shot? "))
        {
            player.Courage += 5;
            Console.WriteLine("You gained 5 Courage and an empty shot glass!")
            player.Items.Add("Empty Shot Glass");
        } else
        {
            Console.WriteLine("You gained a shot!")
            player.Items.Add("Shot");
        }
        
        // To stop program from spamming text
        Console.WriteLine("Where do you go next? ");
        Console.ReadLine();
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
