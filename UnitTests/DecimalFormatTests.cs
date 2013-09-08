using System.Globalization;
using NUnit.Framework;
using Should;
using WithFormat;

namespace UnitTests
{
    [TestFixture]
    public class DecimalFormatTests
    {
        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedString()
        {
            //Arrange
            const decimal test = .50M;

            //Act
            var result = test.WithPercent().Format();

            //Assert
            result.ShouldEqual(test.ToString("P"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecision()
        {
            //Arrange
            const decimal test = .50M;

            //Act
            var result = test.WithPercent().WithPrecision(3).Format();

            //Assert
            result.ShouldEqual(test.ToString("P3"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const decimal test = -0.39678M;

            //Act
            var result = test.WithPercent().WithCulture<FrenchFranceCulture>().WithPrecision(1).Format();

            //Assert
            result.ShouldEqual(test.ToString("P1", CultureInfo.CreateSpecificCulture("fr-FR")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedString()
        {
            //Arrange
            const decimal test = 0.39678M;
            
            //Act
            var result = test.WithCurrency().Format();

            //Assert
            result.ShouldEqual(test.ToString("C"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithPrecision()
        {
            //Arrange
            const decimal test = 0.39678M;

            //Act
            var result = test.WithCurrency().WithPrecision(5).Format();

            //Assert
            result.ShouldEqual(test.ToString("C5"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedStringWithPrecisionAndCulture()
        {
            //Arrange
            const decimal test = 0.39678M;

            //Act
            var result = test.WithCurrency().WithPrecision(5).WithCulture<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(test.ToString("C5", CultureInfo.CreateSpecificCulture("fr-FR")));
        }

        //STOP HERE********************************************************************************************************
        //STOP HERE********************************************************************************************************
        //STOP HERE********************************************************************************************************
        //STOP HERE********************************************************************************************************
        //STOP HERE********************************************************************************************************

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedString()
        {
            //Arrange
            const decimal test = 555555555555555555M;

            //Act
            var result = test.WithExponential().Format();

            //Assert
            result.ShouldEqual(test.ToString("E"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithPrecision()
        {
            //Arrange
            const decimal testInteger = 555555555555555555M;

            //Act
            var result = testInteger.WithExponential().WithPrecision(2).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E2"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCulture()
        {
            //Arrange
            const decimal testInteger = 555555555555555555M;

            //Act
            var result = testInteger.WithExponential().WithCulture<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E", CultureInfo.CreateSpecificCulture("fr-FR")));
        }
        [Test]
        public void Format_WhenInvoked_ShouldReturnExponentialFormattedStringWithCultureAndPrecision()
        {
            //Arrange
            const decimal testInteger = 555555555555555555M;

            //Act
            var result = testInteger.WithExponential().WithPrecision(7).WithCulture<FrenchFranceCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("E7", CultureInfo.CreateSpecificCulture("fr-FR")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedString()
        {
            //Arrange
            const decimal testInteger = 6.123M;

            //Act
            var result = testInteger.WithFixedPoint().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithPrecision()
        {
            //Arrange
            const decimal testInteger = 6.123M;

            //Act
            var result = testInteger.WithFixedPoint().WithPrecision(10).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F10"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnFixedPointFormattedStringWithCulture()
        {
            //Arrange
            const decimal testInteger = 6.123M;

            //Act
            var result = testInteger.WithFixedPoint().WithPrecision(10).WithCulture<GermanGermanyCulture>().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("F10", CultureInfo.CreateSpecificCulture("de-DE")));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedString()
        {
            //Arrange
            const decimal testInteger = 6.123M;

            //Act
            var result = testInteger.WithGeneral().Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("G"));
        }

        [Test]
        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecision()
        {
            //Arrange
            const decimal testInteger = 6.123M;

            //Act
            var result = testInteger.WithGeneral().WithPrecision(9).Format();

            //Assert
            result.ShouldEqual(testInteger.ToString("G9"));
        }

        //Do I need these tests? I'm not sure.... I think I've already verified my funcionality.
//        [Test]
//        public void Format_WhenInvoked_ShouldReturnGeneralFormattedStringWithPrecisionAndCulture()
//        {
//            //Arrange
//            const int testInteger = 69;
//
//            //Act
//            var result = testInteger.WithGeneral().WithPrecision(9).WithCulture<GermanGermanyCulture>().Format();
//
//            //Assert
//            result.ShouldEqual(testInteger.ToString("G9", CultureInfo.CreateSpecificCulture("de-DE")));
//        }
//
//        [Test]
//        public void Format_WhenInvoked_ShouldReturnNumericFormattedString()
//        {
//            //Arrange
//            const int testInteger = -121234;
//
//            //Act
//            var result = testInteger.WithNumeric().Format();
//
//            //Assert
//            result.ShouldEqual(testInteger.ToString("N"));
//        }
//
//        [Test]
//        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecision()
//        {
//            //Arrange
//            const int testInteger = -121234;
//
//            //Act
//            var result = testInteger.WithNumeric().WithPrecision(9).Format();
//
//            //Assert
//            result.ShouldEqual(testInteger.ToString("N9"));
//        }
//
//        [Test]
//        public void Format_WhenInvoked_ShouldReturnNumericFormattedStringWithPrecisionAndCulture()
//        {
//            //Arrange
//            const int testInteger = -121234;
//
//            //Act
//            var result = testInteger.WithNumeric().WithPrecision(9).WithCulture<GermanGermanyCulture>().Format();
//
//            //Assert
//            result.ShouldEqual(testInteger.ToString("N9", CultureInfo.CreateSpecificCulture("de-DE")));
//        }
    }
}