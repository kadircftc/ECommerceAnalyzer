using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class Badge
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("Type")]
        public string? Type { get; set; }
    }
}
