namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void SetUp()
    {
        _tennisGame = new();
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

    [Test]
    public void ThirtyLove()
    {
        _tennisGame.FirstPlayerScore();
        _tennisGame.FirstPlayerScore();
        ScoreShouldBe("Thirty Love");
    }


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}