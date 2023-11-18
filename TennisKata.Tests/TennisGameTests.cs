namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame(Player1, Player2);
    }

    private const string Player1 = "Bob";

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
        GivenScore(1, Player1);
        GivenScore(1, Player2);
        ScoreShouldBe("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenScore(2, Player1);
        GivenScore(2, Player2);
        ScoreShouldBe("Thirty All");
    }

    [Test]
    public void Deuce()
    {
        GivenDeuce();
        ScoreShouldBe("Deuce");
    }

    [Test]
    public void FirstPlayerAdv()
    {
        GivenDeuce();
        GivenScore(1, Player1);
        ScoreShouldBe($"{Player1} Adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        GivenScore(1, Player2);
        ScoreShouldBe($"{Player2} Adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenScore(2, Player2);
        ScoreShouldBe($"{Player2} Win");
    }

    private void GivenDeuce()
    {
        GivenScore(3, Player1);
        GivenScore(3, Player2);
    }


    private const string Player2 = "Alice";


    private void GivenScore(int score, string playerName)
    {
        for (int j = 0; j < score; j++)
        {
            _tennisGame.PlayerScore(playerName);
        }
    }

    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}