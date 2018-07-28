using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Valverij.Extensions.Tests
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void AddOrUpdate_AddNewItem()
        {
            var key = "key";
            var expected = "this is a new item";

            var dictionary = new Dictionary<string, string>();

            Assert.False(dictionary.ContainsKey(key));

            dictionary.AddOrUpdate(key, expected);

            Assert.True(dictionary.ContainsKey(key));
            Assert.Equal(expected, dictionary[key]);
        }

        [Fact]
        public void AddOrUpdate_UpdateExistingItem()
        {
            var key = "key";
            var original = "this is a new item";
            var updated = "this is the updated item";

            var dictionary = new Dictionary<string, string>();

            // add original item
            dictionary.AddOrUpdate(key, original);

            Assert.True(dictionary.ContainsKey(key));
            Assert.Equal(original, dictionary[key]);

            // update the existing item
            dictionary.AddOrUpdate(key, updated);
            Assert.NotEqual(original, dictionary[key]);
            Assert.Equal(updated, dictionary[key]);
        }
    }
}
