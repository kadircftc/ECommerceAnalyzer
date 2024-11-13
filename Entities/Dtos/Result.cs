using Elasticsearch.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class Result
    {
        [JsonProperty("slpName")]
        public string? SlpName { get; set; }

        [JsonProperty("products")]
        public List<Product>? Products { get; set; }

        [JsonProperty("totalCount")]
        public int? TotalCount { get; set; }

        [JsonProperty("roughTotalCount")]
        public string? RoughTotalCount { get; set; }

        [JsonProperty("searchStrategy")]
        public string? SearchStrategy { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("uxLayout")]
        public string? UxLayout { get; set; }

        [JsonProperty("relevancyKey")]
        public string? RelevancyKey { get; set; }

        [JsonProperty("queryTerm")]
        public string? QueryTerm { get; set; }

        [JsonProperty("pageIndex")]
        public int? PageIndex { get; set; }

        [JsonProperty("sortTypes")]
        public List<SortType>? SortTypes { get; set; }
    }
}
