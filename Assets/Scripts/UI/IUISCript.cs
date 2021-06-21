public interface IUISCript
{
    public void DisplayError(string title, string message);
    public void DisplayLeaderboards(LeaderboardData data);
    public void Restart();
}