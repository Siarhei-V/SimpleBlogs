using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using System.Net.Http.Json;

namespace SimpleBlogsDesktopApp.DAL.Repositories
{
    public class ApiAuthorRepository : IRepository<AuthorDTO>
    {
        const string Get_AUTHORS_API_URL = "https://localhost:7247/api/Author/GetAuthors";     // TODO: move url to a file and read it

        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            using HttpClient httpClient = new HttpClient();

            var receivedBlogs = await httpClient.GetAsync(Get_AUTHORS_API_URL);

            return await receivedBlogs.Content.ReadFromJsonAsync<IEnumerable<AuthorDTO>>();
        }

        public Task SendDataAsync(AuthorDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
