namespace WithFormat.DateTime
{
    public static class DateTimeExtentions
    {
        public static DateTimeFormatBuilder AsDateTime(this System.DateTime input)
        {
            return new DateTimeFormatBuilder(input);
        } 
    }
}