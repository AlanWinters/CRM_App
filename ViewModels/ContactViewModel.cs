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
    public class ContactViewModel : BaseModel
    {
        private ContactModel _contact;
        public ContactModel Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        public ObservableCollection<Title> Titles { get; set; }



        private readonly CompanyModel _company;
        private readonly Action<CompanyModel, ContactModel> _saveCallback;
        private readonly Action _closeAction;

        public ContactViewModel(CompanyModel company, Action<CompanyModel, ContactModel> saveCallback, Action closeAction)
        {
            _company = company;
            Contact = new ContactModel();
            Titles = new ObservableCollection<Title>(Enum.GetValues(typeof(Title)).Cast<Title>());

            _saveCallback = saveCallback;
            _closeAction = closeAction;

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private void Save()
        {
            _saveCallback?.Invoke(_company, Contact);
            _closeAction?.Invoke();
        }

        private void Cancel()
        {
            _closeAction?.Invoke();
        }
    }
}
