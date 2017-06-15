using System;
using Prism.Navigation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AquarioVirtual.App.ViewModels;

namespace AquarioVirtual.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private SearchViewModel ViewModel => BindingContext as SearchViewModel;

        public SearchPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.LoadAsync();
        }
    }
}