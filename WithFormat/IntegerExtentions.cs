namespace WithFormat
{
    public static class IntegerExtentions
    {
        public static IntegerFormatBuilder WithDecimal(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static IntegerFormatBuilder WithHexadecimal(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static IntegerFormatBuilder WithExponential(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static IntegerFormatBuilder WithCurrency(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static IntegerFormatBuilder WithFixedPoint(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static IntegerFormatBuilder WithGeneral(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static IntegerFormatBuilder WithNumeric(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static IntegerFormatBuilder WithPercent(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}