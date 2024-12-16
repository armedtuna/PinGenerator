using PinGenerator.Models.DigitRules;
using PinGenerator.Models.Digits;

namespace PinGenerator.Models.Generators;

public class PinGenerator(IDigitRuleManager digitRuleManager, IDigitProvider digitProvider) : IPinGenerator
{
    public string CreatePin(int length)
    {
        string digits = string.Empty;
        char? previousDigit = null;
        for (int i = 0; i < length; i++)
        {
            char digit = digitProvider.RandomDigit();
            digit = digitRuleManager.ApplyRules(previousDigit, digit);
            digits += digit;
            previousDigit = digit;
        }
        
        return digits;
    }
}