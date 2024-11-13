using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TrendyolProductImages: BaseEntity, IEntity
    {
        public int ProductId { get; set; }
        public string ImgUrl { get; set; }
    }
}
