using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class Price
    {
        [JsonProperty("buyingPrice")]
        public decimal BuyingPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("discountedPrice")]
        public decimal DiscountedPrice { get; set; }

        [JsonProperty("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("sellingPrice")]
        public decimal SellingPrice { get; set; }
    }
}
