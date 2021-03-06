﻿using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogApplication.Domain.Data.Repositories
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        BlogDbContext _db;
        public AssetRepository(BlogDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Asset> Find(Expression<Func<Asset, bool>> predicate, Pager pager)
        {
            var skip = pager.CurrentPage * pager.ItemsPerPage - pager.ItemsPerPage;
            var items = _db.Assets.AsNoTracking().Where(predicate).OrderByDescending(a => a.LastUpdated).ToList();
            pager.Configure(items.Count);
            return items.Skip(skip).Take(pager.ItemsPerPage);
        }
    }
}