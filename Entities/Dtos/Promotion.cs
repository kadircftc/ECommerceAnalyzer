using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class Promotion
    {
        [JsonProperty("discountType")]
        public int DiscountType { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("promotionEndDate")]
        public string PromotionEndDate { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

    }
}
