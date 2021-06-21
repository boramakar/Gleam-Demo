using System.Collections.Generic;

public class LeaderboardData
{
    public List<LeaderboardEntry> dailyList;
    public int dailyRank;
    public int dailyPoints;
    public List<LeaderboardEntry> globalList;
    public int globalRank;
    public int globalPoints;
}

public class LeaderboardEntry
{
    public string name;
    public int points;
    public int rank;
}