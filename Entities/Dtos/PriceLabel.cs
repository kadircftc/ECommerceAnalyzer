using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PriceLabel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]

        public int Type { get; set; }
        [JsonProperty("value")]

        public string Value { get; set; }
    }
}
