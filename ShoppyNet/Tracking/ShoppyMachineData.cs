using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shoppy
{
    public class ShoppyMachineData
    {
        [JsonProperty("is_mobile")]
        public bool Mobile { get; private set; }


        [JsonProperty("is_tablet")]
        public bool Tablet { get; private set; }


        [JsonProperty("is_desktop")]
        public bool Desktop { get; private set; }


        [JsonProperty("platform")]
        public string Platform { get; private set; }


        [JsonProperty("browser")]
        private readonly JObject _browser;

        public string Browser
        {
            get { return $"{_browser.Value<string>("name")} {_browser.Value<string>("version")}"; }
        }
    }
}
