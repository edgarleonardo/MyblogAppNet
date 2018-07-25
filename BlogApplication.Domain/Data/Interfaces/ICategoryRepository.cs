using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate, Pager pager);

        IEnumerable<SelectListItem> PostCategories(int postId);
        IEnumerable<SelectListItem> CategoryList(Expression<Func<Category, bool>> predicate);

        Task<Category> SingleIncluded(Expression<Func<Category, bool>> predicate);

        bool AddCategoryToPost(int postId, int categoryId);
        bool RemoveCategoryFromPost(int postId, int categoryId);
    }
}
