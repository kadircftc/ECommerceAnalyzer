using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class ResultItem
    {
        [JsonProperty("basketCount")]
        public CountPriority BasketCount { get; set; }

        [JsonProperty("favoriteCount")]
        public CountPriority FavoriteCount { get; set; }

        [JsonProperty("orderCountL3D")]
        public CountPriority OrderCountL3D { get; set; }

        [JsonProperty("pageViewCount")]
        public CountPriority PageViewCount { get; set; }
    }
}
