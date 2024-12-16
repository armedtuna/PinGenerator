using UnitTests.TestData;

namespace UnitTests.Models.Generators;

public class PinGeneratorTests
{
    [TestCase(1, '1', '2', '3', "3")]
    [TestCase(2, '1', '2', '3', "33")]
    [TestCase(3, '1', '2', '3', "333")]
    [TestCase(4, '1', '2', '3', "3333")]
    [TestCase(5, '1', '2', '3', "33333")]
    public void Pin_ShouldBe(int length, char nextRandomDigit, char nextSequentialDigit, char applyRulesDigit,
        string expectedPin)
    {
        SimpleDigitProvider digitProvider = new(nextRandomDigit, nextSequentialDigit, '_');
        SimpleDigitRuleManager digitRuleManager = new(applyRulesDigit);
        PinGenerator.Models.Generators.PinGenerator pinGenerator = new(digitRuleManager, digitProvider);

        string pin = pinGenerator.CreatePin(length);
        Assert.That(pin, Has.Length.EqualTo(expectedPin.Length));
        Assert.That(pin, Is.EqualTo(expectedPin));
    }
}