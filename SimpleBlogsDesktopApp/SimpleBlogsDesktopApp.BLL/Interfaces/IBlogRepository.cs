using SimpleBlogsDesktopApp.BLL.DTOs;

namespace SimpleBlogsDesktopApp.BLL.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogDTO>> GetAuthors();
    }
}
