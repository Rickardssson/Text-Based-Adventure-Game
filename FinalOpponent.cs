class FinalOpponent : Opponent
{
    private Random random = new Random();
    public FinalOpponent(string name, int popularity, int popularityDifference, string danceType, int actionAmount) : base(name, popularity, popularityDifference, danceType, actionAmount)
    {
        Name = name;
        Popularity = popularity;
        PopularityDifference = popularityDifference;
        DanceType = danceType;
        ActionAmount = actionAmount;
    }

    public override void PickAction(Player player)
    {
        int randomValue = random.Next(3);
        if (randomValue == 1)
        {
            Action1(player);
        }
        else if (randomValue == 2)
        {
            Action2(player);
        }
        else
        {
            Action3(player);
        }
    }
    
    public override void Action1(Player player)
    {
        Console.WriteLine($"{this.Name} used 'Breakdance'!");
        if (this.random.Next(2) == 1)
        {
            int gain = this.random.Next(3, 6);
            this.Popularity += gain;
            int damage = this.random.Next(0, 4);
            player.Popularity -= damage;
            Console.WriteLine($"{this.Name} danced well and {gain} people started cheering for them meanwhile the {player.Name} lost {damage} cheers.");
            
        }
    }

    public override void Action2(Player player)
    {
        Console.WriteLine($"{this.Name} used 'Get the crowd fired up'!");

        Console.WriteLine("After both dancers explosive display, getting the crowd fired up was an easy task!");
        if (player.LastMoveUsed == "disco_dance")
        {
            Console.WriteLine($"After {player.Name}'s last display fans of {this.Name} are growing wary.");
            this.Popularity += 12;
            player.Popularity += 5;
            Console.WriteLine("The crowd got heated and both sides grew louder.");
            Console.WriteLine($"The cheer section for {this.Name} grew by 12 but {player.Name} also gained 5 cheers.");
        }
        else
        {
            this.Popularity += 5;
            player.Popularity += 4;
            Console.WriteLine($"The cheer section for {this.Name} grew by 5 but {player.Name} also gained 4 cheers.");
        }
    }

    public void Action3(Player player)
    {
        Console.WriteLine($"{this.Name} used 'Flip'!");
        int flip = this.random.Next(3);
        int gain;
        if (flip == 0)
        {
            Console.WriteLine($"{this.Name} performs a frontflip!");
            gain = 7;
        }
        else if (flip == 1)
        {
            Console.WriteLine($"{this.Name} performs a backflip!");
            gain = 5;
        }
        else
        {
            Console.WriteLine($"{this.Name} performs a handspring!");
            gain = 3;
        }

        this.Popularity += gain;
        Console.WriteLine($"The cheer for {this.Name} grows louder as if {gain} people joined in.");
    }

    public override void Defeat(Player player)
    {
        Console.WriteLine("'Since you have defeated me you are the strongest dancer at this establishment.'");
        player.Location = "victory";
    }
}
