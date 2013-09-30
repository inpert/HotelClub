using System.Linq;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryIntegrationTest.ClientTests
{
    public class ClientRepositoryBaseTest
    {
        protected Customer MyNewCustomer;
        protected int TotalCustomersBeforeTestRuns = 0;
        protected int TotalOfClientsAfterTheTestRuns = 0 ;

        [SetUp]
        public virtual void Initializer()
        {
            //Add a client to be removed by our test.

            //Instantiate a new context.
            using (var context = new MainContext())
            {
                //Create a repository based on the context.
                var myRepo = new Repository<Core.Customer>(context);

                //Have to provide a valid name and e-mail address

                MyNewCustomer = new Core.Customer {Name = "Rafael", Email = "contact@rafaelfernandes.net"};

                myRepo.Add(MyNewCustomer);

                myRepo.Save();
            }
        }

        [TearDown]
        public virtual void Dispose()
        {
            //Clean the database
            using (var context = new MainContext())
            {
                var myRepo = new Repository<Customer>(context);

                //Get the customer to be removed.
                MyNewCustomer = myRepo.Query(s => s.Name == MyNewCustomer.Name).FirstOrDefault();

                if (myRepo.GetAll().Any())
                {
                    myRepo.Remove(MyNewCustomer);
                    myRepo.Save();
                }
            }
        }
    }
}
