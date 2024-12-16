using PinGenerator.Models.Digits;

namespace PinGenerator.Models.DigitRules;

public class NoIncrementalDigitsRule(IDigitProvider digitProvider, RuleFailedDelegate? ruleFailed) : IDigitRule
{
    public (bool ruleFailed, char? suggestedDigit) HasRuleFailed(char? previousDigit, char digit)
    {
        if (!previousDigit.HasValue)
        {
            return (false, null);
        }

        bool failed = previousDigit == digitProvider.PreviousSequentialDigit(digit)
                      || previousDigit == digitProvider.NextSequentialDigit(digit);
        if (failed)
        {
            if (ruleFailed != null)
            {
                digit = ruleFailed(previousDigit, digit);
            }
        }
            
        return (failed, digit);
    }
}