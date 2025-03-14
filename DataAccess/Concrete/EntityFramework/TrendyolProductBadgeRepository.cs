﻿
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
namespace DataAccess.Concrete.EntityFramework
{
    public class TrendyolProductBadgeRepository : EfEntityRepositoryBase<TrendyolProductBadge, ProjectDbContext>, ITrendyolProductBadgeRepository
    {
        public TrendyolProductBadgeRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
