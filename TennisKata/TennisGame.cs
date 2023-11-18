namespace TennisKata;

public class TennisGame(string firstPlayerName, string secondPlayerName)
{
    private int _firstPlayerScore;
    private int _secondPlayerScore;
    private bool _isDeuce;

    public string GetScore()
    {
        if (_isDeuce)
        {
            if (IsEqualScore())
                return Deuce();
            return IsAdv() ? $"{GetLeadPlayer()} Adv" : $"{GetLeadPlayer()} Win";
        }

        return GetScoreMatch();
    }

    private int GetScoreDiff()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore);
    }

    private bool IsAdv()
    {
        return GetScoreDiff() == 1;
    }

    private bool IsEqualScore()
    {
        return _firstPlayerScore == _secondPlayerScore;
    }

    private string GetLeadPlayer()
    {
        return _firstPlayerScore > _secondPlayerScore ? firstPlayerName : secondPlayerName;
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private string GetScoreMatch()
    {
        var score1 = GetDesc(_firstPlayerScore);
        var score2 = GetDesc(_secondPlayerScore);
        return _firstPlayerScore == _secondPlayerScore ? $"{score1} All" : $"{score1} {score2}";
    }

    private string GetDesc(int score)
    {
        Dictionary<int, string> scoreMap = new()
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" },
        };
        return scoreMap[score];
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScore++;
        CheckDeuce();
    }

    private void CheckDeuce()
    {
        if (_firstPlayerScore == _secondPlayerScore && _firstPlayerScore == 3)
        {
            _isDeuce = true;
        }
    }

    public void SecondPlayerScore()
    {
        _secondPlayerScore++;
        CheckDeuce();
    }
}