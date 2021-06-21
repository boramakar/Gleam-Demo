using System;
using System.Collections.Generic;

[Serializable]
public class LeaderboardData
{
    public string status;
    public UserEntry current_user;
    public List<LeaderboardEntry> users_all_data;
    public List<LeaderboardEntry> users_daily_data;
}

[Serializable]
public class LeaderboardEntry
{
    public string name;
    public int point;
    public int sort;
}

[Serializable]
public class UserEntry
{
    public string name;
    public int monthly_point;
    public int point;
    public int general_sort;
    public int daily_sort;
}