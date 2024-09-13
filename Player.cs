class Player
{
    public string Name = "";
    public string FinalOpponentName = "";
    public int Popularity = 0;
    public int Courage = 50;
    public List<string> Items = new List<string>();
    public string Location = "newgame";
    public string LastMoveUsed = "";
	public bool HasObtainedClothing = false;

    public void Action1(Opponent opponent)
    {
        Console.WriteLine($"{this.Name} used 'Modern Dance'!");
        LastMoveUsed = "modern_dance";
        if (opponent.DanceType == "tiktok_dance")
        {
            Console.WriteLine("It's very effective!");
            opponent.Popularity -= 5;
            this.Popularity += 5;
            Console.WriteLine($"5 people stopped cheering {opponent.Name}'s name and started cheering for {this.Name} instead.");
        }
        else if (opponent.DanceType == "breakdance")
        {
            Console.WriteLine("It's not very effective!");
            opponent.Popularity += 3;
            this.Popularity -= 3;
            Console.WriteLine($"3 people stopped cheering for {this.Name} to cheer for {opponent.Name}.");
        } else
        {
            this.Popularity += 3;
            Console.WriteLine($"3 people joined in the cheer for {this.Name}!");
        }
    }

    public void Action2(Opponent opponent)
    {
        Console.WriteLine($"{this.Name} used 'Disco Dance'!");
        LastMoveUsed = "disco_dance";
        if (opponent.DanceType == "breakdance")
        {
            Console.WriteLine("It's very effective!");
            opponent.Popularity -= 5;
            this.Popularity += 5;
            Console.WriteLine($"5 people stopped cheering {opponent.Name}'s name and started cheering for {this.Name} instead.");
        }
        else if (opponent.DanceType == "tiktok_dance")
        {
            Console.WriteLine("It's not very effective!");
            opponent.Popularity += 3;
            this.Popularity -= 3;
            Console.WriteLine($"3 people stopped cheering for {this.Name} to cheer for {opponent.Name}.");
        } else
        {
            this.Popularity += 3;
            Console.WriteLine($"3 people joined in the cheer for {this.Name}!");
        }
    }

    public void Action3(Opponent opponent)
    {
        Console.WriteLine($"{this.Name} used 'Folk Dance'!");
        LastMoveUsed = "folk_dance";
        if (this.Courage >= 75)
        {
            Console.WriteLine("It's super effective!");
            opponent.Popularity -= 5;
            this.Popularity += 10;
            Console.WriteLine($"5 people stopped cheering for{opponent.Name}.");
            Console.WriteLine($"10 people joined in the cheer for {this.Name}!");
        }
        else
        {
            this.Popularity -= 2;
            Console.WriteLine("You weren't courageous enough to perform and therefore 2 people started booing.");
        }
    }
}
