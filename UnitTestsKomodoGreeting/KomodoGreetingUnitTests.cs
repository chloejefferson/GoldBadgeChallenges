using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoKomodoGreeting;

namespace UnitTestsKomodoGreeting
{
    [TestClass]
    public class KomodoGreetingUnitTests
    {
        private KomodoGreetingRepo _repo = new KomodoGreetingRepo();
        private KomodoGreeting _customer = new KomodoGreeting();
        private KomodoGreeting _customerUpdate = new KomodoGreeting();

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoGreetingRepo();
            _customer = new KomodoGreeting("Chloe", "Jefferson", CustomerTypeEnum.Current);
            _repo.AddCustomerToList(_customer);
            _customerUpdate = new KomodoGreeting("Chloe", "Jefferson", CustomerTypeEnum.Past);
        }

        [TestMethod]
        public void AddCustomerToList_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetCustomerById(_customer.CustomerId));
        }

        [TestMethod]
        public void GetCustomerList_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetCustomerList());
        }

        [TestMethod]
        public void GetCustomerById_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetCustomerById(_customer.CustomerId));
        }

        [TestMethod]
        public void UpdateCustomer_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.UpdateCustomer(_customer.CustomerId,_customerUpdate));
        }

        [TestMethod]
        public void DeleteCustomer_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.DeleteCustomer(_customer.CustomerId));
        }
    }
}
