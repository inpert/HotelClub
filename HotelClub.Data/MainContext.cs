using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HotelClub.Core;
using HotelClub.Interface;

namespace HotelClub.Data
{
    public class MainContext : BaseContext<MainContext>
    {
        public DbSet<Customer> Clients { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
