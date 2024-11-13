
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
namespace DataAccess.Concrete.EntityFramework
{
    public class TrendyolProductTagRepository : EfEntityRepositoryBase<TrendyolProductTag, ProjectDbContext>, ITrendyolProductTagRepository
    {
        public TrendyolProductTagRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
