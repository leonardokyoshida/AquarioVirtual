using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using AquarioVirtual.App.Services;
using Prism.Commands;
using AquarioVirtual.App.Helpers;
using AquarioVirtual.App.Models;

namespace AquarioVirtual.App.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IApiService _service;
        public LoginPageViewModel(INavigationService navigationService, IApiService service) : base(navigationService)
        {
            _service = service;
            LoginCommand = new DelegateCommand(ExecuteLoginCommandAsync);
            LogoutCommand = new DelegateCommand(ExecuteLogoutCommandAsync);

            if (Settings.IsLoggedIn)
                Texto = "Logout";
            else
                Texto = "Entrar com Facebook";
        }

        public DelegateCommand LoginCommand { get; }

        public DelegateCommand LogoutCommand { get; }

        public Usuario usuario { get; set; }

        private string _texto;

        public string Texto
        {
            get
            {
                return _texto;
            }

            set
            {
                SetProperty(ref _texto, value);
            }
        }

        private async void ExecuteLoginCommandAsync()
        {
            if (!Settings.IsLoggedIn)
            {
                if (!(await LoginAsync()))
                    return;
                else
                {
                    await _navigationService.NavigateAsync("AquarioVirtual.App:///HomeView/BaseNavigationPageView/MainPage");
                }
            }

            else
            {
                LogoutCommand.Execute();
            }
        }

        private async void ExecuteLogoutCommandAsync()
        {
            await LogoutAsync();
            await _navigationService.NavigateAsync("AquarioVirtual.App:///HomeView/BaseNavigationPageView/MainPage");
        }

        private void RemovePageFromStack()
        {
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _service.LoginAsync();
        }

        public async Task LogoutAsync()
        {
            if (Settings.IsLoggedIn)
                await _service.LogoutAsync();

        }

      

    }
}
