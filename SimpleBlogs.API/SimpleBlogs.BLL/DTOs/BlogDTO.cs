namespace SimpleBlogs.BLL.DTOs
{
    public class BlogDTO : AuthorDTO
    {
        public List<ArticleDTO> Articles { get; set; } = new List<ArticleDTO>();
    }
}
