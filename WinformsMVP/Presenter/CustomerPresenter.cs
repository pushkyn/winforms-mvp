using System;
using System.Linq;
using WinformsMVP.Model;
using WinformsMVP.View;

namespace WinformsMVP.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly ICustomerRepository _repository;

        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            _view = view;
            _repository = repository;

            _view.CreateCustomer += OnCreateCustomer;
            _view.DeleteCustomer += OnDeleteCustomer;
            _view.CustomerSelected += OnSelectCustomer;

            LoadCustomers();
        }

        private void OnCreateCustomer(object sender, EventArgs e)
        {
            var customer = _view.GetCustomer();
            _repository.Create(customer);
            LoadCustomers();
        }

        private void OnDeleteCustomer(object sender, EventArgs e)
        {
            var id = _view.SelectedCustomer;
            _repository.Delete(id);
            LoadCustomers();
        }

        private void OnSelectCustomer(object sender, EventArgs e)
        {
            var id = _view.SelectedCustomer;
            var customer = _repository.Get(id);
            _view.SetCustomer(customer);
        }

        private void LoadCustomers()
        {
            var customerNames = from customer in _repository.GetAll() select customer.Name;
            _view.CustomerList = customerNames.ToList();
        }
    }
}
