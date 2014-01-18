namespace WithFormat.Short
{
    public static class ShortExtentions
    {
        public static ShortFormatBuilder AsDecimal(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static ShortFormatBuilder AsHexadecimal(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static ShortFormatBuilder AsExponential(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static ShortFormatBuilder AsCurrency(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static ShortFormatBuilder AsFixedPoint(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static ShortFormatBuilder AsGeneral(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static ShortFormatBuilder AsNumeric(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static ShortFormatBuilder AsPercent(this short input)
        {
            return new ShortFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}