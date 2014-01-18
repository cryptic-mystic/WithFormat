namespace WithFormat.Byte
{
    public static class ByteExtentions
    {
        public static ByteFormatBuilder AsDecimal(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static ByteFormatBuilder AsHexadecimal(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static ByteFormatBuilder AsExponential(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static ByteFormatBuilder AsCurrency(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static ByteFormatBuilder AsFixedPoint(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static ByteFormatBuilder AsGeneral(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static ByteFormatBuilder AsNumeric(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static ByteFormatBuilder AsPercent(this byte input)
        {
            return new ByteFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}