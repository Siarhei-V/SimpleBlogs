using SimpleBlogs.DAL.EF;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;

namespace SimpleBlogs.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IRepository<Author> _authorsRepository;
        IRepository<Article> _articlesRepository;
        IRepository<Tag> _tagsRepository;
        IAllBlogsRepository _allBlogsRepository;
        ApplicationContext _db;

        public UnitOfWork(IRepository<Author> authorsRepository, IRepository<Article> articlesRepository,
            IRepository<Tag> tagsRepository, ApplicationContext applicationContext, IAllBlogsRepository allBlogsRepository)
        {
            _authorsRepository = authorsRepository;
            _articlesRepository = articlesRepository;
            _tagsRepository = tagsRepository;
            _allBlogsRepository = allBlogsRepository;

            _db = applicationContext;
        }

        public IAllBlogsRepository AllBlogsRepository => _allBlogsRepository;
        public IRepository<Author> AuthorsRepository => _authorsRepository;

        public IRepository<Article> ArticlesRepository => _articlesRepository;

        public IRepository<Tag> TagsRepository => _tagsRepository;


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
