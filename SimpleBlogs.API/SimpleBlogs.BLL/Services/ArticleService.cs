using AutoMapper;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;

namespace SimpleBlogs.BLL.Services
{
    public class ArticleService : IDataService<ArticleDTO>
    {
        IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllDataAsync()
        {
            var articleTask = _unitOfWork.ArticlesRepository.GetAllAsync();
            
            var mapper = new MapperConfiguration(c => c.CreateMap<Article, ArticleDTO>()).CreateMapper();
            var articles = await articleTask;

            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }

        public async Task CreateArticleAsync(ArticleDTO articleDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()
                .ForMember(dest => dest.Tags, exp => exp.MapFrom(src => MapTags(src.Tags)))
            ).CreateMapper();
            var article = mapper.Map<ArticleDTO, Article>(articleDTO);

            await _unitOfWork.ArticlesRepository.CreateAsync(article);
            await _unitOfWork.SaveAsync();
        }

        private IEnumerable<Tag> MapTags(List<TagDTO> tags)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, Tag>()).CreateMapper();

            return mapper.Map<IEnumerable<TagDTO>, IEnumerable<Tag>>(tags);
        }
    }
}
