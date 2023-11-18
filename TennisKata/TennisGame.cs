namespace TennisKata;

public class TennisGame
{
    private int _firstPlayerCurrentScore;

    private Dictionary<int, string> _scoreMap = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
    };

    private int _secondPlayerCurrentScore;
    private bool _deuceTriggered = false;

    public string GetScore()
    {
        if (!_deuceTriggered)
        {
            var firstScore = _scoreMap[_firstPlayerCurrentScore];
            var secondScore = _scoreMap[_secondPlayerCurrentScore];
            return firstScore == secondScore ? $"{firstScore} All" : $"{firstScore} {secondScore}";
        }
        else
        {
            if (_firstPlayerCurrentScore == _secondPlayerCurrentScore)
                return "Deuce";

            var winner = _firstPlayerCurrentScore > _secondPlayerCurrentScore ? "FirstPlayer" : "SecondPlayer";
            var result = Math.Abs(_firstPlayerCurrentScore - _secondPlayerCurrentScore) == 1 ? "Adv" : "Win";
            return $"{winner} {result}";
        }
    }

    public void FirstPlayerScore()
    {
        _firstPlayerCurrentScore++;
        ScoreChanged();
    }

    private void ScoreChanged()
    {
        if (!_deuceTriggered)
            CheckDeuce();
    }

    private void CheckDeuce()
    {
        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore && _firstPlayerCurrentScore == 3)
            _deuceTriggered = true;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerCurrentScore++;
        ScoreChanged();
    }
}