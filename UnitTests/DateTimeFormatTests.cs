using System;
using System.Globalization;
using NUnit.Framework;
using Should;
using WithFormat.DateTime;

namespace UnitTests
{
    [TestFixture]
    public class DateTimeFormatTests
    {
        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithDate()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeMonth().WithNumericMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("%M"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithDoubleMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeMonth().WithTwoDigitMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithAbbrMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithFullMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeMonth().WithFullMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MMMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearOneDigit()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithOneDigit().Format();

            //Assert
            result.ShouldEqual(date.ToString("%y"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearTwoDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithTwoDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearThreeDigits()
        {
            //Arrange
            var date = new DateTime(88, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithAtLeastThreeDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearFourDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithFourDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearFiveDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithFiveDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearEightDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithDigits(8).Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyyyyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearAndMonth()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearAndMonthWithCustomDelimiter()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().UsingDelimiter(" : ").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy : MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithSingleDigitDay()
        {
            //Arrange
            var date = new DateTime(1988, 12, 3, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeDay().WithAtLeastOneDigit().Format();

            //Assert
            result.ShouldEqual(date.ToString("%d"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithTwoDigitDay()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeDay().WithTwoDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("dd"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithAbbreviatedDayOfWeek()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeDay().WithAbbreviatedDayOfWeek().Format();

            //Assert
            result.ShouldEqual(date.ToString("ddd"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithFullDayOfWeek()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.AsDateTime().IncludeDay().WithFullDayOfWeek().Format();

            //Assert
            result.ShouldEqual(date.ToString("dddd"));
        }

        [Test]
        public void Format_WhenInvoke_ShouldInsertCustomDelimiterWhereSpecified()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result =
                date.AsDateTime()
                    .IncludeYear()
                    .WithFourDigits()
                    .InsertCustomDelimiter(", ")
                    .IncludeMonth()
                    .WithFullMonth()
                    .IncludeDay()
                    .WithAtLeastOneDigit()
                    .Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy, MMMM d"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldFormatDatetimeStringForSpecificCulture()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);
            
            //Act
            var result =
                date.AsDateTime()
                    .IncludeYear()
                    .WithFourDigits()
                    .InsertCustomDelimiter(", ")
                    .IncludeMonth()
                    .WithFullMonth()
                    .IncludeDay()
                    .WithAtLeastOneDigit()
                    .Using<JapaneseJapanCulture>()
                    .Format();


            //Assert
            result.ShouldEqual(date.ToString("yyyy, MMMM d", CultureInfo.CreateSpecificCulture("ja-JP")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeTenthSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InTenthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("%f"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("%f"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeHundredthsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InHundredthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("ff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("ff"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeMillisecondsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InMilliseconds().Format();

            //Assert
            Console.WriteLine(date.ToString("fff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("fff"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeTenThousandthsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InTenThousandthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("ffff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("ffff"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeHundtredThousandthsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InHundredThousandthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("fffff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("fffff"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeMillionthsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InMillionthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("ffffff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("ffffff"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldIncludeTenMillionthsSeconds()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 45, 134);

            //Act
            var result = date.AsDateTime().IncludeMilliSeconds().InTenMillionthsOfASecond().Format();

            //Assert
            Console.WriteLine(date.ToString("fffffff"));
            Console.WriteLine(result);
            result.ShouldEqual(date.ToString("fffffff"));
        }


    }
}