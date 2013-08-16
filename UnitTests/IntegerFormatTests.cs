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
        public void DecimalFormat_WhenInvokedForInt_ShouldReturnIntegerFormatBuilder()
        {
            //Arrange
            const int testInteger = 5;
            
            //Act
            var result = testInteger.DecimalFormat();

            //Assert
            result.ShouldBeType<IntegerFormatBuilder>();
        }

        [Test]
        public void ToString_WhenInvokedForInteger_ShouldReturnADecimalString()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.DecimalFormat().ToString();

            //Assert
            result.ShouldEqual(testInteger.ToString("D"));
        }

        [Test]
        public void ToString_WhenInvokedForIntWithPrecision_ShouldReturnDecimalStringWithPrecision()
        {
            //Arrange
            const int testInteger = 5;

            //Act
            var result = testInteger.DecimalFormat().Precision(3).ToString();

            //Assert
            result.ShouldEqual(testInteger.ToString("D3"));
        }

        [Test]
        public void CurrencyFormat_WhenInvokedForInt_ShouldReturnIntegerFormatBuilder()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.CurrencyFormat();

            //Assert
            result.ShouldBeType<IntegerFormatBuilder>();
        }

        [Test]
        public void ToString_WhenInvokedForInt_ShouldReturnCurrencyFormattedString()
        {
            //Arrange
            const int testInteger = 4;

            //Act
            var result = testInteger.CurrencyFormat().ToString();

            //Assert
            result.ShouldEqual(testInteger.ToString("C"));
        }

        [Test]
        public void ToString_WhenInvokedForIntWithCulture_ShouldReturnCurrencyFormattedString()
        {
            //Arrange
            const int testInteger = 4;
            var specificCulture = CultureInfo.CreateSpecificCulture("ja-JP");

            //Act
            var result = testInteger.CurrencyFormat().JapaneseJapanCulture().ToString();

            //Assert
            result.ShouldEqual(testInteger.ToString("C", specificCulture));
        }

        [Test]
        public void WithPrecision_WhenInvokedForInt_ShouldSetPrecisionForCurrencyFormat()
        {
            //Arrange
            const int testInteger = 4;
            var specificCulture = CultureInfo.CreateSpecificCulture("ja-JP");

            //Act
            var result = testInteger.CurrencyFormat().Precision(3).JapaneseJapanCulture().ToString();

            //Assert
            result.ShouldEqual(testInteger.ToString("C3", specificCulture));
        }

    }
}