using System.Globalization;
using NUnit.Framework;
using Should;
using WithFormat;

namespace UnitTests
{
    [TestFixture]
    public class IntegerFormatTests
    {
        [Test]
        public void Format_WhenInvoked_ShouldReturnIntegerFormatBuilder()
        {
            //Arrange
            const int testInteger = 5;
            
            //Act
            var result = testInteger.WithDecimal();

            //Assert
            result.ShouldBeType<IntegerFormatBuilder>();
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnADecimalString()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.WithDecimal().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("D"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnDecimalStringWithPrecision()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.WithDecimal().WithPrecision(3).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("D3"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnHexFormattedString()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.WithHexadecimal().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("X"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnHexFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.WithHexadecimal().WithPrecision(3).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("X3"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedString()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithCurrency().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("C"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithCurrency().WithPrecision(6).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("C6"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithCulture()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithCurrency().WithCulture<JapaneseJapanCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithCultureAndPrecision()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithCurrency().WithCulture<JapaneseJapanCulture>().WithPrecision(4).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("C4", CultureInfo.CreateSpecificCulture("ja-JP")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedString()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithExponential().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithExponential().WithPrecision(2).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E2"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCulture()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithExponential().WithCulture<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E", CultureInfo.CreateSpecificCulture("fr-FR")));
        }
        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCultureAndPrecision()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.WithExponential().WithPrecision(7).WithCulture<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E7", CultureInfo.CreateSpecificCulture("fr-FR")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedString()
        {
            //Arrange
            const int testInteger = 6;

            //Act
            var result = testInteger.WithFixedPoint().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 6;

            //Act
            var result = testInteger.WithFixedPoint().WithPrecision(10).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F10"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithCulture()
        {
            //Arrange
            const int testInteger = 6;

            //Act
            var result = testInteger.WithFixedPoint().WithPrecision(10).WithCulture<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F10", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedString()
        {
            //Arrange
            const int testInteger = 69;

            //Act
            var result = testInteger.WithGeneral().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("G"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 69;

            //Act
            var result = testInteger.WithGeneral().WithPrecision(9).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("G9"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const int testInteger = 69;

            //Act
            var result = testInteger.WithGeneral().WithPrecision(9).WithCulture<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("G9", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedString()
        {
            //Arrange
            const int testInteger = -121234;

            //Act
            var result = testInteger.WithNumeric().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("N"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = -121234;

            //Act
            var result = testInteger.WithNumeric().WithPrecision(9).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("N9"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const int testInteger = -121234;

            //Act
            var result = testInteger.WithNumeric().WithPrecision(9).WithCulture<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("N9", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedString()
        {
            //Arrange
            const int testInteger = 1;

            //Act
            var result = testInteger.WithPercent().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("P"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecision()
        {
            //Arrange
            const int testInteger = 2;

            //Act
            var result = testInteger.WithPercent().WithPrecision(3).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("P3"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const int testInteger = 3;

            //Act
            var result = testInteger.WithPercent().WithPrecision(3).WithCulture<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("P3", CultureInfo.CreateSpecificCulture("de-DE")));
        }
    }
}