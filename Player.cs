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

    public void Action1(OpponentBase opponent)
    {
        Console.WriteLine($"{this.Name} used 'Modern Dance'!");
		Thread.Sleep(200);
        LastMoveUsed = "modern_dance";
        if (opponent.DanceType == "tiktok_dance")
        {
            Console.WriteLine("It's very effective!");
			Thread.Sleep(200);
            opponent.Popularity -= 5;
            this.Popularity += 5;
            Console.WriteLine($"5 people stopped cheering {opponent.Name}'s name and started cheering for {this.Name} instead.");
        }
        else if (opponent.DanceType == "breakdance")
        {
            Console.WriteLine("It's not very effective!");
			Thread.Sleep(200);
            opponent.Popularity += 3;
            this.Popularity -= 3;
            Console.WriteLine($"3 people stopped cheering for {this.Name} to cheer for {opponent.Name}.");
        } else
        {
            this.Popularity += 3;
            Console.WriteLine($"3 people joined in the cheer for {this.Name}!");
        }
    }

    public void Action2(OpponentBase opponent)
    {
        Console.WriteLine($"{this.Name} used 'Disco Dance'!");
		Thread.Sleep(200);
        LastMoveUsed = "disco_dance";
        if (opponent.DanceType == "breakdance")
        {
            Console.WriteLine("It's very effective!");
			Thread.Sleep(200);
            opponent.Popularity -= 5;
            this.Popularity += 5;
            Console.WriteLine($"5 people stopped cheering {opponent.Name}'s name and started cheering for {this.Name} instead.");
        }
        else if (opponent.DanceType == "tiktok_dance")
        {
            Console.WriteLine("It's not very effective!");
			Thread.Sleep(200);
            opponent.Popularity += 3;
            this.Popularity -= 3;
            Console.WriteLine($"3 people stopped cheering for {this.Name} to cheer for {opponent.Name}.");
        } else
        {
            this.Popularity += 3;
            Console.WriteLine($"3 people joined in the cheer for {this.Name}!");
        }
    }

    public void Action3(OpponentBase opponent)
    {
        Console.WriteLine($"{this.Name} used 'Folk Dance'!");
		Thread.Sleep(200);
        LastMoveUsed = "folk_dance";
        if (this.Courage >= 75)
        {
            Console.WriteLine("It's super effective!");
			Thread.Sleep(200);
            opponent.Popularity -= 5;
            this.Popularity += 10;
            Console.WriteLine($"5 people stopped cheering for{opponent.Name}.");
			Thread.Sleep(100);
            Console.WriteLine($"10 people joined in the cheer for {this.Name}!");
        }
        else
        {
            this.Popularity -= 2;
            Console.WriteLine("You weren't courageous enough to perform and therefore 2 people started booing.");
            Console.WriteLine("You need a total of at least 75 courage.");
        }
    }

    public void Action4(OpponentBase opponent)
    {
        Console.WriteLine($"{this.Name} used 'Throw Empty Shot Glass'!");

        if (this.Items.Contains("Empty Shot Glass"))
        {
            this.Items.Remove("Empty Shot Glass");
            Random random = new Random();

            if (random.Next(4) == 0)
            {
                Console.WriteLine($"{this.Name} looked around after throwing and spots a guard sprinting towards them.");
                Thread.Sleep(1000);
                this.Location = "gameover";
            }
            else
            {
                this.Courage += 5;
                this.Popularity -= 1;
                opponent.Popularity -= 1;
                
                Console.WriteLine($"Both contestants lost a cheer each but {this.Name} gained 5 Courage.");
            }
            
            Console.WriteLine($"{this.Name} lost an Empty Shot Glass with use.");
        }
        else
        {
            this.Popularity -= 2;
            Console.WriteLine($"{this.Name} did not have an Empty Shot Glass to throw and therefore 2 people stopped cheering!");
        }
    }
}
