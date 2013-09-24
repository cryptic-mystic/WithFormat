namespace WithFormat.Integer
{
    public static class IntegerExtentions
    {
        public static IntegerFormatBuilder AsDecimal(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static IntegerFormatBuilder AsHexadecimal(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static IntegerFormatBuilder AsExponential(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static IntegerFormatBuilder AsCurrency(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static IntegerFormatBuilder AsFixedPoint(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static IntegerFormatBuilder AsGeneral(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static IntegerFormatBuilder AsNumeric(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static IntegerFormatBuilder AsPercent(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}