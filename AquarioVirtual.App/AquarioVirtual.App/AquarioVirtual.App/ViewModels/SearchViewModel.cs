using AquarioVirtual.App.Models;
using AquarioVirtual.App.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

namespace AquarioVirtual.App.ViewModels
{
    public class SearchViewModel : BindableBase, INavigationAware
    {
        private readonly IApiService _apiService;

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetProperty(ref _searchTerm, value);
                Artigos.Clear();
            }
        }

        public ObservableCollection<Artigo> Artigos { get; }

        public DelegateCommand AboutCommand { get; }

        public DelegateCommand SearchCommand { get; }

        public DelegateCommand<Artigo> ShowCategoriaCommand { get; }


        //Aqui é injetada o serviço de Navegação. O mais interessante que ele é uma interface, sendo assim, conseguimos testar essa ViewModel facilmente.
        private readonly INavigationService _navigationService;
        //O nome do parâmetro do INavigationService obrigatóriamente deve se chamar navigationService
        public SearchViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._apiService = DependencyService.Get<IApiService>();
            Artigos = new ObservableCollection<Artigo>();
            //AboutCommand = new DelegateCommand(Exe, PodeNavegar)
            //                                         .ObservesProperty(() => this.Parametro);
            SearchCommand = new DelegateCommand(ExecuteSearchCommand, PodeNavegar);
            //ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);          
        }

        private bool PodeNavegar()
        {
            return true;
        }

        private async void ExecuteSearchCommand()
        {
            //await this._navigationService.NavigateAsync("SearchPage");
            await LoadAsync();
        }

        //private async void ExecuteShowCategoriaCommand(Tag tag)
        //{
        //    await PushAsync<CategoriaViewModel>(tag);
        //}

        //private async void ExecuteAboutCommand()
        //{
        //    await PushAsync<AboutViewModel>();
        //}

        public async Task LoadAsync()
        {
            var artigos = await _apiService.GetArtigosByFilterAsync(SearchTerm);

            Artigos.Clear();
            foreach (var tag in artigos)
            {
                Artigos.Add(tag);
            }

            OnPropertyChanged(nameof(Artigos));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}


