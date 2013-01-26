using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinformsMVP.Model;
using WinformsMVP.Presenter;
using WinformsMVP.View;

namespace WinformsMVP.Tests
{
    [TestClass]
    public class CustomerPresenterTest
    {
        private readonly List<Customer> _stubCustomers = new List<Customer> {
                new Customer {Name = "Brad", Address = "Nowhere, AZ 1143", Phone = "123-456"},
                new Customer {Name = "Samanta", Address = "Nowhere, AZ 1055", Phone = "124-456"},
                new Customer {Name = "Tom", Address = "Nowhere, UT 2077", Phone = "125-456"}
        };

        [TestMethod]
        public void CanLoadCustomers()
        {
            // arrange
            var repo = new Mock<ICustomerRepository>();
            var view = new Mock<ICustomerView>();
            repo.Setup(m => m.GetAll())
                .Returns(_stubCustomers).Verifiable();

            var presenter = new CustomerPresenter(view.Object, repo.Object);

            // act

            // assert
            repo.Verify();
            var customerNames = from c in _stubCustomers select c.Name;
            view.VerifySet(m => m.CustomerList = customerNames.ToList());
        }

        [TestMethod]
        public void CanSelectCustomer()
        {
            // arrange
            var repo = new Mock<ICustomerRepository>();
            var view = new Mock<ICustomerView>();
            view.Setup(m => m.SelectedCustomer).Returns(1);
            repo.Setup(m => m.Get(1))
                .Returns(_stubCustomers[1]).Verifiable();

            var presenter = new CustomerPresenter(view.Object, repo.Object);

            // act
            view.Raise(m => m.CustomerSelected += null, null, null);

            // assert
            view.Verify(m => m.SetCustomer(_stubCustomers[1]), Times.Once());
        }

        [TestMethod]
        public void CanCreateCustomer()
        {
            // arrange
            var repo = new Mock<ICustomerRepository>();
            var view = new Mock<ICustomerView>();
            view.Setup(m => m.GetCustomer()).Returns(_stubCustomers[1]);
            repo.Setup(m => m.GetAll())
                .Returns(_stubCustomers).Verifiable();

            var presenter = new CustomerPresenter(view.Object, repo.Object);

            // act
            view.Raise(m => m.CreateCustomer += null, null, null);

            // assert
            repo.Verify(m => m.Create(_stubCustomers[1]), Times.Once());
        }

        [TestMethod]
        public void CanDeleteCustomer()
        {
            // arrange
            var repo = new Mock<ICustomerRepository>();
            var view = new Mock<ICustomerView>();
            view.Setup(m => m.SelectedCustomer).Returns(1);
            repo.Setup(m => m.GetAll())
                .Returns(_stubCustomers).Verifiable();

            var presenter = new CustomerPresenter(view.Object, repo.Object);

            // act
            view.Raise(m => m.DeleteCustomer += null, null, null);

            // assert
            repo.Verify(m => m.Delete(1), Times.Once());
        }
    }
}
