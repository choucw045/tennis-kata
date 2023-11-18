namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    private readonly Dictionary<int, string> _dictionary = new Dictionary<int, string>()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _secondPlayerCurrentScore;
    private bool _deuce;
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;

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
        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore)
            return "Deuce";

        if (IsAdv())
        {
            return $"{GetLeadPlayerName()} Adv";
        }

        return $"{GetLeadPlayerName()} Win";
    }

    private string GetLeadPlayerName()
    {
        return _firstPlayerCurrentScore > _secondPlayerCurrentScore ? _firstPlayerName : _secondPlayerName;
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerCurrentScore - _secondPlayerCurrentScore) == 1;
    }

    private string GetScoreDesc(int score)
    {
        return _dictionary[score];
    }

    public void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
        CheckDeuce();
    }

    private void CheckDeuce()
    {
        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore && _firstPlayerCurrentScore == 3)
            _deuce = true;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerCurrentScore++;
        CheckDeuce();
    }
}