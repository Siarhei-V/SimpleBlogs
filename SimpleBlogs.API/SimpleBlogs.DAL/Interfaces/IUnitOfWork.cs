using SimpleBlogs.DAL.Entities;

namespace SimpleBlogs.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAllBlogsRepository AllBlogsRepository { get; }
        IRepository<Author> AuthorsRepository { get; }
        IRepository<Article> ArticlesRepository { get; }
        IRepository<Tag> TagsRepository { get; }
        Task SaveAsync();
    }
}
