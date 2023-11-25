namespace TennisKata.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoveAll()
    {
        var tennisGame = new TennisGame();
        tennisGame.GetScore().Should().Be("Love All");
    }
}