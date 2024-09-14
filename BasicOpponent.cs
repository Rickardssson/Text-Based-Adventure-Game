class BasicOpponent : OpponentBase
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
		Thread.Sleep(200);
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
		Thread.Sleep(200);

        string[] roasts =
        {
            "'Are you dancing? Looks more like tripping over air.'",
            "'Elegance isn't your dancefloor strong suit.'",
            "'You dance like a malfunctioning robot.'",
        };
        
        Console.WriteLine($"{roasts[this.random.Next(roasts.Length)]}");
		Thread.Sleep(200);

        this.Popularity += 1;
        player.Popularity -= 1;
        Console.WriteLine($"A crowd member stopped cheering for {player.Name} and started cheering for {this.Name}.");
    }

    public override void Defeat(Player player)
    {
        if (player.Courage >= 75)
        {
            Console.WriteLine("'Hey! You're pretty cool, the names Carl!'");
            this.Name = "Carl";
        }
		Thread.Sleep(300);
        Console.WriteLine("'You've won this battle but there is still an opponent left in the lounge!' ");
		Thread.Sleep(300);
        player.Items.Add("VIP Card");
        Console.WriteLine($"{this.Name} hands over a VIP Card.");
        Thread.Sleep(1000);
    }
}
