namespace SimpleBlogs.API.Models
{
    public class BlogModel : AuthorModel
    {
        public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    }
}
