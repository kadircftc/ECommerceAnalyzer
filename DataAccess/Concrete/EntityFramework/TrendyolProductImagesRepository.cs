﻿
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
namespace DataAccess.Concrete.EntityFramework
{
    public class TrendyolProductImagesRepository : EfEntityRepositoryBase<TrendyolProductImages, ProjectDbContext>, ITrendyolProductImagesRepository
    {
        public TrendyolProductImagesRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
