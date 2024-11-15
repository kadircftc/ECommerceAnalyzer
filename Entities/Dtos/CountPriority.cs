using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class CountPriority
    {
        [JsonProperty("count")]
        public string? Count { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }
    }
}
