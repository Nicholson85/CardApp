namespace CardAppTest;
public class InputHelperTest
{
    [TestCase("2C")]
    [TestCase("2D,JK")]
    [TestCase("2H,4H,5H")]
    [TestCase("2S")]
    public void InputHelperTest_IsValidInputString_ShouldReturnTrue(string value)
    {
        bool actual = InputHelper.IsValidInputString(value);

        Assert.That(actual, Is.True);
    }

    [TestCase("2C|2F")]
    [TestCase("2!")]
    [TestCase("2&")]
    public void InputHelperTest_IsValidInputString_ShouldReturnFalse(string value)
    {
        bool actual = InputHelper.IsValidInputString(value);

        Assert.That(actual, Is.False);
    }
}
