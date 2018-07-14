using Newtonsoft.Json;
using System;
using Xunit;

namespace Valverij.Extensions.Web.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ObjectExtensionsTests_SerializeObjectToJsonWithDefaultSettings()
        {
            object nullFunc() => null;

            var testObject = new { Id = 1, Name = "This is a test object", Item = nullFunc() };
            var expectedJson = "{\"id\":1,\"name\":\"This is a test object\"}";

            var actualJson = testObject.ToJson();

            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void ObjectExtensionsTests_SerializeObjectToJsonWithCustomSettings()
        {
            object nullFunc() => null;

            var testObject = new { Id = 1, Name = "This is a test object", Item = nullFunc() };
            var expectedJson = "{\"Id\":1,\"Name\":\"This is a test object\",\"Item\":null}";
            var actualJson = testObject.ToJson(new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Include });

            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void ObjectExtensionsTests_SerializeNullToEmptyJsonObject()
        {
            object nullObject = null;

            var expectedJson = "{}";
            var actualJson = nullObject.ToJson();

            Assert.Equal(expectedJson, actualJson);
        }
    }
}
