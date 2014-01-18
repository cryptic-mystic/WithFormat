namespace WithFormat.Long
{
    public static class LongExtentions
    {
        public static LongFormatBuilder AsCurrency(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static LongFormatBuilder AsExponential(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static LongFormatBuilder AsFixedPoint(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static LongFormatBuilder AsGeneral(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static LongFormatBuilder AsNumeric(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static LongFormatBuilder AsPercent(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.PercentSpecifier);
        }

        public static LongFormatBuilder AsDecimal(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static LongFormatBuilder AsHexadecimal(this long input)
        {
            return new LongFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }
    }
}