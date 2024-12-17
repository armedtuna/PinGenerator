namespace PinGenerator.Models.DigitRules;

public class DigitRuleManager(IEnumerable<IDigitRule> digitRules) : IDigitRuleManager
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