using SimpleBlogs.DAL.Entities;

namespace SimpleBlogs.DAL.Interfaces
{
    public interface IAllBlogsRepository
    {
        Task<IEnumerable<Author>> GetAllBlogsAsync();
    }
}
