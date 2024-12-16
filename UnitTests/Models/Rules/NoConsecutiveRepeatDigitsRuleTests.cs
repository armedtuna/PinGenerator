using PinGenerator.Models.DigitRules;

namespace UnitTests.Models.Rules;

public class NoConsecutiveRepeatDigitsRuleTests
{
    [TestCase('1', '1')]
    public void ConsecutiveRepeatDigits_ShouldFail(char? previousDigit, char digit)
    {
        NoConsecutiveRepeatDigitsRule sut = new(null);
        
        (bool hasFailed, char? _) = sut.HasRuleFailed(previousDigit, digit);
        
        Assert.That(hasFailed, Is.True);
    }

    [TestCase(null, '2')]
    [TestCase('1', '2')]
    public void ConsecutiveRepeatDigits_ShouldNotFail(char? previousDigit, char digit)
    {
        NoConsecutiveRepeatDigitsRule sut = new(null);
        
        (bool hasFailed, char? _) = sut.HasRuleFailed(previousDigit, digit);
        
        Assert.That(hasFailed, Is.False);
    }

    [TestCase('1', '1', '2')]
    public void ConsecutiveRepeatDigits_WhenFailing_ShouldUseDelegate(char? previousDigit, char digit,
        char delegateDigit)
    {
        NoConsecutiveRepeatDigitsRule sut = new(RuleFailed);

        (bool hasRuleFailed, char? suggestedDigit) = sut.HasRuleFailed(previousDigit, digit);
        Assert.Multiple(() =>
        {
            Assert.That(hasRuleFailed, Is.True);
            Assert.That(suggestedDigit, Is.EqualTo(delegateDigit));
        });
        return;

        char RuleFailed(char? _, char __) =>
            delegateDigit;
    }
}