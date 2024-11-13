using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class SocialProof
    {
        [JsonProperty("orderCount")]
        public CountInfo OrderCount { get; set; }

        [JsonProperty("favoriteCount")]
        public CountInfo FavoriteCount { get; set; }

        [JsonProperty("pageViewCount")]
        public CountInfo PageViewCount { get; set; }

        [JsonProperty("basketCount")]
        public CountInfo BasketCount { get; set; }
    }
}
