using Horroras.Web.Data;
using Horroras.Web.Models.Domain;
using Horroras.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Horroras.Web.Repositories
{
    public class TagRepository : ITagInterface
    {
        private readonly BloggieDbContext HorrorasDbContext;

        public TagRepository(BloggieDbContext HorrorasDbContext)
        {
            this.HorrorasDbContext = HorrorasDbContext;
        }

        public async Task<Tag?> AddAsync(Tag tag)
        {
            await HorrorasDbContext.AddAsync(tag);
            await HorrorasDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await HorrorasDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                HorrorasDbContext.Remove(existingTag);
                await HorrorasDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;

        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await HorrorasDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await HorrorasDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await HorrorasDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await HorrorasDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
