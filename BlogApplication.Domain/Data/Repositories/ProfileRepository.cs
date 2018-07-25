using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using BlogApplication.Domain.Data.Interfaces;
using BlogApplication.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogApplication.Domain.Data.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        BlogDbContext _db;
        public ProfileRepository(BlogDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ProfileListItem> ProfileList(Expression<Func<Profile, bool>> predicate, Pager pager)
        {
            var skip = pager.CurrentPage * pager.ItemsPerPage - pager.ItemsPerPage;

            var all = _db.Profiles.Include(p => p.Assets).Include(p => p.BlogPosts).Where(predicate);

            pager.Configure(all.Count());

            var posts = all.OrderBy(p => p.Id).Skip(skip).Take(pager.ItemsPerPage).ToList();

            return posts.Select(p => new ProfileListItem
            {
                ProfileId = p.Id,
                Title = p.Title,
                Email = p.AuthorEmail,
                Url = ApplicationSettings.BlogRoute + "/" + p.Slug,

                IdentityName = p.IdentityName,
                AuthorName = p.AuthorName,
                IsAdmin = p.IsAdmin,

                PostCount = p.BlogPosts.Count,
                PostViews = _db.BlogPosts.Where(bp => bp.Profile.Id == p.Id).Sum(bp => bp.PostViews),
                DbUsage = _db.BlogPosts.Where(bp => bp.Profile.Id == p.Id).Sum(bp => Convert.ToInt32(bp.Content.Length)),

                AssetCount = p.Assets.Count,
                DownloadCount = _db.Assets.Where(a => a.ProfileId == p.Id).Sum(a => a.DownloadCount),
                DiskUsage = _db.Assets.Where(a => a.ProfileId == p.Id).Sum(a => a.Length),

                LastUpdated = p.LastUpdated
            });
        }
    }
}
