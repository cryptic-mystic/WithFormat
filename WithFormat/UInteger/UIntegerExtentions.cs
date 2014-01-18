namespace WithFormat.UInteger
{
    public static class UIntegerExtentions
    {
        public static UIntegerFormatBuilder AsDecimal(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static UIntegerFormatBuilder AsHexadecimal(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.HexidecimalSpecifier);
        }

        public static UIntegerFormatBuilder AsExponential(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.ExponentialSpecifier);
        }

        public static UIntegerFormatBuilder AsCurrency(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static UIntegerFormatBuilder AsFixedPoint(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.FixedPointSpecifier);
        }

        public static UIntegerFormatBuilder AsGeneral(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.GeneralSpecifier);
        }

        public static UIntegerFormatBuilder AsNumeric(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.NumericSpecifier);
        }

        public static UIntegerFormatBuilder AsPercent(this uint input)
        {
            return new UIntegerFormatBuilder(input, FormatConstants.PercentSpecifier);
        }
    }
}