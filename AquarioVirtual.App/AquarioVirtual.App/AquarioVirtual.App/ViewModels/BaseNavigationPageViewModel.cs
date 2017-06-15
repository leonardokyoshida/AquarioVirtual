using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace AquarioVirtual.App.ViewModels
{
    public class BaseNavigationPageViewModel : BaseViewModel
    {
        public BaseNavigationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}