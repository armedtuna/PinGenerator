using PinGenerator.Models.Generators;

namespace UnitTests.TestData;

public class SimplePinGenerator(string startingPin, char incrementalChar) : IPinGenerator
{
    private string _startingPin = startingPin;

    public string CreatePin(int _) =>
        _startingPin += incrementalChar;
}