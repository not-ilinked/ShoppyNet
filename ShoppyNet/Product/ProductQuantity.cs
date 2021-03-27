using Newtonsoft.Json;

namespace Shoppy
{
    public class ProductQuantity
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
