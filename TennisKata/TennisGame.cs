namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    private static readonly Dictionary<int, string> ScoreMap = new()
    {
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    public string GetScore()
    {
        if (_firstPlayerCurrentScore > 0)
        {
            var score = GetScoreDesc(_firstPlayerCurrentScore);
            return $"{score} Love";
        }

        return "Love All";
    }

    private static string GetScoreDesc(int score)
    {
        return ScoreMap[score];
    }

    public void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
    }
}