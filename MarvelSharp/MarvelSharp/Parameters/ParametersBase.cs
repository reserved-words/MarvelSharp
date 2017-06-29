using MarvelSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using MarvelSharp.Interfaces;

namespace MarvelSharp.Parameters
{
    public abstract class ParametersBase : IParameters
    {
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
                else if (typeof(ICollection).IsAssignableFrom(propertyType))
                {
                    dictionary.AddParameter(propertyName, (ICollection)propertyValue);
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
