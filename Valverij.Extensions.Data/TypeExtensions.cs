using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Valverij.Extensions.Data
{
    public static class TypeExtensions
    {
        public static string TableNameForType(this Type type) => type == null
            ? throw new ArgumentNullException(nameof(type))
            : type.GetCustomAttributes(typeof(TableAttribute), false).Cast<TableAttribute>().SingleOrDefault()?.Name ?? type.Name;
    }
}
