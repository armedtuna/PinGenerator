namespace PinGenerator.Models.DigitRules;

public delegate char RuleFailedDelegate(char? previousDigit, char digit);

public interface IDigitRule
{
    public (bool ruleFailed, char? suggestedDigit) HasRuleFailed(char? previousDigit, char digit);
}