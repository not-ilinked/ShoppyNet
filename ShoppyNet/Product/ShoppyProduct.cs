using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppyProduct
    {
        [JsonProperty("id")]
        public string Id { get; private set; }


        [JsonProperty("title")]
        public string Title { get; private set; }


        [JsonProperty("description")]
        public string Description { get; private set; }


        [JsonProperty("unlisted")]
        public bool Unlisted { get; private set; }


        [JsonProperty("type")]
        private readonly string _type;

        public ShoppyProductType Type
        {
            get
            {
                if (_type == "account")
                    return ShoppyProductType.Item;
                else
                    return (ShoppyProductType)Enum.Parse(typeof(ShoppyProductType), _type, true);
            }
        }


        [JsonProperty("custom_fields")]
        public List<ShoppyCustomField> CustomFields { get; private set; }


        [JsonProperty("price")]
        public double Price { get; private set; }


        [JsonProperty("currency")]
        public string Currency { get; private set; }


        [JsonProperty("gateways")]
        public List<string> SupportedPaymentMethods { get; private set; }


        [JsonProperty("confirmations")]
        public int RequiredConfirmations { get; private set; }


        [JsonProperty("quantity")]
        public ShoppyQuantity Quantity { get; private set; }


        [JsonProperty("webhook_urls")]
        public List<string> Webhooks { get; private set; }
    }
}
