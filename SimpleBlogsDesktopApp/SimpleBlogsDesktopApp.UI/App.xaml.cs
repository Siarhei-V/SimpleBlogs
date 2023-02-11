using Ninject;
using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using SimpleBlogsDesktopApp.BLL.Services;
using SimpleBlogsDesktopApp.DAL.Repositories;
using SimpleBlogsDesktopApp.UI.ViewModels;
using SimpleBlogsDesktopApp.UI.Views;
using System.Windows;

namespace SimpleBlogsDesktopApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IKernel? _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IBlogService>().To<BlogService>().InTransientScope();
            _kernel.Bind<IDataService<AuthorDTO>>().To<AuthorService>().InTransientScope();
            _kernel.Bind<IDataService<TagDTO>>().To<TagService>().InTransientScope();
            _kernel.Bind<IDataService<ArticleDTO>>().To<ArticleService>().InTransientScope();

            _kernel.Bind<IBlogRepository>().To<BlogRepository>().InTransientScope();
            _kernel.Bind<IRepository<AuthorDTO>>().To<ApiAuthorRepository>().InTransientScope();
            _kernel.Bind<IRepository<TagDTO>>().To<ApiTagRepository>().InTransientScope();
            _kernel.Bind<IRepository<ArticleDTO>>().To<ApiArticleRepository>().InTransientScope();

            var appVM = _kernel.Get<MainWindowVM>();

            MainWindow = new MainWindow();
            MainWindow.DataContext = appVM;
            MainWindow.Show();
        }
    }
}
