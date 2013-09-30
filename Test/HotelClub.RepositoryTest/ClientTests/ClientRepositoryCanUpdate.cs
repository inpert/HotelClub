using System.Linq;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryIntegrationTest.ClientTests
{
    // Integration testes for Customer

    [TestFixture]
    public class ClientRepositoryCanUpdate : ClientRepositoryBaseTest
    {
     
        [Test]
        public void Update()
        {
            const string newName = "Rafael Fernandes";

            using (var context = new MainContext())
            {
                var myRepo = new Repository<Core.Customer>(context);

                var firstClientInTheDb = myRepo.GetAll().FirstOrDefault();
                if (firstClientInTheDb != null)
                {
                    //Find an entity to be updated.
                    var myClient = myRepo.GetById(firstClientInTheDb.Id);

                    myClient.Name = newName;

                    myRepo.Update(myClient);
                    myRepo.Save();

                    //Compare if the name changed in the database
                    Assert.AreEqual(myRepo.GetById(firstClientInTheDb.Id).Name, newName);
                }
            }
        }


    }
}
