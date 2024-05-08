using System.Text.RegularExpressions;

namespace ResultPatternExample.Utilities.GeneratedRegex
{
    public static partial class StringValidator
    {
        [GeneratedRegex(
            @"\d+",
            RegexOptions.CultureInvariant,
            matchTimeoutMilliseconds: 1000)]
        private static partial Regex IsOnlyNumbers();
        public static bool IsOnlyNumbers(this string value) {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return IsOnlyNumbers().IsMatch(value);
        } 
    }
}
