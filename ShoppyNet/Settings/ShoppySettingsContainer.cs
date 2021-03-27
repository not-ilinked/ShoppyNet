﻿using Newtonsoft.Json;

namespace Shoppy
{
    public class ShoppySettingsContainer
    {
        [JsonProperty("user")]
        public ShoppyUser User { get; private set; }

        
        [JsonProperty("settings")]
        public ShoppySettings Settings { get; private set; }
    }
}
