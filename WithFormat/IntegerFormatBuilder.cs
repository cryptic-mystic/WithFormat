using System.Globalization;

namespace WithFormat
{
    public class IntegerFormatBuilder
    {
        public int Subject { get; private set; }
        public string FormatSpecifier { get; private set; }
        internal CultureInfo Culture { get; private set; }

        internal IntegerFormatBuilder(int subject, string formatSpecifier)
        {
            Subject = subject;
            FormatSpecifier = formatSpecifier;
        }

        internal IntegerFormatBuilder(int subject, string formatSpecifier, CultureInfo culture)
        {
            Subject = subject;
            FormatSpecifier = formatSpecifier;
            Culture = culture;
        }

        public IntegerFormatBuilder WithCulture<T>() where T : IFormatCulture, new()
        {
            var culture = new T();
            Culture = culture.Culture();
            return this;
        }

        public virtual string Format()
        {
            return Subject.ToString(FormatSpecifier, Culture);
        }
    }
}