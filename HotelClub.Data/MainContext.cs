using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HotelClub.Core;
using HotelClub.Interface;

namespace HotelClub.Data
{
    public class MainContext : DbContext
        //BaseContext<MainContext>
    {
        public MainContext()
            : base("name=HotelClubDatabase")
        {
            
        }
        public virtual DbSet<Customer> Clients { get; set; }
        public virtual DbSet<Address> Adresses { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}
