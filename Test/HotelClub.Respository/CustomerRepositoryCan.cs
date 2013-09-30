using HotelClub.Core;
using HotelClub.Interface;
using HotelClub.RepositoryUnitTest.Fakes;
using NUnit.Framework;

namespace HotelClub.RepositoryUnitTest
{
    [TestFixture]
    class CustomerRepositoryCan
    {
        protected IRepository<Customer> MyCustomerRepo;
        protected Customer CustomerSample;

        [SetUp]
        public void InitializeCustomer()
        {
            MyCustomerRepo = new FakeCustomerRepository();
            CustomerSample = ((FakeCustomerRepository)MyCustomerRepo).CustomerSample;
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CustomerRepositoryCanFind(int id)
        {
            Assert.NotNull(MyCustomerRepo.GetById(id));
        }

        [Test]
        public void CustomerRepositoryCanGetAll()
        {
            Assert.NotNull(MyCustomerRepo.GetAll());
        }

        [Test]
        public void CustomerRepositoryCanAdd()
        {
            MyCustomerRepo.Add(CustomerSample);
            Assert.True(((FakeCustomerRepository)MyCustomerRepo).WasAdded);
        }

        [Test]
        public void CustomerRepositoryCanRemove()
        {
            MyCustomerRepo.Remove(CustomerSample);
            Assert.True(((FakeCustomerRepository)MyCustomerRepo).WasDeleted);
        }

        [Test]
        public void CustomerRepositoryCanUpdate()
        {
            MyCustomerRepo.Update(CustomerSample);
            Assert.True(((FakeCustomerRepository)MyCustomerRepo).WasUpdated);
        }

        [Test]
        public void CustomerRepositoryCanSave()
        {
            MyCustomerRepo.Save();
            Assert.True(((FakeCustomerRepository)MyCustomerRepo).WasSaved);
        }
    }
}
