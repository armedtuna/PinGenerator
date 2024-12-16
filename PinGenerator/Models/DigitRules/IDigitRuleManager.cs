namespace PinGenerator.Models.DigitRules;

public interface IDigitRuleManager
{
    char ApplyRules(char? previousDigit, char digit);
}