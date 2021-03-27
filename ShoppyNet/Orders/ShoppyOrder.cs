using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyOrder
    {
        [JsonProperty("id")]
        public string Id { get; private set; }


        [JsonProperty("price")]
        public decimal Price { get; private set; }


        [JsonProperty("currency")]
        public string Currency { get; private set; }

        
        [JsonProperty("email")]
        public string Email { get; private set; }
        

        [JsonProperty("crypto_address")]
        public string CryptoAddress { get; private set; }


        [JsonProperty("confirmations")]
        public int Confirmations { get; private set; }

        
        [JsonProperty("required_confirmations")]
        public int RequiredConfirmations { get; private set; }


        [JsonProperty("quantity")]
        public int Quantity { get; private set; }
        

        [JsonProperty("gateway")]
        public string PaymentMethod { get; private set; }


        [JsonProperty("custom_fields")]
        public List<ShoppyCustomFieldInput> CustomFields { get; private set; }


        [JsonProperty("product")]
        public ShoppyProduct Product { get; private set; }


        [JsonProperty("agent")]
        public ShoppyAgent Agent { get; private set; }


        [JsonProperty("is_partial")]
        private readonly string _partial;

        public bool PartialPayment
        {
            get { return _partial != null; }
        }
    }
}
