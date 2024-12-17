using PinGenerator.Models.DigitRules;
using PinGenerator.Models.Digits;

namespace PinGenerator.Models.Builders;

public class PinGeneratorBuilder
{
    private readonly IDigitProvider _digitProvider;
    private readonly List<IDigitRule> _digitRules = [];

    public PinGeneratorBuilder(IDigitProvider? digitProvider = null)
    {
        if (digitProvider == null)
        {
            _digitProvider ??= new NumericDigitProvider();
        }
        else
        {
            _digitProvider = digitProvider;
        }
    }

    public PinGeneratorBuilder AddNoConsecutiveRepeatDigitsRule(RuleFailedDelegate? ruleFailed = null)
    {
        IDigitRule digitRule = ruleFailed == null
            ? new NoConsecutiveRepeatDigitsRule((_, digit) => _digitProvider.NextSequentialDigit(digit))
            : new NoConsecutiveRepeatDigitsRule(ruleFailed);
        _digitRules.Add(digitRule);
        return this;
    }

    public PinGeneratorBuilder AddNoIncrementalDigitsRule(RuleFailedDelegate? ruleFailed = null)
    {
        IDigitRule digitRule = ruleFailed == null
            ? new NoIncrementalDigitsRule(_digitProvider, (_, digit) => _digitProvider.NextSequentialDigit(digit))
            : new NoIncrementalDigitsRule(_digitProvider, ruleFailed);
        _digitRules.Add(digitRule);
        return this;
    }

    public Generators.PinGenerator Build()
    {
        IDigitRuleManager digitRuleManager = new DigitRuleManager(_digitRules);
        return new Generators.PinGenerator(digitRuleManager, _digitProvider);
    }
}