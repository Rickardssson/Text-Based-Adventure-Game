abstract class OpponentBase
{
    public string Name = "";
    public int Popularity = 0;
    public int PopularityDifference = 10;
    public string DanceType = "";
    public int ActionAmount = 2;

    public OpponentBase(string name, int popularity, int popularityDifference, string danceType, int actionAmount)
    {
        Name = name;
        Popularity = popularity;
        PopularityDifference = popularityDifference;
        DanceType = danceType;
        ActionAmount = actionAmount;
    }

    public abstract void PickAction(Player player);
    public abstract void Action1(Player player);
    public abstract void Action2(Player player);
	public abstract void Defeat(Player player);
}
