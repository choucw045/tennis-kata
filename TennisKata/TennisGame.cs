namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerScoreTimes;

    private Dictionary<int, string> _scoreMap = new()
    {
        { 2, "Thirty" },
    };

    public string GetScore()
    {
        if (_firstPlayerScoreTimes == 2)
        {
            return $"{_scoreMap[_firstPlayerScoreTimes]} Love";
        }

        if (_firstPlayerScoreTimes == 1)
        {
            return "Fifteen Love";
        }

        return "Love All";
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScoreTimes++;
    }
}