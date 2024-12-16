using PinGenerator.Models.DigitRules;

namespace UnitTests.TestData;

public class SimpleDigitRuleManager(char applyRulesDigit) : IDigitRuleManager
{
    public char ApplyRules(char? _, char __) =>
        applyRulesDigit;
}