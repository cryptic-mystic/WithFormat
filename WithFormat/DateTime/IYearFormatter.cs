namespace WithFormat.DateTime
{
    public interface IYearFormatter
    {
        DateTimeFormatBuilder WithOneDigit();
        DateTimeFormatBuilder WithTwoDigits();
        DateTimeFormatBuilder WithAtLeastThreeDigits();
        DateTimeFormatBuilder WithFourDigits();
        DateTimeFormatBuilder WithFiveDigits();
        DateTimeFormatBuilder WithDigits(int digits);
    }
}