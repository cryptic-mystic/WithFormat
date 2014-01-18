using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WithFormat.Cultures;

namespace WithFormat.DateTime
{
    public class FormatElement
    {
        public string FormatString { get; set; }
        public string TrailingDelimiter { get; set; }

        public override string ToString()
        {
            return FormatString + TrailingDelimiter;
        }
    }

    public class DateTimeFormatBuilder : IYearFormatter, IMonthFormatter, IDayFormatter, IMilliSecondsFormatter, ISecondsFormatter, IAmPmFormatter
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
            _defaultDelimiter = ("\\" + delimiter);
            return this;
        }

        #region YearFormatting
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
        #endregion

        #region MonthFormatting
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
        #endregion

        #region DayFormatting
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
        #endregion

        #region SecondsFormatting
        public ISecondsFormatter IncludeSeconds()
        {
            return this;
        }

        DateTimeFormatBuilder ISecondsFormatter.AsSingleDigit()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%s" });
            return this;
        }

        DateTimeFormatBuilder ISecondsFormatter.AsDoubleDigit()
        {
            FormatStrings.Add(new FormatElement { FormatString = "ss" });
            return this;
        }
        #endregion

        #region MilliSecondsFormatting
        public IMilliSecondsFormatter IncludeMilliSeconds()
        {
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%f" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InHundredthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "ff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InMilliseconds()
        {
            FormatStrings.Add(new FormatElement { FormatString = "fff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenThousandthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "ffff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InHundredThousandthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "fffff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InMillionthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "ffffff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenMillionthsOfASecond()
        {
            FormatStrings.Add(new FormatElement { FormatString = "fffffff" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%F" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InHundredthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FF" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InMillisecondsWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FFF" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenThousandthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FFFF" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InHundredThousandthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FFFFF" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InMillionthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FFFFFF" });
            return this;
        }

        DateTimeFormatBuilder IMilliSecondsFormatter.InTenMillionthsOfASecondWithoutZeroes()
        {
            FormatStrings.Add(new FormatElement { FormatString = "FFFFFFF" });
            return this;
        }

        #endregion



        #region AmPmFormatting
        public IAmPmFormatter IncludeAmPmSpecifier()
        {
            return this;
        }

        DateTimeFormatBuilder IAmPmFormatter.WithSingleCharacter()
        {
            FormatStrings.Add(new FormatElement { FormatString = "%t" });
            return this;
        }

        DateTimeFormatBuilder IAmPmFormatter.WithTwoCharacters()
        {
            FormatStrings.Add(new FormatElement { FormatString = "tt" });
            return this;
        }
        #endregion

        public DateTimeFormatBuilder IncludeTimePeriod()
        {
            FormatStrings.Add(new FormatElement{ FormatString = "%g" });
            return this;
        }

        public DateTimeFormatBuilder InsertCustomDelimiter(string customDelimiter)
        {
            FormatStrings.Last().TrailingDelimiter = ("\\" + customDelimiter);
            return this;
        }

        public DateTimeFormatBuilder Using<T>() where T : IFormatCulture, new()
        {
            Culture = new T().Culture();
            return this;
        }

        public string Format()
        {
            var formatString = FormatStrings.Aggregate(new StringBuilder(), (current, s) =>
                {
                    if (String.IsNullOrEmpty(s.TrailingDelimiter))
                    {
                        s.TrailingDelimiter = _defaultDelimiter;
                    }
                    return current.Append(s.ToString());
                }).ToString().TrimEnd(_defaultDelimiter.ToCharArray());

            return Input.ToString(formatString, Culture);
        }
    }
}