using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Extensions
{
    public static class DictionaryExtensionMethods
    {
        public static void AddParameter(this Dictionary<string,string> dictionary, string key, bool? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value ? MarvelApiResources.ParameterValueTrue : MarvelApiResources.ParameterValueFalse);
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, System.Enum value)
        {
            dictionary.Add(key, value.GetStringValue());
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, DateTime? value)
        {
            if (!value.HasValue)
                return;

            dictionary.Add(key, value.Value.ToString(MarvelApiResources.ParameterDateTimeFormat));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, ICollection<int> value)
        {
            if (!value.Any())
                return;

            dictionary.Add(key, string.Join(MarvelApiResources.ParameterListSeparator, value));
        }

        public static void AddParameter(this Dictionary<string, string> dictionary, string key, ICollection value)
        {
            if (value.Count == 0)
                return;

            var list = new List<string>();
            foreach (var item in value)
            {
                list.Add(((System.Enum)item).GetStringValue());
            }
            dictionary.Add(key, string.Join(MarvelApiResources.ParameterListSeparator, list));
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

            dictionary.Add(key, string.Join(MarvelApiResources.ParameterListSeparator, value.Value.StartDate, value.Value.EndDate));
        }

        public static void AddParameter(this Dictionary<string,string> dictionary, string key, object value)
        {
            dictionary.Add(key, value.ToString());
        }
    }
}
