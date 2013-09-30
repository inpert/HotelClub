using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryTest.AddressTests
{
    [TestFixture]
    class AddressRepositoryCanInsert : AdressRepositoryBase
    {
        public override void Initializer()
        {
            //Shouldn't run on Inserting test.
        }

        [Test]
        public void Insert()
        {
            using (var context = new MainContext())
            {
                var myRepo = new Repository<Address>(context);
                TotalAdresssBeforeTestRuns = myRepo.GetAll().Count();

                //Have to provide a valid name and e-mail address
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

                TotalOfClientsAfterTheTestRuns = myRepo.GetAll().Count();

                //Assert that the number of clients increase by 1
                Assert.AreEqual(TotalAdresssBeforeTestRuns + 1, TotalOfClientsAfterTheTestRuns);
            }
            
        }
    }
}
