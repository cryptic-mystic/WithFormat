namespace WithFormat.DateTime
{
    public interface IUtcFormatter
    {
        DateTimeFormatBuilder WithSingleDigitHours();
        DateTimeFormatBuilder WithDoubleDigitHours();
        DateTimeFormatBuilder WithHourAndMinutesOffset();
    }
}