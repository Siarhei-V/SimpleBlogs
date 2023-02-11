using SimpleBlogsDesktopApp.BLL.DTOs;

namespace SimpleBlogsDesktopApp.BLL.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDTO>> GetAllBlogsAsync();

    }
}
