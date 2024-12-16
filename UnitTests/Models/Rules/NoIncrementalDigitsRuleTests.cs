using PinGenerator.Models.DigitRules;
using UnitTests.TestData;

namespace UnitTests.Models.Rules;

public class NoIncrementalDigitsRuleTests
{
    [TestCase('1', '2', '1', '3')]
    [TestCase('3', '2', '1', '3')]
    public void NoIncrementalDigitsRule_ShouldFail(char? previousDigit, char digit, char previousSequentialDigit,
        char nextSequentialDigit)
    {
        SimpleDigitProvider digitProvider = new('_', nextSequentialDigit, previousSequentialDigit);
        NoIncrementalDigitsRule sut = new(digitProvider, null);

        (bool ruleFailed, char? _) = sut.HasRuleFailed(previousDigit, digit);

        Assert.That(ruleFailed, Is.True);
    }

    [TestCase(null, '1', '0', '2')]
    [TestCase('4', '1', '0', '2')]
    [TestCase('1', '1', '0', '2')]
    public void NoIncrementalDigitsRule_ShouldNotFail(char? previousDigit, char digit, char previousSequentialDigit,
        char nextSequentialDigit)
    {
        SimpleDigitProvider digitProvider = new('_', nextSequentialDigit, previousSequentialDigit);
        NoIncrementalDigitsRule sut = new(digitProvider, null);

        (bool ruleFailed, char? _) = sut.HasRuleFailed(previousDigit, digit);

        Assert.That(ruleFailed, Is.False);
    }

    [TestCase('1', '2', '1', '3', '4')]
    [TestCase('3', '2', '1', '3', '4')]
    public void NoIncrementalDigits_WhenFailing_ShouldUseDelegate(char? previousDigit, char digit,
        char previousSequentialDigit, char nextSequentialDigit, char delegateDigit)
    {
        SimpleDigitProvider digitProvider = new('_', nextSequentialDigit, previousSequentialDigit);
        NoIncrementalDigitsRule sut = new(digitProvider, RuleFailed);

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