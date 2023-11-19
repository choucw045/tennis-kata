namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame();
    }

    [Test]
    public void LoveAll()
    {
        ScoreShouldBe("Love All");
    }

    [Test]
    public void FifteenLove()
    {
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Fifteen Love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenFirstPlayerScore(2);
        ScoreShouldBe("Thirty Love");
    }

    [Test]
    public void FortyLove()
    {
        GivenFirstPlayerScore(3);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Love Thirty");
    }

    [Test]
    public void LoveForty()
    {
        GivenSecondPlayerScore(3);
        ScoreShouldBe("Love Forty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenFirstPlayerScore(1);
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenFirstPlayerScore(2);
        GivenSecondPlayerScore(2);
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
        GivenFirstPlayerScore(1);
        ScoreShouldBe("FirstPlayer Adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);
        ScoreShouldBe("SecondPlayer Adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        ScoreShouldBe("SecondPlayer Win");
    }


    private void GivenDeuce()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(3);
    }


    private void GivenSecondPlayerScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            _tennisGame.SecondPlayerScore();
        }
    }


    private void GivenFirstPlayerScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            _tennisGame.FirstPlayerScore();
        }
    }


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}