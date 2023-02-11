using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using System.Net.Http.Json;

namespace SimpleBlogsDesktopApp.DAL.Repositories
{
    public class ApiArticleRepository : IRepository<ArticleDTO>
    {
        const string SEND_ARTICLE_API_URL = "https://localhost:7247/api/Article/CreateArticle";


        public Task<IEnumerable<ArticleDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SendDataAsync(ArticleDTO entity)
        {
            using HttpClient httpClient = new HttpClient();

            await httpClient.PostAsJsonAsync(SEND_ARTICLE_API_URL, entity);
        }
    }
}
