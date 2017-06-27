using System;
using System.Linq;

namespace MarvelSharp.Extensions
{
    internal static class EnumExtensionMethods
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memInfo = value.GetType().GetMember(value.ToString());

            if (memInfo == null || !memInfo.Any())
                return null;

            var attrs = memInfo[0].GetCustomAttributes(typeof(T), false).OfType<T>();

            return attrs.FirstOrDefault();
        }
    }
}
