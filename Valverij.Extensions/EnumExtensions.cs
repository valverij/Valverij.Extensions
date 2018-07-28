using System;
using System.ComponentModel;
using System.Linq;

namespace Valverij.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value) => GetAttributeValueOrToString<DisplayNameAttribute>(value, attr => attr.DisplayName);

        public static string Description(this Enum value) => GetAttributeValueOrToString<DescriptionAttribute>(value, attr => attr.Description);

        private static string GetAttributeValueOrToString<T>(Enum value, Func<T, string> accessor)
        {
            var member = value.GetType().GetMember(value.ToString());

            return member.First().GetCustomAttributes(typeof(T), false).FirstOrDefault() is T attribute
                ? accessor(attribute)
                : value.ToString();
        }
    }
}
