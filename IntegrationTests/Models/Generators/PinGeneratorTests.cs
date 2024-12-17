using PinGenerator.Models.Builders;

namespace IntegrationTests.Models.Generators;

public class PinGeneratorTests
{
    private readonly PinGenerator.Models.Generators.PinGenerator _sut;

    public PinGeneratorTests()
    {
        PinGeneratorBuilder pinGeneratorBuilder = new();
        _sut = pinGeneratorBuilder.Build();
    }
    
    [TestCase(1, 1)]
    [TestCase(4, 4)]
    [TestCase(10, 10)]
    public void Pin_ShouldBeGenerated(int pinLength, int expectedPinLength)
    {
        string pin = _sut.CreatePin(pinLength);

        Assert.That(pin, Has.Length.EqualTo(expectedPinLength));
        foreach (char c in pin)
        {
            Assert.That(c, Is.GreaterThanOrEqualTo('0'));
            Assert.That(c, Is.LessThanOrEqualTo('9'));
        }
    }
}