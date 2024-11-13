using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class SortType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("param")]
        public string Param { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
