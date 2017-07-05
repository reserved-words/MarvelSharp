using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarvelSharp.Internal.Extensions;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;

namespace MarvelSharp.Criteria
{
    /// <summary>
    /// A base class for criteria to be used to filter resources
    /// </summary>
    public abstract class BaseCriteria : ICriteria
    {

        /// <summary>
        /// Return only entities which have been modified since the specified date.
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        /// Converts the criteria data to a key-value dictionary
        /// </summary>
        /// <returns>A dictionary of key value pairs</returns>
        public Dictionary<string, string> ToDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this);

                if (propertyValue == null)
                    continue;

                var propertyName = property.Name.Substring(0, 1).ToLower() + property.Name.Substring(1);

                var propertyType = property.PropertyType;

                if (propertyType == typeof(string))
                {
                    dictionary.AddParameter(propertyName, (string)propertyValue);
                }
                else if (propertyType.IsEnum || (Nullable.GetUnderlyingType(propertyType)?.IsEnum ?? false))
                {
                    dictionary.AddParameter(propertyName, (Enum)propertyValue);
                }
                else if (typeof(bool?).IsAssignableFrom(propertyType))
                {
                    dictionary.AddParameter(propertyName, (bool?)propertyValue);
                }
                else if (typeof(DateTime?).IsAssignableFrom(propertyType))
                {
                    dictionary.AddParameter(propertyName, (DateTime?)propertyValue);
                }
                else if (typeof(ICollection<int>).IsAssignableFrom(propertyType))
                {
                    dictionary.AddParameter(propertyName, (ICollection<int>)propertyValue);
                }
                else if (typeof(ICollection).IsAssignableFrom(propertyType) && propertyType.IsGenericType && propertyType.GenericTypeArguments.Single().IsEnum)
                {
                    dictionary.AddParameter(propertyName, (ICollection)propertyValue);
                }
                else if (propertyType == typeof(DateRange?))
                {
                    dictionary.AddParameter(propertyName, (DateRange?)propertyValue);
                }
                else
                {
                    dictionary.AddParameter(propertyName, propertyValue);
                }
            }

            return dictionary;
        }
    }
}
