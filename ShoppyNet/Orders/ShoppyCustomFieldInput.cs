using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyCustomFieldInput
    {
        [JsonProperty("name")]
        public string Name { get; private set; }


        [JsonProperty("value")]
        public string Value { get; private set; }
    }
}
