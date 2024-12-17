using PinGenerator.Models.Builders;
using PinGenerator.Models.Digits;

namespace IntegrationTests.Models.Builders;

public class PinGeneratorBuilderTests
{
    [Test]
    public void PinGeneratorBuilder_ShouldBuild_WithGoodDefaults()
    {
        PinGeneratorBuilder builder = new();
        PinGenerator.Models.Generators.PinGenerator pinGenerator = builder.Build();

        Assert.That(pinGenerator.GetType(), Is.EqualTo(typeof(PinGenerator.Models.Generators.PinGenerator)));
        
        UsePinBuilderPinGenerator(pinGenerator);
    }

    [Test]
    public void PinGeneratorBuilder_ShouldBuild_WithSpecificChoices()
    {
        PinGeneratorBuilder builder = new(new NumericDigitProvider());
        builder.AddNoIncrementalDigitsRule();
        builder.AddNoConsecutiveRepeatDigitsRule();
        PinGenerator.Models.Generators.PinGenerator pinGenerator = builder.Build();

        Assert.That(pinGenerator.GetType(), Is.EqualTo(typeof(PinGenerator.Models.Generators.PinGenerator)));
        
        UsePinBuilderPinGenerator(pinGenerator);
    }

    private static void UsePinBuilderPinGenerator(PinGenerator.Models.Generators.PinGenerator pinGenerator)
    {
        string pin = pinGenerator.CreatePin(4);

        Assert.That(pin, Is.Not.Null);
        Assert.That(pin.Length, Is.EqualTo(4));
    }
}