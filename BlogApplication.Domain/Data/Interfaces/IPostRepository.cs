using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface IPostRepository : IRepository<BlogPost>
    {
        IEnumerable<PostListItem> Find(Expression<Func<BlogPost, bool>> predicate, Pager pager);
        IEnumerable<BlogPost> AllIncluded(Expression<Func<BlogPost, bool>> predicate);
        Task<List<PostListItem>> ByCategory(string slug, Pager pager, string blog = "");
        Task<List<PostListItem>> ByFilter(string status, List<string> categories, string blog, Pager pager);
        Task<BlogPost> SingleIncluded(Expression<Func<BlogPost, bool>> predicate);
        Task UpdatePostCategories(int postId, IEnumerable<string> catIds);
    }
}
