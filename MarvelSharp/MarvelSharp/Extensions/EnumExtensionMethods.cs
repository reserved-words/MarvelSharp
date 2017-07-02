using System;
using System.Linq;
using MarvelSharp.Attributes;

namespace MarvelSharp.Extensions
{
    internal static class EnumExtensionMethods
    {
        public static string GetStringValue(this Enum value)
        {
            return value.GetAttribute<StringValueAttribute>()?.Value ?? value.ToString();
        }

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memInfo = value.GetType().GetMember(value.ToString());

            if (!memInfo.Any())
                return null;

            var attrs = memInfo[0].GetCustomAttributes(typeof(T), false).OfType<T>();

            return attrs.FirstOrDefault();
        }
    }
}
