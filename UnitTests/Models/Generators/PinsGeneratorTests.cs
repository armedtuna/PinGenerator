using PinGenerator.Models.Generators;
using UnitTests.TestData;

namespace UnitTests.Models.Generators;

public class PinsGeneratorTests
{
    [TestCase(1, 1)]
    [TestCase(10, 10)]
    [TestCase(1000, 1000)]
    public void Pins_ShouldBe(int count, int expectedCount)
    {
        SimplePinGenerator pinGenerator = new("1", '1');
        PinsGenerator pinsGenerator = new(pinGenerator, 1);

        HashSet<string> pins = pinsGenerator.CreateUniquePins(count);
        
        Assert.That(pins.Count, Is.EqualTo(expectedCount));
    }
}