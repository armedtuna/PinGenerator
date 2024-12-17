using PinGenerator.Models.Builders;
using PinGenerator.Models.Generators;

namespace IntegrationTests.Models.Generators;

public class PinsGeneratorTests
{
    private readonly PinsGenerator _sut;

    public PinsGeneratorTests()
    {
        PinGeneratorBuilder pinGeneratorBuilder = new();
        PinGenerator.Models.Generators.PinGenerator pinGenerator = pinGeneratorBuilder.Build();
        _sut = new PinsGenerator(pinGenerator, 4);
    }

    [TestCase(1, 1)]
    [TestCase(10, 10)]
    [TestCase(1000, 1000)]
    public void UniquePins_ShouldBeGenerated(int numberOfPins, int expectedNumberOfPins)
    {
        HashSet<string> pins = _sut.CreateUniquePins(numberOfPins);
        
        Assert.That(pins.Count, Is.EqualTo(expectedNumberOfPins));
    }
}