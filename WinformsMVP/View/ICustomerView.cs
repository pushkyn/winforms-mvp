using System;
using System.Collections.Generic;
using WinformsMVP.Model;

namespace WinformsMVP.View
{
    public interface ICustomerView
    {
        event EventHandler CreateCustomer;
        event EventHandler CustomerSelected;
        event EventHandler DeleteCustomer;

        IList<string> CustomerList { get; set; }
        int SelectedCustomer { get; set; }

        Customer GetCustomer();
        void SetCustomer(Customer customer);
        void Clear();
    }
}
