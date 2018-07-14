using Newtonsoft.Json;

namespace Valverij.Extensions.Web
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) => obj.ToJson(Defaults.DefaultJsonSettings);

        public static string ToJson(this object obj, JsonSerializerSettings settings) => JsonConvert.SerializeObject(obj ?? new { }, settings);
    }
}
