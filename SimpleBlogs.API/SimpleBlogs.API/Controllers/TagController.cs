using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogs.API.Models;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;

namespace SimpleBlogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagController : ControllerBase
    {
        IDataService<TagDTO> _tagService;

        public TagController(IDataService<TagDTO> tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IEnumerable<TagModel>> GetTagsAsync()
        {
            var tagTask = _tagService.GetAllDataAsync();

            var mapper = new MapperConfiguration(c => c.CreateMap<TagDTO, TagModel>()).CreateMapper();
            var tags = await tagTask;

            return mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagModel>>(tags);
        }

    }
}
