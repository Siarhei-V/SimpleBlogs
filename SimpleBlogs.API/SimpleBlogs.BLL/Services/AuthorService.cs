using AutoMapper;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;

namespace SimpleBlogs.BLL.Services
{
    public class AuthorService : IDataService<AuthorDTO>, IAllBlogsService
    {
        IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateArticleAsync(AuthorDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogDTO>> GetAllBlogs()
        {
            var blogsTask = _unitOfWork.AllBlogsRepository.GetAllBlogsAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<Author, BlogDTO>()
                    .ForMember(dest => dest.Articles, ex => ex.MapFrom(src => MapArticles(src.Articles)))
                ).CreateMapper();

            var blogs = await blogsTask;
            
            return mapper.Map<IEnumerable<Author>, IEnumerable<BlogDTO>>(blogs);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllDataAsync()
        {
            var authorTask = _unitOfWork.AuthorsRepository.GetAllAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<Author, AuthorDTO>()).CreateMapper();

            var authors = await authorTask;

            return mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authors);
        }

        #region Private Methods
        private IEnumerable<ArticleDTO> MapArticles(List<Article> articles)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<Article, ArticleDTO>()
                .ForMember(dest => dest.Tags, exp => exp.MapFrom(src => MapTags(src.Tags)))
                ).CreateMapper();
            return mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
        }

        private IEnumerable<TagDTO> MapTags(List<Tag> tags)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<Tag, TagDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(tags);
        }
        #endregion
    }
}
