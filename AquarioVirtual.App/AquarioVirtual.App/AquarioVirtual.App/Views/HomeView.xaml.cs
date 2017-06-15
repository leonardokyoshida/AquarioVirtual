using AquarioVirtual.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AquarioVirtual.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : MasterDetailPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

    }
}