namespace CardAppTest;

public class CardAppTest
{
    private Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new Game();
    }

    [TestCase("2C", 2)]
    [TestCase("2D", 4)]
    [TestCase("2H", 6)]
    [TestCase("2S", 8)]
    [TestCase("TC", 10)]
    [TestCase("JC", 11)]
    [TestCase("QC", 12)]
    [TestCase("KC", 13)]
    [TestCase("AC", 14)]
    [TestCase("3C,4C", 7)]
    [TestCase("TC,TD,TH,TS", 100)]
    public void CardAppTest_ShouldReturnResult(string input, int expected)
    {
        int actual = _game.CalculateScore(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("JK,JK", 0)]
    [TestCase("2C,JK", 4)]
    [TestCase("JK,2C,JK", 8)]
    [TestCase("TC,TD,JK,TH,TS", 200)]
    [TestCase("TC,TD,JK,TH,TS,JK", 400)]
    public void CardAppTest_ShouldReturnResultWithJokers(string input, int expected)
    {
        int actual = _game.CalculateScore(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("1S")]
    [TestCase("2B")]
    [TestCase("2S,1S")]
    public void CardAppTest_ShouldReturnCardNotRecognisedException(string value)
    {
        var exception = Assert.Throws<Exception>(() => _game.CalculateScore(value));

        Assert.That(exception.Message, Is.EqualTo("Card not recognised"));
    }

    [TestCase("3H,3H")]
    [TestCase("4D,5D,4D")]
    public void CardAppTest_ShouldReturnCardsCannotBeDuplicatedException(string value)
    {
        var exception = Assert.Throws<Exception>(() => _game.CalculateScore(value));

        Assert.That(exception.Message, Is.EqualTo("Cards cannot be duplicated"));
    }

    [TestCase("JK,JK,JK")]
    public void CardAppTest_ShouldReturnHandCannotContainMoreThanTwoJokersException(string value)
    {
        var exception = Assert.Throws<Exception>(() => _game.CalculateScore(value));

        Assert.That(exception.Message, Is.EqualTo("A hand cannot contain more than two Jokers"));
    }

    [TestCase("2S|3D")]
    public void CardAppTest_InvalidInputStringException(string value)
    {
        var exception = Assert.Throws<Exception>(() => _game.CalculateScore(value));

        Assert.That(exception.Message, Is.EqualTo("Invalid input string"));
    }
}