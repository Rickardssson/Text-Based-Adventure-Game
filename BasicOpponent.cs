class BasicOpponent : Opponent
{
    private Random random = new Random();
    public BasicOpponent(string name, int popularity, int popularityDifference, string danceType, int actionAmount) : base(name, popularity, popularityDifference, danceType, actionAmount)
    {
        Name = name;
        Popularity = popularity;
        PopularityDifference = popularityDifference;
        DanceType = danceType;
        ActionAmount = actionAmount;
    }

    public override void PickAction(Player player)
    {
        if (random.Next(2) == 1)
        {
            Action1(player);
        }
        else
        {
            Action2(player);
        }
    }
    
    public override void Action1(Player player)
    {
        Console.WriteLine($"{this.Name} used 'TikTok Dance'!");
        if (this.random.Next(2) == 1)
        {
            this.Popularity += 2;
            Console.WriteLine($"{this.Name} danced well and 2 people started cheering for them.");
        }
        else
        {
            this.Popularity -= 2;
            Console.WriteLine($"{this.Name} danced poorly and 2 people started booing.");
        }
    }

    public override void Action2(Player player)
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
        Console.WriteLine($"A crowd member stopped cheering for {player.Name} and started cheering for {this.Name}.");
    }
}
