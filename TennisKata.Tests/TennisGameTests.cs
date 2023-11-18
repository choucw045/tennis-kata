namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame(Player1, Player2);
    }

    [Test]
    public void LoveAll()
    {
        ScoreShouldBe("Love All");
    }

    [Test]
    public void FifteenLove()
    {
        GivenScore(1, Player1);
        ScoreShouldBe("Fifteen Love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenScore(2, Player1);
        ScoreShouldBe("Thirty Love");
    }

    [Test]
    public void FortyLove()
    {
        GivenScore(3, Player1);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenScore(1, Player2);
        ScoreShouldBe("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenScore(2, Player2);
        ScoreShouldBe("Love Thirty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenAll(1);
        ScoreShouldBe("Fifteen All");
    }

    private void GivenAll(int score)
    {
        GivenScore(score, Player1);
        GivenScore(score, Player2);
    }


    private const string Player2 = "Alice";

    private void GivenScore(int score, string playerName)
    {
        for (var i = 0; i < score; i++)
        {
            _tennisGame.PlayerScore(playerName);
        }
    }

    private const string Player1 = "Bob";


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}