using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApplication.Domain.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        BlogDbContext _db;

        public CategoryRepository(BlogDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate, Pager pager)
        {
            if(pager == null)
            {
                return _db.Categories.AsNoTracking()
                    .Include(c => c.PostCategories)
                    .Where(predicate)
                    .OrderBy(c => c.Title);
            }

            var skip = pager.CurrentPage * pager.ItemsPerPage - pager.ItemsPerPage;

            var categories = _db.Categories.AsNoTracking()
                .Include(c => c.PostCategories)
                .Where(predicate)
                .OrderBy(c => c.Title)
                .ToList();

            pager.Configure(categories.Count());
            
            return categories.Skip(skip).Take(pager.ItemsPerPage);
        }

        public IEnumerable<SelectListItem> PostCategories(int postId)
        {
            var items = new List<SelectListItem>();
            var postCategories = _db.PostCategories.Include(pc => pc.Category).Where(c => c.BlogPostId == postId);
            foreach (var item in postCategories)
            {
                var newItem = new SelectListItem { Value = item.Id.ToString(), Text = item.Category.Title };
                if (!items.Contains(newItem))
                {
                    items.Add(newItem);
                }
            }
            return items.OrderBy(c => c.Text);
        }

        public IEnumerable<SelectListItem> CategoryList(Expression<Func<Category, bool>> predicate)
        {
            return _db.Categories.Where(predicate).OrderBy(c => c.Title)
                .Select(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() }).ToList();
        }

        public async Task<Category> SingleIncluded(Expression<Func<Category, bool>> predicate)
        {
            return await _db.Categories.AsNoTracking()
                .Include(c => c.PostCategories)
                .FirstOrDefaultAsync(predicate);
        }

        public bool AddCategoryToPost(int postId, int categoryId)
        {
            try
            {
                var existing = _db.PostCategories.Where(
                    pc => pc.BlogPostId == postId &&
                    pc.CategoryId == categoryId).SingleOrDefault();

                if (existing == null)
                {
                    _db.PostCategories.Add(new PostCategory
                    {
                        BlogPostId = postId,
                        CategoryId = categoryId,
                        LastUpdated = SystemClock.Now()
                    });
                    _db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveCategoryFromPost(int postId, int categoryId)
        {
            try
            {
                var existing = _db.PostCategories.Where(
                    pc => pc.BlogPostId == postId &&
                    pc.CategoryId == categoryId).SingleOrDefault();

                if (existing == null)
                {
                    return false;
                }

                _db.PostCategories.Remove(existing);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}