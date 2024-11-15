using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TrendyolProductTag:BaseEntity,IEntity
    {
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public string TagName { get; set; }
        public int TagCount { get; set; }
    }
}
