using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyPayUrl
    {
        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}
