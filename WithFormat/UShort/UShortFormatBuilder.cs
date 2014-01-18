using System;
using System.Globalization;
using WithFormat.Cultures;

namespace WithFormat.UShort
{
    public class UShortFormatBuilder
    {
        private ushort Subject { get; set; }
        private string FormatSpecifier { get; set; }
        private CultureInfo Culture { get; set; }
        private int? Precision { get; set; }

        internal UShortFormatBuilder(ushort subject, string formatSpecifier)
        {
            Subject = subject;
            FormatSpecifier = formatSpecifier;
        }

        public UShortFormatBuilder Using<T>() where T : IFormatCulture, new()
        {
            Culture = new T().Culture();
            return this;
        }

        public UShortFormatBuilder WithPrecision(int precision)
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