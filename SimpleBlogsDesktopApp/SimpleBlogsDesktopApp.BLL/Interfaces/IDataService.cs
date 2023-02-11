using SimpleBlogsDesktopApp.BLL.DTOs;

namespace SimpleBlogsDesktopApp.BLL.Interfaces
{
    public interface IDataService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();
        Task SendDataAsync(T entity);
    }
}
