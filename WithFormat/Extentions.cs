namespace WithFormat
{
    public static class Extentions
    {
        public static IntegerFormatBuilder DecimalFormat(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static IntegerFormatBuilder CurrencyFormat(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static IntegerFormatBuilder Precision(this IntegerFormatBuilder builder, int precision)
        {
            builder.PrecisionSpecifier = precision.DecimalFormat().ToString();
            return builder;
        }

        public static CurrencyCultureFormatBuilder Precision(this CurrencyCultureFormatBuilder builder, int precision)
        {
            builder.PrecisionSpecifier = precision.DecimalFormat().ToString();
            return builder;
        }
    }
}