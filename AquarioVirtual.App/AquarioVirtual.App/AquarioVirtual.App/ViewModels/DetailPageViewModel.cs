using System.Linq;
using Prism.Navigation;
using AquarioVirtual.App.Models;
using Prism.Commands;
using AquarioVirtual.App.Services;

namespace AquarioVirtual.App.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {

        private Artigo _artigo;

        public Artigo Artigo
        {
            get { return _artigo; }
            set { SetProperty(ref _artigo, value); }
        }

        public readonly DelegateCommand ShowCategoriaCommand;

        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Artigo = parameters?["artigo"] as Artigo;
        }
    }
}
