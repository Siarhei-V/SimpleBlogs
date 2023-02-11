using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogs.API.Models;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;

namespace SimpleBlogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorController : ControllerBase
    {
        IDataService<AuthorDTO> _authorService;
        IAllBlogsService _allBlogsService;

        public AuthorController(IDataService<AuthorDTO> authorService, IAllBlogsService allBlogsService)
        {
            _authorService = authorService;
            _allBlogsService = allBlogsService;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogModel>> GetAllBlogs()
        {
            var blogsTask = _allBlogsService.GetAllBlogs();
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BlogDTO, BlogModel>()
                    .ForMember(dest => dest.Articles, exp => exp.MapFrom(src => MapArticles(src.Articles)))
                ).CreateMapper();
            
            var blogs = await blogsTask;

            return mapper.Map<IEnumerable<BlogDTO>, IEnumerable<BlogModel>>(blogs);
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorModel>> GetAuthorsAsync()
        {
            var authorTask = _authorService.GetAllDataAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<AuthorDTO, AuthorModel>()).CreateMapper();

            var authors = await authorTask;

            return mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorModel>>(authors);
        }

        #region Private Methods
        private IEnumerable<ArticleModel> MapArticles(List<ArticleDTO> articles)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleModel>()
                .ForMember(dest => dest.Tags, exp => exp.MapFrom(src => MapTitles(src.Tags)))
            ).CreateMapper();

            return mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<ArticleModel>>(articles);
        }

        private IEnumerable<TagModel> MapTitles(List<TagDTO> tags)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, TagModel>()).CreateMapper();
            return mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagModel>>(tags);
        }
        #endregion
    }
}
