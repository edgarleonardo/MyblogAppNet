using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        IEnumerable<ProfileListItem> ProfileList(Expression<Func<Profile, bool>> predicate, Pager pager);
    }

    public enum BlogImgType
    {
        Avatar,
        Logo,
        HeaderBg
    }
}
