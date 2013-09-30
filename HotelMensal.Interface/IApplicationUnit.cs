using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelClub.Core;

namespace HotelClub.Interface
{
    public interface IApplicationUnit
    {
        IRepository<Customer> Customers { get; set; }
        IRepository<Address> Addresses { get; set; }
        IRepository<Country> Countries { get; set; }
        IRepository<Fee> Fees { get; set; }
        IRepository<Hotel> Hotels { get; set; }
        IRepository<UserProfile> UsersProfile { get; set; }
    }
}
