using PinGenerator.Models.Builders;

namespace IntegrationTests.Models.Builders;

public class PinGeneratorBuilderTests
{
    [Test]
    public void PinGeneratorBuilder_ShouldBuild_WithGoodDefaults()
    {
        PinGeneratorBuilder builder = new();
        PinGenerator.Models.Generators.PinGenerator pinGenerator = builder.Build();
        string pin = pinGenerator.CreatePin(4);

        Assert.That(pinGenerator.GetType(), Is.EqualTo(typeof(PinGenerator.Models.Generators.PinGenerator)));
        Assert.That(pin, Is.Not.Null);
        Assert.That(pin.Length, Is.EqualTo(4));
    }
}