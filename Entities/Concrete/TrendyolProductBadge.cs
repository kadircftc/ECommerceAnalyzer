using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TrendyolProductBadge: BaseEntity,IEntity
    {
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }
    }
}
