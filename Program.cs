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

            } else
            {
                Console.Error.WriteLine($"You forgot to implement '{player.Location}'!");
            }
        }
        Console.WriteLine("You find yourself in a bar and see the bartender aproach you.");
    }
    
    class Player
    {
        public string Name = "";
        public int Popularity = 0;
        public List<string> Items = new List<string>();
        public string Location = "newgame";
    }

    static void NewGame(Player player)
    {
        Console.Clear();
        string name = "";
        do
        {
            name = Ask("What's your name kid? ");
        } while (!AskYesOrNo($"{name} is it? "));

        player.Name = name;
        player.Location = "bar";
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
