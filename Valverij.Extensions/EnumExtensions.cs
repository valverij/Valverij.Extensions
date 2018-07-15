using System;
using System.ComponentModel;
using System.Linq;

namespace Valverij.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString());

            return member.First().GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() is DisplayNameAttribute attribute
                ? attribute.DisplayName
                : value.ToString();
        }
    }
}
