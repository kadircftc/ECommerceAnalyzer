using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RatingScore
    {
        [JsonProperty("averageRating")]
        public decimal AverageRating { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
