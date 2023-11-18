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
        _tennisGame.FirstPlayerScore();
        ScoreShouldBe("Fifteen Love");
    }

    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}