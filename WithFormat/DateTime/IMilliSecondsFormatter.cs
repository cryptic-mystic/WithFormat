namespace WithFormat.DateTime
{
    public interface IMilliSecondsFormatter
    {
        DateTimeFormatBuilder InTenthsOfASecond();
        DateTimeFormatBuilder InHundredthsOfASecond();
        DateTimeFormatBuilder InMilliseconds();
        DateTimeFormatBuilder InTenThousandthsOfASecond();
        DateTimeFormatBuilder InHundredThousandthsOfASecond();
        DateTimeFormatBuilder InMillionthsOfASecond();
        DateTimeFormatBuilder InTenMillionthsOfASecond();
        DateTimeFormatBuilder InTenthsOfASecondWithoutZeroes();
        DateTimeFormatBuilder InHundredthsOfASecondWithoutZeroes();
        DateTimeFormatBuilder InMillisecondsWithoutZeroes();
        DateTimeFormatBuilder InTenThousandthsOfASecondWithoutZeroes();
        DateTimeFormatBuilder InHundredThousandthsOfASecondWithoutZeroes();
        DateTimeFormatBuilder InMillionthsOfASecondWithoutZeroes();
        DateTimeFormatBuilder InTenMillionthsOfASecondWithoutZeroes();
    }
}