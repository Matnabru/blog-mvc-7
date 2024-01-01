namespace Horroras.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task AddLikeAsync(Guid blogPostId, Guid userId);
    }
}
