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
        public int OrderCount { get; set; }
        public int BasketCount { get; set; }
        public int PageViewCount { get; set; }
    }
}
