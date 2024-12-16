namespace PinGenerator.Models.Digits;

public class NumericDigitProvider : IDigitProvider
{
    private readonly char[] _digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    private readonly int _digitsLowerBound;
    private readonly int _digitsUpperBound;
    private readonly Random _random = new();

    public NumericDigitProvider()
    {
        _digitsLowerBound = _digits.GetLowerBound(0);
        _digitsUpperBound = _digits.GetUpperBound(0);
    }

    public char NextSequentialDigit(char digit) =>
        IncrementDigit(digit, 1);

    public char PreviousSequentialDigit(char digit) =>
        IncrementDigit(digit, -1);
    
    // todo-at: tests that it reaches all values?
    public char RandomDigit()
    {
        int randomIndex = _random.Next(_digits.Length);
        return _digits.ElementAt(randomIndex);
    }
    
    private char IncrementDigit(char digit, int increment)
    {
        int digitIndex = Array.IndexOf(_digits, digit);
        if (digitIndex == -1)
        {
            throw new ArgumentException($"Digit '{digit}' isn't available in '{string.Join(',', _digits)}'.");
        }
        
        digitIndex += increment;
        digitIndex = EnsureValidDigitBounds(digitIndex);
        
        return _digits[digitIndex];
    }

    private int EnsureValidDigitBounds(int digitIndex)
    {
        // keep this simple for now / at the moment only +1 and -1 changes are needed.
        if (digitIndex < _digitsLowerBound)
        {
            digitIndex = _digitsUpperBound;
        }
        else if (digitIndex > _digitsUpperBound)
        {
            digitIndex = _digitsLowerBound;
        }

        return digitIndex;
    }
}