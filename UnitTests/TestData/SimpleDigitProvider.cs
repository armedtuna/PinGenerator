using PinGenerator.Models.Digits;

namespace UnitTests.TestData;

public class SimpleDigitProvider(char randomDigit, char nextSequentialDigit, char previousSequentialDigit)
    : IDigitProvider
{
    public char RandomDigit() =>
        randomDigit;

    public char NextSequentialDigit(char _) =>
        nextSequentialDigit;

    public char PreviousSequentialDigit(char _) =>
        previousSequentialDigit;
}