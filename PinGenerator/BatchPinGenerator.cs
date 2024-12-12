namespace PinGenerator;

public class BatchPinGenerator
{
    // string[] Generate for interface
    public string[] Generate(int size, int pinLength)
    {
        ActualPinGenerator actualPinGenerator = new();
        
        int i = 0;
        HashSet<string> pins = new();
        while (i < size)
        {
            string pin = actualPinGenerator.Generate(pinLength);
            if (!pins.Contains(pin))
            {
                pins.Add(pin);
                i++;
            }
        }

        return pins.ToArray();
    }
}