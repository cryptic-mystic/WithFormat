using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Long;

namespace UnitTests
{
    [TestFixture]
    public class LongFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();
        private static readonly IList<long> Subjects = new List<long>();

        static LongFormatTests()
        {
            for (var i = 0; i < 100; i++)
                Subjects.Add(Gen.Long());
        }
        
        [Test]
        [TestCaseSource("Subjects")]
        //TODO take all the damn culture tests out of here. I can build a list and unit test them all with test case source. Probably.
        public void Format_WhenInvoked_ShouldReturnCurrencyFormattedString(long subject)
        {
            subject.AsCurrency().Format().ShouldEqual(subject.ToString("C"));
            subject.AsCurrency().WithPrecision(6).Format().ShouldEqual(subject.ToString("C6"));
            subject.AsCurrency().Using<JapaneseJapanCulture>().Format().ShouldEqual(subject.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));
            subject.AsCurrency().Using<JapaneseJapanCulture>().WithPrecision(4).Format().ShouldEqual(subject.ToString("C4", CultureInfo.CreateSpecificCulture("ja-JP")));
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
            subject.AsPercent().Format().ShouldEqual(subject.ToString("P"));
            subject.AsPercent().WithPrecision(3).Format().ShouldEqual(subject.ToString("P3"));
            subject.AsPercent().WithPrecision(3).Using<GermanGermanyCulture>().Format().ShouldEqual(subject.ToString("P3", CultureInfo.CreateSpecificCulture("de-DE")));
        }
    }
}