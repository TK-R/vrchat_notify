using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace VRChatApi
{
    static class Utils
    {
        public static void AddIfNotNull(this JObject jObject, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                jObject[key] = value;
            }
        }

        public static void AddIfNotNull(this JObject jObject, string key, JToken value)
        {
            if (value.HasValues)
            {
                jObject[key] = value;
            }
        }

        public static async Task<T> ParseResponse<T>(HttpResponseMessage responseMessage) where T : class
        {
            T res = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var receivedJson = await responseMessage.Content.ReadAsStringAsync();

                res = JsonConvert.DeserializeObject<T>(receivedJson);
            }

            responseMessage.Dispose();

            return res;
        }
    }
}
