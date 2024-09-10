class Opponent
{
    public string Name = "";
    public int Popularity = 0;
    public int PopularityDifference = 10;
    public string DanceType = "";

    public Opponent(string name, int popularity, int popularityDifference, string danceType)
    {
        Name = name;
        Popularity = popularity;
        PopularityDifference = popularityDifference;
        DanceType = danceType;
    }
}
