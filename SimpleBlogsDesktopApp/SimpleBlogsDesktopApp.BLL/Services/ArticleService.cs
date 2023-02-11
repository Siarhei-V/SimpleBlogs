using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;

namespace SimpleBlogsDesktopApp.BLL.Services
{
    public class ArticleService : IDataService<ArticleDTO>
    {
        IRepository<ArticleDTO> _repository;

        public ArticleService(IRepository<ArticleDTO> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ArticleDTO>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SendDataAsync(ArticleDTO entity)
        {
            await _repository.SendDataAsync(entity);
        }
    }
}
