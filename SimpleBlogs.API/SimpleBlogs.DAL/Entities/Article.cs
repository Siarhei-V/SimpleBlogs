using System.ComponentModel.DataAnnotations;

namespace SimpleBlogs.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int AuthorId { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
