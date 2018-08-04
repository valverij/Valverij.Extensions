using System;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;

namespace Valverij.Extensions.Data.Tests
{
    public class TypeExtensionsTests
    {
        private const string _tableNameAttributeValue = "TableNameAttributeValue";

        [Fact]
        public void GetsTableNameFromAttribute() => Assert.Equal(_tableNameAttributeValue, typeof(WithTableAttribute).TableNameForType());

        [Fact]
        public void DefaultsToTypeNameWithoutAttribute() => Assert.Equal(nameof(WithoutTableAttribute), typeof(WithoutTableAttribute).TableNameForType());

        [Fact]
        public void ThrowsArumentNullExceptionForNullType() => Assert.Throws<ArgumentNullException>(() => TypeExtensions.TableNameForType(null));

        [Table(_tableNameAttributeValue)]
        private class WithTableAttribute { }

        private class WithoutTableAttribute { }
    }
}
