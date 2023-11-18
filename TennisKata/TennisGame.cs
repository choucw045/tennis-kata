namespace TennisKata;

public class TennisGame
{
    private static readonly Dictionary<int, string> ScoreMap = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _firstPlayerCurrentScore;
    private int _secondPlayerCurrentScore;
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;
    private bool _deuce;

    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public string GetScore()
    {
        if (_deuce)
        {
            return GetDeuceScore();
        }

        var score1 = GetScoreDesc(_firstPlayerCurrentScore);
        var score2 = GetScoreDesc(_secondPlayerCurrentScore);
        return _firstPlayerCurrentScore == _secondPlayerCurrentScore ? $"{score1} All" : $"{score1} {score2}";
    }

    private string GetDeuceScore()
    {
        if (_secondPlayerCurrentScore == _firstPlayerCurrentScore)
            return "Deuce";

        return IsAdv() ? $"{GetLeadPlayer()} Adv" : $"{GetLeadPlayer()} Win";
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerCurrentScore - _secondPlayerCurrentScore) == 1;
    }

    private string GetLeadPlayer()
    {
        return _firstPlayerCurrentScore > _secondPlayerCurrentScore ? _firstPlayerName : _secondPlayerName;
    }

    private static string GetScoreDesc(int score)
    {
        return ScoreMap[score];
    }

    private void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerCurrentScore++;
    }

    public void PlayerScore(string playerName)
    {
        if (playerName == _firstPlayerName)
            FirstPlayerScore();
        else if (playerName == _secondPlayerName)
            SecondPlayerScore();
        else
            throw new NotSupportedException();

        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore && _firstPlayerCurrentScore == 3)
        {
            _deuce = true;
        }
    }
}