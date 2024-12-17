// See https://aka.ms/new-console-template for more information

// todo-at: add editorconfig?

using PinGenerator.Models.Builders;
using PinGenerator.Models.Generators;

const int pinLength = 4;

// The code is mainly exercised in the unit and integration test projects.
PinGeneratorBuilder builder = new();
PinGenerator.Models.Generators.PinGenerator pinGenerator = builder.Build();
PinsGenerator pinsGenerator = new(pinGenerator, pinLength);
HashSet<string> pins = pinsGenerator.CreateUniquePins(100);
foreach (string pin in pins)
{
    Console.Write($"{pin} ");
}
