using System;
using NUnit.Framework;
using Should;
using WithFormat;

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
            result.ShouldEqual(date.ToString("M"));
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
    }
}