using PinGenerator;

namespace TestProject1;

public class Tests
{
    private readonly ActualPinGenerator _actualPinGenerator = new();
    private readonly BatchPinGenerator _batchPinGenerator = new();

    [Test]
    public void ConfirmThatPinIsCorrectLength()
    {
        const int pinLength = 4;
        
        string result = _actualPinGenerator.Generate(pinLength);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Length, Is.EqualTo(pinLength));
    }

    [TestCase(10)]
    [TestCase(100)]
    [TestCase(1000)]
    public void ConfirmThatNumberOfPinsAreGenerated(int numberOfPins)
    {
        const int pinLength = 4;
        
        string[] results = _batchPinGenerator.Generate(numberOfPins, pinLength);
        Assert.That(results, Is.Not.Null);
        Assert.That(results.Length, Is.EqualTo(numberOfPins));
    }

    [TestCase(10)]
    [TestCase(100)]
    [TestCase(1000)]
    public void ConfirmThatPinsAreActuallyUnique(int numberOfPins)
    {
        const int pinLength = 4;
        
        string[] results = _batchPinGenerator.Generate(numberOfPins, pinLength);
        string[] distinctResults = results.Distinct().ToArray();
        
        Assert.That(results.Length, Is.EqualTo(distinctResults.Length));
    }
}