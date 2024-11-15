using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CountInfo
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("translateIdentifier")]
        public string TranslateIdentifier { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
