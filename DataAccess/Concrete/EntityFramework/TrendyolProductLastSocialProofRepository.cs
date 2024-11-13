
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
namespace DataAccess.Concrete.EntityFramework
{
    public class TrendyolProductLastSocialProofRepository : EfEntityRepositoryBase<TrendyolProductLastSocialProof, ProjectDbContext>, ITrendyolProductLastSocialProofRepository
    {
        public TrendyolProductLastSocialProofRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
