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

    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;
    private int _secondPlayerCurrentScore;
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
            if (IsSameScore())
                return "Deuce";

            if (IsAdv() == 1)
                return $"{GetLeadPlayer()} Adv";

            return $"{GetLeadPlayer()} Win";
        }

        if (_firstPlayerCurrentScore < 1 && _secondPlayerCurrentScore < 1) return "Love All";

        var score1 = GetScoreDesc(_firstPlayerCurrentScore);
        var score2 = GetScoreDesc(_secondPlayerCurrentScore);
        return _firstPlayerCurrentScore == _secondPlayerCurrentScore ? $"{score1} All" : $"{score1} {score2}";
    }

    private int IsAdv()
    {
        return Math.Abs(_firstPlayerCurrentScore - _secondPlayerCurrentScore);
    }

    private bool IsSameScore()
    {
        return _firstPlayerCurrentScore == _secondPlayerCurrentScore;
    }

    private string GetLeadPlayer()
    {
        return _firstPlayerCurrentScore > _secondPlayerCurrentScore ? _firstPlayerName : _secondPlayerName;
    }

    private static string GetScoreDesc(int firstPlayerCurrentScore)
    {
        return ScoreMap[firstPlayerCurrentScore];
    }

    public void PlayerScore(string playerName)
    {
        if (playerName == _firstPlayerName)
            _firstPlayerCurrentScore++;
        if (playerName == _secondPlayerName)
            _secondPlayerCurrentScore++;

        if (!_deuce && _firstPlayerCurrentScore == _secondPlayerCurrentScore && _firstPlayerCurrentScore == 3)
            _deuce = true;
    }
}