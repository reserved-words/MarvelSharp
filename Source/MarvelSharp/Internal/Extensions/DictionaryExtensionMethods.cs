using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Extensions
{
    internal static class DictionaryExtensionMethods
    {
        public static void AddParameter(this Dictionary<string,string> dictionary, string key, bool? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value ? ParameterValueTrue : ParameterValueFalse);
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, Enum value)
        {
            dictionary.Add(key, value.GetStringValue());
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, DateTime? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value.ToString(ParameterDateTimeFormat));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, ICollection<int> value)
        {
            if (!value.Any())
                return;

            dictionary.Add(key, string.Join(ParameterListSeparator, value));
        }

        public static void AddParameter(this Dictionary<string, string> dictionary, string key, ICollection value)
        {
            if (value.Count == 0)
                return;

            var list = new List<string>();
            foreach (var item in value)
            {
                list.Add(((Enum)item).GetStringValue());
            }
            dictionary.Add(key, string.Join(ParameterListSeparator, list));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, string value)
        {
            if (value == string.Empty)
                return;

            dictionary.Add(key, value);
        }

        public static void AddParameter(this Dictionary<string, string> dictionary, string key, DateRange? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, string.Join(ParameterListSeparator, value.Value.StartDate, value.Value.EndDate));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, object value)
        {
            dictionary.Add(key, value.ToString());
        }
    }
}
