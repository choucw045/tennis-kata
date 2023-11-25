namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerScoreTimes;

    public string GetScore()
    {
        if (_firstPlayerScoreTimes == 2)
        {
            return "Thirty Love";
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