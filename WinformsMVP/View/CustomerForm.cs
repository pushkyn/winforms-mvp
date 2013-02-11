using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformsMVP.Model;
using WinformsMVP.Presenter;

namespace WinformsMVP.View
{
    public partial class CustomerForm : Form, ICustomerView
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public event EventHandler CreateCustomer;
        public event EventHandler CustomerSelected;
        public event EventHandler DeleteCustomer;

        public IList<string> CustomerList
        {
            get { return (IList<string>) listBoxCustomers.DataSource; }
            set { listBoxCustomers.DataSource = value; }
        }

        public int SelectedCustomer
        {
            get { return listBoxCustomers.SelectedIndex; }
            set { listBoxCustomers.SelectedIndex = value; }
        }

        public Customer GetCustomer()
        {
            return new Customer
                       {
                           Name = textBoxName.Text,
                           Address = textBoxAddress.Text,
                           Phone = textBoxPhone.Text
                       };
        }

        public void SetCustomer(Customer customer)
        {
            textBoxCustomer.Text = customer.ToString();
        }

        public void Clear()
        {
            textBoxName.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
        }

        private void ButtonCreateClick(object sender, EventArgs e)
        {
            if (CreateCustomer != null)
            {
                CreateCustomer(sender, e);
            }
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (DeleteCustomer != null)
            {
                DeleteCustomer(sender, e);
            }
        }

        private void ListBoxCustomersSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerSelected != null)
            {
                CustomerSelected(sender, e);
            }
        }

        private void buttonNotes_Click(object sender, EventArgs e)
        {
            var container = new IoCContainer();
            container.Register<INoteRepository, NoteFileRepository>();
            container.Register<INoteView, NoteForm>();

            var view = container.Resolve<INoteView>();
            var presenter = new NotePresenter(view, container.Resolve<INoteRepository>());
            ((Form) view).ShowDialog();
        }
    }
}
