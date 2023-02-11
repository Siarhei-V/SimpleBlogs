namespace SimpleBlogs.BLL.Interfaces
{
    public interface IDataService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();
        Task CreateArticleAsync(T entity);
    }
}
