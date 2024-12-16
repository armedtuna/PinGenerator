using PinGenerator.Models.DigitRules;
using PinGenerator.Models.Digits;
using PinGenerator.Models.Generators;

namespace IntegrationTests.Models.Generators;

public class PinsGeneratorTests
{
    private PinsGenerator _sut;

    public PinsGeneratorTests()
    {
        NumericDigitProvider digitProvider = new();
        IDigitRule[] rules =
        [
            new NoConsecutiveRepeatDigitsRule((_, digit) =>
                digitProvider.NextSequentialDigit(digit)),
            new NoIncrementalDigitsRule(digitProvider,
                (_, digit) =>
                    digitProvider.NextSequentialDigit(digit))
        ];
        DigitRuleManager digitRuleManager = new(rules, digitProvider);
        PinGenerator.Models.Generators.PinGenerator pinGenerator = new(digitRuleManager, digitProvider);
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