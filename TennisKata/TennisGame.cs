namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerScoreTimes;

    private Dictionary<int, string> _scoreMap = new()
    {
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    public TennisGame(string firstPlayer)
    {
    }

    public string GetScore()
    {
        if (_firstPlayerScoreTimes > 0)
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