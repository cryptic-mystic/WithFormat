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
            var result = date.WithDate().IncludeMonth().WithNumericMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("%M"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithDoubleMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeMonth().WithTwoDigitMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithAbbrMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithFullMonth()
        {
            //Arrange
            var date = new DateTime(1988, 1, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeMonth().WithFullMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("MMMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearOneDigit()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithOneDigit().Format();

            //Assert
            result.ShouldEqual(date.ToString("%y"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearTwoDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithTwoDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearThreeDigits()
        {
            //Arrange
            var date = new DateTime(88, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithAtLeastThreeDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearFourDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithFourDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearFiveDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithFiveDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearEightDigits()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithDigits(8).Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyyyyyy"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearAndMonth()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithYearAndMonthWithCustomDelimiter()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().UsingDelimiter(" : ").IncludeYear().WithFourDigits().IncludeMonth().WithAbbreviatedMonth().Format();

            //Assert
            result.ShouldEqual(date.ToString("yyyy : MMM"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithSingleDigitDay()
        {
            //Arrange
            var date = new DateTime(1988, 12, 3, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeDay().WithAtLeastOneDigit().Format();

            //Assert
            result.ShouldEqual(date.ToString("%d"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithTwoDigitDay()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeDay().WithTwoDigits().Format();

            //Assert
            result.ShouldEqual(date.ToString("dd"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithAbbreviatedDayOfWeek()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeDay().WithAbbreviatedDayOfWeek().Format();

            //Assert
            result.ShouldEqual(date.ToString("ddd"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFormattedStringWithFullDayOfWeek()
        {
            //Arrange
            var date = new DateTime(1988, 12, 13, 12, 1, 1, 1);

            //Act
            var result = date.WithDate().IncludeDay().WithFullDayOfWeek().Format();

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
                date.WithDate()
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
                date.WithDate()
                    .IncludeYear()
                    .WithFourDigits()
                    .InsertCustomDelimiter(", ")
                    .IncludeMonth()
                    .WithFullMonth()
                    .IncludeDay()
                    .WithAtLeastOneDigit()
                    .WithCulture<JapaneseJapanCulture>()
                    .Format();


            //Assert
            result.ShouldEqual(date.ToString("yyyy, MMMM d", CultureInfo.CreateSpecificCulture("ja-JP")));
        }
    }
}