using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using System.Net.Http.Json;

namespace SimpleBlogsDesktopApp.DAL.Repositories
{
    public class ApiTagRepository : IRepository<TagDTO>
    {
        const string API_URL = "https://localhost:7247/api/Tag/GetTags";     // TODO: move url to a file and read it

        public async Task<IEnumerable<TagDTO>> GetAllAsync()
        {
            using HttpClient httpClient = new HttpClient();

            var receivedBlogs = await httpClient.GetAsync(API_URL);

            return await receivedBlogs.Content.ReadFromJsonAsync<IEnumerable<TagDTO>>();
        }

        public Task SendDataAsync(TagDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
