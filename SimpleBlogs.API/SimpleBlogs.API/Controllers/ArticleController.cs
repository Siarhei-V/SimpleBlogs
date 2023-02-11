using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogs.API.Models;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;

namespace SimpleBlogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ArticleController : ControllerBase
    {
        IDataService<ArticleDTO> _articleService;

        public ArticleController(IDataService<ArticleDTO> articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleModel>> GetArticlesAsync()
        {
            var articleTask = _articleService.GetAllDataAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<ArticleDTO, ArticleModel>()).CreateMapper();
            var articles = await articleTask;

            return mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<ArticleModel>>(articles);
        }

        [HttpPost]
        public async Task CreateArticleAsync(ArticleModel article)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleModel, ArticleDTO>()
                .ForMember(dest => dest.Tags, exp => exp.MapFrom(src => MapTags(src.Tags)))    
            ).CreateMapper();
            var articleDto = mapper.Map<ArticleModel, ArticleDTO>(article);

            _articleService.CreateArticleAsync(articleDto);
        }

        private IEnumerable<TagDTO> MapTags(List<TagModel> tags)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagModel, TagDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<TagModel>, IEnumerable<TagDTO>>(tags);
        }
    }
}