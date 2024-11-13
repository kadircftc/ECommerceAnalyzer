using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class Stamp
    {
        [JsonProperty("aspectRatio")]
        public double AspectRatio { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
