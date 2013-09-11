namespace WithFormat.Long
{
    public static class LongExtentions
    {
        public static LongFormatBuilder WithCurrency(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static LongFormatBuilder WithExponential(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static LongFormatBuilder WithFixedPoint(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static LongFormatBuilder WithGeneral(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static LongFormatBuilder WithNumeric(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static LongFormatBuilder WithPercent(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}