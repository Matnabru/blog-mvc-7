using Horroras.Web.Models.Domain;

namespace Horroras.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<(IEnumerable<BlogPost>, int totalItems)> GetBlogPostsAsync(string searchQuery, int pageNumber, int pageSize);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost?> UpdateAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteAsync(Guid id);
        Task<BlogPost?> AddAsync(BlogPost blogPost);
    }
}
