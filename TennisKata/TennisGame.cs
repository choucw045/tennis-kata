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
            {
                return "Deuce";
            }

            var leadPlayer = GetLeadPlayer();
            return $"{leadPlayer} Adv";
        }

        var score1 = GetScoreDesc(_firstPlayerCurrentScore);
        var score2 = GetScoreDesc(_secondPlayerCurrentScore);
        return IsSameScore() ? $"{score2} All" : $"{score1} {score2}";
    }

    private string GetLeadPlayer()
    {
        if (_firstPlayerCurrentScore > _secondPlayerCurrentScore)
        {
            return _firstPlayerName;
        }

        return _secondPlayerName;
    }

    private bool IsSameScore()
    {
        return _firstPlayerCurrentScore == _secondPlayerCurrentScore;
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

        CheckDeuce();
    }

    private void CheckDeuce()
    {
        if (_firstPlayerCurrentScore == _secondPlayerCurrentScore && _firstPlayerCurrentScore == 3)
        {
            _deuce = true;
        }
    }
}