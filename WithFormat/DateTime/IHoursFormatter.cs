namespace WithFormat.DateTime
{
    public interface IHoursFormatter
    {
        DateTimeFormatBuilder With12HrSingleDigit();
        DateTimeFormatBuilder With12HrDoubleDigit();
        DateTimeFormatBuilder With24HrSingleDigit();
        DateTimeFormatBuilder With24HrDoubleDigit();
    }
}