using MarvelSharp.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MarvelSharp.Extensions
{
    internal static class DictionaryExtensionMethods
    {
        public static void AddParameter(this Dictionary<string,string> dictionary, string key, bool? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value ? "true" : "false");
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, Enum value)
        {
            dictionary.Add(key, value.GetAttribute<StringValueAttribute>()?.Value ?? value.ToString());
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, DateTime? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value.ToString("YYYY-MM-dd"));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, ICollection value)
        {
            if (value.Count == 0)
                return;

            dictionary.Add(key, string.Join(",", value));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, string value)
        {
            if (value == string.Empty)
                return;

            dictionary.Add(key, value);
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, object value)
        {
            dictionary.Add(key, value.ToString());
        }
    }
}
