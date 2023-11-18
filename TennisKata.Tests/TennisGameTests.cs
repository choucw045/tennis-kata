namespace TennisKata.Tests;

public class Tests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new();
    }

    [Test]
    public void LoveAll()
    {
        _tennisGame.GetScore().Should().Be("Love All");
    }

    [Test]
    public void FifteenLove()
    {
        _tennisGame.FirstPlayerScore();
        ScoreShouldBe(("Fifteen Love"));
    }

    [Test]
    public void ThirtyLove()
    {
        GivenPlayerScore(FirstPlayer, 2);
        ScoreShouldBe("Thirty Love");
    }

    private const Player FirstPlayer = Player.FirstPlayer;

    private void ScoreShouldBe(string result)
    {
        _tennisGame.GetScore().Should().Be(result);
    }

    [Test]
    public void FortyLove()
    {
        GivenPlayerScore(FirstPlayer, 3);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenPlayerScore(SecondPlayer, 1);
        ScoreShouldBe("Love Fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenPlayerScore(SecondPlayer, 2);
        ScoreShouldBe("Love Thirty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenPlayerScore(FirstPlayer, 1);
        GivenPlayerScore(SecondPlayer, 1);
        ScoreShouldBe("Fifteen All");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenPlayerScore(FirstPlayer, 2);
        GivenPlayerScore(SecondPlayer, 2);
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
        GivenPlayerScore(FirstPlayer, 1);
        ScoreShouldBe("FirstPlayer Adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        GivenPlayerScore(SecondPlayer, 1);
        ScoreShouldBe("SecondPlayer Adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenPlayerScore(SecondPlayer, 2);
        ScoreShouldBe("SecondPlayer Win");
    }


    private void GivenDeuce()
    {
        GivenPlayerScore(FirstPlayer, 3);
        GivenPlayerScore(SecondPlayer, 3);
    }


    private const Player SecondPlayer = Player.SecondPlayer;

    private void GivenPlayerScore(Player player, int score)
    {
        for (var i = 0; i < score; i++)
        {
            if (player == SecondPlayer)
                _tennisGame.SecondPlayerScore();
            else
                _tennisGame.FirstPlayerScore();
        }
    }
}

internal enum Player

{
    SecondPlayer,
    FirstPlayer
}