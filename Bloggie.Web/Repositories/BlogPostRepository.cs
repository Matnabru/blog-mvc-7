using Horroras.Web.Data;
using Horroras.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Horroras.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext HorrorasDbContext;

        public async Task<(IEnumerable<BlogPost>, int)> GetBlogPostsAsync(string searchQuery, int pageNumber, int pageSize)
        {
            // Filtering
            var query = HorrorasDbContext.BlogPosts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(b => b.Heading.Contains(searchQuery));
            }

            // Total item count for pagination
            int totalItems = await query.CountAsync();

            // Pagination
            var blogPosts = await query.Include(b => b.Tags)
                                       .OrderByDescending(b => b.PublishedDate)
                                       .Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return (blogPosts, totalItems);
        }

        public BlogPostRepository(BloggieDbContext HorrorasDbContext)
        {
            this.HorrorasDbContext = HorrorasDbContext;
        }

        public async Task<BlogPost?> AddAsync(BlogPost blogPost)
        {
            await HorrorasDbContext.AddAsync(blogPost);
            await HorrorasDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await HorrorasDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                HorrorasDbContext.Remove(existingBlog);
                await HorrorasDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await HorrorasDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await HorrorasDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await HorrorasDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await HorrorasDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if(existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Author = blogPost.Author;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;
                existingBlog.Heading = blogPost.Heading;

                await HorrorasDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
