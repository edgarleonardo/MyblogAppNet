using BlogApplication.Domain.Common;
using BlogApplication.Domain.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Domain.Data
{
	public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        #region DB Sets

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ApplicationSettings.DatabaseOptions(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
