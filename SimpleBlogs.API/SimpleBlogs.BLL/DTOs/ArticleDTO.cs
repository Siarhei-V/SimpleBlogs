namespace SimpleBlogs.BLL.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public List<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
