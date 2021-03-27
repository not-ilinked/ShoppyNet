using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyPayIds
    {
        [JsonProperty("payment")]
        public string Payment { get; private set; }

        [JsonProperty("product")]
        public string Product { get; private set; }
    }
}
