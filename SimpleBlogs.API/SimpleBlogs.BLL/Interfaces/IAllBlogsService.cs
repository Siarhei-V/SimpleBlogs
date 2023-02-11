using SimpleBlogs.BLL.DTOs;

namespace SimpleBlogs.BLL.Interfaces
{
    public interface IAllBlogsService
    {
        Task<IEnumerable<BlogDTO>> GetAllBlogs();
    }
}
