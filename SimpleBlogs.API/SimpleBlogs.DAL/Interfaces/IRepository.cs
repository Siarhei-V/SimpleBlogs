using System.Linq.Expressions;

namespace SimpleBlogs.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}
