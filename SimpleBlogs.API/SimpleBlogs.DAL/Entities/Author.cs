using System.ComponentModel.DataAnnotations;

namespace SimpleBlogs.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
