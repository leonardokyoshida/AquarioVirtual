using AquarioVirtual.App.Models;
using AquarioVirtual.App.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;

namespace AquarioVirtual.App.ViewModels
{
    public class IRRFViewModel : BaseViewModel
    {
        public IRRFViewModel(INavigationService navigationService, IApiService service)
            : base(navigationService)
        {
            this._service = service;
            IRRFCommand = new DelegateCommand(IRRFCommandExecute);

        }

        private readonly IApiService _service;

        private string _txtSalary;
        public string txtSalary
        {
            get
            {
                return _txtSalary;
            }
            set
            {
                SetProperty(ref _txtSalary, value);
            }
        }

        private Salary _salary;
        public Salary Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                SetProperty(ref _salary, value);
            }
        }
        public DelegateCommand IRRFCommand { get; }

        private  async void IRRFCommandExecute()
        {
            RetornoIRRF ir = await _service.GetSalary(txtSalary);
            Salary = ir.data;

        }
    }
}
