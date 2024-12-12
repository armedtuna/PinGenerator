namespace PinGenerator;

public class ActualPinGenerator
{
    public string Generate(int length)
    {
        string result = string.Empty;
        int? previousDigit = null;
        for (int i = 0; i < length; i++)
        {
            char digit = GenerateDigit(previousDigit);
            result += digit;
            previousDigit = digit;
        }
        
        return result;
    }

    // todo-at: starting point?
    // todo-at: could this be hexadecimal? :) as if users would want that!!! :D
    // todo-at: tests -- how to test this private method? should this be a new class?
    // - test for 6 isn't followed by a 5, 6, or 7
    // - would that include 9 followed by a 0?
    // todo-at: should there be a valid digits array? and digits checked against
    private static char GenerateDigit(int? previousDigit)
    {
        Random random = new Random();
        int digit = random.Next(10);

        if (previousDigit.HasValue)
        {
            // assuming that 9 followed by 0 is sequential and should be avoided.
            if (digit == previousDigit)
            {
                digit++;
                digit = EnsureSingleDigit(digit);
            }

            int digitBefore = EnsureSingleDigit(digit - 1);
            if (digit == digitBefore)
            {
                digit--;
            }

            int digitAfter = EnsureSingleDigit(digit + 1);
            if (digit == digitAfter)
            {
                digit++;
            }
        }

        // todo-at: also check for 8 = 9 - 1 = sequential
        /*
         * if r is a 9, then ++
         * if r is a 10, then ++
         * if r > 9
         * 0123456789
        */
        
        return digit.ToString()[0];
    }

    private static int EnsureSingleDigit(int digit)
    {
        const int lowestValidDigit = 0;
        const int highestValidDigit = 9;
        const int validDigitsBase = 10;
        if (digit is < lowestValidDigit or > highestValidDigit)
        {
            digit %= validDigitsBase;
        }

        return digit;
    }
}
