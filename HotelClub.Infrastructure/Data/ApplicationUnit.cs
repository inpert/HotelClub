using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HotelClub.Core;
using HotelClub.Interface;
using HotelClub.Repository;

namespace HotelClub.Infrastructure.Data
{
    public class ApplicationUnit : IApplicationUnit
    {
        public IRepository<Customer> Customers { get; set; }
        public IRepository<Address> Addresses { get; set; }
        public IRepository<Country> Countries { get; set; }
        public IRepository<Fee> Fees { get; set; }
        public IRepository<Hotel> Hotels { get; set; }
        public IRepository<UserProfile> UsersProfile { get; set; }

        //public ApplicationUnit(DbContext context)
        //{
        //    Customers = new Repository<Customer>(context);
        //    Addresses = new Repository<Address>(context);
        //    Countries = new Repository<Country>(context);
        //    Fees = new Repository<Fee>(context);
        //    Hotels = new Repository<Hotel>(context);
        //    UsersProfile = new Repository<UserProfile>(context);
        //}

        public ApplicationUnit()
        {
            
        }

        public ApplicationUnit(
                        IRepository<Customer> customers,
                        IRepository<Address> addresses,
                        IRepository<Country> countries,
                        IRepository<Fee> fees,
                        IRepository<Hotel> hotels,
                        IRepository<UserProfile> usersProfile)
        {
            Customers = customers;
            Addresses = addresses;
            Countries = countries;
            Fees = fees;
            Hotels = hotels;
            UsersProfile = usersProfile;
        }
    }
}
