namespace PinGenerator.Models.Digits;

public interface IDigitProvider
{
    char NextSequentialDigit(char digit);
    char PreviousSequentialDigit(char digit);
    char RandomDigit();
}