using System;
using System.Globalization;
using WithFormat.Cultures;

namespace WithFormat.Long
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

        public LongFormatBuilder Using<T>() where T : IFormatCulture, new()
        {
            Culture = new T().Culture();
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