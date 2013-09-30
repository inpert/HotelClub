using System.Linq;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryTest.AddressTests
{

    public class AdressRepositoryBase
    {
        protected Address MyNewAddress;
        protected int TotalAdresssBeforeTestRuns = 0;
        protected int TotalOfClientsAfterTheTestRuns = 0;
        protected Country MyCountryTest;

        [SetUp]
        public virtual void A_SetUpCountryRepo()
        {
            using (var context = new MainContext())
            {
                //Get the country.
                var myCountryRepo = new Repository<Country>(context);
                MyCountryTest = myCountryRepo.GetById(1);
            }
        }


        [SetUp]
        public virtual void Initializer()
        {
            //Add a client to be removed by our test.

            //Instantiate a new context.
            using (var context = new MainContext())
            {
                //Create a repository based on the context.
                var myRepo = new Repository<Address>(context);

                //Have to provide valid info.
                MyNewAddress = new Address
                {
                    AddressLine1 = "Barão de Mesquita Street",
                    AddressLine2 = "Tijuca",
                    Country = MyCountryTest,
                    State = "RJ",
                    Zip = "20540-156"
                };

                myRepo.Add(MyNewAddress);

                myRepo.Save();
            }
        }

        [TearDown]
        public virtual void Dispose()
        {
            //Clean the database
            using (var context = new MainContext())
            {
                var myRepo = new Repository<Address>(context);

                //Get the Address to be removed.
                MyNewAddress = myRepo.Query(s => s.AddressLine1 == MyNewAddress.AddressLine1).FirstOrDefault();

                if (myRepo.GetAll().Any())
                {
                    myRepo.Remove(MyNewAddress);
                    myRepo.Save();
                }
            }
        }

    }
}
