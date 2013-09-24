namespace WithFormat.Decimal
{
    public static class DecimalExtentions
    {
        public static DecimalFormatBuilder AsPercent(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.PercentSpecifier);
        }

        public static DecimalFormatBuilder AsCurrency(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static DecimalFormatBuilder AsExponential(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static DecimalFormatBuilder AsFixedPoint(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static DecimalFormatBuilder AsGeneral(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static DecimalFormatBuilder AsNumeric(this decimal input)
        {
            return new DecimalFormatBuilder(input, FormatConstants.NumericSpecifier);
        }
    }
}