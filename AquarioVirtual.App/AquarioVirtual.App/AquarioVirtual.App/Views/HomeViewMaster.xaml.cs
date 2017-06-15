using AquarioVirtual.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AquarioVirtual.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewMaster : ContentPage
    {
        public HomeViewMaster()
        {
            InitializeComponent();
        }

        private void MenuItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeViewMenuItemViewModel;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            //ViewModel.NavegateCommand.Execute(page);
            //Detail = new NavigationPage(page);
            //IsPresented = false;
            item.NavegateCommand.Execute();
        }
    }
}