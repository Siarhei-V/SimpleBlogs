using Microsoft.EntityFrameworkCore;
using SimpleBlogs.DAL.Entities;

namespace SimpleBlogs.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

    }
}
