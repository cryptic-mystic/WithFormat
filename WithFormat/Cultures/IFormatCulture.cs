using System.Globalization;

namespace WithFormat.Cultures
{
    public interface IFormatCulture
    {
        CultureInfo Culture();
        string GetCultureCode();
    }
}