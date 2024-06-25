using CRM_App.Library.Enums;
using CRM_App.Models;
using CRM_App.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CRM_App.ViewModels
{
    public class MainViewModel : BaseModel
    {
        public ObservableCollection<CompanyModel> Companies { get; set; }

        public MainViewModel()
        {
            // Initialize the Companies collection with some sample data
            Companies = new ObservableCollection<CompanyModel>
            {
                new CompanyModel
                {
                    Company = "Company A",
                    Street = "Main St",
                    HouseNr = "123",
                    Zipcode = 12345,
                    City = "Tech City",
                    Tag = Tags.Java,
                    Contacts = new List<ContactModel>
                    {
                        new ContactModel
                        {
                            Title = Title.Frau,
                            Firstname = "Alice",
                            Lastname = "Smith",
                            Phone = "123-4567",
                            Mobile = "123-4567",
                            Email = "alice@companya.com",
                            Status = Status.Active
                        },
                        new ContactModel
                        {
                            Title = Title.Herr,
                            Firstname = "Bob",
                            Lastname = "Johnson",
                            Phone = "234-5678",
                            Mobile = "234-5678",
                            Email = "bob@companya.com",
                            Status = Status.Active
                        }
                    }
                },
                new CompanyModel
                {
                    Company = "Company B",
                    Street = "Second St",
                    HouseNr = "456",
                    Zipcode = 54321,
                    City = "Finance City",
                    Tag = Tags.Python,
                    Contacts = new List<ContactModel>
                    {
                        new ContactModel
                        {
                            Title = Title.Herr,
                            Firstname = "Charlie",
                            Lastname = "Brown",
                            Phone = "345-6789",
                            Mobile = "345-6789",
                            Email = "charlie@companyb.com",
                            Status = Status.Active
                        },
                        new ContactModel
                        {
                            Title = Title.Herr,
                            Firstname = "David",
                            Lastname = "Williams",
                            Phone = "456-7890",
                            Mobile = "456-7890",
                            Email = "david@companyb.com",
                            Status = Status.Active
                        }
                    }
                }
            };

            OpenNewCompanyCommand = new RelayCommand(_ => OpenNewCompany());
            OpenNewContactCommand = new RelayCommand(company => OpenNewContact((CompanyModel)company));
            DeleteContactCommand = new RelayCommand(contact => DeleteContact((ContactModel)contact));
        }

        public ICommand OpenNewCompanyCommand { get; }
        public ICommand OpenNewContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        // Opens Company Form
        private void OpenNewCompany()
        {
            CompanyWindow companyWindow = new CompanyWindow(AddNewCompany);
            companyWindow.ShowDialog();
        }

        // Adds a new Company Entry
        private void AddNewCompany(CompanyModel newCompany)
        {
            if (newCompany != null)
            {
                Companies.Add(newCompany);
            }
        }

        // Opens Contact Form
        private void OpenNewContact(CompanyModel company)
        {
            ContactWindow contactWindow = new ContactWindow(company, AddNewContact);
            contactWindow.ShowDialog();
        }

        // Adds a new Contact Entry
        private void AddNewContact(CompanyModel company, ContactModel newContact)
        {
            if (company != null && newContact != null)
            {
                company.Contacts.Add(newContact);
            }
        }

        // Sets the Status of a Contact to inactive
        private void DeleteContact(ContactModel contact)
        {
            if (contact != null)
            {
                contact.Status = Status.Inactive;
            }
        }
    }
}
