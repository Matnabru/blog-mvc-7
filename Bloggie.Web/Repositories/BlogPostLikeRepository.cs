using Horroras.Web.Data;
using Horroras.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Horroras.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext HorrorasDbContext;

        public BlogPostLikeRepository(BloggieDbContext HorrorasDbContext)
        {
            this.HorrorasDbContext = HorrorasDbContext;
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await HorrorasDbContext.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId);
        }

        public async Task AddLikeAsync(Guid blogPostId, Guid userId)
        {
            // Check if the like already exists
            var existingLike = await HorrorasDbContext.BlogPostLikes
                .FirstOrDefaultAsync(x => x.BlogPostId == blogPostId && x.UserId == userId);

            if (existingLike == null)
            {
                // Create a new like
                var blogPostLike = new BlogPostLike
                {
                    Id = Guid.NewGuid(),
                    BlogPostId = blogPostId,
                    UserId = userId
                };

                await HorrorasDbContext.BlogPostLikes.AddAsync(blogPostLike);
                await HorrorasDbContext.SaveChangesAsync();
            }
        }
    }
}
