using System.Globalization;

namespace WithFormat
{
    public static class Extentions
    {
        public static IntegerFormatBuilder DecimalFormat(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.DecimalSpecifier);
        }

        public static IntegerFormatBuilder CurrencyFormat(this int input)
        {
            return new IntegerFormatBuilder(input, FormatConstants.CurrencySpecifier);
        }

        public static CurrencyCultureFormatBuilder UsDollar(this IntegerFormatBuilder builder)
        {
            return new CurrencyCultureFormatBuilder(builder, CurrencyCultureConstants.UsDollar);
        }

        public static CurrencyCultureFormatBuilder JapaneseYen(this IntegerFormatBuilder builder)
        {
            return new CurrencyCultureFormatBuilder(builder, CurrencyCultureConstants.JapaneseYen);
        }

        public static IntegerFormatBuilder Precision(this IntegerFormatBuilder builder, int precision)
        {
            builder.PrecisionSpecifier = precision.DecimalFormat().ToString();
            return builder;
        }

        public static CurrencyCultureFormatBuilder Precision(this CurrencyCultureFormatBuilder builder, int precision)
        {
            builder.PrecisionSpecifier = precision.DecimalFormat().ToString();
            return builder;
        }
    }

    public class CurrencyCultureFormatBuilder
    {
        private readonly IntegerFormatBuilder subject;
        private readonly string _cultureString;

        public CurrencyCultureFormatBuilder(IntegerFormatBuilder subject, string cultureString)
        {
            this.subject = subject;
            this._cultureString = cultureString;
        }

        public string PrecisionSpecifier
        {
            get { return subject.PrecisionSpecifier; }
            set { subject.PrecisionSpecifier = value; }
        }

        public override string ToString()
        {
            return subject.ToString(CultureInfo.CreateSpecificCulture(_cultureString));
        }
    }
}