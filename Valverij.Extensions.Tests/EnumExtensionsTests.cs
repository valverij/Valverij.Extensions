using System.ComponentModel;
using Xunit;

namespace Valverij.Extensions.Tests
{
    public class EnumExtensionsTests
    {
        public enum MessageTypes
        {
            Info,
            Error,
            [DisplayName("A long message")]
            A_Long_Message
        }

        [Fact]
        public void EnumExtensionsTests_GetDisplayNameForEnum() => Assert.Equal("A long message", MessageTypes.A_Long_Message.DisplayName());

        [Fact]
        public void EnumExtensionsTests_GetDisplayNameForEnumWithoutDisplayName() => Assert.Equal("Error", MessageTypes.Error.DisplayName());
    }
}
