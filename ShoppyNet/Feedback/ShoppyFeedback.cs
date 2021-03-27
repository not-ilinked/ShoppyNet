using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shoppy
{
    public class ShoppyFeedback
    {
        [JsonProperty("id")]
        public string Id { get; private set; }


        [JsonProperty("order_id")]
        public string OrderId { get; private set; }


        [JsonProperty("comment")]
        public string Comment { get; private set; }


        [JsonProperty("stars")]
        public int Stars { get; private set; }


        [JsonProperty("rating")]
        public int Rating { get; private set; }


        [JsonProperty("response")]
        public string Response { get; private set; }


        [JsonProperty("product")]
        private readonly JObject _product;

        public string ProductId
        {
            get { return _product.Value<string>("id"); }
        }
    }
}
