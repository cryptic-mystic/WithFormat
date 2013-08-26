using System;

namespace WithFormat
{
    public class PrecisionFormatBuilder : IntegerFormatBuilder
    {
        internal int Precision { get; private set; }

        public PrecisionFormatBuilder(IntegerFormatBuilder builder, int precision) : base(builder.Subject, builder.FormatSpecifier, builder.Culture)
        {
            Precision = precision;
        }

        public string Format()
        {
            var formatString = String.Format("{0}{1}", FormatSpecifier, Precision);
            return Subject.ToString(formatString, Culture);
        }
    }
}