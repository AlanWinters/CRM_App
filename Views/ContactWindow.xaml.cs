using CRM_App.Models;
using CRM_App.ViewModels;
using System.Windows;

namespace CRM_App.Views
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        public ContactWindow(CompanyModel company, Action<CompanyModel, ContactModel> saveCallback)
        {
            InitializeComponent();
            DataContext = new ContactViewModel(company, saveCallback, Close);
        }
    }
}
