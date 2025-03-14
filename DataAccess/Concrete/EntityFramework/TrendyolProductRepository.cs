﻿
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
namespace DataAccess.Concrete.EntityFramework
{
    public class TrendyolProductRepository : EfEntityRepositoryBase<TrendyolProduct, ProjectDbContext>, ITrendyolProductRepository
    {
        public TrendyolProductRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
