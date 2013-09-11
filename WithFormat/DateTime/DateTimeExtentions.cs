namespace WithFormat.DateTime
{
    public static class DateTimeExtentions
    {
        public static DateTimeFormatBuilder WithDate(this System.DateTime input)
        {
            return new DateTimeFormatBuilder(input);
        } 
    }
}