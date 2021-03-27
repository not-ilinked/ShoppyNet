using Newtonsoft.Json;

namespace Shoppy
{
    public class PaymentUrlCollection
    {
        [JsonProperty("payment")]
        public ShoppyPayUrl Payment { get; private set; }

        [JsonProperty("embed")]
        public ShoppyPayUrl Embed { get; private set; }

        [JsonProperty("delete")]
        public ShoppyPayUrl Delete { get; private set; }
    }
}
