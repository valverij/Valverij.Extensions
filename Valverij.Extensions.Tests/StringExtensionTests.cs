using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Valverij.Extensions.Tests
{
    public class StringExtensionTests
    {
        private readonly List<string> _testCollection = new List<string> { "Test", "this", "stuff" };

        [Fact]
        public void In_UsingParams_CaseSensitive_IsInCollection() => Assert.True("this".In("Test", "this", "stuff"));

        [Fact]
        public void In_UsingParams_NotCaseSensitive_IsInCollection() => Assert.True("STUFF".In(StringComparison.OrdinalIgnoreCase, "Test", "this", "stuff"));

        [Fact]
        public void In_UsingParams_CaseSensitive_IsNotInCollection() => Assert.True(!"THIS".In("Test", "this", "stuff"));

        [Fact]
        public void In_UsingParams_NotCaseSensitive_IsNotInCollection() => Assert.True(!"Some other string".In("Test", "this", "stuff"));

        [Fact]
        public void In_UsingParams_EmptyCollection_IsNotInCollection() => Assert.True(!"Test".In());

        [Fact]
        public void In_UsingParams_NullCollection_IsNotInCollection() => Assert.True(!"Test".In(null));

        [Fact]
        public void In_UsingParams_NullInput_IsNotInCollection() => Assert.True(!((string)null).In("Test", "this", "stuff"));

        [Fact]
        public void In_UsingParams_NullInput_NullCollection_IsNotInCollection() => Assert.True(!((string)null).In(null));

        [Fact]
        public void In_UsingList_CaseSensitive_IsInCollection() => Assert.True("this".In(_testCollection));

        [Fact]
        public void In_UsingList_NotCaseSensitive_IsInCollection() => Assert.True("STUFF".In(StringComparison.OrdinalIgnoreCase, _testCollection));

        [Fact]
        public void In_UsingList_CaseSensitive_IsNotInCollection() => Assert.True(!"THIS".In(_testCollection));

        [Fact]
        public void In_UsingList_NotCaseSensitive_IsNotInCollection() => Assert.True(!"Some other string".In(_testCollection));

        [Fact]
        public void DefaultIfEmpty_GetDefaultUsingNullInputString()
        {
            var expectedDefaultValue = "this is a default value";
            Assert.Equal(expectedDefaultValue, ((string)null).DefaultIfEmpty(expectedDefaultValue));
        }

        [Fact]
        public void DefaultIfEmpty_GetDefaultUsingEmptyInputString()
        {
            var expectedDefaultValue = "this is a default value";
            Assert.Equal(expectedDefaultValue, string.Empty.DefaultIfEmpty(expectedDefaultValue));
        }

        [Fact]
        public void DefaultIfEmpty_GetInputString()
        {
            var defaultValue = "this is a default value";
            var inputString = "real input";
            Assert.Equal(inputString, inputString.DefaultIfEmpty(defaultValue));
        }

        [Fact]
        public void DefaultIfEmpty_DoesNotAllowNullDefaultValue() => Assert.Throws<ArgumentNullException>(() => string.Empty.DefaultIfEmpty(null));

        [Fact]
        public void RegexReplace_ReplacesAllMatches()
        {
            var inputString = "this is a default value";
            var noSpaces = "thisisadefaultvalue";

            var result = inputString.RegexReplace(@"[ ]", string.Empty);

            Assert.Equal(noSpaces, result);
        }

        [Fact]
        public void RegexReplace_ReplacesAllMatches_IgnoreCase()
        {
            var pattern = @"THIS";
            var inputString = "this is a default value";
            var expected = " is a default value";

            var result = inputString.RegexReplace(pattern, string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RegexReplace_DoesNotAllowNullPattern() => Assert.Throws<ArgumentNullException>(() => string.Empty.RegexReplace(null, string.Empty));

        [Fact]
        public void RegexReplace_DoesNotAllowNullReplacement() => Assert.Throws<ArgumentNullException>(() => string.Empty.RegexReplace(string.Empty, null));

        [Fact]
        public void RegexReplace_ReturnsNullOnNullInput() => Assert.Null(((string)null).RegexReplace(string.Empty, string.Empty));

        [Fact]
        public void ToBytes_ConvertsStringToByteArray()
        {
            var inputString = "this is a default value";
            var expected = Encoding.UTF8.GetBytes(inputString);

            Assert.Equal(expected, inputString.ToBytes());
        }

        [Fact]
        public void ToBytes_DoesNotAllowNullInput() => Assert.Throws<ArgumentNullException>(() => ((string)null).ToBytes());

        [Fact]
        public void ToBase64_ConvertsStringToBase64()
        {
            var inputString = "this is a default value";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(inputString));

            Assert.Equal(expected, inputString.ToBase64());
        }

        [Fact]
        public void ToBase64_DoesNotAllowNullInput() => Assert.Throws<ArgumentNullException>(() => ((string)null).ToBase64());

        [Fact]
        public void FromBytes_ConvertsByteArrayToString()
        {
            var expected = "this is a default value";
            var byteArray = Encoding.UTF8.GetBytes(expected);

            Assert.Equal(expected, byteArray.FromBytes());
        }

        [Fact]
        public void FromBytes_DoesNotAllowNullInput() => Assert.Throws<ArgumentNullException>(() => ((byte[])null).FromBytes());

        [Fact]
        public void FromBase64_ConvertsBase64ToString()
        {
            var expected = "this is a default value";
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(expected));

            Assert.Equal(expected, base64.FromBase64());
        }

        [Fact]
        public void FromBase64_DoesNotAllowNullInput() => Assert.Throws<ArgumentNullException>(() => ((string)null).FromBase64());
    }
}
