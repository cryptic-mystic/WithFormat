using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Cultures;
using WithFormat.Decimal;

namespace UnitTests
{
    [TestFixture]
    public class DecimalFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();
        private static readonly IList<decimal> Subjects = new List<decimal>();
        private static readonly IEnumerable<Type> CultureSubjects = typeof(JapaneseJapanCulture).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IFormatCulture)));

        static DecimalFormatTests()
        {
            for (var i = 0; i < 100; i++)
                Subjects.Add(Gen.Decimal());
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

        [Test]
        [TestCaseSource("CultureSubjects")]
        public void Format_WhenInvoked_ShouldReturnCultureFormattedString(Type subject)
        {
            var formatCulture = (IFormatCulture)Activator.CreateInstance(subject);

            var method = typeof(DecimalFormatBuilder).GetMethod("Using");
            var genericMethod = method.MakeGenericMethod(subject);
            foreach (var sample in Subjects)
            {
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsCurrency(), null)).Format().ShouldEqual(sample.ToString("C", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsExponential(), null)).Format().ShouldEqual(sample.ToString("E", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsFixedPoint(), null)).Format().ShouldEqual(sample.ToString("F", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsGeneral(), null)).Format().ShouldEqual(sample.ToString("G", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsNumeric(), null)).Format().ShouldEqual(sample.ToString("N", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((DecimalFormatBuilder)genericMethod.Invoke(sample.AsPercent(), null)).Format().ShouldEqual(sample.ToString("P", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
            }
        }
    }
}