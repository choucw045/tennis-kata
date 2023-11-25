namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void SetUp()
    {
        _tennisGame = new(FirstPlayer);
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

    [Test]
    public void FortyLove()
    {
        GivenFirstPlayerScoreTimes(3);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void FirstPlayerWin()
    {
        GivenFirstPlayerScoreTimes(4);
        ScoreShouldBe($"{FirstPlayer} Win");
    }

    private const string FirstPlayer = "Bob";


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