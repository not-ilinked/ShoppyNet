using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyQuantity
    {
        public ShoppyQuantity()
        {
            
        }

        public ShoppyQuantity(int min, int max)
        {
            Min = min;
            Max = max;
        }

        [JsonProperty("min")]
        public int Min { get; private set; }


        [JsonProperty("max")]
        public int Max { get; private set; }
    }
}
