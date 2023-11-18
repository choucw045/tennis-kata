namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame(FirstPlayer, SecondPlayer);
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
        _tennisGame.SecondPlayerScore();
        ScoreShouldBe("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Love Thirty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenSecondPlayerScore(1);
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenSecondPlayerScore(2);
        GivenFirstPlayerScore(2);
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
        ScoreShouldBe($"{FirstPlayer} Adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);
        ScoreShouldBe($"{SecondPlayer} Adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        ScoreShouldBe($"{SecondPlayer} Win");
    }


    private const string SecondPlayer = "Bob";

    private void GivenDeuce()
    {
        GivenSecondPlayerScore(3);
        GivenFirstPlayerScore(3);
    }

    private const string FirstPlayer = "Alice";


    private void GivenSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.SecondPlayerScore();
        }
    }


    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.FirstPlayerScore();
        }
    }


    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}