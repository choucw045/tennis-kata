namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame();
    }

    [Test]
    public void LoveAll()
    {
        _tennisGame.GetScore().Should().Be("Love All");
    }

    [Test]
    public void FifteenLove()
    {
        GivenFirstPlayerScore(1);
        _tennisGame.GetScore().Should().Be("Fifteen Love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenFirstPlayerScore(2);
        _tennisGame.GetScore().Should().Be("Thirty Love");
    }

    [Test]
    public void FortyLove()
    {
        GivenFirstPlayerScore(3);
        _tennisGame.GetScore().Should().Be("Forty Love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenSecondPlayerScore(1);
        _tennisGame.GetScore().Should().Be("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenSecondPlayerScore(2);
        _tennisGame.GetScore().Should().Be("Love Thirty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenBothPlayerScore(1);
        _tennisGame.GetScore().Should().Be("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenBothPlayerScore(2);
        _tennisGame.GetScore().Should().Be("Thirty All");
    }

    [Test]
    public void Deuce()
    {
        GivenDeuce();
        _tennisGame.GetScore().Should().Be("Deuce");
    }

    [Test]
    public void FirstPlayerAdv()
    {
        GivenDeuce();
        _tennisGame.FirstPlayerScore();
        _tennisGame.GetScore().Should().Be("FirstPlayer Adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        _tennisGame.SecondPlayerScore();
        _tennisGame.GetScore().Should().Be("SecondPlayer Adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        _tennisGame.GetScore().Should().Be("SecondPlayer Win");
    }


    private void GivenDeuce()

    {
        GivenBothPlayerScore(3);
    }

    private void GivenBothPlayerScore(int score)
    {
        GivenFirstPlayerScore(score);
        GivenSecondPlayerScore(score);
    }


    private void GivenFirstPlayerScore(int score)
    {
        for (var i = 0; i < score; i++) _tennisGame.FirstPlayerScore();
    }

    private void GivenSecondPlayerScore(int score)
    {
        for (var i = 0; i < score; i++) _tennisGame.SecondPlayerScore();
    }
}