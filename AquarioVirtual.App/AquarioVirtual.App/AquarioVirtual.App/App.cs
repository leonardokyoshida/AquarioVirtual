using System;
using Prism.Unity;

using Xamarin.Forms;
using AquarioVirtual.App.Views;
using AquarioVirtual.App.ViewModels;

namespace AquarioVirtual.App
{
    public class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
       
        protected async override void OnInitialized()
        {
            try
            {

                //await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageView");
                //await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/SearchPage");
                await NavigationService.NavigateAsync("AquarioVirtual.App:///HomeView/BaseNavigationPageView/MainPage");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void RegisterTypes()
        {
            try
            {
                Container.RegisterTypeForNavigation<HomeView>();
                Container.RegisterTypeForNavigation<HomeViewMaster, HomeViewMasterViewModel>();
                Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
                Container.RegisterTypeForNavigation<SearchPage, SearchViewModel>();
                Container.RegisterTypeForNavigation<DetailPageView, DetailPageViewModel>();
                Container.RegisterTypeForNavigation<BaseNavigationPageView, BaseNavigationPageViewModel>();
                Container.RegisterTypeForNavigation<LoginPageView, LoginPageViewModel>();
                Container.RegisterTypeForNavigation<AboutPage, AboutPageViewModel>();
                Container.RegisterTypeForNavigation<IRRFView, IRRFViewModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
