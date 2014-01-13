using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Cultures;
using WithFormat.Integer;

namespace UnitTests
{
    [TestFixture]
    public class IntegerFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();
        private static readonly IList<int> Subjects = new List<int>();

        static IntegerFormatTests()
        {
            for (var i = 0; i < 100; i++)
                Subjects.Add(Gen.Int());
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void Format_WhenInvoked_ShouldReturnADecimalString(int subject)
        {
            subject.AsDecimal().Format().ShouldEqual(subject.ToString("D"));
            subject.AsDecimal().WithPrecision(3).Format().ShouldEqual(subject.ToString("D3"));
            subject.AsHexadecimal().Format().ShouldEqual(subject.ToString("X"));
            subject.AsHexadecimal().WithPrecision(3).Format().ShouldEqual(subject.ToString("X3"));
            subject.AsCurrency().Format().ShouldEqual(subject.ToString("C"));
            subject.AsCurrency().WithPrecision(6).Format().ShouldEqual(subject.ToString("C6"));
            subject.AsCurrency().Using<JapaneseJapanCulture>().Format().ShouldEqual(subject.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));
            subject.AsCurrency().Using<JapaneseJapanCulture>().WithPrecision(4).Format().ShouldEqual(subject.ToString("C4", CultureInfo.CreateSpecificCulture("ja-JP")));
            subject.AsExponential().WithPrecision(2).Format().ShouldEqual(subject.ToString("E2"));
            subject.AsExponential().Format().ShouldEqual(subject.ToString("E"));
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
            subject.AsPercent().Format().ShouldEqual(subject.ToString("P"));
            subject.AsPercent().WithPrecision(3).Format().ShouldEqual(subject.ToString("P3"));
            subject.AsPercent().WithPrecision(3).Using<GermanGermanyCulture>().Format().ShouldEqual(subject.ToString("P3", CultureInfo.CreateSpecificCulture("de-DE")));
        }
    }
}