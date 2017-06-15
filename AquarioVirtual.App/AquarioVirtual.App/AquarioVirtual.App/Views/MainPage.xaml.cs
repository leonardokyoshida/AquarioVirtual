
using System;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AquarioVirtual.App.ViewModels;

namespace AquarioVirtual.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.NoticiasCommand.Execute();
        }
    }
}