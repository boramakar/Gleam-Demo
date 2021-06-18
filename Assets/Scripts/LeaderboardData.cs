using System.Collections.Generic;

class LeaderboardData
{
    public List<LeaderboardEntry> dailyList;
    public int dailyRank;
    public List<LeaderboardEntry> globalList;
    public int globalRank;
}

class LeaderboardEntry
{
    public string name;
    public int points;
    public int rank;
}

