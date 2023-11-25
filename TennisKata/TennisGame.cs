namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerScoreTimes;

    private Dictionary<int, string> _scoreMap = new()
    {
        { 1, "Fifteen" },
        { 2, "Thirty" },
    };

    public string GetScore()
    {
        if (_firstPlayerScoreTimes == 2 || _firstPlayerScoreTimes == 1)
        {
            return $"{_scoreMap[_firstPlayerScoreTimes]} Love";
        }

        return "Love All";
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScoreTimes++;
    }
}