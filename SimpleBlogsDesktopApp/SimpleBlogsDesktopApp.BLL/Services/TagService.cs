using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;

namespace SimpleBlogsDesktopApp.BLL.Services
{
    public class TagService : IDataService<TagDTO>
    {
        IRepository<TagDTO> _repository;

        public TagService(IRepository<TagDTO> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TagDTO>> GetAllDataAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task SendDataAsync(TagDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
