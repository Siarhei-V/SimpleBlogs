using SimpleBlogsDesktopApp.BLL.DTOs;
using SimpleBlogsDesktopApp.BLL.Interfaces;
using SimpleBlogsDesktopApp.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SimpleBlogsDesktopApp.UI.ViewModels
{
    internal class MainWindowVM : INotifyPropertyChanged
    {
        IBlogService _blogService;
        IDataService<AuthorDTO> _authorService;
        IDataService<TagDTO> _tagService;
        IDataService<ArticleDTO> _articleService;

        public MainWindowVM(IBlogService blogService, IDataService<AuthorDTO> authorService,
            IDataService<TagDTO> tagService, IDataService<ArticleDTO> articleService)
        {
            _blogService = blogService;
            _authorService = authorService;
            _tagService = tagService;
            _articleService = articleService;
        }

        IEnumerable<BlogDTO> _blogsListVM;
        public IEnumerable<BlogDTO> BlogsListVM
        {
            get => _blogsListVM;
            set
            {
                _blogsListVM = value;
                OnPropertyChanged();
            }
        }

        BlogDTO _selectedBlog;
        public BlogDTO SelectedBlogVM
        {
            get => _selectedBlog;
            set 
            {
                _selectedBlog = value;
                OnPropertyChanged();
            }
        }

        ArticleDTO _selectedArticleVM;
        public ArticleDTO SelectedArticleVM
        {
            get => _selectedArticleVM;
            set
            {
                _selectedArticleVM = value;
                OnPropertyChanged();
            }
        }

        IEnumerable<AuthorDTO> _authorDtosVM;
        public IEnumerable<AuthorDTO> AuthorDtosVM
        {
            get => _authorDtosVM;
            set
            {
                _authorDtosVM = value;
                OnPropertyChanged();
            }
        }

        AuthorDTO _selectedAuthorVM;
        public AuthorDTO SelectedAuthorVM
        {
            get => _selectedAuthorVM;
            set
            {
                _selectedAuthorVM = value;
            }
        }

        IEnumerable<TagDTO> _tagDtosVM;
        public IEnumerable<TagDTO> TagDtosVM
        {
            get => _tagDtosVM;
            set
            {
                _tagDtosVM = value;
                OnPropertyChanged();
            }
        }

        string _statusVM = "Ready";
        public string StatusVM
        {
            get => _statusVM;
            set
            {
                _statusVM = value;
                OnPropertyChanged();
            }
        }

        TagDTO _selectedTagDtoMV;
        public TagDTO SelectedTagDtoMV
        {
            get => _selectedTagDtoMV;
            set
            {
                if (!SelectedTagDtosListVM.Contains(value))
                {
                    _selectedTagDtoMV = value;
                    SelectedTagDtosListVM.Add(value);
                }
            }
        }

        public ArticleDTO NewArticle { get; set; } = new ArticleDTO();

        public ObservableCollection<TagDTO> SelectedTagDtosListVM { get; set; } = new ObservableCollection<TagDTO>();

        private RelayCommand _getAllBlogsCommand;
        public RelayCommand GetAllBlogsCommand
        {
            get
            {
                return _getAllBlogsCommand ??
                    (_getAllBlogsCommand = new RelayCommand(async obj =>
                    {
                        try
                        {
                            BlogsListVM = await _blogService.GetAllBlogsAsync();
                            StatusVM = "Ready!";
                        }
                        catch (System.Exception)
                        {
                            StatusVM = "Error!";
                        }
                    }));
            }
        }

        private RelayCommand _getAvailableParamsCommand;
        public RelayCommand GetAvailableParamsCommand
        {
            get
            {
                return _getAvailableParamsCommand ??
                    (_getAvailableParamsCommand = new RelayCommand(async obj =>
                    {
                        try
                        {
                            AuthorDtosVM = await _authorService.GetAllDataAsync();
                            TagDtosVM = await _tagService.GetAllDataAsync();
                            StatusVM = "Ready!";
                        }
                        catch (System.Exception)
                        {
                            StatusVM = "Error!";
                        }
                    }));
            }
        }
        private RelayCommand _removeSelectedTagsCommand;
        public RelayCommand RemoveSelectedTagsCommand
        {
            get
            {
                return _removeSelectedTagsCommand ??
                    (_removeSelectedTagsCommand = new RelayCommand(obj =>
                    {
                        SelectedTagDtosListVM.Clear();
                    }));
            }
        }

        private RelayCommand _saveArticleCommand;
        public RelayCommand SaveArticleCommand
        {
            get
            {
                return _saveArticleCommand ??
                    (_saveArticleCommand = new RelayCommand(async obj =>
                    {
                        if (!PrepareArticleForSaving())
                        {
                            return;
                        }

                        try
                        {
                            await _articleService.SendDataAsync(NewArticle);
                            StatusVM = "Ready!";
                        }
                        catch (Exception)
                        {
                            StatusVM = "Error!";
                        }

                    }));
            }
        }

        private bool PrepareArticleForSaving()
        {
            if (SelectedTagDtosListVM.Count == 0)
            {
                StatusVM = "Please select the tags";
                return false;
            }

            foreach (var item in SelectedTagDtosListVM)
            {

                if (!NewArticle.Tags.Contains(item))
                {
                    NewArticle.Tags.Add(item);
                }
            }

            if (_selectedAuthorVM == null)
            {
                StatusVM = "Please select the author";
                return false;
            }
            
            NewArticle.AuthorId = _selectedAuthorVM.Id;
            StatusVM = "Ready!";

            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
