namespace WithFormat.UShort
{
    public static class UShortExtentions
    {
        public static UShortFormatBuilder AsDecimal(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static UShortFormatBuilder AsHexadecimal(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static UShortFormatBuilder AsExponential(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static UShortFormatBuilder AsCurrency(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static UShortFormatBuilder AsFixedPoint(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static UShortFormatBuilder AsGeneral(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static UShortFormatBuilder AsNumeric(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static UShortFormatBuilder AsPercent(this ushort input)
        {
            return new UShortFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}