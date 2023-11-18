namespace TennisKata;

public class TennisGame(string firstPlayer, string secondPlayer)
{
    private readonly string _firstPlayer = firstPlayer;
    private readonly string _secondPlayer = secondPlayer;
    private int _firstPlayerScoreTimes;

    private readonly Dictionary<int, string> _scoreMap = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _secondPlayerScoreTimes;

    public string GetScore()
    {
        if (IsDeuce())
        {
            if (IsSameScore())
                return "Deuce";
            return IsAdv() ? $"{GetAdvPlayer()} Adv" : $"{GetAdvPlayer()} Win";
        }

        if (IsSameScore())
        {
            return $"{_scoreMap[_firstPlayerScoreTimes]} All";
        }

        return $"{_scoreMap[_firstPlayerScoreTimes]} {_scoreMap[_secondPlayerScoreTimes]}";
    }

    private bool IsSameScore()
    {
        return _firstPlayerScoreTimes == _secondPlayerScoreTimes;
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1;
    }

    private bool IsDeuce()
    {
        return _firstPlayerScoreTimes >= 3 && _secondPlayerScoreTimes >= 3;
    }

    private string GetAdvPlayer()
    {
        return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? _firstPlayer : _secondPlayer;
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScoreTimes++;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerScoreTimes++;
    }
}