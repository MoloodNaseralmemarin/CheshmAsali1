using CheshmAsali.Domain.Models;
using CheshmAsali.Infrastructure.Communication.Interfaces;
using System.Collections.ObjectModel;


namespace CheshmAsali.Desktop.ViewModels
{
    public class RegisterViewModel:ViewModelBase
    {
        public ObservableCollection<Customer> People { get; set; }
        private ICustomerRepository PersonService;
        private Customer _selectedPerson;

        public RegisterViewModel(ICustomerRepository personService)
        {
            PersonService = personService;
            People=new ObservableCollection<Customer>();
        }

        public async Task LoadPeopleAsync()
        {
            var people = await PersonService.GetAllCustomers();

            People.Clear();

            foreach (var person in people)
            {
                People.Add(person);
            }

        }

        public Customer SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
               
            }
        }

    }
}