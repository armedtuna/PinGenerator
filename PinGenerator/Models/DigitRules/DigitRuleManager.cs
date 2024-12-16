using PinGenerator.Models.Digits;

namespace PinGenerator.Models.DigitRules;

public class DigitRuleManager(IDigitRule[] digitRules, IDigitProvider digitProvider) : IDigitRuleManager
{
    public char ApplyRules(char? previousDigit, char digit)
    {
        foreach (var digitRule in digitRules)
        {
            bool ruleFailed;
            do
            {
                (ruleFailed, char? suggestedDigit) = digitRule.HasRuleFailed(previousDigit, digit);
                if (suggestedDigit.HasValue)
                {
                    digit = suggestedDigit.Value;
                }
            } while (ruleFailed);
        }

        return digit;
    }
}