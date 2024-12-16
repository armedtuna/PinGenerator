// using PinGenerator.Models.Digits;
//
// namespace IntegrationTests.TestData;
//
// public class TestGivenDigitsProvider(char[] digits) : IDigitProvider
// {
//     private int _currentIndex = 0;
//
//     public char RandomDigit() =>
//         digits[_currentIndex++];
//
//     public char NextSequentialDigit(char digit) =>
//         ++digit;
//
//     public char PreviousSequentialDigit(char digit)
//     {
//         throw new NotImplementedException();
//     }
// }