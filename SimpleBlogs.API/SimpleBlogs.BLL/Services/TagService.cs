using AutoMapper;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;

namespace SimpleBlogs.BLL.Services
{
    public class TagService : IDataService<TagDTO>
    {
        IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateArticleAsync(TagDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TagDTO>> GetAllDataAsync()
        {
            var tagTask = _unitOfWork.TagsRepository.GetAllAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<Tag, TagDTO>()).CreateMapper();

            var tags = await tagTask;

            return mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(tags);
        }
    }
}
