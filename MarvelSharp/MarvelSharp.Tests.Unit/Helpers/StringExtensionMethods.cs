using System.Text.RegularExpressions;

namespace MarvelSharp.Tests.Unit.Helpers
{
    public static class StringExtensionMethods
    {
        public static bool ContainsKeyValuePair(this string result, string parameterKey, string parameterValue)
        {
            var pattern = @"(\?|\&)" + parameterKey + "=" + parameterValue + @"(\&|$)";

            return Regex.IsMatch(result, pattern);
        }
    }
}
