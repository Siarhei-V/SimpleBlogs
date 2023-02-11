using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;

namespace SimpleBlogsDesktopApp.BLL.Services
{
    public class BlogService : IBlogService
    {
        IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDTO>> GetAllBlogsAsync()
        {
             return await _blogRepository.GetAuthors();
        }
    }
}
