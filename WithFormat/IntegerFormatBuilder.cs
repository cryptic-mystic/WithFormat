using System;
using System.Globalization;

namespace WithFormat
{
    public class IntegerFormatBuilder
    {
        private readonly int _subject;
        private readonly char _formatSpecifier;

        public string PrecisionSpecifier { get; set; }

        public IntegerFormatBuilder(int subject, char formatSpecifier)
        {
            _subject = subject;
            _formatSpecifier = formatSpecifier;
        }

        public override string ToString()
        {
            var formatString = String.Format("{0}{1}", _formatSpecifier, PrecisionSpecifier);
            return _subject.ToString(formatString);
        }

        public string ToString(CultureInfo culture)
        {
            var formatString = String.Format("{0}{1}", _formatSpecifier, PrecisionSpecifier);
            return _subject.ToString(formatString, culture);
        }
    }
}