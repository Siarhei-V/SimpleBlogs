namespace SimpleBlogs.API.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
    }
}
