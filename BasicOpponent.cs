class BasicOpponent : Opponent
{
    private Random random = new Random();
    public BasicOpponent(string name, int popularity, int popularityDifference) : base(name, popularity, popularityDifference)
    {
        Name = name;
        Popularity = popularity;
        PopularityDifference = popularityDifference;
    }
    public void Action1()
    {
        Console.WriteLine($"{this.Name} used 'TikTok Dance'!");
        if (this.random.Next(2) == 1)
        {
            this.Popularity += 2;
            Console.WriteLine($"{this.Name} danced well and 2 people joined their crowd.");
        }
        else
        {
            this.Popularity -= 2;
            Console.WriteLine($"{this.Name} danced poorly and 2 people left their crowd.");
        }
    }

    public void Action2(Player player)
    {
        Console.WriteLine($"{this.Name} used 'Roast Opponent'!");

        string[] roasts =
        {
            "Are you dancing? Looks more like tripping over air.",
            "Elegance isn't your dancefloor strong suit.",
            "You dance like a malfunctioning robot.",
        };
        
        Console.WriteLine($"{roasts[this.random.Next(roasts.Length)]}");
        this.Popularity += 1;
        player.Popularity -= 1;
        Console.WriteLine($"One member of {player.Name}'s crowd joins the crowd of {this.Name}.");
    }
}
