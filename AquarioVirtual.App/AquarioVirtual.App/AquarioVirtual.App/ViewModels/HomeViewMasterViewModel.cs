using AquarioVirtual.App.Helpers;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.ViewModels
{
    public class HomeViewMasterViewModel : BaseViewModel
    {

        public const string Title = "Aquaman";
        private ObservableCollection<HomeViewMenuItemViewModel> _menuItems;
        public ObservableCollection<HomeViewMenuItemViewModel> MenuItems
        {
            get
            {
                return _menuItems;
            }

            set
            {
                SetProperty(ref _menuItems, value);
            }
        }

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                SetProperty(ref _nome, value);
            }
        }
        private string _foto;

        public string Foto
        {
            get
            {
                if (string.IsNullOrEmpty(_foto))
                    _foto = "profileAquaman.png";

                return _foto;
            }

            set
            {
                SetProperty(ref _foto, value);
            }
        }

        public HomeViewMasterViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Nome = Settings.Name;
            Foto = Settings.Image;
            MenuItems = new ObservableCollection<HomeViewMenuItemViewModel>(new[]
            {
                    new HomeViewMenuItemViewModel(navigationService) { Id = 0, Title = "Login", Name = "LoginPageView" },
                    new HomeViewMenuItemViewModel(navigationService) { Id = 1, Title = "Home", Name = "MainPage" },
                    new HomeViewMenuItemViewModel(navigationService) { Id = 1, Title = "About", Name = "AboutPage" },
                    new HomeViewMenuItemViewModel(navigationService) { Id = 1, Title = "IRRF", Name = "IRRFView" }
                });

        }

      

    }
}
