using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppy
{
    public class ShoppyCustomField
    {
        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("type")]
        private string _type;

        public bool Number
        {
            get
            {
                return _type == "number";
            }
            set
            {
                _type = value ? "number" : "text";
            }
        }


        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}
