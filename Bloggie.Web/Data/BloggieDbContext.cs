using Horroras.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace Horroras.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLikes { get; set; }

        public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
        {
           
        }
    }
}
