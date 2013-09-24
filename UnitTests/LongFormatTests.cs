using System.Globalization;
using NUnit.Framework;
using Should;
using WithFormat.Long;

namespace UnitTests
{
    [TestFixture]
    public class LongFormatTests
    {
        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedString()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsCurrency().Format();

            //Assert
            result.ShouldEqual(test.ToString("C"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithPrecision()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsCurrency().WithPrecision(6).Format();

            //Assert
            result.ShouldEqual(test.ToString("C6"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithCulture()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsCurrency().Using<JapaneseJapanCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithCultureAndPrecision()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsCurrency().Using<JapaneseJapanCulture>().WithPrecision(4).Format();

            //Assert
            result.ShouldEqual(test.ToString("C4", CultureInfo.CreateSpecificCulture("ja-JP")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedString()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsExponential().Format();

            //Assert
            result.ShouldEqual(test.ToString("E"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithPrecision()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsExponential().WithPrecision(2).Format();

            //Assert
            result.ShouldEqual(test.ToString("E2"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCulture()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsExponential().Using<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("E", CultureInfo.CreateSpecificCulture("fr-FR")));
        }
        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCultureAndPrecision()
        {
            //Arrange
            const long test = 4;

            //Act
            var result = test.AsExponential().WithPrecision(7).Using<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("E7", CultureInfo.CreateSpecificCulture("fr-FR")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedString()
        {
            //Arrange
            const long test = 6;

            //Act
            var result = test.AsFixedPoint().Format();

            //Assert
            result.ShouldEqual(test.ToString("F"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithPrecision()
        {
            //Arrange
            const long test = 6;

            //Act
            var result = test.AsFixedPoint().WithPrecision(10).Format();

            //Assert
            result.ShouldEqual(test.ToString("F10"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithCulture()
        {
            //Arrange
            const long test = 6;

            //Act
            var result = test.AsFixedPoint().WithPrecision(10).Using<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("F10", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedString()
        {
            //Arrange
            const long test = 69;

            //Act
            var result = test.AsGeneral().Format();

            //Assert
            result.ShouldEqual(test.ToString("G"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecision()
        {
            //Arrange
            const long test = 69;

            //Act
            var result = test.AsGeneral().WithPrecision(9).Format();

            //Assert
            result.ShouldEqual(test.ToString("G9"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const long test = 69;

            //Act
            var result = test.AsGeneral().WithPrecision(9).Using<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("G9", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedString()
        {
            //Arrange
            const long test = -121234;

            //Act
            var result = test.AsNumeric().Format();

            //Assert
            result.ShouldEqual(test.ToString("N"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecision()
        {
            //Arrange
            const long test = -121234;

            //Act
            var result = test.AsNumeric().WithPrecision(9).Format();

            //Assert
            result.ShouldEqual(test.ToString("N9"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const long test = -121234;

            //Act
            var result = test.AsNumeric().WithPrecision(9).Using<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("N9", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedString()
        {
            //Arrange
            const long test = 1;

            //Act
            var result = test.AsPercent().Format();

            //Assert
            result.ShouldEqual(test.ToString("P"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecision()
        {
            //Arrange
            const long test = 2;

            //Act
            var result = test.AsPercent().WithPrecision(3).Format();

            //Assert
            result.ShouldEqual(test.ToString("P3"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const long test = 3;

            //Act
            var result = test.AsPercent().WithPrecision(3).Using<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("P3", CultureInfo.CreateSpecificCulture("de-DE")));
        }
    }
}