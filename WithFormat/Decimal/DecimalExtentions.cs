namespace WithFormat.Decimal
{
    public static class DecimalExtentions
    {
        public static DecimalFormatBuilder WithPercent(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.PercentSpecifier);
        }

        public static DecimalFormatBuilder WithCurrency(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static DecimalFormatBuilder WithExponential(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static DecimalFormatBuilder WithFixedPoint(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static DecimalFormatBuilder WithGeneral(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static DecimalFormatBuilder WithNumeric(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.NumericSpecifier);
        }
    }
}