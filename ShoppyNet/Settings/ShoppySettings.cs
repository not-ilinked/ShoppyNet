using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppySettings
    {
        [JsonProperty("bitcoinAddress")]
        public string BitcoinAddress { get; set; }

        
        [JsonProperty("bitcoinCashAddress")]
        public string BitcoinCashAddress { get; set; }


        [JsonProperty("blockVPNsAndProxiesForRiskyOrders")]
        public bool? BlockProxies { get; set; }


        [JsonProperty("currency")]
        public string Currency { get; set; }


        #pragma warning disable IDE0051
        [JsonProperty("discordChannelConnected")]
        private readonly string _discordChannel;


        [JsonProperty("discordInviteURL")]
        private readonly string _discordInvite;


        [JsonProperty("discordNotificationChannelId")]
        private readonly string _discordNotifs;
        

        [JsonProperty("ethereumAddress")]
        public string EthereumAddress { get; set; }

        
        [JsonProperty("gaTrackingId")]
        private readonly string gaTracking;


        [JsonProperty("globalWebhookEndpoint")]
        public string GlobalWebhookEndpoint { get; set; }


        [JsonProperty("litecoinAddress")]
        public string LitecoinAddress { get; set; }


        [JsonProperty("networkFeeAmount")]
        private readonly string netFee;


        [JsonProperty("overrideNetworkFee")]
        private readonly string overrideFee;

        
        [JsonProperty("paypalAddress")]
        public string PaypalAddress { get; set; }

        
        [JsonProperty("receiveEmailOnFulfilmentRequired")]
        private readonly bool _receiveEmailFulfilment;


        [JsonProperty("receiveEmailOnNewSale")]
        private readonly bool _receiveEmailNewSale;


        [JsonProperty("receiveEmailOnNewQuery")]
        private readonly bool _receiveEmailNewQuery;


        [JsonProperty("receiveEmailOnQueryReply")]
        private readonly bool _receiveEmailQueryReply;


        [JsonProperty("receiveEmailOnSuccessfulOrder")]
        private readonly bool _receiveEmailSuccessfulOrder;


        [JsonProperty("stripeAccountId")]
        private readonly string _stripeAccountId;


        [JsonProperty("stripeConnected")]
        private readonly string _stripeConnected;


        [JsonProperty("theshold")]
        private readonly string _threshold;


        [JsonProperty("thresholdAmount")]
        private readonly string _thresholdAmount;


        [JsonProperty("useDarkModeTheme")]
        private readonly string _darkMode;


        [JsonProperty("useDefaultTheme")]
        private readonly string _defaultTheme;


        [JsonProperty("useGlobalWebhooks")]
        private readonly string _useGlobalHooks;


        [JsonProperty("userAvatar")]
        public string Avatar { get; set; }


        [JsonProperty("useTwoFactorAuthentication")]
        private readonly string _mfa;


        [JsonProperty("webhookSecret")]
        public string WebhookSecret { get; set; }
#pragma warning restore 
    }
}
