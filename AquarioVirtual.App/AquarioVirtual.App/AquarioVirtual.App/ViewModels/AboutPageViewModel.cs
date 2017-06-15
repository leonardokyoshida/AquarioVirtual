using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;

namespace AquarioVirtual.App.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
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
        public AboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Texto = "O App Aquaman visa abranger a necessidade da criação de uma plataforma com o intuito de armazenar informações sobre as mais variadas espécies de peixes de água doce, bem como procedimentos necessários para se ter um determinado peixe em seu aquário";
        }
    }
}
