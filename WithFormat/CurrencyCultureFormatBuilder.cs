using System.Globalization;

namespace WithFormat
{
    public class CurrencyCultureFormatBuilder
    {
        private readonly IntegerFormatBuilder subject;
        private readonly string _cultureString;

        public CurrencyCultureFormatBuilder(IntegerFormatBuilder subject, string cultureString)
        {
            this.subject = subject;
            this._cultureString = cultureString;
        }

        public string PrecisionSpecifier
        {
            get { return subject.PrecisionSpecifier; }
            set { subject.PrecisionSpecifier = value; }
        }

        public override string ToString()
        {
            return subject.ToString(CultureInfo.CreateSpecificCulture(_cultureString));
        }
    }
}