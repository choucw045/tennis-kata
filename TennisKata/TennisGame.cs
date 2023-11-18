namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    public string GetScore()
    {
        if (_firstPlayerCurrentScore > 0)
        {
            return "Fifteen Love";
        }

        return "Love All";
    }

    public void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
    }
}