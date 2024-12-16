namespace PinGenerator.Models.Generators;

public class PinsGenerator(IPinGenerator pinGenerator, int pinLength) : IPinsGenerator
{
    public HashSet<string> CreateUniquePins(int count)
    {
        HashSet<string> pins = [];
        while (pins.Count < count)
        {
            string pin = pinGenerator.CreatePin(pinLength);
            pins.Add(pin);
        }

        return pins;
    }
}