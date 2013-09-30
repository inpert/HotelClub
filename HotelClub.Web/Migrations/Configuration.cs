using HotelClub.Core;
using HotelClub.Data;

namespace HotelClub.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(MainContext context)
        {
            context.Hotels.AddOrUpdate(
                    p => p.Name,
                    new Hotel {Name = "Orlando Club"},
                    new Hotel { Name = "California Club" },
                    new Hotel { Name = "Toronto Club" }
                );

            context.Countries.AddOrUpdate(
                    c => c.Name,
                    new Country { Name = "Brazil" },
                    new Country { Name = "Canada" },
                    new Country { Name = "United States" }
                );
           
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
