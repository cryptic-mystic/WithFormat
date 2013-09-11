namespace WithFormat.DateTime
{
    public interface IDayFormatter
    {
        DateTimeFormatBuilder WithAtLeastOneDigit();
        DateTimeFormatBuilder WithTwoDigits();
        DateTimeFormatBuilder WithAbbreviatedDayOfWeek();
        DateTimeFormatBuilder WithFullDayOfWeek();
    }
}