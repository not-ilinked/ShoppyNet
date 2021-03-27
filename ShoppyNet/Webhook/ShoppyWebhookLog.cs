using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shoppy
{
    public class ShoppyWebhookLog
    {
        [JsonProperty("status")]
        public bool Status { get; private set; }


        [JsonProperty("webhook_type")]
        public int WebhookType { get; private set; }


        [JsonProperty("event")]
        public string Event { get; private set; }


        [JsonProperty("data")]
        private readonly JObject _data;

        public ShoppyOrder Order
        {
            get
            {
                if (_data == null)
                    return null;
                else
                    return _data.Value<JObject>("order").ToObject<ShoppyOrder>();
            }
        }
    }
}
