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
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;

    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

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

    private void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
    }

    private void SecondPlayerScore()
    {
        _secondPlayerCurrentScore++;
    }

    public void PlayerScore(string playerName)
    {
        if (playerName == _firstPlayerName)
            FirstPlayerScore();
        else if (playerName == _secondPlayerName)
            SecondPlayerScore();
        else throw new NotSupportedException();
    }
}