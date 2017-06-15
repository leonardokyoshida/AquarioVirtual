using AquarioVirtual.App.Models;
using AquarioVirtual.App.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;

namespace AquarioVirtual.App.ViewModels
{
    //A classe BindableBase expões métodos para facilitar a criação de propriedades Bindables.
    //BindableBase implementa o INotifyPropertyChanged e o método SetProperty atribui valor e lança o evento notificando que a propriedade foi alterada
    public class MainPageViewModel : BaseViewModel
    {
        string _title = "Noticias";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private readonly IApiService _service;
        private ObservableCollection<Artigo> _artigos;
        public ObservableCollection<Artigo> Artigos
        {
            get
            {
                return _artigos;
            }
            set
            {
                SetProperty(ref _artigos, value);
            }
        }

        //Aqui é injetada o serviço de Navegação. O mais interessante que ele é uma interface, sendo assim, conseguimos testar essa ViewModel facilmente.

        public DelegateCommand NoticiasCommand { get; }
        public DelegateCommand<ItemTappedEventArgs> DetailPageCommand { get; }
        public MainPageViewModel(INavigationService navigationService, IApiService service)
            : base(navigationService)
        {
            this._service = service;
            NoticiasCommand = new DelegateCommand(ExecuteNoticiasCommand);
            DetailPageCommand = new DelegateCommand<ItemTappedEventArgs>(ExecuteDetailPageCommand);
            Artigos = new ObservableCollection<Artigo>();
        }

        private async void ExecuteNoticiasCommand()
        {
            try
            {
                Artigos?.Clear();
                var artigos = await _service.GetArtigosAsync();
                foreach (var art in artigos)
                {
                    Artigos?.Add(art);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void ExecuteDetailPageCommand(ItemTappedEventArgs selected)
        {
            try
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("artigo", selected?.Item);
                await _navigationService.NavigateAsync("DetailPageView", param);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}


