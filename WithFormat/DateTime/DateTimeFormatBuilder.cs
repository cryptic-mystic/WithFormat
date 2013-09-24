using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WithFormat.DateTime
{
    public class FormatElement
    {
        public string FormatString { get; set; }
        public string TrailingDelimiter { get; set; }
    }

    public class DateTimeFormatBuilder : IYearFormatter, IMonthFormatter, IDayFormatter
    {
        private CultureInfo Culture { get; set; }
        private System.DateTime Input { get; set; }
        private IList<FormatElement> FormatStrings { get; set; }
        private string _defaultDelimiter = " ";

        internal DateTimeFormatBuilder(System.DateTime input)
        {
            Input = input;
            FormatStrings = new List<FormatElement>();
        }

        public DateTimeFormatBuilder UsingDelimiter(string delimiter)
        {
            _defaultDelimiter = delimiter;
            return this;
        }

        public IYearFormatter IncludeYear()
        {
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithOneDigit()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%y" });
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithTwoDigits()
        {
            FormatStrings.Add(new FormatElement { FormatString = "yy" });
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithAtLeastThreeDigits()
        {
            FormatStrings.Add(new FormatElement { FormatString = "yyy" });
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithFourDigits()
        {
            FormatStrings.Add(new FormatElement { FormatString = "yyyy" });
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithFiveDigits()
        {
            FormatStrings.Add(new FormatElement { FormatString = "yyyyy" });
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithDigits(int numberOfDigits)
        {
            var yearDigits = String.Empty;
            for (var i = 0; i < numberOfDigits; i++) { yearDigits += 'y'; }

            FormatStrings.Add(new FormatElement { FormatString = yearDigits });
            return this;
        }

        public IMonthFormatter IncludeMonth()
        {
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithNumericMonth()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%M" });
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithTwoDigitMonth()
        {
            FormatStrings.Add(new FormatElement { FormatString = "MM" });
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithAbbreviatedMonth()
        {
            FormatStrings.Add(new FormatElement { FormatString = "MMM" });
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithFullMonth()
        {
            FormatStrings.Add(new FormatElement { FormatString = "MMMM" });
            return this;
        }

        public IDayFormatter IncludeDay()
        {
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithAtLeastOneDigit()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%d" });
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithTwoDigits()
        {
            FormatStrings.Add(new FormatElement { FormatString = "dd" });
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithAbbreviatedDayOfWeek()
        {
            FormatStrings.Add(new FormatElement { FormatString = "ddd" });
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithFullDayOfWeek()
        {
            FormatStrings.Add(new FormatElement { FormatString = "dddd" });
            return this;
        }

        public DateTimeFormatBuilder InsertCustomDelimiter(string customDelimiter)
        {
            FormatStrings.Last().TrailingDelimiter = customDelimiter;
            return this;
        }

        public DateTimeFormatBuilder Using<T>() where T : IFormatCulture, new()
        {
            Culture = new T().Culture();
            return this;
        }

        public string Format()
        {
            var formatString = FormatStrings.Aggregate(String.Empty, (current, s) =>
                {
                    if (String.IsNullOrEmpty(s.TrailingDelimiter))
                    {
                        s.TrailingDelimiter = _defaultDelimiter;
                    }
                    return current + (s.FormatString + s.TrailingDelimiter);
                }).TrimEnd(_defaultDelimiter.ToCharArray());

            return Input.ToString(formatString, Culture);
        }
    }
}