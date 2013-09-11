using System;
using System.Collections.Generic;
using System.Linq;

namespace WithFormat.DateTime
{
    public static class DateTimeExtentions
    {
        public static DateTimeFormatBuilder WithDate(this System.DateTime input)
        {
            return new DateTimeFormatBuilder(input);
        } 
    }

    public class DateTimeFormatBuilder : IYearFormatter, IMonthFormatter, IDayFormatter
    {
        private System.DateTime Input { get; set; }
        private IList<string> FormatStrings { get; set; }
        private string Delimiter = " ";

        internal DateTimeFormatBuilder(System.DateTime input)
        {
            Input = input;
            FormatStrings = new List<string>();
        }

        public DateTimeFormatBuilder UsingDelimiter(string delimiter)
        {
            Delimiter = delimiter;
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

        DateTimeFormatBuilder IYearFormatter.WithMinimumThreeDigits()
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

        public string Format()
        {
            var formatString = FormatStrings.Aggregate(String.Empty, (current, s) => current + (s + Delimiter)).Trim(Delimiter.ToCharArray());

            return Input.ToString(formatString);
        }
    }

    public interface IYearFormatter
    {
        DateTimeFormatBuilder WithOneDigit();
        DateTimeFormatBuilder WithTwoDigits();
        DateTimeFormatBuilder WithMinimumThreeDigits();
        DateTimeFormatBuilder WithFourDigits();
        DateTimeFormatBuilder WithFiveDigits();
    }

    public interface IDayFormatter
    {
    }

    public interface IMonthFormatter
    {
        DateTimeFormatBuilder WithNumericMonth();
        DateTimeFormatBuilder WithTwoDigitMonth();
        DateTimeFormatBuilder WithAbbreviatedMonth();
        DateTimeFormatBuilder WithFullMonth();
    }
}