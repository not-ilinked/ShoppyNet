using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyPayResponse
    {
        [JsonProperty("product")]
        public ShoppyProduct Product { get; private set; }

        [JsonProperty("ids")]
        public ShoppyPayIds Ids { get; private set; }

        [JsonProperty("urls")]
        public PaymentUrlCollection Urls { get; private set; }
    }
}
