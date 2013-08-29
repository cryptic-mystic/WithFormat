using System;

namespace WithFormat
{
    public class PrecisionFormatBuilder : IntegerFormatBuilder
    {
        private int Precision { get; set; }

        public PrecisionFormatBuilder(IntegerFormatBuilder builder, int precision) : base(builder.Subject, builder.FormatSpecifier, builder.Culture)
        {
            Precision = precision;
        }

        public override string Format()
        {
            var formatString = String.Format("{0}{1}", FormatSpecifier, Precision);
            return Subject.ToString(formatString, Culture);
        }
    }
}