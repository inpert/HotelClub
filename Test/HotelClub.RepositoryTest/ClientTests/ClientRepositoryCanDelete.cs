using System.Linq;
using HotelClub.Data;
using HotelClub.Repository;
using NUnit.Framework;

namespace HotelClub.RepositoryIntegrationTest.ClientTests
{
    // Integration testes for Client

    [TestFixture]
    public class ClientRepositoryCanDelete : ClientRepositoryBaseTest
    {
        [Test]
        public void Delete()
        {
            using (var context = new MainContext())
            {
                var myRepo = new Repository<Core.Customer>(context);
                TotalCustomersBeforeTestRuns = myRepo.GetAll().Count();

                var allEntities = myRepo.GetAll().ToList();
                if (allEntities.Count > 0)
                {
                    //Find an entity to be removed.
                    var firstClientInTheDb = allEntities.FirstOrDefault();

                    //Check if there is an entity to be removed
                    if (firstClientInTheDb != null)
                    {
                        myRepo.Remove(firstClientInTheDb.Id);
                        myRepo.Save();

                        TotalOfClientsAfterTheTestRuns = myRepo.GetAll().Count();

                        // Check if the total number of entites was reduced by one.
                        Assert.AreEqual(TotalCustomersBeforeTestRuns - 1, TotalOfClientsAfterTheTestRuns);
                    }

                }
            }
        }

        public override void Dispose()
        {
            //Doesn't require it.
        }
    }
}
