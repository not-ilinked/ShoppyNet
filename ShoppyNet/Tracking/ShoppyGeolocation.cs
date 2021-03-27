using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyGeolocation
    {
        [JsonProperty("ip")]
        public string IP { get; private set; }


        [JsonProperty("iso_code")]
        public string CountryCode { get; private set; }


        [JsonProperty("country")]
        public string Country { get; private set; }


        [JsonProperty("city")]
        public string City { get; private set; }


        [JsonProperty("state_name")]
        public string State { get; private set; }


        [JsonProperty("postal_code")]
        public string PostalCode { get; private set; }


        [JsonProperty("lat")]
        public decimal Latitude { get; private set; }

        
        [JsonProperty("lon")]
        public decimal Longitude { get; private set; }


        [JsonProperty("timezone")]
        public string Timezone { get; private set; }


        [JsonProperty("continent")]
        public string ContinentCode { get; private set; }


        [JsonProperty("currency")]
        public string Currency { get; private set; }
    }
}
