using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;
using WithFormat.Cultures;
using WithFormat.SByte;

namespace UnitTests
{
    [TestFixture]
    public class SByteFormatTests
    {
        private static readonly RandomGenerator Gen = new RandomGenerator();
        private static readonly IList<sbyte> Subjects = new List<sbyte>();
        private static readonly IEnumerable<Type> CultureSubjects = typeof(JapaneseJapanCulture).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IFormatCulture)));

        static SByteFormatTests()
        {
            for (var i = 0; i < 100; i++)
                Subjects.Add(Gen.SByte());
        }

        [Test]
        [TestCaseSource("Subjects")]
        public void Format_WhenInvoked_ShouldReturnADecimalString(sbyte subject)
        {
            subject.AsDecimal().Format().ShouldEqual(subject.ToString("D"));
            subject.AsDecimal().WithPrecision(3).Format().ShouldEqual(subject.ToString("D3"));
            subject.AsHexadecimal().Format().ShouldEqual(subject.ToString("X"));
            subject.AsHexadecimal().WithPrecision(3).Format().ShouldEqual(subject.ToString("X3"));
            subject.AsCurrency().Format().ShouldEqual(subject.ToString("C"));
            subject.AsCurrency().WithPrecision(6).Format().ShouldEqual(subject.ToString("C6"));
            subject.AsExponential().WithPrecision(2).Format().ShouldEqual(subject.ToString("E2"));
            subject.AsExponential().Format().ShouldEqual(subject.ToString("E"));
            subject.AsFixedPoint().Format().ShouldEqual(subject.ToString("F"));
            subject.AsFixedPoint().WithPrecision(10).Format().ShouldEqual(subject.ToString("F10"));
            subject.AsGeneral().Format().ShouldEqual(subject.ToString("G"));
            subject.AsGeneral().WithPrecision(9).Format().ShouldEqual(subject.ToString("G9"));
            subject.AsNumeric().Format().ShouldEqual(subject.ToString("N"));
            subject.AsNumeric().WithPrecision(9).Format().ShouldEqual(subject.ToString("N9"));
            subject.AsPercent().Format().ShouldEqual(subject.ToString("P"));
            subject.AsPercent().WithPrecision(3).Format().ShouldEqual(subject.ToString("P3"));
        }

        [Test]
        [TestCaseSource("CultureSubjects")]
        public void Format_WhenInvoked_ShouldReturnCultureFormattedString(Type subject)
        {
            var formatCulture = (IFormatCulture)Activator.CreateInstance(subject);

            var method = typeof(SByteFormatBuilder).GetMethod("Using");
            var genericMethod = method.MakeGenericMethod(subject);
            foreach (var sample in Subjects)
            {
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsCurrency(), null)).Format().ShouldEqual(sample.ToString("C", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsExponential(), null)).Format().ShouldEqual(sample.ToString("E", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsFixedPoint(), null)).Format().ShouldEqual(sample.ToString("F", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsGeneral(), null)).Format().ShouldEqual(sample.ToString("G", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsNumeric(), null)).Format().ShouldEqual(sample.ToString("N", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsPercent(), null)).Format().ShouldEqual(sample.ToString("P", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsDecimal(), null)).Format().ShouldEqual(sample.ToString("D", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
                ((SByteFormatBuilder)genericMethod.Invoke(sample.AsHexadecimal(), null)).Format().ShouldEqual(sample.ToString("X", CultureInfo.CreateSpecificCulture(formatCulture.GetCultureCode())));
            }
        }

    }
}