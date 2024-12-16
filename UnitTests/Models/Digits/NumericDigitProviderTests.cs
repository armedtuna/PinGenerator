using PinGenerator.Models.Digits;

namespace UnitTests.Models.Digits;

public class NumericDigitProviderTests
{
    private readonly NumericDigitProvider _sut = new();
    
    [TestCase('0', '9')]
    [TestCase('1', '0')]
    public void PreviousSequentialDigitShouldBe(char digit, char expectedDigit)
    {
        char previousSequentialDigit = _sut.PreviousSequentialDigit(digit);
        
        Assert.That(previousSequentialDigit, Is.EqualTo(expectedDigit));
    }
    
    [TestCase('4', '5')]
    [TestCase('9', '0')]
    public void NextSequentialDigitShouldBe(char digit, char expectedDigit)
    {
        char nextSequentialDigit = _sut.NextSequentialDigit(digit);
        
        Assert.That(nextSequentialDigit, Is.EqualTo(expectedDigit));
    }
}