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
            var result = testInteger.WithDecimal().Precision(3).Format();

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
            var result = testInteger.WithHexadecimal().Precision(3).Format();

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
            var result = testInteger.WithCurrency().Precision(6).Format();

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
            var result = testInteger.WithCurrency().WithCulture<JapaneseJapanCulture>().Precision(4).Format();

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
            var result = testInteger.WithExponential().Precision(2).Format();

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
            var result = testInteger.WithExponential().WithCulture<FrenchFranceCulture>().Precision(7).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E7", CultureInfo.CreateSpecificCulture("fr-FR")));
        }
    }
}