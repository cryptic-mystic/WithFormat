namespace WithFormat.SByte
{
    public static class SByteExtentions
    {
        public static SByteFormatBuilder AsDecimal(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static SByteFormatBuilder AsHexadecimal(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static SByteFormatBuilder AsExponential(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static SByteFormatBuilder AsCurrency(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static SByteFormatBuilder AsFixedPoint(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static SByteFormatBuilder AsGeneral(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static SByteFormatBuilder AsNumeric(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static SByteFormatBuilder AsPercent(this sbyte input)
        {
            return new SByteFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}