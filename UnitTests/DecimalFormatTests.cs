using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Decimal;

namespace UnitTests
{
    [TestFixture]
    public class DecimalFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();
        private static readonly IList<decimal> Subjects = new List<decimal>();

        static DecimalFormatTests()
        {
            for (var i = 0; i < 100; i++)
                Subjects.Add(Gen.Long());
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void Format_WhenInvoked_ShouldReturnPercentFormattedString(decimal subject)
        {
            subject.AsPercent().Format().ShouldEqual(subject.ToString("P"));
            subject.AsPercent().WithPrecision(3).Format().ShouldEqual(subject.ToString("P3"));
            subject.AsPercent().Using<FrenchFranceCulture>().WithPrecision(1).Format().ShouldEqual(subject.ToString("P1", CultureInfo.CreateSpecificCulture("fr-FR")));
            subject.AsCurrency().Format().ShouldEqual(subject.ToString("C"));
            subject.AsCurrency().WithPrecision(5).Format().ShouldEqual(subject.ToString("C5"));
            subject.AsCurrency().WithPrecision(5).Using<FrenchFranceCulture>().Format().ShouldEqual(subject.ToString("C5", CultureInfo.CreateSpecificCulture("fr-FR")));
            subject.AsExponential().Format().ShouldEqual(subject.ToString("E"));
            subject.AsExponential().WithPrecision(2).Format().ShouldEqual(subject.ToString("E2"));
            subject.AsExponential().Using<FrenchFranceCulture>().Format().ShouldEqual(subject.ToString("E", CultureInfo.CreateSpecificCulture("fr-FR")));
            subject.AsExponential().WithPrecision(7).Using<FrenchFranceCulture>().Format().ShouldEqual(subject.ToString("E7", CultureInfo.CreateSpecificCulture("fr-FR")));
            subject.AsFixedPoint().Format().ShouldEqual(subject.ToString("F"));
            subject.AsFixedPoint().WithPrecision(10).Format().ShouldEqual(subject.ToString("F10"));
            subject.AsFixedPoint().WithPrecision(10).Using<GermanGermanyCulture>().Format().ShouldEqual(subject.ToString("F10", CultureInfo.CreateSpecificCulture("de-DE")));
            subject.AsGeneral().Format().ShouldEqual(subject.ToString("G"));
            subject.AsGeneral().WithPrecision(9).Format().ShouldEqual(subject.ToString("G9"));
            subject.AsGeneral().WithPrecision(9).Using<GermanGermanyCulture>().Format().ShouldEqual(subject.ToString("G9", CultureInfo.CreateSpecificCulture("de-DE")));
            subject.AsNumeric().Format().ShouldEqual(subject.ToString("N"));
            subject.AsNumeric().WithPrecision(9).Format().ShouldEqual(subject.ToString("N9"));
            subject.AsNumeric().WithPrecision(9).Using<GermanGermanyCulture>().Format().ShouldEqual(subject.ToString("N9", CultureInfo.CreateSpecificCulture("de-DE")));
        }
    }
}