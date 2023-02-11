using Microsoft.EntityFrameworkCore;
using SimpleBlogs.DAL.EF;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;
using System.Linq.Expressions;

namespace SimpleBlogs.DAL.Repositories
{
    public class EFAuthhorsRepository : IRepository<Author>, IAllBlogsRepository
    {
        ApplicationContext _db;

        public EFAuthhorsRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }
        
        public async Task CreateAsync(Author entity)
        {
            await _db.Authors.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var authhor = await _db.Authors.FindAsync(id);

            if (authhor != null)
            {
                _db.Authors.Remove(authhor);
            }
        }

        public async Task<IEnumerable<Author>> FindAsync(Expression<Func<Author, bool>> expression)
        {
            return await _db.Authors.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllBlogsAsync()
        {
            return await _db.Authors.Include(a => a.Articles).ThenInclude(a => a.Tags).ToListAsync();
        }

        public async Task<Author> GetAsync(int id)
        {
            return await _db.Authors.FindAsync(id);
        }

        public void Update(Author entity)
        {
            _db.Authors.Update(entity);
        }
    }
}
