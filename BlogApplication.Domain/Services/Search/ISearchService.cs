using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Services.Search
{
    public interface ISearchService
    {
        Task<List<PostListItem>> Find(Pager pager, string term, string blogSlug = "");
    }
}
