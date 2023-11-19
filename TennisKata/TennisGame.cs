namespace TennisKata;

public class TennisGame
{
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
        if (IsWin())
            return $"{GetLeadPlayer()} Win";

        if (IsSameScore())
        {
            if (_firstPlayerScoreTimes >= 3)
                return "Deuce";
            return $"{_scoreMap[_firstPlayerScoreTimes]} All";
        }

        if (IsAdv())
        {
            return $"{GetLeadPlayer()} Adv";
        }

        return $"{_scoreMap[_firstPlayerScoreTimes]} {_scoreMap[_secondPlayerScoreTimes]}";
    }

    private bool IsWin()
    {
        return GetScoreDiff() > 1 && (_firstPlayerScoreTimes > 3 || _secondPlayerScoreTimes > 3);
    }

    private string GetLeadPlayer()
    {
        return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "FirstPlayer" : "SecondPlayer";
    }

    private bool IsAdv()
    {
        return GetScoreDiff() < 2 &&
               _firstPlayerScoreTimes >= 3 && _secondPlayerScoreTimes >= 3;
    }

    private int GetScoreDiff()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes);
    }

    private bool IsSameScore()
    {
        return _firstPlayerScoreTimes == _secondPlayerScoreTimes;
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