using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TrendyolService.Abstract
{
    public interface ITrendyolService
    {
        Task<IEnumerable<TrendyolProduct>> GetAll();
    }
}
