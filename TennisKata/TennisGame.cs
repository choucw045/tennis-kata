namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    private static readonly Dictionary<int, string> ScoreMap = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _secondPlayerCurrentScore;

    public string GetScore()
    {
        if (_firstPlayerCurrentScore > 0 || _secondPlayerCurrentScore > 0)
        {
            var score1 = GetScoreDesc(_firstPlayerCurrentScore);
            var score2 = GetScoreDesc(_secondPlayerCurrentScore);
            return $"{score1} {score2}";
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

    public void SecondPlayerScore()
    {
        _secondPlayerCurrentScore++;
    }
}