using System.Text.RegularExpressions;

namespace EO.Domain.Core
{
    public static class Helper
    {
        public static string SemFormatacao(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;

            var rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(value, "");
        }
    }
}