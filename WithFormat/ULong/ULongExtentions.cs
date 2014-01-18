namespace WithFormat.ULong
{
    public static class ULongExtentions
    {
        public static ULongFormatBuilder AsCurrency(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static ULongFormatBuilder AsExponential(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static ULongFormatBuilder AsFixedPoint(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static ULongFormatBuilder AsGeneral(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static ULongFormatBuilder AsNumeric(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static ULongFormatBuilder AsPercent(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.PercentSpecifier);
        }

        public static ULongFormatBuilder AsDecimal(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static ULongFormatBuilder AsHexadecimal(this ulong input)
        {
            return new ULongFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }
    }
}