using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.ViewModels
{

    public class HomeViewMenuItemViewModel : BaseViewModel
    {
        public HomeViewMenuItemViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavegateCommand = new DelegateCommand(ExecuteNavegateCommand);
        }
        public DelegateCommand NavegateCommand { get; }

        public int Id { get; set; }
        public string Title { get; set; }

        public string Name { get; set; }

        private async void ExecuteNavegateCommand()
        {
            if (Name == "MainPage")
                await _navigationService.NavigateAsync("AquarioVirtual.App:///HomeView/BaseNavigationPageView/MainPage");
            else
                await _navigationService.NavigateAsync("HomeView/BaseNavigationPageView/" + Name);
        }

    }
}