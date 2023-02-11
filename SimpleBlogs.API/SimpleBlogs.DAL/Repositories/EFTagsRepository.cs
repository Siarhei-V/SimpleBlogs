using Microsoft.EntityFrameworkCore;
using SimpleBlogs.DAL.EF;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;
using System.Linq.Expressions;

namespace SimpleBlogs.DAL.Repositories
{
    public class EFTagsRepository : IRepository<Tag>
    {
        ApplicationContext _db;

        public EFTagsRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public async Task CreateAsync(Tag entity)
        {
            await _db.Tags.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _db.Tags.FindAsync(id);

            if (tag != null)
            {
                _db.Tags.Remove(tag);
            }
        }

        public async Task<IEnumerable<Tag>> FindAsync(Expression<Func<Tag, bool>> expression)
        {
            return await _db.Tags.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _db.Tags.ToListAsync();
        }

        public async Task<Tag> GetAsync(int id)
        {
            return await _db.Tags.FindAsync(id);
        }

        public void Update(Tag entity)
        {
            _db.Update(entity);
        }
    }
}
