using System;
using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
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
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithDate(DateTime subject)
        {
            subject.AsDateTime().IncludeMonth().WithNumericMonth().Format().ShouldEqual(subject.ToString("%M"));
            subject.AsDateTime().IncludeMonth().WithTwoDigitMonth().Format().ShouldEqual(subject.ToString("MM"));
            subject.AsDateTime().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("MMM"));
            subject.AsDateTime().IncludeMonth().WithFullMonth().Format().ShouldEqual(subject.ToString("MMMM"));
            subject.AsDateTime().IncludeYear().WithOneDigit().Format().ShouldEqual(subject.ToString("%y"));
            subject.AsDateTime().IncludeYear().WithTwoDigits().Format().ShouldEqual(subject.ToString("yy"));
            subject.AsDateTime().IncludeYear().WithAtLeastThreeDigits().Format().ShouldEqual(subject.ToString("yyy"));
            subject.AsDateTime().IncludeYear().WithFourDigits().Format().ShouldEqual(subject.ToString("yyyy"));
            subject.AsDateTime().IncludeYear().WithFiveDigits().Format().ShouldEqual(subject.ToString("yyyyy"));
            subject.AsDateTime().IncludeYear().WithDigits(8).Format().ShouldEqual(subject.ToString("yyyyyyyy"));
            subject.AsDateTime().IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy MMM"));
            subject.AsDateTime().UsingDelimiter(" : ").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format().ShouldEqual(subject.ToString("yyyy : MMM"));
            subject.AsDateTime().IncludeDay().WithAtLeastOneDigit().Format().ShouldEqual(subject.ToString("%d"));
            subject.AsDateTime().IncludeDay().WithTwoDigits().Format().ShouldEqual(subject.ToString("dd"));
            subject.AsDateTime().IncludeDay().WithAbbreviatedDayOfWeek().Format().ShouldEqual(subject.ToString("ddd"));
            subject.AsDateTime().IncludeDay().WithFullDayOfWeek().Format().ShouldEqual(subject.ToString("dddd"));

            subject.AsDateTime()
                .IncludeYear()
                .WithFourDigits()
                .InsertCustomDelimiter(", ")
                .IncludeMonth()
                .WithFullMonth()
                .IncludeDay()
                .WithAtLeastOneDigit()
                .Format().ShouldEqual(subject.ToString("yyyy, MMMM d"));

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

            subject.AsDateTime().IncludeMilliSeconds().InTenthsOfASecond().Format().ShouldEqual(subject.ToString("%f"));
            subject.AsDateTime().IncludeMilliSeconds().InHundredthsOfASecond().Format().ShouldEqual(subject.ToString("ff"));
            subject.AsDateTime().IncludeMilliSeconds().InMilliseconds().Format().ShouldEqual(subject.ToString("fff"));
            subject.AsDateTime().IncludeMilliSeconds().InTenThousandthsOfASecond().Format().ShouldEqual(subject.ToString("ffff"));
            subject.AsDateTime().IncludeMilliSeconds().InHundredThousandthsOfASecond().Format().ShouldEqual(subject.ToString("fffff"));
            subject.AsDateTime().IncludeMilliSeconds().InMillionthsOfASecond().Format().ShouldEqual(subject.ToString("ffffff"));
            subject.AsDateTime().IncludeMilliSeconds().InTenMillionthsOfASecond().Format().ShouldEqual(subject.ToString("fffffff"));
        }
    }
}