namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    private readonly Dictionary<int, string> _scoreMap = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _secondPlayerCurrentScore;

    public string GetScore()
    {
        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore && (_firstPlayerCurrentScore >= 3 || _secondPlayerCurrentScore >= 3))
            return "Deuce";
        if (ScoreDiff() == 1 && (_firstPlayerCurrentScore > 3 || _secondPlayerCurrentScore > 3))
        {
            return $"{LeadPlayerName()} Adv";
        }
        else if (ScoreDiff() >= 2 && (_firstPlayerCurrentScore > 3 || _secondPlayerCurrentScore > 3))
        {
            return $"{LeadPlayerName()} Win";
        }

        var firstPlayerScore = _scoreMap[_firstPlayerCurrentScore];
        var secondPlayerScore = _scoreMap[_secondPlayerCurrentScore];

        return firstPlayerScore == secondPlayerScore ? $"{firstPlayerScore} All" : $"{firstPlayerScore} {secondPlayerScore}";
    }

    private int ScoreDiff()
    {
        return Math.Abs(_firstPlayerCurrentScore - _secondPlayerCurrentScore);
    }

    private string LeadPlayerName()
    {
        return _firstPlayerCurrentScore > _secondPlayerCurrentScore ? "FirstPlayer" : "SecondPlayer";
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