using CRM_App.Library.Enums;
using CRM_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_App.ViewModels
{
    public class CompanyViewModel : BaseModel
    {
        private CompanyModel _company;
        public CompanyModel Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        public ObservableCollection<Tags> Tags { get; set; }

        private readonly Action<CompanyModel> _saveCallback;
        private readonly Action _closeAction;

        public CompanyViewModel(Action<CompanyModel> saveCallback, Action closeAction)
        {
            Company = new CompanyModel();
            Tags = new ObservableCollection<Tags>(Enum.GetValues(typeof(Tags)).Cast<Tags>());

            _saveCallback = saveCallback;
            _closeAction = closeAction;

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private void Save()
        {
            _saveCallback?.Invoke(Company);
            _closeAction?.Invoke();
        }

        private void Cancel()
        {
            _closeAction?.Invoke();
        }
    }
}