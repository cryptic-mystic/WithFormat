using System;
using System.Collections.Generic;
using System.Linq;

namespace WithFormat.DateTime
{
    public class DateTimeFormatBuilder : IYearFormatter, IMonthFormatter, IDayFormatter
    {
        private System.DateTime Input { get; set; }
        private IList<string> FormatStrings { get; set; }
        private string _delimiter = " ";

        internal DateTimeFormatBuilder(System.DateTime input)
        {
            Input = input;
            FormatStrings = new List<string>();
        }

        public DateTimeFormatBuilder UsingDelimiter(string delimiter)
        {
            _delimiter = delimiter;
            return this;
        }

        public IYearFormatter IncludeYear()
        {
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithOneDigit()
        {
            FormatStrings.Add("%y");
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithTwoDigits()
        {
            FormatStrings.Add("yy");
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithAtLeastThreeDigits()
        {
            FormatStrings.Add("yyy");
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithFourDigits()
        {
            FormatStrings.Add("yyyy");
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithFiveDigits()
        {
            FormatStrings.Add("yyyyy");
            return this;
        }

        DateTimeFormatBuilder IYearFormatter.WithDigits(int numberOfDigits)
        {
            var yearDigits = String.Empty;
            for (var i = 0; i < numberOfDigits; i++) { yearDigits += 'y'; }

            FormatStrings.Add(yearDigits);
            return this;
        }

        public IMonthFormatter IncludeMonth()
        {
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithNumericMonth()
        {
            FormatStrings.Add("%M");
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithTwoDigitMonth()
        {
            FormatStrings.Add("MM");
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithAbbreviatedMonth()
        {
            FormatStrings.Add("MMM");
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithFullMonth()
        {
            FormatStrings.Add("MMMM");
            return this;
        }

        public IDayFormatter IncludeDay()
        {
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithAtLeastOneDigit()
        {
            FormatStrings.Add("%d");
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithTwoDigits()
        {
            FormatStrings.Add("dd");
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithAbbreviatedDayOfWeek()
        {
            FormatStrings.Add("ddd");
            return this;
        }

        DateTimeFormatBuilder IDayFormatter.WithFullDayOfWeek()
        {
            FormatStrings.Add("dddd");
            return this;
        }

        public string Format()
        {
            var formatString = FormatStrings.Aggregate(String.Empty, (current, s) => current + (s + _delimiter)).Trim(_delimiter.ToCharArray());

            return Input.ToString(formatString);
        }
    }
}