using System.Linq;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryIntegrationTest.ClientTests
{
    // Integration testes for Customer

    [TestFixture]
    public class ClientRepositoryCanInsert : ClientRepositoryBaseTest
    {
        public override void Initializer()
        {
            //Doesn't require it and shouldn't run in insertion test.
        }

        [Test]
        public void Insert()
        {
            using (var context = new MainContext())
            {
                var myRepo = new Repository<Customer>(context);
                TotalCustomersBeforeTestRuns = myRepo.GetAll().Count();

                //Have to provide a valid name and e-mail address
                MyNewCustomer = new Customer {Name = "Rafael", Email = "contact@rafaelfernandes.net"};
                myRepo.Add(MyNewCustomer);
                myRepo.Save();

                TotalOfClientsAfterTheTestRuns = myRepo.GetAll().Count();

                //Assert that the number of clients increase by 1
                Assert.AreEqual(TotalCustomersBeforeTestRuns + 1, TotalOfClientsAfterTheTestRuns);
            }
        }

    }
}
