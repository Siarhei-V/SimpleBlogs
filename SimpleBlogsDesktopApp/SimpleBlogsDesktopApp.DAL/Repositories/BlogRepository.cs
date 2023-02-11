using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using System.Net.Http.Json;

namespace SimpleBlogsDesktopApp.DAL.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public async Task<IEnumerable<BlogDTO>> GetAuthors()
        {
            using HttpClient httpClient = new HttpClient();

            var receivedBlogs = await httpClient.GetAsync("https://localhost:7247/api/Author/GetAllBlogs");

            return await receivedBlogs.Content.ReadFromJsonAsync<IEnumerable<BlogDTO>>();
        }
    }
}
