using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;

namespace SimpleBlogsDesktopApp.BLL.Services
{
    public class AuthorService : IDataService<AuthorDTO>
    {
        IRepository<AuthorDTO> _repository;

        public AuthorService(IRepository<AuthorDTO> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllDataAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task SendDataAsync(AuthorDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
