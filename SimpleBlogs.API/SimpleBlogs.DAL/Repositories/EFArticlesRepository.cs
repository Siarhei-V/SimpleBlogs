using Microsoft.EntityFrameworkCore;
using SimpleBlogs.DAL.EF;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;
using System.Linq.Expressions;

namespace SimpleBlogs.DAL.Repositories
{
    public class EFArticlesRepository : IRepository<Article>
    {
        ApplicationContext _db;

        public EFArticlesRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public async Task CreateAsync(Article entity)
        {
            List<Tag> tags = new List<Tag>();   // TODO: fix this bad implementation

            foreach (var item in entity.Tags)
            {
                tags.Add(_db.Tags.FirstOrDefault(t => t.Name == item.Name));
            }

            entity.Tags.Clear();
            entity.Tags.AddRange(tags);
            await _db.Articles.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _db.Articles.FindAsync(id);

            if (article != null)
            {
                _db.Articles.Remove(article);
            }
        }

        public async Task<IEnumerable<Article>> FindAsync(Expression<Func<Article, bool>> expression)
        {
            return await _db.Articles.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _db.Articles.ToListAsync();
        }

        public async Task<Article> GetAsync(int id)
        {
            return await _db.Articles.FindAsync(id);
        }

        public void Update(Article entity)
        {
            _db.Update(entity);
        }
    }
}
