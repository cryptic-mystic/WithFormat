namespace WithFormat.DateTime
{
    public interface IMinutesFormatter
    {
        DateTimeFormatBuilder WithSingleDigit();
        DateTimeFormatBuilder WithTwoDigits();
    }
}