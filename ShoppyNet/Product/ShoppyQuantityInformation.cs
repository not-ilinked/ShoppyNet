using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyQuantityInformation
    {
        [JsonProperty("min")]
        public int Min { get; private set; }


        [JsonProperty("max")]
        public int Max { get; private set; }
    }
}
