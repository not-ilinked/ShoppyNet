using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyUserSettings
    {
        [JsonProperty("username")]
        public string Username { get; set; }


        [JsonProperty("email")]
        public string Email { get; private set; }
    }
}
