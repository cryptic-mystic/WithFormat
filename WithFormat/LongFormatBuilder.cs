using System;
using System.Globalization;

namespace WithFormat
{
    public class LongFormatBuilder
    {
        private long Subject { get; set; }
        private string FormatSpecifier { get; set; }
        private CultureInfo Culture { get; set; }
        private int? Precision { get; set; }

        internal LongFormatBuilder(long subject, string formatSpecifier)
        {
            Subject = subject;
            FormatSpecifier = formatSpecifier;
        }

        public LongFormatBuilder WithCulture<T>() where T : IFormatCulture, new()
        {
            var culture = new T();
            Culture = culture.Culture();
            return this;
        }

        public LongFormatBuilder WithPrecision(int precision)
        {
            Precision = precision;
            return this;
        }

        public string Format()
        {
            var formatString = String.Format("{0}{1}", FormatSpecifier, Precision);
            return Subject.ToString(formatString, Culture);
        }
    }
}