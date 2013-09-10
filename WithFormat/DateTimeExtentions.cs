using System;
using System.Collections.Generic;
using System.Linq;

namespace WithFormat
{
    public static class DateTimeExtentions
    {
        public static IDateFormatter WithDate(this DateTime input)
        {
            return new DateTimeFormatBuilder(input);
        } 
    }

    public class DateTimeFormatBuilder : IDateFormatter, IYearFormatter, IMonthFormatter, IDayFormatter
    {
        private DateTime Input { get; set; }
        private IList<string> FormatStrings { get; set; }
        private string Delimiter = " ";

        internal DateTimeFormatBuilder(DateTime input)
        {
            Input = input;
            FormatStrings = new List<string>();
        }

        public DateTimeFormatBuilder UsingDelimiter(string delimiter)
        {
            Delimiter = delimiter;
            return this;
        }

        IYearFormatter IDateFormatter.IncludeYear()
        {
            return this;
        }

        IDateFormatter IYearFormatter.WithOneDigit()
        {
            FormatStrings.Add("y");
            return this;
        }

        IDateFormatter IYearFormatter.WithTwoDigits()
        {
            FormatStrings.Add("yy");
            return this;
        }

        IDateFormatter IYearFormatter.WithThreeDigits()
        {
            FormatStrings.Add("yyy");
            return this;
        }

        IDateFormatter IYearFormatter.WithFourDigits()
        {
            FormatStrings.Add("yyyy");
            return this;
        }

        IDateFormatter IYearFormatter.WithFiveDigits()
        {
            FormatStrings.Add("yyyyy");
            return this;
        }

        IMonthFormatter IDateFormatter.IncludeMonth()
        {
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithNumericMonth()
        {
            FormatStrings.Add("M");
            return this;
        }

        DateTimeFormatBuilder IMonthFormatter.WithNumericMonthLeadingZero()
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
            FormatStrings.Add("MMM");
            return this;
        }

        public string Format()
        {
            var formatString = FormatStrings.Aggregate(String.Empty, (current, s) => current + (s + Delimiter)).Trim(Delimiter.ToCharArray());

            return Input.ToString(formatString);
        }
    }

    public interface IYearFormatter
    {
        IDateFormatter WithOneDigit();
        IDateFormatter WithTwoDigits();
        IDateFormatter WithThreeDigits();
        IDateFormatter WithFourDigits();
        IDateFormatter WithFiveDigits();
    }

    public interface IDateFormatter
    {
        IMonthFormatter IncludeMonth();
        IYearFormatter IncludeYear();
    }

    public interface IDayFormatter
    {
    }

    public interface IMonthFormatter
    {
        DateTimeFormatBuilder WithNumericMonth();
        DateTimeFormatBuilder WithNumericMonthLeadingZero();
        DateTimeFormatBuilder WithAbbreviatedMonth();
        DateTimeFormatBuilder WithFullMonth();
    }
}