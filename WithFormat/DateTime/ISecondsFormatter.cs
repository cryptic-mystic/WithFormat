namespace WithFormat.DateTime
{
    public interface ISecondsFormatter
    {
        DateTimeFormatBuilder AsSingleDigit();
        DateTimeFormatBuilder AsDoubleDigit();
    }
}