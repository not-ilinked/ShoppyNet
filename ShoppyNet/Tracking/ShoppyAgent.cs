using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyAgent
    {
        [JsonProperty("geo")]
        public ShoppyGeolocation Geolocation { get; private set; }


        [JsonProperty("data")]
        public ShoppyMachineData Data { get; private set; }
    }
}
