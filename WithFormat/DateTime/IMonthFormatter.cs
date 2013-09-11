namespace WithFormat.DateTime
{
    public interface IMonthFormatter
    {
        DateTimeFormatBuilder WithNumericMonth();
        DateTimeFormatBuilder WithTwoDigitMonth();
        DateTimeFormatBuilder WithAbbreviatedMonth();
        DateTimeFormatBuilder WithFullMonth();
    }
}