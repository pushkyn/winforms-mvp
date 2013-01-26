using System.Collections.Generic;

namespace WinformsMVP.Model
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer Get(int id);

        void Create(Customer customer);

        void Delete(int id);
    }
}
