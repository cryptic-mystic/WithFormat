using System;
using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Cultures;
using WithFormat.DateTime;

namespace UnitTests
{
    [TestFixture]
    public class DateTimeFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();

        private static readonly IEnumerable<DateTime> Subjects =
            Builder<DateTime>.CreateListOfSize(100)
                .All()
                .WithConstructor(() => new DateTime(Gen.Next(1, 9999), Gen.Next(1, 12), Gen.Next(1, 28), Gen.Next(0, 23), Gen.Next(0, 59), Gen.Next(0, 59), Gen.Next(0, 999)))
                .Build();

        [Test]
        [TestCaseSource("Subjects")]
        public void WithNumericMonth_WhenInvoked_ShouldReturnNumericMonth(DateTime subject)
        {
            subject.AsDateTime().IncludeMonth().WithNumericMonth().Format().ShouldEqual(subject.ToString("%M"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithAbbrebiatedMonth_WhenInvoked_ShouldReturnAbbreviatedMonth(DateTime subject)
        {
            subject.AsDateTime().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("MMM"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithTwoDigitMonth_WhenInvoked_ShouldReturnTwoDigitMonth(DateTime subject)
        {
            subject.AsDateTime().IncludeMonth().WithTwoDigitMonth().Format().ShouldEqual(subject.ToString("MM"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithFullMonth_WhenInvoked_ShouldReturnFullMonth(DateTime subject)
        {
            subject.AsDateTime().IncludeMonth().WithFullMonth().Format().ShouldEqual(subject.ToString("MMMM"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithOneDigit_WhenInvoked_ShouldReturnOneDigitYear(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithOneDigit().Format().ShouldEqual(subject.ToString("%y"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithTwoDigits_WhenInvoked_ShouldReturnTwoDigitYear(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithTwoDigits().Format().ShouldEqual(subject.ToString("yy"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithAtLeastThreeDigits_WhenInvoked_ShouldReturnThreeDigitYear(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithAtLeastThreeDigits().Format().ShouldEqual(subject.ToString("yyy"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithFourDigits_WhenInvoked_ShouldReturnFourDigitYear(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithFourDigits().Format().ShouldEqual(subject.ToString("yyyy"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithFiveDigits_WhenInvoked_ShouldReturnFiveDigitYear(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithFiveDigits().Format().ShouldEqual(subject.ToString("yyyyy"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithDigits_WhenInvoked_ShouldReturnStringFormattedWithProperDigits(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithDigits(7).Format().ShouldEqual(subject.ToString("yyyyyyy"));
            subject.AsDateTime().IncludeYear().WithDigits(8).Format().ShouldEqual(subject.ToString("yyyyyyyy"));
            subject.AsDateTime().IncludeYear().WithDigits(9).Format().ShouldEqual(subject.ToString("yyyyyyyyy"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void IncludeMonth_WhenInvokedAfterIncludeYear_ShouldReturnYearThenMonthFormatted(DateTime subject)
        {
            subject.AsDateTime().IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy MMM"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithDelimiter_WhenInvoked_ShouldReturnStringFormattedWithDelimiter(DateTime subject)
        {
            subject.AsDateTime().UsingDelimiter(" : ").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy : MMM"));
            subject.AsDateTime().UsingDelimiter("/").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy/MMM"));
            subject.AsDateTime().UsingDelimiter("-").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy-MMM"));
            subject.AsDateTime().UsingDelimiter("+").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy+MMM"));
            subject.AsDateTime().UsingDelimiter(" ").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy MMM"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithAtLeastOneDigit_WhenInvoked_ShouldReturnOneDigit(DateTime subject)
        {
            subject.AsDateTime().IncludeDay().WithAtLeastOneDigit().Format().ShouldEqual(subject.ToString("%d"));
        }
        [Test]
        [TestCaseSource("Subjects")]
        public void WithTwoDigits_WhenInvoked_ShouldReturnTwoDigits(DateTime subject)
        {
            subject.AsDateTime().IncludeDay().WithTwoDigits().Format().ShouldEqual(subject.ToString("dd"));
        }
        [Test]
        [TestCaseSource("Subjects")]
        public void WithAbbreviatedDayOfWeek_WhenInvoked_ShouldReturnAbbreviatedDayOfWeek(DateTime subject)
        {
            subject.AsDateTime().IncludeDay().WithAbbreviatedDayOfWeek().Format().ShouldEqual(subject.ToString("ddd"));
        }
        [Test]
        [TestCaseSource("Subjects")]
        public void WithFullDayOfWeek_WhenInvoked_ShouldReturnFullDayOfWeek(DateTime subject)
        {
            subject.AsDateTime().IncludeDay().WithFullDayOfWeek().Format().ShouldEqual(subject.ToString("dddd"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void InsertCustomDelimiter_WhenInvoked_ShouldInsertDelimiterAtSpecifiedPoint(DateTime subject)
        {
            subject.AsDateTime()
                .IncludeYear().WithFourDigits().InsertCustomDelimiter(", ")
                .IncludeMonth().WithFullMonth()
                .IncludeDay().WithAtLeastOneDigit()
                .Format().ShouldEqual(subject.ToString("yyyy, MMMM d"));

            subject.AsDateTime()
                .IncludeYear().WithFourDigits()
                .IncludeMonth().WithFullMonth().InsertCustomDelimiter(":")
                .IncludeDay().WithAtLeastOneDigit()
                .Format().ShouldEqual(subject.ToString("yyyy MMMM:d"));

            subject.AsDateTime()
                .IncludeYear().WithFourDigits()
                .IncludeMonth().WithFullMonth()
                .IncludeDay().WithAtLeastOneDigit().InsertCustomDelimiter("!")
                .Format().ShouldEqual(subject.ToString("yyyy MMMM d!"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void WithMilliseconds_WhenInvoked_ShouldIncludeMillisecondsInString(DateTime subject)
        {
            subject.AsDateTime().IncludeMilliSeconds().InTenthsOfASecond().Format().ShouldEqual(subject.ToString("%f"));
            subject.AsDateTime().IncludeMilliSeconds().InHundredthsOfASecond().Format().ShouldEqual(subject.ToString("ff"));
            subject.AsDateTime().IncludeMilliSeconds().InMilliseconds().Format().ShouldEqual(subject.ToString("fff"));
            subject.AsDateTime().IncludeMilliSeconds().InTenThousandthsOfASecond().Format().ShouldEqual(subject.ToString("ffff"));
            subject.AsDateTime().IncludeMilliSeconds().InHundredThousandthsOfASecond().Format().ShouldEqual(subject.ToString("fffff"));
            subject.AsDateTime().IncludeMilliSeconds().InMillionthsOfASecond().Format().ShouldEqual(subject.ToString("ffffff"));
            subject.AsDateTime().IncludeMilliSeconds().InTenMillionthsOfASecond().Format().ShouldEqual(subject.ToString("fffffff"));
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithDate(DateTime subject)
        {
            subject.AsDateTime()
                .IncludeYear()
                .WithFourDigits()
                .InsertCustomDelimiter(", ")
                .IncludeMonth()
                .WithFullMonth()
                .IncludeDay()
                .WithAtLeastOneDigit()
                .Using<JapaneseJapanCulture>()
                .Format().ShouldEqual(subject.ToString("yyyy, MMMM d", CultureInfo.CreateSpecificCulture("ja-JP")));
        }
    }
}