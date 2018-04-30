using System;
using System.Linq;
using MarvelousApi.Internal.Attributes;

namespace MarvelousApi.Internal.Extensions
{
    public static class EnumExtensionMethods
    {
        public static string GetStringValue(this System.Enum value)
        {
            var resourceName = value.GetAttribute<StringValueAttribute>()?.ResourceName;

            return string.IsNullOrEmpty(resourceName)
                ? value.ToString()
                : MarvelApiResources.ResourceManager.GetString(resourceName);
        }

        private static T GetAttribute<T>(this System.Enum value) where T : Attribute
        {
            var memInfo = value.GetType().GetMember(value.ToString());

            if (!memInfo.Any())
                return null;

            var attrs = memInfo[0].GetCustomAttributes(typeof(T), false).OfType<T>();

            return attrs.FirstOrDefault();
        }
    }
}
