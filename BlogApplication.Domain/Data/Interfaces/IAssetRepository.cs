using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface IAssetRepository : IRepository<Asset>
    {
        IEnumerable<Asset> Find(Expression<Func<Asset, bool>> predicate, Pager pager);
    }
}
