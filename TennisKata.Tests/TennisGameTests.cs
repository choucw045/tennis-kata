namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new(Player1, Player2);
    }

    [Test]
    public void LoveAll()
    {
        ScoreShouldBe("Love All");
    }

    [Test]
    public void FifteenLove()
    {
        GivenScore(Player1, 1);
        ScoreShouldBe("Fifteen Love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenScore(Player1, 2);
        ScoreShouldBe("Thirty Love");
    }

    [Test]
    public void FortyLove()
    {
        GivenScore(Player1, 3);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenScore(Player2, 1);
        ScoreShouldBe("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenScore(Player2, 2);
        ScoreShouldBe("Love Thirty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenScore(Player1, 1);
        GivenScore(Player2, 1);
        ScoreShouldBe("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenScore(Player1, 2);
        GivenScore(Player2, 2);
        ScoreShouldBe("Thirty All");
    }

    [Test]
    public void Deuce()
    {
        GivenDuce();
        ScoreShouldBe("Deuce");
    }

    [Test]
    public void Player1Adv()
    {
        GivenDuce();
        GivenScore(Player1, 1);
        ScoreShouldBe($"{Player1} Adv");
    }

    [Test]
    public void Player2Adv()
    {
        GivenDuce();
        GivenScore(Player2, 1);
        ScoreShouldBe($"{Player2} Adv");
    }

    [Test]
    public void BobWin()
    {
        GivenDuce();
        GivenScore(Player2, 2);
        ScoreShouldBe($"{Player2} Win");
    }


    private void GivenDuce()
    {
        GivenScore(Player1, 3);
        GivenScore(Player2, 3);
    }


    private const string Player1 = "Bob";
    private const string Player2 = "Alice";


    private void GivenScore(string player, int score)
    {
        for (int i = 0; i < score; i++)
        {
            if (player == Player1)
                _tennisGame.FirstPlayerScore();
            else if (player == Player2)
                _tennisGame.SecondPlayerScore();
        }
    }


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}