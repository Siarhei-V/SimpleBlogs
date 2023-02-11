namespace SimpleBlogsDesktopApp.BLL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task SendDataAsync(T entity);
    }
}
