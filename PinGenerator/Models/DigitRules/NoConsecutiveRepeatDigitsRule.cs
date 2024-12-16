namespace PinGenerator.Models.DigitRules;

public class NoConsecutiveRepeatDigitsRule(RuleFailedDelegate? ruleFailed) : IDigitRule
{
    public (bool ruleFailed, char? suggestedDigit) HasRuleFailed(char? previousDigit, char digit)
    {
        bool isDifferent = previousDigit != digit;
        if (isDifferent)
        {
            return (false, null);
        }

        if (ruleFailed != null)
        {
            digit = ruleFailed(previousDigit, digit);
        }

        return (true, digit);
    }
}