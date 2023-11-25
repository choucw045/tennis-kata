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
        GivenFirstPlayerScoreTimes(1);
        ScoreShouldBe("Fifteen Love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenFirstPlayerScoreTimes(2);
        ScoreShouldBe("Thirty Love");
    }

    private void GivenFirstPlayerScoreTimes(int times)
    {
        for (var i = 0; i < times; i++)
        {
            _tennisGame.FirstPlayerScore();
        }
    }


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}