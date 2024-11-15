using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TrendyolProductLastSocialProof: BaseEntity, IEntity
    {
        public int ProductId { get; set; }
        public int FavoriteCount { get; set; }
        public int CommentCount { get; set; }
        public int OrderCount { get; set; }
        public decimal AvarageRating { get; set; }
        public int RatingTotalCount { get; set; }
        public int BasketCount { get; set; }
        public int PageViewCount { get; set; }
        public int PIndex { get; set; }
        public int Tax { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool HasCategoryTopRankings { get; set; }
        public string SortType { get; set; }
        public bool HasPriceLabels { get; set; }
        public bool HasCollectableCoupon { get; set; }
        public bool HasPromotions { get; set; }
        public bool FreeCargo { get; set; }
    }
}
