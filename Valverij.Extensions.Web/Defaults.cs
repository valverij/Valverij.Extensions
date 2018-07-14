using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Valverij.Extensions.Web
{
    public static class Defaults
    {
        /// <summary>
        /// Default settings for Json.NET:
        /// <para/>ContractResolver = new CamelCasePropertyNamesContractResolver()
        /// <para/>NullValueHandling = NullValueHandling.Ignore
        /// </summary>
        public static readonly JsonSerializerSettings DefaultJsonSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
