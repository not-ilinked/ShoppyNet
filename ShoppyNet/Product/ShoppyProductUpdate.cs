using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shoppy
{
    public class ShoppyProductUpdate
    {
        public ShoppyProductUpdate()
        { }

        public ShoppyProductUpdate(ShoppyProduct origin)
        {
            Title = origin.Title;
            Price = origin.Price;
            Unlisted = origin.Unlisted;
            Description = origin.Description;
            Type = origin.Type;
            RequiredConfirmations = origin.RequiredConfirmations;
            CustomFields = origin.CustomFields;
            Webhooks = origin.Webhooks;
            SupportedPaymentMethods = origin.SupportedPaymentMethods;
            Currency = origin.Currency;
        }

        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("price")]
        public decimal Price { get; set; }


        private readonly OptionalParameter<bool> _unlistedParam = new OptionalParameter<bool>();
        [JsonProperty("unlisted")]
        public bool Unlisted
        {
            get { return _unlistedParam.Value; }
            set { _unlistedParam.Value = value; }
        }

        public bool ShouldSerializeUnlisted()
        {
            return _unlistedParam.Set;
        }


        private readonly OptionalParameter<string> _descriptionParam = new OptionalParameter<string>();
        [JsonProperty("description")]
        public string Description
        {
            get { return _descriptionParam.Value; }
            set { _descriptionParam.Value = value; }
        }


        public bool ShouldSerializeDescription()
        {
            return _descriptionParam.Set;
        }


        [JsonProperty("type")]
        private string _type;


        public ShoppyProductType Type
        {
            get
            {
                if (_type == "account")
                    return ShoppyProductType.Item;
                else
                    return (ShoppyProductType)Enum.Parse(typeof(ShoppyProductType), _type, true);
            }
            set
            {
                if (value == ShoppyProductType.Item)
                    _type = "account";
                else
                    _type = value.ToString().ToLower();
            }
        }


        private readonly OptionalParameter<int> _confirmsParam = new OptionalParameter<int>();
        [JsonProperty("confirmations")]
        public int RequiredConfirmations
        {
            get { return _confirmsParam.Value; }
            set { _confirmsParam.Value = value; }
        }


        public bool ShouldSerializeRequiredConfirmations()
        {
            return _confirmsParam.Set;
        }


        private readonly OptionalParameter<ProductQuantity> _quantityParam = new OptionalParameter<ProductQuantity>();
        [JsonProperty("quantity")]
        public ProductQuantity Quantity
        {
            get { return _quantityParam.Value; }
            set { _quantityParam.Value = value; }
        }


        public bool ShouldSerializeQuantity()
        {
            return _quantityParam.Set;
        }


        private readonly OptionalParameter<List<ShoppyCustomField>> _fieldsParam = new OptionalParameter<List<ShoppyCustomField>>();
        [JsonProperty("custom_fields")]
        public List<ShoppyCustomField> CustomFields
        {
            get { return _fieldsParam.Value; }
            set { _fieldsParam.Value = value; }
        }


        public bool ShouldSerializeCustomFields()
        {
            return _fieldsParam.Set;
        }


        private readonly OptionalParameter<List<string>> _hooksParam = new OptionalParameter<List<string>>();
        [JsonProperty("webhook_urls")]
        public List<string> Webhooks
        {
            get { return _hooksParam.Value; }
            set { _hooksParam.Value = value; }
        }


        public bool ShouldSerializeWebhooks()
        {
            return _hooksParam.Set;
        }


        private readonly OptionalParameter<List<string>> _gatewaysParam = new OptionalParameter<List<string>>();
        [JsonProperty("gateway")]
        public List<string> SupportedPaymentMethods
        {
            get { return _gatewaysParam.Value; }
            set { _gatewaysParam.Value = value; }
        }


        public bool ShouldSerializeSupportedPaymentMethods()
        {
            return _gatewaysParam.Set;
        }


        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
