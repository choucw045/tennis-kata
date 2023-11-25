namespace TennisKata.Tests;

public class Tests
{
    private readonly TennisGame _tennisGame = new TennisGame();

    [Test]
    public void LoveAll()
    {
        ScoreShouldBe("Love All");
    }

    private void ScoreShouldBe(string expected)
    {
        _tennisGame.GetScore().Should().Be(expected);
    }
}